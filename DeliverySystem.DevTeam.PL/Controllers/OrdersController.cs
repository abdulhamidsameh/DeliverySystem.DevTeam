namespace DeliverySystem.DevTeam.PL.Controllers
{
    [Authorize]
	public class OrdersController : Controller
    {
        public OrdersController(IUnitOfWork unitOf, UserManager<ApplicationUser> userManager)
        {
            _UnitOf = unitOf;
            _UserManager = userManager;
        }

        public IUnitOfWork _UnitOf { get; }
        public UserManager<ApplicationUser> _UserManager { get; }

        public IActionResult Index()
        {
            var spc = new BaseSpacefications<Order>();
            spc.Includes.Add(c => c.OrderProducts);
            spc.Includes.Add(c => c.Merchant);

            var dbProduct = _UnitOf.Repository<Order>().GetAllWithSpec(spc).ToList();
            return View();
        }

        public IActionResult Create(int id)
        {
            var spc = new BaseSpacefications<Product>(c => c.WarhouseId == id);
            var product = _UnitOf.Repository<Product>().GetAllWithSpec(spc).ToList();

            var WarehouseCommation = _UnitOf.Repository<Warhouse>().GetById(id).Commition;
            var viewModel = new CreateOrderViewModel
            {
                ProductsList = product,
                WarehouseIId = id,
                WarehouseCommation = WarehouseCommation,
                
            };

            return View("Index", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderViewModel model)
        {

            var WarehouseCommation = _UnitOf.Repository<Warhouse>().GetById(model.WarehouseIId).Commition;
            var user = await _UserManager.GetUserAsync(User);
            var email = await _UserManager.GetEmailAsync(user);
            var spec = new BaseSpacefications<Merchant>(c => c.Email == email);
            var Merchant = _UnitOf.Repository<Merchant>().GetAllWithSpec(spec).FirstOrDefault();

            var order = new Order
            {
                OrderDate = model.OrderDate,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                WarehouseId = model.WarehouseIId,
                MerchantId = Merchant.Id,
                OrderStatus = OrderStatus.Processing,
                SubTotal = model.SubTotal,
                Total = model.SubTotal + WarehouseCommation,
                IsCashOnDelivery = model.IsCashOnDelivery

            };


            _UnitOf.Repository<Order>().Add(order);
            _UnitOf.Complete();


            foreach (var product in model?.Products)
            {
           
                var spc = new BaseSpacefications<Product>(c => c.Id == product.ProductId);
                var dbProduct = _UnitOf.Repository<Product>().GetAllWithSpec(spc).FirstOrDefault();

                if (product.Quantity <= 0 || product.Quantity > dbProduct.QuantityAvailable)
                {
                    ModelState.AddModelError("", $"Invalid quantity for product {dbProduct.Name}. Quantity must be between 1 and {dbProduct.QuantityAvailable}.");
                    return View("Index", model);
                }

           
                var orderProduct = new OrderProduct
                {
                    OrderId = order.Id,
                    ProductId = product.ProductId,
                    Quantity = product.Quantity,
                    Name = dbProduct.Name,
                    Description = dbProduct.Description,
                    Price = dbProduct.Price 

                };
                _UnitOf.Repository<OrderProduct>().Add(orderProduct);

       
                dbProduct.QuantityAvailable -= product.Quantity;

                _UnitOf.Repository<Product>().Update(dbProduct);
            }

         
            _UnitOf.Complete();

            return RedirectToAction(nameof(Create));
        }

        public IActionResult GetProductDetails(int productId)
        {
            var spc = new BaseSpacefications<Product>(c => c.Id == productId);
            var product = _UnitOf.Repository<Product>().GetAllWithSpec(spc).FirstOrDefault();

            if (product != null)
            {
                return Json(new { productName = product.Name, currentQuantity = product.QuantityAvailable, price = product.Price });
            }

            return Json(null);
        }
    }
}
