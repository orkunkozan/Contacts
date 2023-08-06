using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Rise.Report.Business.SubServices.RegisterServices
{
    public static class SubServisRegister
    {
        public static void AddSubServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<LocationReportRequestedSubServices>();
            builder.Services.AddTransient<ContactSubServices>();
            builder.Services.AddTransient<PersonSubServices>(); 
        } 
    }
}
