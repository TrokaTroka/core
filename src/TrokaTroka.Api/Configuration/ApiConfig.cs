using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrokaTroka.Api.Dtos.InputModels.Validators;
using TrokaTroka.Api.Infra.Context;

namespace TrokaTroka.Api.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDbContext<TrokatrokaDbContext>(options =>
                options.UseMySQL(configuration.GetConnectionString("TrokaTroka"), 
                    b => b.MigrationsAssembly(typeof(TrokatrokaDbContext).Assembly.FullName)));

            services.AddInjection();
            
            services.AddControllers()
                .AddFluentValidation(fv =>
                    fv.RegisterValidatorsFromAssemblyContaining<LoginInputModelValidator>());

            services.AddSwagger();

            services.AddCors(options =>
            {
                options.AddPolicy("Total",
                    builder =>
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
            });

            return services;
        }

        public static void UseApiConfiguration(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("Total");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
