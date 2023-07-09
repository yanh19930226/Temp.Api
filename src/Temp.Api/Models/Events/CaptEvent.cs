namespace Temp.Api.Models.Events
{
    public class TestCapEventModel
    {
        public string CustomerId { get; set; }

        public string Amount { get; set; }

        public string TransactionLogId { get; set; }
    }

    public class CaptEvent : Event<TestCapEventModel>
    {
        public CaptEvent()
        {
        }
        public CaptEvent(string source, TestCapEventModel eventData) : base(source, eventData)
        {

        }
    }
}
