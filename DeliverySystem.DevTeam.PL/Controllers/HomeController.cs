namespace DeliverySystem.DevTeam.PL.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error(int id = 500)
		{
			return View(new ErrorViewModel { ErrorCode = id, ErrorDescription = ReasonPhrases.GetReasonPhrase(id) });
		}
	}
}
