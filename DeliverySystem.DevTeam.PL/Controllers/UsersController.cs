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

			var result = await _userManager.CreateAsync(user, model.Password);

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
					_unitOfWork.Complete();
					
				}
				if (model.SelectedRoles.Contains(AppRoles.Delivery))
				{
					var delivery = new Delivery()
					{
						Name = model.FullName,
						Email = model.Email,
						CreatedById = User.FindFirst(ClaimTypes.NameIdentifier)!.Value,
						Address = string.Empty,
						PhoneNumber = string.Empty,
						IsDeleted = false,
						CreatedOn = DateTime.Now,
					};
					_unitOfWork.Repository<Delivery>().Add(delivery);
					_unitOfWork.Complete();


				}
				return PartialView("_UserRow", viewModel);
			}

			return BadRequest(string.Join(',', result.Errors.Select(e => e.Description)));
		}
		public async Task<IActionResult> AllowUserName(UserFormViewModel model)
		{
			var user = await _userManager.FindByNameAsync(model.UserName);
			var isAllowed = user is null || user.Id.Equals(model.Id);
			return Json(isAllowed);
		}
		public async Task<IActionResult> AllowEmail(UserFormViewModel model)
		{
			var user = await _userManager.FindByEmailAsync(model.Email);
			var isAllowed = user is null || user.Id.Equals(model.Id);
			return Json(isAllowed);
		}
		[HttpPost]
		public async Task<IActionResult> ToggleStatus(string id)
		{
			var user = await _userManager.FindByIdAsync(id);

			if (user is null)
				return NotFound();

			user.IsDeleted = !user.IsDeleted;
			user.LastUpdatedById = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
			user.LastUpdatedOn = DateTime.Now;

			return Ok(user.LastUpdatedOn.ToString());
		}
		[HttpGet]
		[AjaxOnly]
		public async Task<IActionResult> Edit(string id)
		{
			var user = await _userManager.FindByIdAsync(id);

			if (user is null)
				return NotFound();

			var viewModel = _mapper.Map<UserFormViewModel>(user);

			viewModel.SelectedRoles = await _userManager.GetRolesAsync(user);
			viewModel.Roles = await _roleManager.Roles
				.Select(r => new SelectListItem
				{
					Text = r.Name,
					Value = r.Name
				})
				.ToListAsync();

			return PartialView("_Form", viewModel);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(UserFormViewModel model)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var user = await _userManager.FindByIdAsync(model.Id);

			if (user is null)
				return NotFound();

			user = _mapper.Map(model, user);
			user.LastUpdatedById = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
			user.LastUpdatedOn = DateTime.Now;

			var result = await _userManager.UpdateAsync(user);

			if (result.Succeeded)
			{
				var currentRoles = await _userManager.GetRolesAsync(user);

				var rolesUpdated = !currentRoles.SequenceEqual(model.SelectedRoles);

				if (rolesUpdated)
				{
					await _userManager.RemoveFromRolesAsync(user, currentRoles);
					await _userManager.AddToRolesAsync(user, model.SelectedRoles);
				}
				var viewModel = _mapper.Map<UserViewModel>(user);
				return PartialView("_UserRow", viewModel);
			}
			return BadRequest(string.Join(',', result.Errors.Select(e => e.Description)));

		}
	}
}
