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
        public DbSet<media_type> media_types { get; set; }
        public DbSet<genre> genres { get; set; }
        public DbSet<track> tracks { get; set; }
        public DbSet<artist> artists { get; set; }
        public DbSet<album> albums { get; set; }
        public DbSet<playlist_track> playlist_tracks { get; set; }
        public DbSet<playlist> playlists { get; set; }

        public const string default_filename = "chinook.db";
        string _dsn = null;

        public ChinookDbContext(string db_filename) 
            => _dsn = "Data Source=" + db_filename;
        
        public ChinookDbContext() 
            : this(default_filename) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(_dsn);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<media_type>().HasIndex(o => new { o.Name }).IsUnique();
            modelBuilder.Entity<genre>().HasIndex(o => new { o.Name }).IsUnique();
            modelBuilder.Entity<playlist>().HasIndex(o => new { o.Name }).IsUnique();
            modelBuilder.Entity<artist>().HasIndex(o => new { o.Name }).IsUnique();
            modelBuilder.Entity<playlist_track>().HasKey(o => new { o.PlaylistId, o.TrackId });
        }
    }

    public class media_type
    {
        public int Media_TypeId { get; set; }
        [Required] public string Name { get; set; }
    }
    public class genre
    {
        public int GenreId { get; set; }
        [Required] public string Name { get; set; }
    }
    public class playlist
    {
        public int PlaylistId { get; set; }
        [Required] public string Name { get; set; }
        public ICollection<playlist_track> tracks { get; set; } = new List<playlist_track>();
    }
    public class playlist_track
    {
        [Key] [Column(Order = 1)] public int PlaylistId { get; set; }
        [Key] [Column(Order = 2)] public int TrackId { get; set; }
        [ForeignKey("TrackId")] public track track { get; set; }
        [ForeignKey("PlaylistId")] public playlist playlist { get; set; }
    }
    public class track
    {
        public int TrackId { get; set; }
        public string Name { get; set; }
        public int AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int GenreId { get; set; }
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public int Bytes { get; set; }
        public float UnitPrice { get; set; }
        [ForeignKey("AlbumId")] public album Album { get; set; }
        [ForeignKey("MediaTypeId")] public media_type MediaType { get; set; }
        [ForeignKey("GenreId")] public genre Genre { get; set; }
    }
    public class album
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        [ForeignKey("ArtistId")] public artist Artist { get; set; }
    }
    public class artist
    {
        public int ArtistId { get; set; }
        [Required] public string Name { get; set; }
    }
    public class invoice
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingZip { get; set; }
        public ICollection<invoice_item> InvoiceItems { get; set; }
        [ForeignKey("CustomerId")] public customer Customer { get; set; }
    }
    public class invoice_item
    {
        public int InvoiceItemId { get; set; }
        public int InvoiceId { get; set; }
        public int TrackId { get; set; }
        public float UnitPrice { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("InvoiceId")] public invoice Invoice { get; set; }
    }
    public class customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int SupportRepId { get; set; }
    }
    public class employee
    {
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public int ReportsTo { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
