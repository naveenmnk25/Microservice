namespace rabbitmq_organization_service
{
    public class RabbitMqOptions
    {
        public string Host { get; set; } = default!;
        public string VirtualHost { get; set; } = "/";
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}