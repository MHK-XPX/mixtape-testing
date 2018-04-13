using Coypu;
using MixTapeCoypuFramework.Pages;
using OpenQA.Selenium;
using System.Threading;

namespace MixTapeCoypuFramework.Component
{
    /// <summary>
    /// The Navbar component object, handles the Navbar functionality
    /// </summary>
    public static class Navbar
    {
        private static bool IsLoaded = false;

        #region Elements
        private static ElementScope UserMenu
        {
            get
            {
                //return Driver.Instance.FindCss("nav-item dropdown");
                return Driver.Instance.FindXPath("//div[@class = 'nav-item dropdown']");
            }
        }

        public static string User
        {
            get
            {
                return Driver.Instance.FindCss("#navbarSupportedContent > div.ml-auto.no-padding > h6").Text;
            }
        }
        #endregion
        
        public static void CollapseSideBar()
        {
            WaitUntilLoaded();
            Driver.Instance.ClickButton("<<");
        }

        public static void ExpandSideBar()
        {
            WaitUntilLoaded();
            Driver.Instance.ClickButton(">>");
        }

        public static void GoHome()
        {
            WaitUntilLoaded();
            Driver.Instance.FindSection("Mi").Click();
            Driver.WaitFor(PageTypes.Dashboard);
        }

        public static void Search(string query)
        {
            WaitUntilLoaded();
            Driver.Instance.FillIn("Search").With(query + Keys.Return);
        }

        public static void Last()
        {
            WaitUntilLoaded();
            Driver.Instance.FindId("lastSongButton").Click();
        }

        public static void PlayPause()
        {
            WaitUntilLoaded();
            Driver.Instance.FindId("playPauseButton").Click();
        }

        public static void Next()
        {
            WaitUntilLoaded();
            Driver.Instance.FindId("nextSongButton").Click();
        }

        public static void Repeat()
        {
            WaitUntilLoaded();
            Driver.Instance.FindId("repeatButton").Click();
        }

        public static void ShowPage()
        {
            WaitUntilLoaded();
            Driver.Instance.ClickButton("Show Page");
        }

        public static void ShowPlaylist()
        {
            WaitUntilLoaded();
            Driver.Instance.ClickButton("Show Playlist");
        }

        public static void Profile()
        {
            WaitUntilLoaded();
            UserMenu.Click();
            Driver.Instance.ClickButton("Profile");
            Driver.WaitFor(PageTypes.Profile);
        }

        public static void Logout()
        {
            WaitUntilLoaded();
            UserMenu.Click();
            Driver.Instance.ClickButton("Logout");
            Driver.WaitFor(PageTypes.Login);
        }

        /// <summary>
        /// Sleep until the Navbar Component is Loaded.
        /// This especially helps for the slow login times that occasionally occur.
        /// </summary>
        public static void WaitUntilLoaded()
        {
            while (!IsLoaded)
            {
                try
                {
                    if (Driver.Instance.FindField("Search").Id != null)
                    {
                        IsLoaded = true;
                        break;
                    }
                }
                catch (Coypu.MissingHtmlException e)
                {
                    Thread.Sleep(25);
                }
            }
        }
    }
}
