using Coypu;
using OpenQA.Selenium;
using System.Threading;

namespace MixTapeCoypuFramework.Component
{
    /// <summary>
    /// The Playlist component object, handles the Playlist sidebar functionality
    /// </summary>
    public class Youtube
    {
        private static bool IsLoaded = false;
        #region Elements
        #region Player
        private static ElementScope VideoPlayer
        {
            get
            {
                // Get the iframe driver, then find the player div
                return Driver.Instance.FindCss("youtube-player > iframe").FindCss("#player > div.html5-video-player", Options.Invisible);
            }
        }

        private static ElementScope YouTubeTitle
        {
            get
            {
                // Hover over the player to make the text come up, then grab it
                VideoPlayer.Hover();
                return VideoPlayer.FindCss("div.ytp-chrome-top.ytp-share-button-visible > div.ytp-title", Options.Invisible);
            }
        }

        private static ElementScope Mute
        {
            get
            {
                // Hover over the player to make the text come up, then grab it
                VideoPlayer.Hover();
                return VideoPlayer.FindCss("button.ytp-mute-button.ytp-button", Options.Invisible);
            }
        }

        private static ElementScope CC
        {
            get
            {
                // Hover over the player to make the text come up, then grab it
                VideoPlayer.Hover();
                return VideoPlayer.FindCss("button.ytp-subtitles-button.ytp-button", Options.Invisible);
            }
        }

        private static ElementScope PlayerSettings
        {
            get
            {
                // Hover over the player to make the text come up, then grab it
                VideoPlayer.Hover();
                return VideoPlayer.FindCss("button.ytp-settings-button.ytp-button", Options.Invisible);
                // div.ytp-right-controls > button.ytp-button.ytp-settings-button.ytp-hd-quality-badge
            }
        }

        private static ElementScope YouTubeLink
        {
            get
            {
                // Hover over the player to make the text come up, then grab it
                VideoPlayer.Hover();
                return VideoPlayer.FindLink("Watch on youtube.com", Options.Invisible);
            }
        }

        private static ElementScope FullScreen
        {
            get
            {
                // Hover over the player to make the text come up, then grab it
                VideoPlayer.Hover();
                //#player_uid_895096664_1 > div.ytp-chrome-bottom > div.ytp-chrome-controls > div.ytp-right-controls > button.ytp-fullscreen-button.ytp-button
                return VideoPlayer.FindCss("button.ytp-fullscreen-button.ytp-button", Options.Invisible);
            }
        }
        #endregion
        #region Playlist
        public static ElementScope PlaylistName
        {
            get
            {
                return Driver.Instance.FindCss("app-youtube > div > div:nth-child(2) > div > div > div > h5");
            }
        }

        public static ElementScope Save
        {
            get
            {
                return Driver.Instance.FindCss("app-youtube > div > div:nth-child(2) > div > div > div > h5");
            }
        }

        private static ElementScope Songs
        {
            get
            {
                //return Driver.Instance.FindCss("app-youtube > div.playlist-container.playlist-song-list > div");
                return Driver.Instance.FindCss("app-youtube > div > div:nth-child(2) > div > div");
            }
        }

        private static int SongCount
        {
            get
            {
                int songCount = 0;
                WaitUntilLoaded();
                foreach (ElementScope song in Songs.FindAllCss("li"))
                {
                    songCount++;
                }

                return songCount;
            }
        }
        #endregion
        #endregion

        public static string PlayerSongTitle => YouTubeTitle.Text;

        #region Utility
        /// <summary>
        /// Opens the song at YouTube.com in a new tab
        /// </summary>
        public static void GoToYouTube()
        {
            YouTubeLink.Click();
        }

        public static void ToggleMute()
        {
            Mute.Click();
        }

        public static void ToggleCC()
        {
            // Some videos don't have CC available
            try
            {
                CC.Click();
            }
            catch (ElementNotVisibleException e)
            {
                
            }
        }

        public static void ToggleSettingsMenu()
        {
            PlayerSettings.Click();
        }

        /// <summary>
        /// Make the video player go full screen
        /// </summary>
        public static void GoFullScreen()
        {
            FullScreen.Click();
        }

        /// <summary>
        /// Exit the full screen mode, doesn't currently work
        /// </summary>
        public static void ExitFullScreen()
        {
            FullScreen.Click();
            VideoPlayer.SendKeys(Keys.Escape);
        }
        #endregion
        #region Utility
        /// <summary>
        /// Rename the playlist to the given name
        /// </summary>
        /// <param name="newName">The new playlist name</param>
        public static void RenamePlaylist(string newName)
        {
            PlaylistName.Click();
            Driver.Instance.FillIn("Playlist Name").With(newName);
            Driver.Instance.ClickButton("Save");
        }

        /// <summary>
        /// Click the song with the given name
        /// </summary>
        /// <param name="songName">The name of the song to click</param>
        public static void ClickSong(string songName)
        {
            WaitUntilLoaded();
            foreach (ElementScope song in Songs.FindAllCss("li"))
            {
                if (song.Text.Trim().Contains(songName))
                {
                    song.Click();
                }
            }
        }

        /// <summary>
        /// Click the song at the given index
        /// </summary>
        /// <param name="index">The index of the song to click</param>
        public static void ClickSong(int index)
        {
            WaitUntilLoaded();
            foreach (ElementScope song in Songs.FindAllCss("li"))
            {
                if (song.Text.Trim().StartsWith(index.ToString() + "."))
                {
                    song.Click();
                }
            }
        }

        /// <summary>
        /// Click the first song in the playlist
        /// </summary>
        public static void ClickFirstSong()
        {
            WaitUntilLoaded();
            Songs.FindCss("ol", Options.First).Click();
        }

        /// <summary>
        /// Click the last song in the playlist
        /// </summary>
        public static void ClickLastSong()
        {
            ClickSong(SongCount);
        }
        #endregion
        #region Utility
        /// <summary>
        /// Sleep until the component is loaded and populated
        /// </summary>
        public static void WaitUntilLoaded()
        {
            //bool isLoaded = false;

            while (!IsLoaded)
            {
                try
                {
                    if (true)
                    {
                        IsLoaded = true;
                        break;
                    }
                    else
                    {
                        Thread.Sleep(25);
                    }
                }
                catch (Coypu.MissingHtmlException e)
                {
                    Thread.Sleep(25);
                }
            }
        }
        #endregion
    }
}
