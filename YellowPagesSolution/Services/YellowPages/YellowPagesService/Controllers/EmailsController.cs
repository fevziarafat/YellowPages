using Microsoft.AspNetCore.Mvc;
using YellowPages.Shared.ControllerBase;
using YellowPages.Shared.Dtos;
using YellowPagesService.Business.Abstract;

namespace YellowPagesService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmailsController : CustomBaseController
{
    private readonly IEMailInformationService _eMailInformationService;

    public EmailsController(IEMailInformationService eMailInformationService)
    {
        _eMailInformationService = eMailInformationService;
    }


    [HttpPost]
    public async Task<IActionResult> Create(
        EMailInformationCreateDto eMailInformationCreateDto)
    {
        var response = await _eMailInformationService.CreateAsync(eMailInformationCreateDto);

        return CreateActionResultInstance(response);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var response = await _eMailInformationService.DeleteAsync(id);

        return CreateActionResultInstance(response);
    }
}