﻿using Coypu;
using OpenQA.Selenium;
using System.Threading;

namespace MixTapeCoypuFramework.Component
{
    /// <summary>
    /// The Playlist component object, handles the Playlist sidebar functionality
    /// </summary>
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

        public static void WaitUntilLoaded()
        {
            bool isLoaded = false;

            while (!isLoaded)
            {
                try
                {

                    if (Playlists.InnerHTML.Contains("li"))
                    {
                        isLoaded = true;
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
