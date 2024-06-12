using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace stone_music_backend.Migrations
{
    /// <inheritdoc />
    public partial class Init_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlbumGenre",
                columns: table => new
                {
                    sAlbumGenreId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sAlbumGenreName = table.Column<string>(type: "nvarchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumGenre_sAlbumGenreId", x => x.sAlbumGenreId);
                });

            migrationBuilder.CreateTable(
                name: "PlayListGerne",
                columns: table => new
                {
                    sPlaylistGenreId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sPlaylistGenreName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayListGenre_sPlaylistGenreId", x => x.sPlaylistGenreId);
                });

            migrationBuilder.CreateTable(
                name: "TrackGenre",
                columns: table => new
                {
                    sTrackGenreId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sTrackGenreName = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackGenre", x => x.sTrackGenreId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    sUserId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sFirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    sLastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    sEmail = table.Column<string>(type: "varchar(30)", nullable: true),
                    sAvatar = table.Column<string>(type: "varchar(30)", nullable: true),
                    sBio = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    sAccount = table.Column<string>(type: "varchar(20)", nullable: false),
                    sPassword = table.Column<string>(type: "varchar(20)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_sUserId", x => x.sUserId);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    sAlbumId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sAlbumName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    sDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sUserId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sAlbumGenreId = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album_sAlbumId", x => x.sAlbumId);
                    table.ForeignKey(
                        name: "FK_Album_AlbumGenre_sAlbumGenreId",
                        column: x => x.sAlbumGenreId,
                        principalTable: "AlbumGenre",
                        principalColumn: "sAlbumGenreId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Album_User_sUserId",
                        column: x => x.sUserId,
                        principalTable: "User",
                        principalColumn: "sUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Follow",
                columns: table => new
                {
                    sUserId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sTrackedPersonId = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follow", x => new { x.sUserId, x.sTrackedPersonId });
                    table.ForeignKey(
                        name: "FK_Follow_User_sTrackedPersonId",
                        column: x => x.sTrackedPersonId,
                        principalTable: "User",
                        principalColumn: "sUserId");
                    table.ForeignKey(
                        name: "FK_Follow_User_sUserId",
                        column: x => x.sUserId,
                        principalTable: "User",
                        principalColumn: "sUserId");
                });

            migrationBuilder.CreateTable(
                name: "Playlist",
                columns: table => new
                {
                    sPlaylistId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sPlaylistName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    sDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    bIsPrivate = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    sUserId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sPlaylistGenreId = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlist_sPlaylistId", x => x.sPlaylistId);
                    table.ForeignKey(
                        name: "FK_Playlist_PlaylistGenre_sPlaylistGenreId",
                        column: x => x.sPlaylistGenreId,
                        principalTable: "PlayListGerne",
                        principalColumn: "sPlaylistGenreId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Playlist_User_sUserId",
                        column: x => x.sUserId,
                        principalTable: "User",
                        principalColumn: "sUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    sTrackId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sTrackName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    sDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sThumbnail = table.Column<string>(type: "varchar(100)", nullable: false),
                    sSource = table.Column<string>(type: "varchar(30)", nullable: false),
                    sHashtag = table.Column<string>(type: "varchar(100)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    bIsPrivate = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    sAlbumId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sUserId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sTrackGenreId = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track_sTrackId", x => x.sTrackId);
                    table.ForeignKey(
                        name: "FK_Track_Album_sAlbumId",
                        column: x => x.sAlbumId,
                        principalTable: "Album",
                        principalColumn: "sAlbumId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Track_TrackGenre_sTrackGenreId",
                        column: x => x.sTrackGenreId,
                        principalTable: "TrackGenre",
                        principalColumn: "sTrackGenreId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Track_User_sUserId",
                        column: x => x.sUserId,
                        principalTable: "User",
                        principalColumn: "sUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    sCommentId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sContent = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    sUserId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sTrackId = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.sCommentId);
                    table.ForeignKey(
                        name: "FK_Comment_Track_sTrackId",
                        column: x => x.sTrackId,
                        principalTable: "Track",
                        principalColumn: "sTrackId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_User_sUserId",
                        column: x => x.sUserId,
                        principalTable: "User",
                        principalColumn: "sUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    sHistoryId = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    sUserId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sTrackId = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History_sHistoryId", x => x.sHistoryId);
                    table.ForeignKey(
                        name: "FK_History_Track_sTrackId",
                        column: x => x.sTrackId,
                        principalTable: "Track",
                        principalColumn: "sTrackId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_History_User_sUserId",
                        column: x => x.sUserId,
                        principalTable: "User",
                        principalColumn: "sUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    sUserId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sTrackId = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => new { x.sUserId, x.sTrackId });
                    table.ForeignKey(
                        name: "FK_Like_Track_sTrackId",
                        column: x => x.sTrackId,
                        principalTable: "Track",
                        principalColumn: "sTrackId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Like_User_sUserId",
                        column: x => x.sUserId,
                        principalTable: "User",
                        principalColumn: "sUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Playlist_Track",
                columns: table => new
                {
                    PlayListId = table.Column<string>(type: "varchar(50)", nullable: false),
                    TrackId = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlist_Track", x => new { x.PlayListId, x.TrackId });
                    table.ForeignKey(
                        name: "FK_PlaylistTrack_Playlist_PlaylistId",
                        column: x => x.PlayListId,
                        principalTable: "Playlist",
                        principalColumn: "sPlaylistId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlaylistTrack_Track_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Track",
                        principalColumn: "sTrackId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_sAlbumGenreId",
                table: "Album",
                column: "sAlbumGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Album_sUserId",
                table: "Album",
                column: "sUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumGenre_sAlbumGenreName",
                table: "AlbumGenre",
                column: "sAlbumGenreName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_sTrackId",
                table: "Comment",
                column: "sTrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_sUserId",
                table: "Comment",
                column: "sUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Follow_sTrackedPersonId",
                table: "Follow",
                column: "sTrackedPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_History_sTrackId",
                table: "History",
                column: "sTrackId");

            migrationBuilder.CreateIndex(
                name: "IX_History_sUserId",
                table: "History",
                column: "sUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_sTrackId",
                table: "Like",
                column: "sTrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_sPlaylistGenreId",
                table: "Playlist",
                column: "sPlaylistGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_sUserId",
                table: "Playlist",
                column: "sUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_Track_TrackId",
                table: "Playlist_Track",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayListGerne_sPlaylistGenreName",
                table: "PlayListGerne",
                column: "sPlaylistGenreName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Track_sAlbumId",
                table: "Track",
                column: "sAlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Track_sTrackGenreId",
                table: "Track",
                column: "sTrackGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Track_sUserId",
                table: "Track",
                column: "sUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackGenre_sTrackGenreName",
                table: "TrackGenre",
                column: "sTrackGenreName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Follow");

            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropTable(
                name: "Playlist_Track");

            migrationBuilder.DropTable(
                name: "Playlist");

            migrationBuilder.DropTable(
                name: "Track");

            migrationBuilder.DropTable(
                name: "PlayListGerne");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "TrackGenre");

            migrationBuilder.DropTable(
                name: "AlbumGenre");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
