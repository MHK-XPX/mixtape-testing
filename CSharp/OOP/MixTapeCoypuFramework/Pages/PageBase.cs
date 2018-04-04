using Coypu;

namespace MixTapeCoypuFramework.Pages
{
    public abstract class PageBase
    {
        protected BrowserSession browserSession;
        protected const string base_url = "https://mhk-xpx.github.io/mixtape-frontend/";

        protected PageBase(BrowserSession browserSession)
        {
            this.browserSession = browserSession;
        }

        public string Title
        {
            get
            {
                return browserSession.Title;
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
                return string.Equals(browserSession.Location, Url);
            }
        }
    }
}
