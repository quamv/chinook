using Microsoft.EntityFrameworkCore.Migrations;

namespace chinook_lib_netstandard_ef.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "artists",
                columns: table => new
                {
                    ArtistId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artists", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "media_types",
                columns: table => new
                {
                    Media_TypeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_media_types", x => x.Media_TypeId);
                });

            migrationBuilder.CreateTable(
                name: "playlists",
                columns: table => new
                {
                    PlaylistId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playlists", x => x.PlaylistId);
                });

            migrationBuilder.CreateTable(
                name: "albums",
                columns: table => new
                {
                    AlbumId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    ArtistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_albums", x => x.AlbumId);
                    table.ForeignKey(
                        name: "FK_albums_artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tracks",
                columns: table => new
                {
                    TrackId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    AlbumId = table.Column<int>(nullable: false),
                    MediaTypeId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false),
                    Composer = table.Column<string>(nullable: true),
                    Milliseconds = table.Column<int>(nullable: false),
                    Bytes = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tracks", x => x.TrackId);
                    table.ForeignKey(
                        name: "FK_tracks_albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "albums",
                        principalColumn: "AlbumId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tracks_genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tracks_media_types_MediaTypeId",
                        column: x => x.MediaTypeId,
                        principalTable: "media_types",
                        principalColumn: "Media_TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "playlist_tracks",
                columns: table => new
                {
                    PlaylistId = table.Column<int>(nullable: false),
                    TrackId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playlist_tracks", x => new { x.PlaylistId, x.TrackId });
                    table.ForeignKey(
                        name: "FK_playlist_tracks_playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "playlists",
                        principalColumn: "PlaylistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_playlist_tracks_tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "tracks",
                        principalColumn: "TrackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_albums_ArtistId",
                table: "albums",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_artists_Name",
                table: "artists",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_genres_Name",
                table: "genres",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_media_types_Name",
                table: "media_types",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_playlist_tracks_TrackId",
                table: "playlist_tracks",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_playlists_Name",
                table: "playlists",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tracks_AlbumId",
                table: "tracks",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_tracks_GenreId",
                table: "tracks",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_tracks_MediaTypeId",
                table: "tracks",
                column: "MediaTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "playlist_tracks");

            migrationBuilder.DropTable(
                name: "playlists");

            migrationBuilder.DropTable(
                name: "tracks");

            migrationBuilder.DropTable(
                name: "albums");

            migrationBuilder.DropTable(
                name: "genres");

            migrationBuilder.DropTable(
                name: "media_types");

            migrationBuilder.DropTable(
                name: "artists");
        }
    }
}
