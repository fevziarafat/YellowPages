using Microsoft.AspNetCore.Mvc;
using YellowPages.Shared.ControllerBase;

namespace YellowPagesService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class YellowPagesController : CustomBaseController
{

    private readonly YellowPagesService.Services.IYellowPagesService _yellowPagesService;

    public YellowPagesController(YellowPagesService.Services.IYellowPagesService yellowPagesService)
    {
        _yellowPagesService = yellowPagesService;
      
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _yellowPagesService.GetAllAsync();

        return CreateActionResultInstance(response);
    }


    [HttpGet]
    [Route("/api/[controller]/GetAllInformationByUserId/{userId}")]
    public async Task<IActionResult> GetAllByUserId(string userId)
    {
        var response = await _yellowPagesService.GetAllInformationByUserIdAsync(userId);

        return CreateActionResultInstance(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        YellowPagesService.Dtos.YellowPagesCreateDto yellowPagesCreateDto)
    {
        var response = await _yellowPagesService.CreateAsync(yellowPagesCreateDto);

        return CreateActionResultInstance(response);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var response = await _yellowPagesService.DeleteAsync(id);

        return CreateActionResultInstance(response);
    }

 
}