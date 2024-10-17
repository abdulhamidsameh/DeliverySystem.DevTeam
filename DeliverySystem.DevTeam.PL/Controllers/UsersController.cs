namespace DeliverySystem.DevTeam.PL.Controllers
{
    [Authorize(Roles = AppRoles.Admin)]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(UserManager<ApplicationUser> userManager,
            IMapper mapper,
            RoleManager<ApplicationRole> roleManager,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var viewModel = _mapper.Map<IEnumerable<UserViewModel>>(users);
            return View(viewModel);
        }
        [HttpGet]
        [AjaxOnly]
        public async Task<IActionResult> Create()
        {
            var viewModel = new UserFormViewModel()
            {
                Roles = await _roleManager.Roles.Select(R => new SelectListItem()
                {
                    Text = R.Name,
                    Value = R.Name
                }).ToListAsync()
            };
            return PartialView("_Form", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserFormViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            ApplicationUser user = new ApplicationUser()
            {
                FullName = model.FullName,
                UserName = model.UserName,
                Email = model.Email,
                CreatedById = User.FindFirst(ClaimTypes.NameIdentifier)!.Value
            };

            var result = await _userManager.CreateAsync(user,model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, model.SelectedRoles);
                var viewModel = _mapper.Map<UserViewModel>(user);
                if (model.SelectedRoles.Contains(AppRoles.Merchant))
                {
                    var merchant = new Merchant() 
                    {
                        Name = model.FullName,
                        Email = model.Email,
                        CreatedById = User.FindFirst(ClaimTypes.NameIdentifier)!.Value,
                        Address = string.Empty,
                        PhoneNumber = string.Empty,
                        IsDeleted = false,
                        CreatedOn = DateTime.Now,
                    };
                    _unitOfWork.Repository<Merchant>().Add(merchant);
                   var num = _unitOfWork.Complete();

                }
                return PartialView("_UserRow", viewModel);
            }

            return BadRequest();

        }
    }
}
