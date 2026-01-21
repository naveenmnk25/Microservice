using MassTransit;
using rabbitmq_organization_service.Events;

namespace ApplicationService.Consumers
{
    public class MemberCreatedConsumer : IConsumer<MemberCreated>
    {
        public async Task Consume(ConsumeContext<MemberCreated> context)
        {
            var message = context.Message;

            Console.WriteLine(
                $"[ApplicationService] Member received: {message.MemberId} - {message.Name}");

            // Assign default applications
            // Cache member
            // Send notifications
            await Task.CompletedTask;
        }
    }
}
