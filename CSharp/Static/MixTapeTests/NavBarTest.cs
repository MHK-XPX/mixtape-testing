using Microsoft.VisualStudio.TestTools.UnitTesting;
using MixTapeCoypuFramework.Component;
using MixTapeCoypuFramework.Pages;

namespace MixTapeTests
{
    [TestClass]
    public class NavBarTest : TestBase
    {
        [TestMethod]
        public void GoHome()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("testuser").WithPassword("password").Login();
            ProfilePage.GoTo();
            Navbar.GoHome();
            Assert.IsTrue(DashboardPage.IsAt);
        }

        [TestMethod]
        public void NextSong()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("testuser").WithPassword("password").Login();
            Wait(100);
            Playlist.ClickPlaylist("Playlist 1");
            Navbar.Next();
            Navbar.PlayPause();
            //Navbar.Last();
            //Wait(1000);
            Navbar.CollapseSideBar();
            //Wait(3000);
            Navbar.ExpandSideBar();
            Wait(10000);
        }
    }
}
