namespace YellowPagesUI.Controllers
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> Index()
        {
            return View();
            //return View(await _catalogService.GetAllCourseAsync());
        }

        [Microsoft.AspNetCore.Mvc.ResponseCacheAttribute(Duration = 0, Location = Microsoft.AspNetCore.Mvc.ResponseCacheLocation.None, NoStore = true)]
        public Microsoft.AspNetCore.Mvc.IActionResult Error()
        {
            var errorFeature = HttpContext.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();

            if (errorFeature != null && errorFeature.Error is Exceptions.UnAuthorizeException)
            {
                return RedirectToAction(nameof(AuthController.Logout), "Auth");
            }

            return View(new Models.ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}