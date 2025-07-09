using Microsoft.Extensions.Options;
using UGOptionsPattern.Settings;

namespace UGOptionsPattern.Services
{
    public class HomePageService
    {
        private HomePageSettings _homePageSettings;

        public HomePageService(IOptions<HomePageSettings> homePageSettings)
        {
            _homePageSettings = homePageSettings.Value;
        }

        public HomePageSettings Get()
        {
            return _homePageSettings;
        }
    }
}
