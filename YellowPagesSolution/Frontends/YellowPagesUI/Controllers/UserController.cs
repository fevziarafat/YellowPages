using YellowPagesUI.Business.Abstract;


namespace YellowPagesUI.Controllers
{
    [Microsoft.AspNetCore.Authorization.AuthorizeAttribute]
    public class UserController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> Index()
        {
            return View(await _userService.GetUser());
        }
    }
}