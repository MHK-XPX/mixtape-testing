using Microsoft.VisualStudio.TestTools.UnitTesting;
using MixTapeCoypuFramework.Component;
using MixTapeCoypuFramework.Pages;
using MixTapeCoypuFramework.Workflows;

namespace MixTapeTests.Components
{
    [TestClass]
    public class NavBarTest : TestBase
    {
        [TestMethod]
        public void GoHome()
        {
            LoginPage.LoginWithDefault();
            ProfilePage.GoTo();
            Navbar.GoHome();
            Assert.IsTrue(DashboardPage.IsAt);
        }

        [TestMethod]
        public void NextSong()
        {
            LoginPage.LoginWithDefault();
            //Playlist.DeleteAllPlaylists();
            PlaylistManager.CreateSimplePlaylist();
            Wait(2000);
            Playlist.ClickPlaylist(PlaylistManager.CreatedPlaylistName);
            //Youtube.ClickFirstSong();
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
