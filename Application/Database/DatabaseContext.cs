using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using TransferBase.Application.Models;

namespace TransferBase.Application.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }

        public virtual DbSet<User> Users { set; get; }
        public virtual DbSet<Role> Roles { set; get; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Player> Players { set; get; }
        public virtual DbSet<PlayerSkill> PlayerSkills { set; get; }
        public virtual DbSet<Appearance> Appearances { set; get; }
        public virtual DbSet<Competition> Competitions { set; get; }
        public virtual DbSet<Club> Clubs { set; get; }
        public virtual DbSet<ClubGame> ClubGames { set; get; }
        public virtual DbSet<GameEvent> GameEvents { set; get; }
        public virtual DbSet<PlayerValue> PlayerValues { set; get; }
        public virtual DbSet<Game> Games { set; get; }
        public virtual DbSet<NationalTeam> NationalTeams { set; get; }
        public virtual DbSet<Coach> Coaches { set; get; }   
        public virtual DbSet<Transfer> Transfers { set; get; }
        public virtual DbSet<TransferPrice> TransferPrices { set; get; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // it should be placed here, otherwise it will rewrite the following settings!
            base.OnModelCreating(builder);

            // Custom application mappings
            builder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(450).IsRequired();
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Password).IsRequired();
            });

            builder.Entity<Appearance>(entity => {
                entity.Property(e => e.Id).HasMaxLength(450).IsRequired();
                entity.Property(e => e.GameId).HasMaxLength(450).IsRequired();
            });

            builder.Entity<PlayerSkill>(entity =>
            {
                entity.HasKey(entity => new { entity.Id, entity.Season });
            });

            builder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(450).IsRequired();
                entity.HasIndex(e => e.Name).IsUnique();
            });

            builder.Entity<TransferPrice>().HasNoKey();

            builder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
                entity.HasIndex(e => e.UserId);
                entity.HasIndex(e => e.RoleId);
                entity.Property(e => e.UserId);
                entity.Property(e => e.RoleId);
                entity.HasOne(d => d.Role).WithMany(p => p.UserRoles).HasForeignKey(d => d.RoleId);
                entity.HasOne(d => d.User).WithMany(p => p.UserRoles).HasForeignKey(d => d.UserId);
            });

            //builder.Entity<Appearance>(entity =>
            //{
            //    entity.HasOne(d => d.Player).WithMany(p => p.Appearances).HasForeignKey(d => d.PlayerId);
            //    entity.HasOne(d => d.Game).WithMany(p => p.Appearances).HasForeignKey(d => d.GameId);
            //    entity.HasOne(d => d.Club).WithMany(p => p.Appearances).HasForeignKey(d => d.PlayerClubId);
            //    entity.HasOne(d => d.Club).WithMany(p => p.Appearances).HasForeignKey(d => d.PlayerCurrentClubId);
            //    entity.HasOne(d => d.Competition).WithMany(p => p.Appearances).HasForeignKey(d => d.CompetitionId);
            //});


            builder.Entity<ClubGame>(entity =>
            {
                entity.HasKey(e => new { e.GameId, e.ClubId });
                entity.HasIndex(e => e.GameId);
                entity.HasIndex(e => e.ClubId);
                entity.Property(e => e.GameId);
                entity.Property(e => e.ClubId);
                entity.HasOne(d => d.Game).WithMany(p => p.ClubGames).HasForeignKey(d => d.GameId);
                entity.HasOne(d => d.Club).WithMany(p => p.ClubGames).HasForeignKey(d => d.ClubId);
            });

            builder.Entity<GameEvent>(entity =>
            {
                entity.HasKey(e => new { e.GameId, e.ClubId, e.PlayerId });
                entity.HasIndex(e => e.GameId);
                entity.HasIndex(e => e.ClubId);
                entity.HasIndex(e => e.PlayerId);
                entity.Property(e => e.GameId);
                entity.Property(e => e.ClubId);
                entity.Property(e => e.PlayerId);
                entity.HasOne(d => d.Game).WithMany(p => p.GameEvents).HasForeignKey(d => d.GameId);
                entity.HasOne(d => d.Club).WithMany(p => p.GameEvents).HasForeignKey(d => d.ClubId);
                entity.HasOne(d => d.Player).WithMany(p => p.GameEvents).HasForeignKey(d => d.PlayerId);
            });

            builder.Entity<Role>().HasData(
                new Role { Id = 1, Name = CustomRoles.User },
                new Role { Id = 2, Name = CustomRoles.Admin }
            );
        }
    }
}