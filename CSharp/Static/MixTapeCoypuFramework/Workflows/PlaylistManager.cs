﻿using Coypu;
using OpenQA.Selenium;
using System.Threading;
using MixTapeCoypuFramework.Component;

namespace MixTapeCoypuFramework.Workflows
{
    public class PlaylistManager
    {
        public static string CreatedPlaylistName = "";
        public static void CreateSimplePlaylist()
        {
            Playlist.CreatePlaylist();
            CreatedPlaylistName = Youtube.PlaylistName.Text;
            Playlist.ClearQueue();
            //Results.ClickFirstSong();
            Thread.Sleep(100);
            Results.AddSong("The Thunder Rolls").ToPlaylist(CreatedPlaylistName);
            Results.AddSong("Kyoto").ToPlaylist(CreatedPlaylistName);
            //Youtube.PlaylistName.Click();
            /*
             app-youtube > div > div:nth-child(2) > div > div > div > h5
             app-youtube > div > div:nth-child(2) > div > div > ol:nth-child(2) > li
             */
        }
    }
}
