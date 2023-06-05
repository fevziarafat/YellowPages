namespace YellowPagesService.Controllers;

[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
[Microsoft.AspNetCore.Mvc.ApiController]
public class LocationsController : YellowPages.Shared.ControllerBase.CustomBaseController
{
    private readonly YellowPages.Services.ILocationInformationService _locationInformationService;

    public LocationsController(YellowPages.Services.ILocationInformationService locationInformationService)
    {
        _locationInformationService = locationInformationService;
    }


    [Microsoft.AspNetCore.Mvc.HttpPost]
    public async Task<Microsoft.AspNetCore.Mvc.IActionResult> Create(
        YellowPagesService.Dtos.LocationInformationCreateDto locationInformationCreateDto)
    {
        var response = await _locationInformationService.CreateAsync(locationInformationCreateDto);

        return CreateActionResultInstance(response);
    }


    [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
    public async Task<Microsoft.AspNetCore.Mvc.IActionResult> Delete(string id)
    {
        var response = await _locationInformationService.DeleteAsync(id);

        return CreateActionResultInstance(response);
    }
}