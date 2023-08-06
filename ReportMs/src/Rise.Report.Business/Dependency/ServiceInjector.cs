using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Rice.Core.Behaviors;
using Rise.Report.Business.SubServices.RegisterServices;
using Rise.Report.Infrastructure.Dependency;

namespace Rise.Report.Business.Dependency
{
    public static class ServiceInjector
    {
        public static void AddBusinessDependency(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(PublishBehavior<,>));
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Services.AddMediatR(Assembly.GetExecutingAssembly()); 
            builder.AddInfrastructureDependency();
            builder.AddSubServices();
        }
    }
}
