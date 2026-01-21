namespace rabbitmq_organization_service.Events
{
    public record MemberCreatedEvent(
        Guid MemberId,
        string MemberName,
        string Email,
        Guid TeamId
    );
}