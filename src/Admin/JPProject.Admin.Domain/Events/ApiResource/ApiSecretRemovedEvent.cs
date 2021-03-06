using JPProject.Domain.Core.Events;

namespace JPProject.Admin.Domain.Events.ApiResource
{
    public class ApiSecretRemovedEvent : Event
    {
        public string Type { get; }

        public ApiSecretRemovedEvent(string type, string resourceName)
        {
            Type = type;
            AggregateId = resourceName;
        }
    }
}