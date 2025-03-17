using Microsoft.EntityFrameworkCore;
using ExperienceAPI.Models;

namespace ExperienceAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<SharedExperience> SharedExperiences { get; set; }
        public DbSet<GuestSharedExperience> GuestSharedExperiences { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Provider
            modelBuilder.Entity<Provider>()
                .HasKey(p => p.ProviderID);
            modelBuilder.Entity<Provider>()
                .Property(p => p.TouristicPermit).IsRequired(); 
            modelBuilder.Entity<Provider>()
                .Property(p => p.BusinessPhysicalAddress).IsRequired();
            modelBuilder.Entity<Provider>()
                .Property(p => p.PhoneNumber).IsRequired();

            // Experience
            modelBuilder.Entity<Experience>()
                .HasKey(e => e.ExperienceID);
            modelBuilder.Entity<Experience>()
                .HasOne(e => e.Provider)
                .WithMany()
                .HasForeignKey(e => e.ProviderID_FK)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Experience>()
                .Property(e => e.Price).HasColumnType("decimal(18,2)");

            // Discount
            modelBuilder.Entity<Discount>()
                .HasKey(d => new { d.ExperienceID_FK, d.GroupSize });
            modelBuilder.Entity<Discount>()
                .HasOne(d => d.Experience)
                .WithMany(e => e.Discounts)
                .HasForeignKey(d => d.ExperienceID_FK)
                .OnDelete(DeleteBehavior.Cascade); // <-- Cascade Delete her
            modelBuilder.Entity<Discount>()
                .Property(d => d.PriceAfterDiscount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Discount>()
                .Property(d => d.DiscountAmount).HasColumnType("decimal(18,2)");

            // Guest
            modelBuilder.Entity<Guest>()
                .HasKey(g => g.GuestID);
            modelBuilder.Entity<Guest>()
                .Property(g => g.Name).IsRequired();
            modelBuilder.Entity<Guest>()
                .Property(g => g.PhoneNumber).IsRequired();
            modelBuilder.Entity<Guest>()
                .Property(g => g.Age).IsRequired();

            // Reservation
            modelBuilder.Entity<Reservation>()
                .HasKey(r => r.ReservationID);
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Guest)
                .WithMany(g => g.Reservations)
                .HasForeignKey(r => r.GuestID)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Experience)
                .WithMany(e => e.Reservations)
                .HasForeignKey(r => r.ExperienceID_FK)
                .OnDelete(DeleteBehavior.Cascade); // <-- Cascade Delete her
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Discount)
                .WithMany()
                .HasForeignKey(r => new { r.ExperienceID_FK, r.GroupSize_FK })
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Reservation>()
                .Property(r => r.PriceAfterDiscount_PK).HasColumnType("decimal(18,2)");

            // SharedExperience
            modelBuilder.Entity<SharedExperience>()
                .HasKey(se => se.ShareExperienceID);
            modelBuilder.Entity<SharedExperience>()
                .HasOne(se => se.Experience)
                .WithMany(e => e.SharedExperiences)
                .HasForeignKey(se => se.ExperienceID_FK)
                .OnDelete(DeleteBehavior.Cascade); // <-- Cascade Delete her

            // GuestSharedExperience
            modelBuilder.Entity<GuestSharedExperience>()
                .HasKey(gse => new { gse.ShareExperienceID, gse.GuestID });
            modelBuilder.Entity<GuestSharedExperience>()
                .HasOne(gse => gse.Guest)
                .WithMany(g => g.GuestSharedExperiences)
                .HasForeignKey(gse => gse.GuestID)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<GuestSharedExperience>()
                .HasOne(gse => gse.SharedExperience)
                .WithMany(se => se.GuestSharedExperiences)
                .HasForeignKey(gse => gse.ShareExperienceID)
                .OnDelete(DeleteBehavior.Cascade); // <-- Cascade Delete her

            base.OnModelCreating(modelBuilder);
        }
    }
}
