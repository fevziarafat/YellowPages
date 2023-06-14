using Microsoft.AspNetCore.Mvc;
using YellowPages.Shared.ControllerBase;
using YellowPages.Shared.Dtos;
using YellowPagesService.Business.Abstract;

namespace YellowPagesService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PhonesController : CustomBaseController
{
    private readonly IPhoneInformationService _phoneInformationService;

    public PhonesController(IPhoneInformationService phoneInformationService)
    {
        _phoneInformationService = phoneInformationService;
    }


    [HttpPost]
    public async Task<IActionResult> Create(PhoneInformationCreateDto phoneInformationCreateDto)
    {
        var response = await _phoneInformationService.CreateAsync(phoneInformationCreateDto);

        return CreateActionResultInstance(response);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var response = await _phoneInformationService.DeleteAsync(id);

        return CreateActionResultInstance(response);
    }
}