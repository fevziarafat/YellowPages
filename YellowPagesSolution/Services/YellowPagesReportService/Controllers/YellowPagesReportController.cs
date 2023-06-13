



using YellowPagesReportService.Business.Abstract;

namespace YellowPagesReportService.Controllers;

[Microsoft.AspNetCore.Mvc.RouteAttribute("api/[controller]")]
[Microsoft.AspNetCore.Mvc.ApiControllerAttribute]
public class YellowPagesReportController : YellowPages.Shared.ControllerBase.CustomBaseController
{
    private readonly IYellowPagesReportService _yellowPagesReportService;

    public YellowPagesReportController(
      IYellowPagesReportService yellowPagesReportService)
    {
        _yellowPagesReportService = yellowPagesReportService;
    }


    [Microsoft.AspNetCore.Mvc.HttpGetAttribute]
    [Microsoft.AspNetCore.Mvc.RouteAttribute("/api/[controller]/ReportByLocation/{locationName}")]
    public async Task<Microsoft.AspNetCore.Mvc.IActionResult> GetReportByLocation(string locationName)
    {
        var response = await _yellowPagesReportService.CreateAsync(locationName);

        return CreateActionResultInstance(response);
    }

    [Microsoft.AspNetCore.Mvc.HttpGetAttribute]
    [Microsoft.AspNetCore.Mvc.RouteAttribute("/api/[controller]/GetAllReport")]
    public async Task<Microsoft.AspNetCore.Mvc.IActionResult> GetAllReport()
    {
        var response = await _yellowPagesReportService.GetAllAsync();

        return CreateActionResultInstance(response);
    }

    [Microsoft.AspNetCore.Mvc.HttpGetAttribute]
    [Microsoft.AspNetCore.Mvc.RouteAttribute("/api/[controller]/ReportById/{id}")]
    public async Task<Microsoft.AspNetCore.Mvc.IActionResult> GetReportById(string id)
    {
        var response = await _yellowPagesReportService.GetReportByIdAsync(id);

        return CreateActionResultInstance(response);
    }

    //[Microsoft.AspNetCore.Mvc.HttpPost]
    //public async Task<Microsoft.AspNetCore.Mvc.IActionResult> Create(
    //    ContactServicesCD.Dtos.ContactCreateDto contactCreateDto)
    //{
    //    var response = await _contactService.CreateAsync(contactCreateDto);

    //    return CreateActionResultInstance(response);
    //}
}