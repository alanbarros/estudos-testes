using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestandoIdentity.Areas.Identity.Data;
using TestandoIdentity.Models;

[assembly: HostingStartup(typeof(TestandoIdentity.Areas.Identity.IdentityHostingStartup))]
namespace TestandoIdentity.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TestandoIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TestandoIdentityContextConnection")));

                services.AddDefaultIdentity<TestandoIdentityUser>()
                    .AddEntityFrameworkStores<TestandoIdentityContext>();
            });
        }
    }
}