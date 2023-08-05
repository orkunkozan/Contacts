using Microsoft.AspNetCore.Builder;
using System.Reflection;
using FluentValidation;
using MediatR;
using Rise.Contacts.Infrastructure.Dependency;

namespace Rise.Contacts.Business.Dependency
{
    public static class ServiceInjector
    {
        public static void AddBusinessDependency(this WebApplicationBuilder builder)
        {
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Services.AddMediatR(Assembly.GetExecutingAssembly()); 
            builder.AddInfrastructureDependency();
        }
    }
}
