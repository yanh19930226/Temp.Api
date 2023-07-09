namespace Temp.Api.Models.Events
{
    public class RabbitTestEventModel
    {
        public string Id { get; set; }

        public string Test { get; set; }
    }

    public class RabbitTestEvent : Event<RabbitTestEventModel>
    {
        public RabbitTestEvent()
        {
        }
        public RabbitTestEvent(string source, RabbitTestEventModel eventData) : base(source, eventData)
        {

        }
    }


    public class RabbitDemoEventModel
    {

        public string Id { get; set; }

        public string Demo { get; set; }
    }

    public class RabbitDemoEvent : Event<RabbitDemoEventModel>
    {
        public RabbitDemoEvent()
        {
        }
        public RabbitDemoEvent(string source, RabbitDemoEventModel eventData) : base(source, eventData)
        {

        }
    }

}
