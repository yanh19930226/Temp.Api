namespace Temp.Api.Applications.Subscribers
{
    /// <summary>
    /// 事件处理服务，相当于订阅事件
    /// </summary>
    public class RabbitDemoEventBusHandler : IEventsBusHandler<RabbitDemoEvent>
    {
        private readonly ILogger<RabbitDemoEventBusHandler> _logger;
        public RabbitDemoEventBusHandler(ILogger<RabbitDemoEventBusHandler> logger)
        {
            _logger = logger;
        }
        public async Task HandleAsync(RabbitDemoEvent eventData)
        {
            _logger.LogError(JsonSerializer.Serialize(eventData));

            Console.WriteLine($"Data： {JsonSerializer.Serialize(eventData)}");

            await Task.CompletedTask;
        }
    }
}
