using Coypu;
using OpenQA.Selenium;
using System.Threading;

namespace MixTapeCoypuFramework.Component
{
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
            Driver.Instance.FindCss("#navbarSupportedContent > div:nth-child(2) > img:nth-child(1)").Click();
        }

        public static void PlayPause()
        {
            Driver.Instance.FindCss("#navbarSupportedContent > div:nth-child(2) > img:nth-child(2)").Click();
        }

        public static void Next()
        {
            Driver.Instance.FindCss("#navbarSupportedContent > div:nth-child(2) > img:nth-child(3)").Click();
        }

        public static void Repeat()
        {
            //#navbarSupportedContent > div:nth-child(2) > img:nth-child(4)
            Driver.Instance.FindXPath("//*[@id='navbarSupportedContent']/div[1]/img[4]").Click();
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

        public static void WaitUntillLoaded()
        {
            bool isLoaded = false;

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
