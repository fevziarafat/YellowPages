using MassTransit;
using Microsoft.AspNetCore.Mvc;
using YellowPages.Shared.ControllerBase;
using YellowPages.Shared.Dtos;
using YellowPages.Shared.Messages;
using YellowPagesService.Business.Abstract;

namespace YellowPagesService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class YellowPagesController : CustomBaseController
{
    private readonly ISendEndpointProvider _sendEndpointProvider;
    private readonly IYellowPagesService _yellowPagesService;

    public YellowPagesController(IYellowPagesService yellowPagesService, ISendEndpointProvider sendEndpointProvider)
    {
        _yellowPagesService = yellowPagesService;
        _sendEndpointProvider = sendEndpointProvider;

    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _yellowPagesService.GetAllAsync();


        var a = response;

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
        YellowPagesCreateDto yellowPagesCreateDto)
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

    [Microsoft.AspNetCore.Mvc.HttpPostAttribute]
    [Microsoft.AspNetCore.Mvc.RouteAttribute("/api/[controller]/ReceiveReport/{location}")]
    public async Task<IActionResult> ReceiveReport(string location)
    {
        var createMessage = new CreateReportCommand();
        createMessage.Location = location;
        var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:create-report-service"));

        await sendEndpoint.Send<CreateReportCommand>(createMessage);

        return CreateActionResultInstance(YellowPages.Shared.Dtos.Response<NoContent>.Success(200));
    }


}