using Coypu;
using OpenQA.Selenium;
using System.Threading;

namespace MixTapeCoypuFramework.Component
{
    /// <summary>
    /// The Navbar component object, handles the Navbar functionality
    /// </summary>
    public static class Navbar
    {
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
            Driver.Instance.ClickButton("<<");
        }

        public static void ExpandSideBar()
        {
            Driver.Instance.ClickButton(">>");
        }

        public static void GoHome()
        {
            Driver.Instance.FindSection("Mi").Click();
        }

        public static void Search(string query)
        {
            Driver.Instance.FillIn("Search").With(query + Keys.Return);
        }

        public static void Last()
        {
            Driver.Instance.FindId("lastSongButton").Click();
        }

        public static void PlayPause()
        {
            Driver.Instance.FindId("playPauseButton").Click();
        }

        public static void Next()
        {
            Driver.Instance.FindId("nextSongButton").Click();
        }

        public static void Repeat()
        {
            Driver.Instance.FindId("repeatButton").Click();
        }

        public static void ShowPage()
        {
            Driver.Instance.ClickButton("Show Page");
        }

        public static void ShowPlaylist()
        {
            Driver.Instance.ClickButton("Show Playlist");
        }

        public static void Profile()
        {
            UserMenu.Click();
            Driver.Instance.ClickButton("Profile");
        }

        public static void Logout()
        {
            UserMenu.Click();
            Driver.Instance.ClickButton("Logout");
        }

        /// <summary>
        /// Sleep until the Navbar Component is Loaded.
        /// This especially helps for the slow login times that occasionally occur.
        /// </summary>
        public static void WaitUntilLoaded()
        {
            // Make sure we are at the Dashboard Page before we check if the component is loaded
            // This check is for the case that the login fails
            bool isLoaded = !Pages.DashboardPage.IsAt;

            while (!isLoaded)
            {
                try
                {
                    if (Driver.Instance.FindField("Search").Id != null)
                    {
                        isLoaded = true;
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
