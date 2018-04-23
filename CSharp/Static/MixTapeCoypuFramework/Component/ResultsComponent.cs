using Coypu;
using OpenQA.Selenium;
using System.Threading;

namespace MixTapeCoypuFramework.Component
{
    /// <summary>
    /// The Playlist component object, handles the Playlist sidebar functionality
    /// </summary>
    public class Results
    {
        private static bool IsLoaded = false;
        #region Elements
        private static ElementScope Songs
        {
            get
            {
                //#ngb-tab-2-panel
                //home > div > ngb-tabset > div > div
                return Driver.Instance.FindCss("home > div > ngb-tabset > div > div > ul");
            }
        }
        #endregion

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

        public static void ClickFirstSong()
        {
            WaitUntilLoaded();
            Songs.FindCss("li", Options.First).Click();
            //#ngb-tab-9-panel > div:nth-child(2) > ul:nth-child(1) > li
            //#ngb-tab-8-panel > ul > li:nth-child(2)
        }

        private static void AddSongToPlaylist(string songName, string playlistName)
        {
            WaitUntilLoaded();
            foreach (ElementScope song in Songs.FindAllCss("li"))
            {
                if (song.Text.Trim().Contains(songName))
                {
                    // Scroll to the song since the mouseover won't work if the song is not visible
                    // Note: we are using false to align the bottoms, otherwise the song stays behind the navbar
                    Driver.Instance.ExecuteScript("arguments[0].scrollIntoView(false);", song);
                    song.Hover();
                    var dropup = song.FindCss("app-mouseover-menu > div > div.dropup");
                    dropup.FindCss("img").Click();
                    foreach (ElementScope pl in dropup.FindAllCss("li"))
                    {
                        if (pl.Text.Trim().Contains(playlistName))
                        {
                            pl.Click();
                        }
                    }
                    //song.FindCss("app-mouseover-menu > div > div.show.dropup > div > ul").ClickLink(playlistName);
                    ////app-mouseover-menu > div > div.show.dropup > div > ul
                }
            }
            //#ngb-tab-10-panel > ul > li:nth-child(1) > app-mouseover-menu > div > div.dropup > img
        }

        public static ResultsCommand AddSong(string songName)
        {
            return new ResultsCommand(songName);
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

        /// <summary>
        /// A command class to allow chaining for the "LoginAs" method
        /// </summary>
        public class ResultsCommand
        {
            private readonly string songName;

            public ResultsCommand(string songName)
            {
                this.songName = songName;
            }

            public void ToPlaylist(string playlistName)
            {
                Results.AddSongToPlaylist(songName, playlistName);
            }
        }
    }
}
