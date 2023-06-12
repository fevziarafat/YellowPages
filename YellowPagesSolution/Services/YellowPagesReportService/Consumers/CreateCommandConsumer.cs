
using MassTransit;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

using YellowPages.Shared.Messages;
using YellowPagesReportService.Business.Abstract;

namespace YellowPagesReportService.Consumers
{
    public class CreateCommandConsumer : IConsumer<CreateReportCommand>
    {
        private readonly IYellowPagesReportService _yellowPagesReportService;

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