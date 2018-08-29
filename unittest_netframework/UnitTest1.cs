using System;
using System.Collections.Generic;
using System.Linq;
using chinook_lib_netstandard_ef.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace unittest_netframework
{
    [TestClass]
    public class db_file_creation_tests
    {
        private ChinookDbContext create_db_file(string filepath)
        {
            var db = new ChinookDbContext(filepath);
            
            // file is only created on call to Migrate
            db.Database.Migrate();

            // verify the expected file was created
            if (!System.IO.File.Exists(filepath))
                Assert.Fail("File: " + filepath + " was not created as expected.");

            // verify that the tables were created
            var num_tracks = db.tracks.Count();

            return db;
        }

        private ChinookDbContext delete_and_create_db_file(string filepath)
        {
            System.IO.File.Delete(ChinookDbContext.default_filename);
            return create_db_file(ChinookDbContext.default_filename);
        }

        [TestMethod]
        public void should_create_databasefile_with_default_name()
            => delete_and_create_db_file(ChinookDbContext.default_filename);

        [TestMethod]
        public void should_create_db_with_custom_filename()
            => delete_and_create_db_file("chinook_customdb.db");

        [TestMethod]
        public void should_create_db_with_custom_filepath()
            => delete_and_create_db_file("c:\\temp\\chinook_customdb.db");

        [TestMethod]
        public void should_create_db_and_load_data()
        {
            var db = delete_and_create_db_file("chinook_customdb.db");
            add_sample_data(db);
            verify_sample_data_in_database(db);
        }

        public void add_sample_data(ChinookDbContext db)
        {
            var digital_download = new media_type() { Name = "Digital Download" };
            var rock_genre = new genre() { Name = "Rock" };
            var new_artist = new artist() { Name = "Bob Sacamano" };
            var new_album = new album() { Title = "My stuff 2018", Artist = new_artist };
            var new_track = new track() { Name = "Bad Medicine", Album = new_album, Genre = rock_genre, MediaType = digital_download };
            var new_playlist = new playlist() { PlaylistId = 0, Name = "Test playlist" };
            var ref_playlist_track = new playlist_track() { playlist = new_playlist, track = new_track };
            new_playlist.tracks.Add(ref_playlist_track);
            db.playlist_tracks.Add(ref_playlist_track);
            db.SaveChanges();
        }

        private void verify_sample_data_in_database(ChinookDbContext db)
        {
            var digital_download = db.media_types.Where(mt => mt.Name == "Digital Download").Single();
            var sample_artist = db.artists.Where(artist => artist.Name == "Bob Sacamano").Single();
            var playlists = db.playlists.ToList();
            var playlist = db.playlists.Include("tracks").FirstOrDefault();
            Assert.IsNotNull(playlist);
            Assert.IsNotNull(playlist.tracks);
            Assert.AreEqual(1, playlist.tracks.Count);
            Assert.AreEqual(1, playlist.tracks.First().TrackId);
        }
    }
}