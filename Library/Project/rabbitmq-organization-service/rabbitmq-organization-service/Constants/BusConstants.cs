namespace rabbitmq_organization_service.Constants
{
    public static class BusConstants
    {
        // Exchange / Queue names
        public const string MemberCreatedQueue = "member-created-queue";

        // Consumer endpoint names
        public const string ApplicationServiceQueue = "application-service";

        public const string OrganizationServiceQueue = "organization-service";
    }
}