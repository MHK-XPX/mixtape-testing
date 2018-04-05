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
            switch (browserType)
            {
                case BrowserTypes.Chrome:
                    driver = new ChromeDriver();
                    break;
                case BrowserTypes.FireFox:
                    driver = new FirefoxDriver();
                    break;
                case BrowserTypes.InternetExplorer:
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }
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
