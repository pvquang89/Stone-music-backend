using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using stone_music_backend.Models;

namespace stone_music_backend.Data
{
    public class MyDbContext : DbContext
    {

        #region dbset
        public DbSet<Album>? Albums { get; set; }
        public DbSet<AlbumGenre>? AlbumGenres { get; set; }
        public DbSet<Comment>? Comments { get; set; }
        public DbSet<Follow>? Follows { get; set; }
        public DbSet<History>? Historys { get; set; }
        public DbSet<Like>? Likes { get; set; }
        public DbSet<Playlist>? Playlists { get; set; }
        public DbSet<PlaylistGenre>? PlaylistGenres { get; set; }
        public virtual DbSet<Playlist_Track>? Playlist_Tracks { get; set; }
        public DbSet<Track>? Tracks { get; set; }
        public DbSet<TrackGenre>? TrackGenres { get; set; }
        public DbSet<User>? Users { get; set; }

        #endregion

        public MyDbContext(DbContextOptions<MyDbContext> opt) : base(opt)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var configSection = configBuilder.GetSection("ConnectionStrings");
            var connectionString = configSection["MyStoneMusic"] ?? "";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region fluentAPI
            //m-n
            // Playlist_track
            modelBuilder.Entity<Playlist_Track>(entity =>
            {
                entity.HasKey(plt => new { plt.PlayListId, plt.TrackId }).HasName("PK_Playlist_Track");
                entity.HasOne(plt => plt.PlayList).WithMany(pl => pl.Playlist_Tracks).HasForeignKey(plt => plt.PlayListId).HasConstraintName("FK_PlaylistTrack_Playlist_PlaylistId").OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(plt => plt.Track).WithMany(t => t.Playlist_Tracks).HasForeignKey(plt => plt.TrackId).HasConstraintName("FK_PlaylistTrack_Track_TrackId").OnDelete(DeleteBehavior.Restrict);
                entity.ToTable("Playlist_Track");
            });

            //1-n
            // User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.sUserId).HasName("PK_User_sUserId");
                entity.HasMany(u => u.Albums).WithOne(al => al.User).HasForeignKey(al => al.sUserId).HasConstraintName("FK_Album_User_sUserId");
                entity.HasMany(u => u.Tracks).WithOne(t => t.User).HasForeignKey(t => t.sUserId).HasConstraintName("FK_Track_User_sUserId");
                entity.HasMany(u => u.PlayLists).WithOne(pl => pl.User).HasForeignKey(pl => pl.sUserId).HasConstraintName("FK_Playlist_User_sUserId");
                entity.HasMany(u => u.Likes).WithOne(l => l.User).HasForeignKey(l => l.sUserId).HasConstraintName("FK_Like_User_sUserId");
                entity.HasMany(u => u.Histories).WithOne(h => h.User).HasForeignKey(h => h.sUserId).HasConstraintName("FK_History_User_sUserId");
                entity.HasMany(u => u.Comments).WithOne(c => c.User).HasForeignKey(c => c.sUserId).HasConstraintName("FK_Comment_User_sUserId");
                //1 user được theo dõi bởi nhiều user khác (follwers - tập người theo dõi user), mỗi bảng Follow chỉ mô tả 1 user theo dõi user nào
                entity.HasMany(u => u.Followers).WithOne(f => f.TrackedPerson).HasForeignKey(f => f.sTrackedPersonId).HasConstraintName("FK_Follow_User_sTrackedPersonId").OnDelete(DeleteBehavior.NoAction);
                //1 user theo dõi nhiều user khác, mỗi bảng Follow có 1 người theo dõi
                entity.HasMany(u => u.TrackedPersons).WithOne(f => f.Follower).HasForeignKey(f => f.sUserId).HasConstraintName("FK_Follow_User_sUserId").OnDelete(DeleteBehavior.NoAction);
                entity.ToTable("User");

