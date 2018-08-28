using System;
using System.Collections.Generic;
using System.Linq;
using chinook_lib_netstandard_ef.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace unittest_netframework
{
    public class SampleData
    {
        List<track> tracks = new List<track>() { new track() { Name = "Bad Medicine" } };
    }

    [TestClass]
    public class UnitTest1
    {
        private void create_db_if_not_exists()
        {
            var db = new ChinookDbContext();
            db.Database.Migrate();
        }

        [TestInitialize]
        public void test_initialize()
        {
            //create_db_if_not_exists();
        }

        private ChinookDbContext create_db_file(string filepath)
        {
            System.IO.File.Delete(filepath); // ChinookDbContext.default_filename);
            var db = new ChinookDbContext(filepath);
            db.Database.Migrate();
            // verify the expected file was created
            if (!System.IO.File.Exists(filepath))
                Assert.Fail("File: " + filepath + " was not created as expected.");
            // verify that the tables were created
            var num_tracks = db.tracks.Count();
            add_sample_data(db);

            return db;
        }

        [TestMethod]
        public void should_create_databasefile_with_default_name()
        {
            create_db_file(ChinookDbContext.default_filename);
        }

        [TestMethod]
        public void should_create_db_with_custom_filename()
        {
            create_db_file("chinook_customdb.db");
        }

        [TestMethod]
        public void should_create_db_and_load_data()
        {
            var db = create_db_file("chinook_customdb.db");
            add_sample_data(db);
            verify_sample_data_in_database(db);
        }

        public void add_sample_data(ChinookDbContext db)
        {
            var new_track = new track() { TrackId = null, Name = "Bad Medicine" };
            db.tracks.Add(new_track);
            var new_playlist = new playlist() { PlaylistId = 0, Name = "Test playlist" };
            db.playlists.Add(new_playlist);
            var ref_playlist_track = new playlist_track() { playlist = new_playlist, track = new_track };
            new_playlist.tracks.Add(ref_playlist_track);
            db.SaveChanges();
        }

        private void verify_sample_data_in_database(ChinookDbContext db)
        {
            var playlist = db.playlists.Include("tracks").FirstOrDefault();
            Assert.IsNotNull(playlist);
            Assert.IsNotNull(playlist.tracks);
            Assert.AreEqual(1, playlist.tracks.Count);
            Assert.AreEqual(1, playlist.tracks.First().TrackId);
        }
    }
}