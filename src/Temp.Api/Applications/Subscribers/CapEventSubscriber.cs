namespace Temp.Api.Applications.Subscribers
{
    public sealed class CapEventSubscriber : ICapSubscribe
    {
        private readonly ILogger<CapEventSubscriber> _logger;

        public CapEventSubscriber(
            ILogger<CapEventSubscriber> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// TestEvent
        /// </summary>
        /// <param name="eventDto"></param>
        /// <returns></returns>
        [CapSubscribe(nameof(CaptEvent))]
        public async Task ProcessWarehouseQtyBlockedEvent(CaptEvent eventDto)
        {
            eventDto.EventTarget = nameof(ProcessWarehouseQtyBlockedEvent);
            //var hasProcessed = await _tracker.HasProcessedAsync(eventDto);
            //if (!hasProcessed)
            //    await _orderSrv.MarkCreatedStatusAsync(eventDto, _tracker);
        }
    }
}
