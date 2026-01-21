namespace rabbitmq_organization_service.Events
{
    public record MemberCreated(Guid MemberId, string Name);
}