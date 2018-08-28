using System;
using chinook_lib_netstandard_ef.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace unittest_netframework
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var db = new ChinookDbContext();
            var playlist = db.playlists.Include("tracks").FirstOrDefault();

            if (playlist == null)
            {
                var new_track = new track() { TrackId = null, Name = "Bad Medicine" };
                db.tracks.Add(new_track);

                var new_playlist = new playlist() { PlaylistId = 0, Name = "Test playlist" };
                db.playlists.Add(new_playlist);

                var ref_playlist_track = new playlist_track() { playlist = new_playlist, track = new_track };
                new_playlist.tracks.Add(ref_playlist_track);
                db.SaveChanges();

                Tracks.ItemsSource = new_playlist.tracks;
            }
            else
            {
                Tracks.ItemsSource = playlist.tracks; // db.playlists.Include("tracks").ToList();
            }

        }
    }
