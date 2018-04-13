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
            /* Sleep until we get to the Dashboard.
               Sometimes the next command happens before the page is loaded.
               Not typically an issue with Coypu except for certain situations, but probably
               useful for for the base Selenium Framework, and might as well stay consistent.
            */
            while (!DashboardPage.IsAt)
            {
                Thread.Sleep(20);
            }
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
            /* Sleep until we get to the Profile Page.
               Sometimes the next command happens before the page is loaded.
               Not typically an issue with Coypu except for certain situations, but probably
               useful for for the base Selenium Framework, and might as well stay consistent.
            */
            while (!ProfilePage.IsAt)
            {
                Thread.Sleep(20);
            }
        }

        public static void Logout()
        {
            WaitUntilLoaded();
            UserMenu.Click();
            Driver.Instance.ClickButton("Logout");
            /* Sleep until we get to the Login Page.
               Sometimes the next command happens before the page is loaded.
               Not typically an issue with Coypu except for certain situations, but probably
               useful for for the base Selenium Framework, and might as well stay consistent.
            */
            while (!LoginPage.IsAt)
            {
                Thread.Sleep(20);
            }
        }

        /// <summary>
        /// Sleep until the Navbar Component is Loaded.
        /// This especially helps for the slow login times that occasionally occur.
        /// </summary>
        public static void WaitUntilLoaded()
        {
            //bool isLoaded = false;

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
