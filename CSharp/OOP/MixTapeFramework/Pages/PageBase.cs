using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixTapeFramework.Pages
{
    public abstract class PageBase
    {
        protected IWebDriver driver;
        protected const string base_url = "https://mhk-xpx.github.io/mixtape-frontend/";

        protected PageBase(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string Title
        {
            get
            {
                return driver.Title;
            }
        }

        public abstract string Url
        {
            get;
        }

        public bool IsAt
        {
            get
            {
                return string.Equals(driver.Url, Url);
            }
        }
    }
}
