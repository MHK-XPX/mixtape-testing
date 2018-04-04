using MixTapeFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MixTapeFramework.Pages;

namespace MixTapeTests
{
    [TestClass]
    public class TestBase
    {
        protected Browser browser;
        protected Pages pages;

        [TestInitialize]
        public void Setup()
        {
            browser = new Browser(Browser.BrowserTypes.Chrome);
            pages = new Pages(browser);
        }

        [TestCleanup]
        public void Cleanup()
        {
            browser.Close();
        }
    }
}
