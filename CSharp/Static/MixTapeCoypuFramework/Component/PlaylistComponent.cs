using Coypu;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;

namespace MixTapeCoypuFramework.Component
{
    /// <summary>
    /// The Playlist component object, handles the Playlist sidebar functionality
    /// </summary>
    public class Playlist
    {
        private static bool IsLoaded = false;

        /// <summary>
        /// Checks to see if there are any playlists
        /// </summary>
        public static bool IsEmpty
        {
            get
            {
                try
                {
                    WaitUntilLoaded(true);
                    foreach (ElementScope playlist in Playlists.FindAllCss("li"))
                    {
                        if (playlist.Text.Trim().Equals("No Playlists :("))
                        {
                            return true;
                        }
                    }

                    return false;
                }
                catch (StaleElementReferenceException e)
                {
                    throw;
                }
            }
        }
        #region Elements
        private static ElementScope CreatePlaylistButton
        {
            get
            {
                //app-sidebar > div > div > div > img
                return Driver.Instance.FindCss("app-sidebar > div > div > div > img");
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
            WaitUntilLoaded();
            CreatePlaylistButton.Click();
        }

        public static void ClearQueue()
        {
            WaitUntilLoaded();
            ClearQueueButton.Click();
        }

        /// <summary>
        /// Checks to see if a specific playlist exists
        /// </summary>
        /// <param name="playlistName">The name of the playlist to check</param>
        /// <returns></returns>
        public static bool HasPlaylist(string playlistName)
        {
            WaitUntilLoaded();
            foreach (ElementScope playlist in Playlists.FindAllCss("li"))
            {
                if (playlist.Text.Trim().Equals(playlistName))
                {
                    return true;
                }
            }
            return false;
        }

        public static void ClickPlaylist(string playlistName)
        {
            WaitUntilLoaded();
            foreach (ElementScope playlist in Playlists.FindAllCss("li"))
            {
                if (playlist.Text.Trim().Equals(playlistName))
                {
                    playlist.Click();
                    break;
                }
            }
        }

        public static void ClickFirstPlaylist()
        {
            WaitUntilLoaded();
            Playlists.FindCss("li", Options.First).Click();
        }

        /// <summary>
        /// Deletes the specified playlist
        /// </summary>
        /// <param name="playlistName">The name of the playlist to delete</param>
        public static void DeletePlaylist(string playlistName)
        {
            WaitUntilLoaded();
            foreach (ElementScope playlist in Playlists.FindAllCss("li"))
            {
                if (playlist.Text.Trim().Equals(playlistName))
                {
                    playlist.Hover();
                    playlist.FindCss("app-mouseover-menu > div > div > img").Click();
                    return;
                }
            }
        }

        /// <summary>
        /// Deletes all playlists
        /// </summary>
        public static void DeleteAllPlaylists()
        {
            // Sometimes the hover leads to 1 of 2 exceptions, so swallow them and try again
            try
            {
                WaitUntilLoaded();
                List<ElementScope> playlists = new List<ElementScope>();

                // Get all of the playlists available and put them in a separate list
                foreach (ElementScope playlist in Playlists.FindAllCss("li"))
                {
                    if (playlist.Text.Trim().Equals("No Playlists :("))
                    {
                        // This means we don't have a playlist to delete, so return
                        return;
                    }
                    else
                    {
                        playlists.Add(playlist);
                    }
                }

                // Loop backwards and delete the playlists so that we are not confusing the parent UL
                for (int i = playlists.Count - 1; i >= 0; i--)
                {
                    playlists[i].Hover();
                    // If we can't find the mouse over, the hover failed and we will retry in the exception
                    // so skip the wait.
                    playlists[i].FindCss("app-mouseover-menu > div > div > img", Options.NoWait).Click();
                }

                // Sometimes there is a lag where it doesn't delete one of the records, or there's a refresh
                // delay with the "No Playlists :(" item appearing, so do a recursive call until empty
                DeleteAllPlaylists();
            }
            catch (StaleElementReferenceException e)
            {
                DeleteAllPlaylists();
            }
            catch (MissingHtmlException e)
            {
                DeleteAllPlaylists();
            }
        }

        /// <summary>
        /// Sleep until the Playlist Component is loaded and populated
        /// </summary>
        public static void WaitUntilLoaded(bool forceRefresh = false)
        {
            if (forceRefresh)
            {
                IsLoaded = false;
            }

            while (!IsLoaded)
            {
                try
                {
                    if (Playlists.InnerHTML.Contains("li"))
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
