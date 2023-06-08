using Microsoft.AspNetCore.Authentication;

namespace YellowPagesUI.Controllers
{
    public class AuthController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly Services.Interfaces.IIdentityService _identityService;

        public AuthController(Services.Interfaces.IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public Microsoft.AspNetCore.Mvc.IActionResult SignIn()
        {
            return View();
        }

        [Microsoft.AspNetCore.Mvc.HttpPostAttribute]
        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> SignIn(Models.SigninInput signinInput)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var response = await _identityService.SignIn(signinInput);

            if (!response.IsSuccessful)
            {
                response.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(string.Empty, x);
                });

                return View();
            }

            return RedirectToAction(nameof(Index), "Home");
        }

        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme);
            await _identityService.RevokeRefreshToken();
            return RedirectToAction(nameof(YellowPagesUI.Controllers.HomeController.Index), "Home");
        }
    }
}