                //property
                entity.Property(p => p.sUserId).HasColumnType("varchar(50)").HasColumnOrder(0).IsRequired();
                entity.Property(p => p.sFirstName).HasColumnType("nvarchar(50)").HasColumnOrder(1).IsRequired();
                entity.Property(p => p.sLastName).HasColumnType("nvarchar(50)").HasColumnOrder(2).IsRequired();
                entity.Property(p => p.sEmail).HasColumnType("varchar(30)").HasColumnOrder(3);
                entity.Property(p => p.sAvatar).HasColumnType("varchar(30)").HasColumnOrder(4);
                entity.Property(p => p.sBio).HasColumnType("nvarchar(100)").HasColumnOrder(5);
                entity.Property(p => p.sAccount).HasColumnType("varchar(20)").HasColumnOrder(6).IsRequired();
                entity.Property(p => p.sPassword).HasColumnType("varchar(20)").HasColumnOrder(7).IsRequired();
                entity.Property(p => p.CreatedAt).HasColumnOrder(8).IsRequired().HasDefaultValueSql("GETDATE()");
            });

            // Track
            modelBuilder.Entity<Track>(entity =>
            {
                entity.HasKey(t => t.sTrackId).HasName("PK_Track_sTrackId");
                entity.HasOne(t => t.Album).WithMany(al => al.Tracks).HasForeignKey(t => t.sAlbumId).HasConstraintName("FK_Track_Album_sAlbumId").OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(t => t.TrackGenre).WithMany(tg => tg.Tracks).HasForeignKey(t => t.sTrackGenreId).HasConstraintName("FK_Track_TrackGenre_sTrackGenreId").OnDelete(DeleteBehavior.Restrict); ;
                entity.HasMany(t => t.Likes).WithOne(l => l.Track).HasForeignKey(l => l.sTrackId).HasConstraintName("FK_Like_Track_sTrackId").OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(t => t.Histories).WithOne(h => h.Track).HasForeignKey(h => h.sTrackId).HasConstraintName("FK_History_Track_sTrackId").OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(t => t.Comments).WithOne(c => c.Track).HasForeignKey(c => c.sTrackId).HasConstraintName("FK_Comment_Track_sTrackId").OnDelete(DeleteBehavior.Restrict);
                entity.ToTable("Track");

                // property 
                entity.Property(p => p.sTrackId).HasColumnType("varchar(50)").IsRequired();
                entity.Property(p => p.sTrackName).HasColumnType("nvarchar(100)").IsRequired();
                entity.Property(p => p.sTrackGenreId).HasColumnType("varchar(50)");
                entity.Property(p => p.sAlbumId).HasColumnType("varchar(50)");
                entity.Property(p => p.sUserId).HasColumnType("varchar(50)").IsRequired();
                entity.Property(p => p.sDescription);
                entity.Property(p => p.sThumbnail).HasColumnType("varchar(100)").IsRequired();
                entity.Property(p => p.sSource).HasColumnType("varchar(30)").IsRequired();
                entity.Property(p => p.sHashtag).HasColumnType("varchar(100)");
                entity.Property(p => p.bIsPrivate).HasColumnType("bit").IsRequired().HasDefaultValue(0);
                entity.Property(p => p.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
            });

            // Album
            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasKey(al => al.sAlbumId).HasName("PK_Album_sAlbumId");
                entity.HasOne(al => al.AlbumGenre).WithMany(alg => alg.Albums).HasForeignKey(al => al.sAlbumGenreId).HasConstraintName("FK_Album_AlbumGenre_sAlbumGenreId").OnDelete(DeleteBehavior.Restrict);
                entity.ToTable("Album");

                // property
                entity.Property(p => p.sAlbumId).HasColumnType("varchar(50)").IsRequired();
                entity.Property(p => p.sAlbumName).HasColumnType("nvarchar(100)").IsRequired();
                entity.Property(p => p.sDescription);
                entity.Property(p => p.sUserId).HasColumnType("varchar(50)").IsRequired();

            });

            // AlbumGenre
            modelBuilder.Entity<AlbumGenre>(entity =>
           {
               entity.HasKey(alg => alg.sAlbumGenreId).HasName("PK_AlbumGenre_sAlbumGenreId");
               entity.HasIndex(alg => alg.sAlbumGenreName).IsUnique();
               entity.ToTable("AlbumGenre");

               // property
               entity.Property(p => p.sAlbumGenreId).HasColumnType("varchar(50)").IsRequired();
               entity.Property(p => p.sAlbumGenreName).HasColumnType("nvarchar(30)").IsRequired();

           });

            // Comment
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(c => c.sCommentId).HasName("PK_Comment");
                entity.ToTable("Comment");

                // property
                entity.Property(p => p.sCommentId).HasColumnType("varchar(50)").IsRequired();
                entity.Property(p => p.sUserId).HasColumnType("varchar(50)").IsRequired();
                entity.Property(p => p.sTrackId).HasColumnType("varchar(50)").IsRequired();
                entity.Property(p => p.sContent).HasColumnType("nvarchar(100)").IsRequired();
                entity.Property(p => p.CreatedAt).HasColumnType("datetime").IsRequired().HasDefaultValueSql("GETDATE()");
                entity.Property(p => p.UpdatedAt).HasColumnType("datetime");
            });

            // Follow
             modelBuilder.Entity<Follow>(entity =>
          {
              entity.HasKey(f => new { f.sUserId, f.sTrackedPersonId }).HasName("PK_Follow");
              entity.ToTable("Follow");

              // property
              entity.Property(p => p.sUserId).HasColumnType("varchar(50)").IsRequired();
              entity.Property(p => p.sTrackedPersonId).HasColumnType("varchar(50)").IsRequired();


          });

            // History
            modelBuilder.Entity<History>(entity =>
          {
              entity.HasKey(h => h.sHistoryId).HasName("PK_History_sHistoryId");
              entity.ToTable("History");

              // property
              entity.Property(p => p.sHistoryId).HasColumnType("varchar(50)").IsRequired();
              entity.Property(p => p.sUserId).HasColumnType("varchar(50)").IsRequired();
              entity.Property(p => p.sTrackId).HasColumnType("varchar(50)").IsRequired();
              entity.Property(p => p.CreatedAt).HasColumnType("datetime").IsRequired().HasDefaultValueSql("GETDATE()");
              entity.Property(p => p.UpdatedAt).HasColumnType("datetime");

          });

            // Like
            modelBuilder.Entity<Like>(entity =>
           {
               entity.HasKey(l => new { l.sUserId, l.sTrackId }).HasName("PK_Like");
               entity.ToTable("Like");

               // property
               entity.Property(p => p.sUserId).HasColumnType("varchar(50)").IsRequired();
               entity.Property(p => p.sTrackId).HasColumnType("varchar(50)").IsRequired();


           });

            // PlayList 
            modelBuilder.Entity<Playlist>(entity =>
          {
              entity.HasKey(pl => pl.sPlaylistId).HasName("PK_Playlist_sPlaylistId");
              entity.HasOne(pl => pl.PlaylistGenre).WithMany(plg => plg.Playlists).HasForeignKey(pl => pl.sPlaylistGenreId).HasConstraintName("FK_Playlist_PlaylistGenre_sPlaylistGenreId").OnDelete(DeleteBehavior.Restrict);
              entity.ToTable("Playlist");

              // property
              entity.Property(p => p.sPlaylistId).HasColumnType("varchar(50)").IsRequired();
              entity.Property(p => p.sPlaylistName).HasColumnType("nvarchar(100)").IsRequired();
              entity.Property(p => p.sUserId).HasColumnType("varchar(50)").IsRequired();
              entity.Property(p => p.sDescription);
              entity.Property(p => p.bIsPrivate).HasColumnType("bit").IsRequired().HasDefaultValue(0);
              entity.Property(p => p.CreatedAt).HasColumnType("datetime").IsRequired().HasDefaultValueSql("GETDATE()");

          });

            // TrackGenre
            modelBuilder.Entity<TrackGenre>(entity =>
           {
               entity.HasKey(tg => tg.sTrackGenreId).HasName("PK_TrackGenre");
               entity.HasIndex(tg => tg.sTrackGenreName).IsUnique();
               entity.ToTable("TrackGenre");

               // property
               entity.Property(p => p.sTrackGenreId).HasColumnType("varchar(50)").IsRequired();
               entity.Property(p => p.sTrackGenreName).HasColumnType("nvarchar(50)").IsRequired();

           });


            // PlayListGenre
            modelBuilder.Entity<PlaylistGenre>(entity =>
           {
               entity.HasKey(plg => plg.sPlaylistGenreId).HasName("PK_PlayListGenre_sPlaylistGenreId");
               entity.HasIndex(plg => plg.sPlaylistGenreName).IsUnique();
               entity.ToTable("PlayListGerne");

               // property
               entity.Property(p => p.sPlaylistGenreId).HasColumnType("varchar(50)").IsRequired();
               entity.Property(p => p.sPlaylistGenreName).HasColumnType("nvarchar(100)").IsRequired();
           });
            #endregion
        }




    }
}