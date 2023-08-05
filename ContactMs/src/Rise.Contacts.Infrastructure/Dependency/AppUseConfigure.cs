using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rise.Contacts.Infrastructure.DataAccess.Contexts;

namespace Rise.Contacts.Infrastructure.Dependency
{
    public static class AppUseConfigure
    {
        public static void UseConfigure(this IApplicationBuilder app)
        { 
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ContactContext>();
                context.Database.Migrate();
            }

        }
    }
}
