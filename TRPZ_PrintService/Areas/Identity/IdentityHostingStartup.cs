using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TRPZ_PrintService.Areas.Identity;
using TRPZ_PrintService.Areas.Identity.Data;
using TRPZ_PrintService.Data;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]

namespace TRPZ_PrintService.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<TRPZ_PrintServiceContext>(options =>
                    options.UseNpgsql(
                        "Host=localhost;Port=5432;Database=printdb;Username=printuser;Password=printpasswd"));

                services.AddDefaultIdentity<TRPZ_PrintServiceUser>(options =>
                    {
                        // options.SignIn.RequireConfirmedAccount = true;
                    })
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<TRPZ_PrintServiceContext>();
            });
        }
    }
}