

namespace DeliverySystem.DevTeam.PL.Controllers
{
	public class RolesController : Controller
	{
		private readonly RoleManager<ApplicationRole> _roleManager;
		private readonly IMapper _mapper;

		public RolesController(RoleManager<ApplicationRole> roleManager,
			IMapper mapper)
		{
			_roleManager = roleManager;
			_mapper = mapper;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			// Get All Roles 
			var roles = await _roleManager.Roles.ToListAsync();
			var rolesViewModels = _mapper.Map<List<ApplicationRole>, List<RoleToUpdateOrReturnViewModel>>(roles);
			return View(rolesViewModels);
		}
		[HttpGet]
        [AjaxOnly]
		public IActionResult Create()
		{
			var viewMoel = new CreateRoleViewModel();
			return PartialView("_Form", viewMoel);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CreateRoleViewModel viewModel)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var rolesExists = await _roleManager.RoleExistsAsync(viewModel.Name);

			if (rolesExists)
			{
				ModelState.AddModelError("Name", "Role Is Exist");
				return BadRequest();
			}

			var role = new ApplicationRole() { Name = viewModel.Name };

			await _roleManager.CreateAsync(role);

			var roleToReturn = _mapper.Map<RoleToUpdateOrReturnViewModel>(role);

			return PartialView("_RoleRow", roleToReturn);
		}
		[HttpGet]
		[AjaxOnly]
		public async Task<IActionResult> Edit(string id)
		{
			var role = await _roleManager.FindByIdAsync(id);

			if (role is null)
				return RedirectToAction(nameof(Index));

			var viewModel = _mapper.Map<ApplicationRole, CreateRoleViewModel>(role);

			return PartialView("_Form", viewModel);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(CreateRoleViewModel viewModel)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var roleExist = await _roleManager.RoleExistsAsync(viewModel.Name);
			if (roleExist)
			{
				ModelState.AddModelError("Name", "Role Is Exist");
				return PartialView("_Form", viewModel);
			}
			var role = await _roleManager.FindByIdAsync(viewModel.Id);
			role.Name = viewModel.Name;
			role.LastUpdatedOn = DateTime.Now;
			await _roleManager.UpdateAsync(role);


			var roleToReturn = _mapper.Map<RoleToUpdateOrReturnViewModel>(role);

			return PartialView("_RoleRow", roleToReturn);
		}
		[HttpPost]
		public async Task<IActionResult> ToggleStatus(string id)
		{
			var role = await _roleManager.FindByIdAsync(id);
			if (role is null)
				return NotFound();

			role.IsDeleted = !role.IsDeleted;
			role.LastUpdatedOn = DateTime.Now;
			await _roleManager.UpdateAsync(role);

			return Ok(role.LastUpdatedOn.ToString());
		}
	}
}