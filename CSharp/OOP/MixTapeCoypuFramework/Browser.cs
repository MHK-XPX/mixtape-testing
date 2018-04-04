using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using Coypu;
using System.Collections.Generic;

namespace MixTapeCoypuFramework
{
    public class Browser
    {
        public static SessionConfiguration SessConfiguration = new SessionConfiguration();
        private const string HUB_URL = "http://localhost:4444/wd/hub";
        protected static BrowserSession browser = null;
        protected static BrowserWindow CurrentBrowser = null;

        public static Dictionary<BrowserTypes, Coypu.Drivers.Browser> browsersToBeTested = new Dictionary<BrowserTypes, Coypu.Drivers.Browser>()
        {
            {BrowserTypes.InternetExplorer, Coypu.Drivers.Browser.InternetExplorer},
            {BrowserTypes.FireFox, Coypu.Drivers.Browser.Firefox},
            {BrowserTypes.Chrome, Coypu.Drivers.Browser.Chrome}
        };
        
        public enum BrowserTypes
        {
            Chrome,
            FireFox,
            InternetExplorer
        }

        public BrowserSession GetBrowserSession()
        {
            return browser;
        }

        public Browser(BrowserTypes browserType)
        {
            ////WebDriverManager.chromedriver().setup();
            //ChromeOptions options = new ChromeOptions();
            ////// this.driver = new ChromeDriver(options);
            //this.driver = new RemoteWebDriver(new Uri(HUB_URL), options);
            SessConfiguration.Browser = browsersToBeTested[browserType];
            SessConfiguration.Timeout = TimeSpan.FromSeconds(Constants.MaxTimeOut);
            SessConfiguration.RetryInterval = TimeSpan.FromSeconds(0.5);
            browser = new BrowserSession(SessConfiguration);
            ((RemoteWebDriver)browser.Native).Manage().Window.Maximize();
        }

        public void GoTo(String url)
        {
            browser.Visit(url);
        }

        public void Close()
        {
            browser.Dispose();
        }
    }
}
