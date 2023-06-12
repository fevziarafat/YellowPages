using YellowPages.Shared.Dtos;

using YellowPagesService.Business.Abstract;

namespace YellowPagesService.Controllers;

[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
[Microsoft.AspNetCore.Mvc.ApiController]
public class EmailsController : YellowPages.Shared.ControllerBase.CustomBaseController
{
    private readonly IEMailInformationService _eMailInformationService;

    public EmailsController(IEMailInformationService eMailInformationService)
    {
        _eMailInformationService = eMailInformationService;
    }


    [Microsoft.AspNetCore.Mvc.HttpPost]
    public async Task<Microsoft.AspNetCore.Mvc.IActionResult> Create(
        EMailInformationCreateDto eMailInformationCreateDto)
    {
        var response = await _eMailInformationService.CreateAsync(eMailInformationCreateDto);

        return CreateActionResultInstance(response);
    }


    [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
    public async Task<Microsoft.AspNetCore.Mvc.IActionResult> Delete(string id)
    {
        var response = await _eMailInformationService.DeleteAsync(id);

        return CreateActionResultInstance(response);
    }
}