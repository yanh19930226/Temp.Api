namespace Temp.Api.Applications.Subscribers
{
    /// <summary>
    /// 事件处理服务，相当于订阅事件
    /// </summary>
    public class RabbitTestEventBusHandler : IEventsBusHandler<RabbitTestEvent>
    {
        private readonly ILogger<RabbitTestEventBusHandler> _logger;
        public RabbitTestEventBusHandler(ILogger<RabbitTestEventBusHandler> logger)
        {
            _logger = logger;
        }
        public async Task HandleAsync(RabbitTestEvent eventData)
        {

            _logger.LogError(JsonSerializer.Serialize(eventData));

            Console.WriteLine($"Event Data： {JsonSerializer.Serialize(eventData)}");

            await Task.CompletedTask;
        }
    }
}
