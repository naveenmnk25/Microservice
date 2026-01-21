using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace rabbitmq_organization_service
{
    public static class RabbitMqExtensions
    {
        public static IServiceCollection AddRabbitMq(
            this IServiceCollection services,
            IConfiguration configuration,
            Action<IBusRegistrationConfigurator>? configure = null)
        {
            services.AddMassTransit(x =>
            {
                configure?.Invoke(x);

                x.UsingRabbitMq((context, cfg) =>
                {
                    var options = configuration
                        .GetSection("RabbitMQ").Get<RabbitMqOptions>();

                    cfg.Host(options!.Host, options.VirtualHost, h =>
                    {
                        h.Username(options.Username);
                        h.Password(options.Password);
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });

            return services;
        }
    }
}