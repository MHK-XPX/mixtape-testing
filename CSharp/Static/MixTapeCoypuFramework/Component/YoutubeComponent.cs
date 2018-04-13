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
        public static ElementScope PlaylistName
        {
            get
            {
                return Driver.Instance.FindCss("app-youtube > div > div:nth-child(2) > div > div > div > h5");
                //#player_uid_663600372_1 > div.html5-video-container > video
                //app-youtube > div > div:nth-child(2) > h5
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

        public static void ClickSong(string playlistName)
        {
            WaitUntilLoaded();
            foreach (ElementScope playlist in Playlists.FindAllCss("li"))
            {
                if (playlist.Text.Trim().Equals(playlistName))
                {
                    playlist.Click();
                }
            }
        }

        public static void ClickFirstSong()
        {
            WaitUntilLoaded();
            //Playlists.FindCss("li", Options.First).Click();
        }

        /// <summary>
        /// Sleep until the Playlist Component is loaded and populated
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
    }
}
