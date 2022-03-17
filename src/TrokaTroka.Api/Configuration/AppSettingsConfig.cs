using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrokaTroka.Api.Extensions;

namespace TrokaTroka.Api.Configuration
{
    public static class AppSettingsConfig
    {
        public static void AddSettings(this IServiceCollection services,
            IConfiguration configuration)
        {
            AppSettings.Initialize(configuration.GetSection("AppSettings").Get<AppSettings>());          
        }
    }
}
