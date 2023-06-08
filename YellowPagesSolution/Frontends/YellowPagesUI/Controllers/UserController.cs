namespace YellowPagesUI.Controllers
{
    [Microsoft.AspNetCore.Authorization.AuthorizeAttribute]
    public class UserController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly Services.Interfaces.IUserService _userService;

        public UserController(Services.Interfaces.IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> Index()
        {
            return View(await _userService.GetUser());
        }
    }
}