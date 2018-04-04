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
            Wait(3000);
            Assert.AreEqual(Navbar.User, "testuser");
            Playlist.ClickPlaylist("Playlist 1");
            Wait(1000);
            Navbar.Next();
            Wait(1000);
            Navbar.PlayPause();
            Wait(1000);
            Navbar.PlayPause();
            Wait(1000);
            Navbar.Last();
            Wait(1000);
            Navbar.CollapseSideBar();
            Wait(1000);
            Navbar.ExpandSideBar();
            Wait(1000);
            Navbar.Repeat();
            Wait(1000);
        }
    }
}
