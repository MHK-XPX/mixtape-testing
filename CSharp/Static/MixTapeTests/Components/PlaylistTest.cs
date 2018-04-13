using Microsoft.VisualStudio.TestTools.UnitTesting;
using MixTapeCoypuFramework.Component;
using MixTapeCoypuFramework.Pages;
using MixTapeCoypuFramework.Workflows;

namespace MixTapeTests.Components
{
    [TestClass]
    public class PlaylistTest : TestBase
    {
        [TestMethod]
        public void CreatePlaylist()
        {
            LoginPage.LoginWithDefault();
            PlaylistManager.CreateSimplePlaylist();
            Assert.IsTrue(Playlist.HasPlaylist(PlaylistManager.CreatedPlaylistName));
        }

        [TestMethod]
        public void DeletePlaylist()
        {
            LoginPage.LoginWithDefault();
            PlaylistManager.CreateSimplePlaylist();
            Assert.IsTrue(Playlist.HasPlaylist(PlaylistManager.CreatedPlaylistName));
            Playlist.DeletePlaylist(PlaylistManager.CreatedPlaylistName);
            Assert.IsFalse(Playlist.HasPlaylist(PlaylistManager.CreatedPlaylistName));
        }

        [TestMethod]
        public void DeleteAllPlaylists()
        {
            LoginPage.LoginWithDefault();
            PlaylistManager.CreateSimplePlaylist();
            PlaylistManager.CreateSimplePlaylist();
            PlaylistManager.CreateSimplePlaylist();
            PlaylistManager.CreateSimplePlaylist();
            //Assert.IsFalse(Playlist.IsEmpty);
            Playlist.DeleteAllPlaylists();
            Assert.IsTrue(Playlist.IsEmpty);
        }
    }
}
