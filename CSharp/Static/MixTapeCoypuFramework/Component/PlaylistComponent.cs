using Coypu;
using OpenQA.Selenium;

namespace MixTapeCoypuFramework.Component
{
    public static class Playlist
    {
        #region Elements
        private static ElementScope CreatePlaylistButton
        {
            get
            {
                return Driver.Instance.FindButton("Create Playlist");
            }
        }

        private static ElementScope ClearQueueButton
        {
            get
            {
                return Driver.Instance.FindButton("Clear Queue");
            }
        }

        private static ElementScope Playlists
        {
            get
            {
                return Driver.Instance.FindCss("app-sidebar > div > div > ul");
            }
        }
        #endregion

        public static void CreatePlaylist()
        {
            CreatePlaylistButton.Click();
        }

        public static void ClearQueue()
        {
            ClearQueueButton.Click();
        }

        public static void ClickPlaylist(string playlistName)
        {
            //Playlists.FindCss("li", Options.First).Click();
            //Playlists.FindLink("*Playlist 1*").Click();
            foreach (ElementScope playlist in Playlists.FindAllCss("li"))
            {
                if (playlist.Text.Trim().Equals(playlistName))
                {
                    playlist.Click();
                }
            }
        }

        public static void ClickFirstPlaylist()
        {
            Playlists.FindCss("li", Options.First).Click();
        }
    }
}
