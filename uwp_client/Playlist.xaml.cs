using chinook_lib_netstandard_ef.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace uwp_client
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Playlist : Page
    {
        public Playlist()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new ChinookDbContext())
            {
                var playlist = db.playlists.Include("tracks").FirstOrDefault();

                if (playlist == null)
                {
                    var new_track = new track() { TrackId = null, Name = "Bad Medicine" };
                    db.tracks.Add(new_track);
                    db.SaveChanges();

                    var new_playlist = new playlist() { PlaylistId = 0, Name = "Test playlist" };
                    db.playlists.Add(new_playlist);
                    db.SaveChanges();

                    var new_playlist_track = new playlist_track() { PlaylistId = new_playlist.PlaylistId, TrackId = (int)new_track.TrackId };
                    new_playlist.tracks.Add(new_playlist_track);
                    //db.playlists.Add(new_playlist);
                    db.SaveChanges();

                    Tracks.ItemsSource = new_playlist.tracks;
                }
                else
                {
                    Tracks.ItemsSource = playlist.tracks; // db.playlists.Include("tracks").ToList();
                }
            }
        }

        private void Go_Click(object sender, RoutedEventArgs e)
        {
            //using (var db = new ChinookDbContext())
            //{
            //    var dvd_media_type = new media_type { Name = NewMediaType.Text };
            //    db.media_types.Add(dvd_media_type);
            //    db.SaveChanges();

            //    Tracks.ItemsSource = db.media_types.ToList();
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
