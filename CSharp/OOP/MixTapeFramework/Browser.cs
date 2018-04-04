using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;

namespace MixTapeFramework
{
    public class Browser
    {

        private const string HUB_URL = "http://localhost:4444/wd/hub";
	    private IWebDriver driver;

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

        public enum BrowserTypes
        {
            Chrome,
            FireFox,
            InternetExplorer
        }

        public IWebDriver GetDriver()
        {
            return this.driver;
        }

        public Browser(BrowserTypes browserType)
        {
            //WebDriverManager.chromedriver().setup();
            driver = new ChromeDriver();
            //ChromeOptions options = new ChromeOptions();
		    //driver = new RemoteWebDriver(new Uri(HUB_URL), options);
	    }

        public void GoTo(String url)
        {
            driver.Url = url;
            driver.Navigate();
        }

        public void Close()
        {
            driver.Close();
        }
    }
}
