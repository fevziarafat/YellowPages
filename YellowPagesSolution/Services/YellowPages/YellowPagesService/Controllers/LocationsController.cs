using Microsoft.AspNetCore.Mvc;
using YellowPages.Shared.ControllerBase;
using YellowPages.Shared.Dtos;
using YellowPagesService.Business.Abstract;

namespace YellowPagesService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationsController : CustomBaseController
{
    private readonly ILocationInformationService _locationInformationService;

    public LocationsController(ILocationInformationService locationInformationService)
    {
        _locationInformationService = locationInformationService;
    }


    [HttpPost]
    public async Task<IActionResult> Create(
        LocationInformationCreateDto locationInformationCreateDto)
    {
        var response = await _locationInformationService.CreateAsync(locationInformationCreateDto);

        return CreateActionResultInstance(response);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var response = await _locationInformationService.DeleteAsync(id);

        return CreateActionResultInstance(response);
    }
}