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
            LoginPage.LoginAs("testuser").WithPassword("password").Login();
            ProfilePage.GoTo();
            Navbar.GoHome();
            Assert.IsTrue(DashboardPage.IsAt);
        }

        [TestMethod]
        public void NextSong()
        {
            LoginPage.LoginAs("testuser").WithPassword("password").Login();
            Playlist.ClickPlaylist("Playlist 1");
            Navbar.Next();
            Navbar.PlayPause();
            Navbar.Last();
            Navbar.Next();
            Navbar.PlayPause();
            Navbar.Last();
            Navbar.Repeat();
            Navbar.CollapseSideBar();
            Navbar.ExpandSideBar();
        }
    }
}
