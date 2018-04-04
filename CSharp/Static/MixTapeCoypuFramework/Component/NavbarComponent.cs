using Coypu;

namespace MixTapeCoypuFramework.Component
{
    public static class NavbarComponent
    {
        #region Elements
        public static ElementScope SearchBar
        {
            get
            {
                return Driver.Instance.FindField("Search");
            }
        }

        public static ElementScope HomeLink
        {
            get
            {
                return Driver.Instance.FindSection("Mi");
            }
        }

        public static ElementScope UserMenu
        {
            get
            {
                //return Driver.Instance.FindCss("nav-item dropdown");
                return Driver.Instance.FindXPath("//div[@class = 'nav-item dropdown']");
            }
        }

        public static ElementScope ProfileButton
        {
            get
            {
                return Driver.Instance.FindButton("Profile");
            }
        }

        public static ElementScope LogoutButton
        {
            get
            {
                return Driver.Instance.FindButton("Logout");
            }
        }
        #endregion

        public static void GoHome()
        {
            HomeLink.Click();
        }

        public static void Logout()
        {
            UserMenu.Click();
            LogoutButton.Click();
        }
    }
}
