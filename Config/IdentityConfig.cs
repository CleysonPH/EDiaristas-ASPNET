using System.Text;
using EDiaristas.Core.Data.Contexts;
using EDiaristas.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace EDiaristas.Config;

public static class IdentityConfig
{
    public static void RegisterIdentity(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
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
        }).AddEntityFrameworkStores<EDiaristasDbContext>();

        services.AddAuthorization();
        services.AddAuthentication()
            .AddCookie(options =>
            {
                options.LoginPath = "/admin/login";
                options.AccessDeniedPath = "/admin/login";
                options.ExpireTimeSpan = TimeSpan.FromDays(1);
            })
            .AddJwtBearer(options =>
            {
                var accessKey = Encoding.UTF8.GetBytes(configuration.GetValue<string>("Jwt:AccessKey"));
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(accessKey)
                };
            });
    }
}