using Microsoft.AspNetCore.Builder;
using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Rise.Contacts.Infrastructure.Dependency;
using Rice.Core.Behaviors;

namespace Rise.Contacts.Business.Dependency
{
    public static class ServiceInjector
    {
        public static void AddBusinessDependency(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Services.AddMediatR(Assembly.GetExecutingAssembly()); 
            builder.AddInfrastructureDependency();
        }
    }
}
