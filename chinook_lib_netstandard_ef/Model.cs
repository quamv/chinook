using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace chinook_lib_netstandard_ef.Model
{
    public class ChinookDbContext : DbContext
    {
        const string data_source_string = "Data Source=chinook.db";

        public DbSet<media_type> media_types{ get; set; }
        public DbSet<genre> genres { get; set; }
        public DbSet<track> tracks { get; set; }
        public DbSet<playlist_track> playlist_tracks { get; set; }
        public DbSet<playlist> playlists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(data_source_string);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<playlist_track>()
                .HasKey(c => new { c.PlaylistId, c.TrackId }); // c.FarmerSS, c.HotelID });
        }
    }

    public class media_type
    {
        public int Media_TypeId { get; set; }
        [Required]
        public string Name { get; set; }
    }
    public class genre
    {
        public int GenreId { get; set; }
        [Required]
        public string Name { get; set; }
    }   
    public class playlist
    {
        public int PlaylistId { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<playlist_track> tracks { get; set; } = new List<playlist_track>();
    }
    public class playlist_track
    {
        [Key]
        [Column(Order=1)]
        public int PlaylistId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int TrackId { get; set; }

        [ForeignKey("TrackId")]
        public track track { get; set; }

        [ForeignKey("PlaylistId")]
        public playlist playlist { get; set; }
    }
    public class track
    {
        [Key]
        public int? TrackId { get; set; }
        public string Name { get; set; }
        //public int AlbumId;
        //public int MediaTypeId;
        //public int GenreId;
        //public string Composer;
        //public int Milliseconds;
        //public int Bytes;
        //public float UnitPrice;
    }
    //public class invoice
    //{
    //    public int InvoiceId;
    //    public int CustomerId;
    //    public DateTime InvoiceDate;
    //    public string BillingAddress;
    //    public string BillingCity;
    //    public string BillingState;
    //    public string BillingZip;
    //}
    //public class invoice_item
    //{
    //    public int InvoiceItemId;
    //    public int InvoiceId;
    //    public int TrackId;
    //    public float UnitPrice;
    //    public int Quantity;
    //}
    //public class album
    //{
    //    public int AlbumId;
    //    public string Title;
    //    public int ArtistId;
    //}
    //public class artist
    //{
    //    public int ArtistId;
    //    public string Name;
    //}
    //public class customer
    //{
    //    public int CustomerId;
    //    public string FirstName;
    //    public string LastName;
    //    public string Company;
    //    public string Address;
    //    public string City;
    //    public string State;
    //    public string Country;
    //    public string PostalCode;
    //    public string Phone;
    //    public string Fax;
    //    public string Email;
    //    public int SupportRepId;
    //}
    //public class employee
    //{
    //    public int EmployeeId;
    //    public string LastName;
    //    public string FirstName;
    //    public string Title;
    //    public int ReportsTo;
    //    public DateTime BirthDate;
    //}

}
