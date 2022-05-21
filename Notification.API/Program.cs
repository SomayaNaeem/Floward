using Autofac;
using Autofac.Extensions.DependencyInjection;
using Catalog.Infrastructure;
using EventBus.Abstractions;
using EventBusRabbitMQ;
using Notification.API.EventHandlers;
using Notification.Application.Common;
using Notification.Application.Common.ConfigurationKeys;
using Notification.Application.Common.Events;
using Notification.Application.Common.Interfaces;
using Notification.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(configuration);
builder.Services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddTransient<SendEmailEventHandler>();

builder.Services.AddEventBus(configuration);

var container = new ContainerBuilder();
container.Populate(builder.Services);
//container.Build();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
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

ConfigureEventBus(app);

app.Run();

void ConfigureEventBus(IApplicationBuilder app)
{
    var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

    eventBus.Subscribe<SendEmailEvent, SendEmailEventHandler>();
}