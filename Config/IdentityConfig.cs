using System.Text;
using EDiaristas.Admin.Common.Routes;
using Microsoft.IdentityModel.Tokens;

namespace EDiaristas.Config;

public static class IdentityConfig
{
    public static void RegisterIdentity(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
        services.AddAuthorization();
        services.AddAuthentication()
            .AddCookie(options =>
            {
                options.LoginPath = AdminRoutes.Auth.Login;
                options.AccessDeniedPath = AdminRoutes.Auth.Login;
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
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(accessKey)
                };
            });
    }
}