using Microsoft.AspNetCore.Mvc;
using YellowPages.Shared.ControllerBase;
using YellowPagesReportService.Business.Abstract;

namespace YellowPagesReportService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class YellowPagesReportController : CustomBaseController
{
    private readonly IYellowPagesReportService _yellowPagesReportService;

    public YellowPagesReportController(
        IYellowPagesReportService yellowPagesReportService)
    {
        _yellowPagesReportService = yellowPagesReportService;
    }


    [HttpGet]
    [Route("/api/[controller]/ReportByLocation/{locationName}")]
    public async Task<IActionResult> GetReportByLocation(string locationName)
    {
        var response = await _yellowPagesReportService.CreateAsync(locationName);

        return CreateActionResultInstance(response);
    }

    [HttpGet]
    [Route("/api/[controller]/GetAllReport")]
    public async Task<IActionResult> GetAllReport()
    {
        var response = await _yellowPagesReportService.GetAllAsync();

        return CreateActionResultInstance(response);
    }

    [HttpGet]
    [Route("/api/[controller]/ReportById/{id}")]
    public async Task<IActionResult> GetReportById(string id)
    {
        var response = await _yellowPagesReportService.GetReportByIdAsync(id);

        return CreateActionResultInstance(response);
    }

}