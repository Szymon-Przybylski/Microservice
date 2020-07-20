using System;
using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using Convey.CQRS.Queries;
using Convey.Docs.Swagger;
using Convey.HTTP;
using Convey.MessageBrokers.CQRS;
using Convey.MessageBrokers.Outbox;
using Convey.MessageBrokers.Outbox.Mongo;
using Convey.MessageBrokers.RabbitMQ;
using Convey.Persistence.MongoDB;
using Convey.WebApi;
using Convey.WebApi.CQRS;
using Convey.WebApi.Exceptions;
using Convey.WebApi.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HostFiltering;
using Microsoft.Extensions.DependencyInjection;
using ShippingService.Application;
using ShippingService.Application.Events;
using ShippingService.Application.Events.External;
using ShippingService.Application.Services;
using ShippingService.Infrastructure.Exceptions;
using ShippingService.Infrastructure.OutboxDecorators;
using ShippingService.Infrastructure.Services;

namespace ShippingService.Infrastructure
{
    public static class Extensions
    {
        public static IConveyBuilder AddInfrastructure(this IConveyBuilder builder)
        {
            builder
                .AddQueryHandlers()
                .AddInMemoryQueryDispatcher()
                .AddHttpClient()
                .AddErrorHandler<ExceptionToResponseMapper>()
                .AddExceptionToMessageMapper<ExceptionToMessageMapper>()
                .AddMongo()
                .AddRabbitMq()
                .AddSwaggerDocs()
                .AddWebApiSwaggerDocs()
                .AddMessageOutbox(o => o.AddMongo());
            IServiceCollection services = builder.Services;
            
            services.AddTransient<IDomainToIntegrationEventMapper, DomainToIntegrationEventMapper>();
            services.AddTransient<IEventProcessor, EventProcessor>();
            services.AddTransient<IMessageBroker, MessageBroker>();

            services.TryDecorate(typeof(ICommandHandler<>), typeof(OutboxCommandHandlerDecorator<>));
            services.TryDecorate(typeof(IEventHandler<>), typeof(OutboxEventHandlerDecorator<>));
            
            builder.Services.Scan(s => s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddClasses(c => c.AssignableTo(typeof(IDomainEventHandler<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());
            return builder;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app
                .UseErrorHandler()
                .UseSwaggerDocs()
                .UseConvey()
                .UsePublicContracts<ShipmentAttribute>()
                .UseRabbitMq()
                .SubscribeEvent<ShipmentCreated>();
            return app;
        }
    }
}