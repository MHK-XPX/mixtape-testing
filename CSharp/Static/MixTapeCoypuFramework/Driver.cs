using System;
using Coypu;
using System.Collections.Generic;

namespace MixTapeCoypuFramework
{
    public static class Driver
    {
        private const string HUB_URL = "http://localhost:4444/wd/hub";
        public const string BaseUrl = "https://mhk-xpx.github.io/mixtape-frontend/";
        public static BrowserSession Instance;
        public static SessionConfiguration SessConfiguration = new SessionConfiguration();

        public static Dictionary<DriverTypes, Coypu.Drivers.Browser> browsersToBeTested = new Dictionary<DriverTypes, Coypu.Drivers.Browser>()
        {
            {DriverTypes.InternetExplorer, Coypu.Drivers.Browser.InternetExplorer},
            {DriverTypes.FireFox, Coypu.Drivers.Browser.Firefox},
            {DriverTypes.Chrome, Coypu.Drivers.Browser.Chrome}
        };
        
        public enum DriverTypes
        {
            Chrome,
            FireFox,
            InternetExplorer
        }

        public static void Initialize(DriverTypes driverType)
        {
            //SessConfiguration.AppHost = BaseUrl;
            SessConfiguration.Browser = browsersToBeTested[driverType];
            SessConfiguration.Timeout = TimeSpan.FromSeconds(Constants.MaxTimeOut);
            SessConfiguration.RetryInterval = TimeSpan.FromSeconds(0.5);
            Instance = new BrowserSession(SessConfiguration);
            Instance.MaximiseWindow();
            //((RemoteWebDriver)Instance.Native).Manage().Window.Maximize();
        }

        public static void GoTo(string url)
        {
            //Instance.Visit("./mixtape-frontend" + url);
            Instance.Visit(BaseUrl + url);
        }

        public static bool IsAt(string url)
        {
            return string.Equals(Instance.Location, url);
        }

        public static void Close()
        {
            Instance.Dispose();
        }
    }
}
