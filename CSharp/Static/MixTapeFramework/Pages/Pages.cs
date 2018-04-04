using OpenQA.Selenium;

namespace MixTapeFramework.Pages
{
    public class Pages
    {
        private IWebDriver driver;

        public Pages(Browser browser)
        {
            this.driver = browser.GetDriver();
        }

        public LoginPage LoginPage ()
        {
            return new LoginPage(driver);
        }
    }
}
