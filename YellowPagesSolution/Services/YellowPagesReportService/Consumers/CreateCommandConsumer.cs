
using MassTransit;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using YellowPagesReportService.Services;

namespace YellowPagesReportService.Consumers
{
    public class CreateCommandConsumer : IConsumer<YellowPages.Shared.Messages.CreateReportCommand>
    {
        private readonly YellowPagesReportService.Services.IYellowPagesReportService _yellowPagesReportService;

        public CreateCommandConsumer(IYellowPagesReportService yellowPagesReportService)
        {
            _yellowPagesReportService = yellowPagesReportService;
        }

        public async Task Consume(ConsumeContext<YellowPages.Shared.Messages.CreateReportCommand> context)
        {
            await _yellowPagesReportService.CreateAsync(context.Message.Location);
        }
    }
}