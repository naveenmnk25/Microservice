using ApplicationService.Consumers;
using ApplicationService.Models;
using Microsoft.EntityFrameworkCore;
using rabbitmq_organization_service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .Build();

builder.Services.AddDbContext<OrganizationServiceDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b =>
    {
        b.MigrationsAssembly(typeof(OrganizationServiceDbContext).Assembly.FullName);
        b.EnableRetryOnFailure();
    }));

builder.Services.AddHttpClient("OrgService", (sp, client) =>
{
    var baseUrl = configuration["ServiceUrls:OrganizationService"];

    client.BaseAddress = new Uri(baseUrl!);
});

builder.Services.AddRabbitMq(
    builder.Configuration,
    cfg =>
    {
        cfg.AddConsumer<MemberCreatedConsumer>();
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
