using MediatR;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.CommandHandlers;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Application.Services;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Data.Repository;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbitBaking.Application.Interfaces;
using MicroRabbitBaking.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;


namespace MicroRabbit.Infra.IOC
{
    public static class DependencyContainer
    {

        public static IServiceCollection RegisterServices(this IServiceCollection services , IConfiguration configuration)
        {

            //services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();


            //MediatR Mediator
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR( cfg => cfg.RegisterServicesFromAssemblies( typeof(RabbitMQBus).Assembly));


            // Domain Bus 
            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp => {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                var optionsFactory = sp.GetService<IOptions<RabbitMQSettings>>();
                return new RabbitMQBus(scopeFactory, sp.GetService<IMediator>(), optionsFactory);
            });

            //services.Configure<RabbitMQSettings>(c => configuration.GetSection("RabbitMQSettings"));

            //// Application services
            //services.AddTransient<IAccountService, AccountService>();
            //services.AddTransient<ITransferService, TransferService>();

            //// Data
            //services.AddTransient<IAccountRepository, AccountRepository>();
            //services.AddTransient<ITransferRepository, TransferRepository>();

            //services.AddTransient<BackingDbContext>();
            //services.AddTransient<TransferDbContext>();

            return services;

        }
    }
}
