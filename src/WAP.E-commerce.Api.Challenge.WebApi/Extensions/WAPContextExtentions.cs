using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WAP.E_commerce.Api.Challenge.Infra;

namespace WAP.E_commerce.Api.Challenge.WebApi.Extensions
{
    public static class WAPContextExtentions
    {
        public static void AddWAPContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WAPContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    builder =>
                    {
                        builder.MigrationsAssembly("WAP.E_commerce.Api.Challenge.WebApi");
                        builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                    }
                )
            );
        }
    }
}