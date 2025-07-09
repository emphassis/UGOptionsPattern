using Microsoft.Extensions.Options;
using UGOptionsPattern.Settings;

namespace UGOptionsPattern.Services
{
    public class DatabaseService
    {
        /*
         * For this to work with controllers, wire up the controllers the same way that the services are
         * Wire up controllers normally, the options are injected for free
         */
        private ConnectionStringSettings _connectionStringSettings;
        private List<ContentSettings> _contentSettings;

        public DatabaseService(IOptions<ConnectionStringSettings> connectionStringSettings, IOptions<List<ContentSettings>> contentSettings)
        {
            _connectionStringSettings = connectionStringSettings.Value;
            _contentSettings = contentSettings.Value;
        }

        public ConnectionStringSettings GetConnectionStrings()
        {
            return _connectionStringSettings;
        }

        public List<ContentSettings> GetContent() 
        {
            List<ContentSettings> response = new();
            Random random = new Random();

            for (var i = 0; i <= _contentSettings.Count; i++) 
            {
                var item = random.Next(0, _contentSettings.Count());
                response.Add(_contentSettings[item]);
            }

            return response;
        }
    }
}
