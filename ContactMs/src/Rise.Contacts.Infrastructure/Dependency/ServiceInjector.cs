using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rice.Core.Config;
using Rice.Core.Context.Abstraction;
using Rice.Core.Services.EntityChangeServices;
using Rise.Contacts.Infrastructure.DataAccess.Contexts;

namespace Rise.Contacts.Infrastructure.Dependency
{
    public static class ServiceInjector
    {
        public static void AddInfrastructureDependency(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<IProjectContext,ContactContext>(ServiceLifetime.Scoped);  
            builder.Services.AddDbContext<IProjectContext,ContactSubscribeDbContext>(ServiceLifetime.Scoped);

            builder.Services.AddScoped<IEntityChangeServices, EntityChangeServices>();

            var capConfig = builder.Configuration.GetSection("CapConfig").Get<CapConfig>();

            builder.Services.AddCap(options =>
            {
                options.UsePostgreSql(sqlOptions =>
                {
                    sqlOptions.ConnectionString = builder.Configuration.GetConnectionString("PostgresContext");
                });
                options.UseRabbitMQ(rabbitMqOptions =>
                {
                    rabbitMqOptions.ConnectionFactoryOptions = connectionFactory =>
                    {
                        connectionFactory.Ssl.Enabled = capConfig.SslEnable;
                        connectionFactory.HostName = capConfig.HostName;
                        connectionFactory.UserName = capConfig.UserName;
                        connectionFactory.Password = capConfig.Password;
                        connectionFactory.Port = capConfig.Port;
                    };
                });
                options.UseDashboard(otp => { otp.PathMatch = "/MyCap"; });
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
        }
    }
}
