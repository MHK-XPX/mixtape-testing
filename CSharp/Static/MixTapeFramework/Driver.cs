using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;

namespace MixTapeFramework
{
    public static class Driver
    {

        private const string HUB_URL = "http://localhost:4444/wd/hub";
        public const string BaseUrl = "https://mhk-xpx.github.io/mixtape-frontend/";
        public static IWebDriver Instance;

        //public static Dictionary<BrowserTypes, DriverOptions> browsersToBeTested = new Dictionary<BrowserTypes, DriverOptions>()
        //{
        //    {BrowserTypes.InternetExplorer, new InternetExplorerOptions()},
        //    {BrowserTypes.FireFox, new FirefoxOptions()},
        //    {BrowserTypes.Chrome, new ChromeOptions()}
        //};

        //public static Dictionary<BrowserTypes, RemoteWebDriver> browsersToBeTested = new Dictionary<BrowserTypes, IWebDriver>()
        //{
        //    {BrowserTypes.InternetExplorer, InternetExplorerDriver},
        //    {BrowserTypes.FireFox, FirefoxDriver},
        //    {BrowserTypes.Chrome, ChromeDriver}
        //};

        public enum DriverTypes
        {
            Chrome,
            FireFox,
            InternetExplorer
        }

        public static void Initialize(DriverTypes driverType)
        {
            switch (driverType)
            {
                case DriverTypes.Chrome:
                    Instance = new ChromeDriver();
                    break;
                case DriverTypes.FireFox:
                    Instance = new FirefoxDriver();
                    break;
                case DriverTypes.InternetExplorer:
                    Instance = new InternetExplorerDriver();
                    break;
                default:
                    Instance = new ChromeDriver();
                    break;
            }
            //ChromeOptions options = new ChromeOptions();
		    //driver = new RemoteWebDriver(new Uri(HUB_URL), options);
	    }

        public static void GoTo(string url)
        {
            Instance.Url = url;
            Instance.Navigate();
        }

        public static bool IsAt(string url)
        {
            return string.Equals(Instance.Url, url);
        }

        public static void Close()
        {
            Instance.Close();
        }
    }
}
