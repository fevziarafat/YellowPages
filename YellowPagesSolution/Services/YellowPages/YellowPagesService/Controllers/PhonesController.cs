﻿namespace YellowPagesService.Controllers;

[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
[Microsoft.AspNetCore.Mvc.ApiController]
public class PhonesController : YellowPages.Shared.ControllerBase.CustomBaseController
{
    private readonly YellowPages.Services.IPhoneInformationService _phoneInformationService;

    public PhonesController(YellowPages.Services.IPhoneInformationService phoneInformationService)
    {
        _phoneInformationService = phoneInformationService;
    }


    [Microsoft.AspNetCore.Mvc.HttpPost]
    public async Task<Microsoft.AspNetCore.Mvc.IActionResult> Create(YellowPagesService.Dtos.PhoneInformationCreateDto phoneInformationCreateDto)
    {
        var response = await _phoneInformationService.CreateAsync(phoneInformationCreateDto);

        return CreateActionResultInstance(response);
    }


    [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
    public async Task<Microsoft.AspNetCore.Mvc.IActionResult> Delete(string id)
    {
        var response = await _phoneInformationService.DeleteAsync(id);

        return CreateActionResultInstance(response);
    }
}