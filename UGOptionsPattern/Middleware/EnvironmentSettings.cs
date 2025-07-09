using UGOptionsPattern.Settings;

namespace UGOptionsPattern.Middleware
{
    public class EnvironmentSettings
    {
        private IServiceCollection _services;

        public EnvironmentSettings(IServiceCollection services)
        {
            _services = services;
        }

        public void ConfigureSettings(IConfiguration configuration)
        {
            // read each section of the appsettings file
            _services.Configure<ConnectionStringSettings>(configuration.GetSection("ConnectionStrings"));
            _services.Configure<HomePageSettings>(configuration.GetSection("HomePage"));
            _services.Configure<List<ContentSettings>>(configuration.GetSection("Content"));

            // you can add options individually, or all with the following line
            _services.AddOptions();

            //_services.AddOptions<ConnectionStrings>();
            //_services.AddOptions<HomePage>();
        }
    }
}
