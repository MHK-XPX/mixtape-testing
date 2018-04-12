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
