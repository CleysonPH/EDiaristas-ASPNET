using EDiaristas.Admin.Auth.Routes;
using EDiaristas.Core.Data.Contexts;
using EDiaristas.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace EDiaristas.Config;

public static class IdentityConfig
{
    public static void RegisterIdentity(this IServiceCollection services)
    {
        services.AddIdentity<Usuario, IdentityRole<int>>(options =>
        {
            options.Password.RequireUppercase = false;
            options.Password.RequireDigit = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase = false;
            options.Password.RequiredLength = 6;
            options.SignIn.RequireConfirmedAccount = false;
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;
        })
            .AddEntityFrameworkStores<EDiaristasDbContext>();

        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = AuthRoutes.Login;
            options.AccessDeniedPath = AuthRoutes.Login;
            options.ExpireTimeSpan = TimeSpan.FromDays(14);
        });
    }
}