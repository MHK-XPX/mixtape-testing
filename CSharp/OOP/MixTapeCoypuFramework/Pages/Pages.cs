using Coypu;

namespace MixTapeCoypuFramework.Pages
{
    public class Pages
    {
        private BrowserSession browserSession;

        public Pages(Browser browser)
        {
            this.browserSession = browser.GetBrowserSession();
        }

        public LoginPage LoginPage()
        {
            return new LoginPage(browserSession);
        }
    }
}
