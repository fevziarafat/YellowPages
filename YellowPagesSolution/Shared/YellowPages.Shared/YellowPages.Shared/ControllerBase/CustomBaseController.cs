namespace YellowPages.Shared.ControllerBase
{
    public class CustomBaseController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        public Microsoft.AspNetCore.Mvc.IActionResult CreateActionResultInstance<T>(
            YellowPages.Shared.Dtos.Response<T> response)
        {
            return new Microsoft.AspNetCore.Mvc.ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}