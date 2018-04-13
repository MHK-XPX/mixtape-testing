using System;
using Coypu;
using System.Collections.Generic;
using System.Threading;
using MixTapeCoypuFramework.Pages;
using System.Reflection;

namespace MixTapeCoypuFramework
{
    /// <summary>
    /// The main driver interface.
    /// Stores the "driver" instance, and is in charge of initializing/disposing of it.
    /// Also stores the website's base url and the base GoTo and IsAt functionality.
    /// </summary>
    public static class Driver
    {
        private const string HUB_URL = "http://localhost:4444/wd/hub";
        private const string PageNamespace = "MixTapeCoypuFramework.Pages.";
        public const string BaseUrl = "https://mhk-xpx.github.io/mixtape-frontend";
        public static BrowserSession Instance;
        public static SessionConfiguration SessConfiguration = new SessionConfiguration();

        /// <summary>
        /// Dictionary for selecting different browsers/drivers
        /// </summary>
        public static Dictionary<DriverTypes, Coypu.Drivers.Browser> browsersToBeTested = new Dictionary<DriverTypes, Coypu.Drivers.Browser>()
        {
            {DriverTypes.InternetExplorer, Coypu.Drivers.Browser.InternetExplorer},
            {DriverTypes.FireFox, Coypu.Drivers.Browser.Firefox},
            {DriverTypes.Chrome, Coypu.Drivers.Browser.Chrome}
        };

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

        /// <summary>
        /// Go to the requested page type and then wait for that page to load
        /// </summary>
        /// <param name="pageType">The page to go to</param>
        public static void GoTo(PageTypes pageType)
        {
            // Uses reflection to keep generic and avoid a switch statement
            Type page = Type.GetType(PageNamespace + pageType.ToString() + "Page");
            Instance.Visit(BaseUrl + page.GetField("Url").GetValue(null));
            WaitFor(pageType);
        }

        public static bool IsAt(string url)
        {
            return string.Equals(Instance.Location.AbsoluteUri, BaseUrl + url);
        }

        public static void Close()
        {
            Instance.Dispose();
        }

        /// <summary>
        /// Sleep until we get to the requested page.
        /// Sometimes the next command happens before the page is loaded.
        /// Not typically an issue with Coypu except for certain situations, but probably
        /// useful for for the base Selenium Framework, and might as well stay consistent.
        /// </summary>
        /// <param name="pageType">The type of page to wait to be loaded</param>
        public static void WaitFor(PageTypes pageType)
        {
            // Uses reflection to keep generic and avoid a switch statement
            int waitTime = 20;
            Type page = Type.GetType(PageNamespace + pageType.ToString() + "Page");
            MethodInfo pageIsAt = page.GetMethod("get_IsAt");

            while (!Convert.ToBoolean(pageIsAt.Invoke(null, null)))
            {
                Thread.Sleep(waitTime);
            }
        }

        public static void CheckLocation(PageTypes pageType)
        {
            // Uses reflection to keep generic and avoid a switch statement
            Type page = Type.GetType(PageNamespace + pageType.ToString() + "Page");
            MethodInfo pageIsAt = page.GetMethod("get_IsAt");
            MethodInfo pageGoTo = page.GetMethod("GoTo");

            if (!Convert.ToBoolean(pageIsAt.Invoke(null, null)))
            {
                pageGoTo.Invoke(null, null);
            }
        }
    }
}
