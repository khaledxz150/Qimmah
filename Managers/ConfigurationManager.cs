using Microsoft.Extensions.Localization;

using Qimmah.Models.Options;

namespace Qimmah.Managers
{
    public static class ConfigurationManager
    {
        public static void ConfigureOptions(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JWTOptions>(configuration.GetSection("JWT"));
            //services.Configure<ContractOption>(configuration.GetSection("ContractOption"));
            //services.Configure<ServiceGroupOption>(configuration.GetSection("ServiceGroupOption"));
            //services.Configure<LocalizationOption>(configuration.GetSection("LocalizationOption"));
            //services.Configure<ManPowerOption>(configuration.GetSection("ManPowerOption"));
            //services.Configure<VehicleOption>(configuration.GetSection("VehicleOption"));
            //services.Configure<DisposalPointOption>(configuration.GetSection("DisposalPointOption"));
            //services.Configure<OvernightPointOption>(configuration.GetSection("OvernightPointOption"));
            //services.Configure<CommonOption>(configuration.GetSection("CommonOption"));
            //services.Configure<OperationPlanOption>(configuration.GetSection("OperationPlanOption"));
            //services.Configure<TripOption>(configuration.GetSection("TripOption"));
        }
    }
}
