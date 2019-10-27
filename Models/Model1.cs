namespace WebApplication2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=CarModel")
        {
        }

        public virtual DbSet<BookingSet> BookingSets { get; set; }
        public virtual DbSet<CarRatingSet> CarRatingSets { get; set; }
        public virtual DbSet<CarSet> CarSets { get; set; }
        public virtual DbSet<LocationSet> LocationSets { get; set; }
        public virtual DbSet<OrderLineSet> OrderLineSets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingSet>()
                .HasMany(e => e.OrderLineSets)
                .WithRequired(e => e.BookingSet)
                .HasForeignKey(e => e.BookingBookingID1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarRatingSet>()
                .Property(e => e.Rating)
                .IsUnicode(false);

            modelBuilder.Entity<CarRatingSet>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<CarSet>()
                .HasMany(e => e.BookingSets)
                .WithRequired(e => e.CarSet)
                .HasForeignKey(e => e.CarId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarSet>()
                .HasMany(e => e.CarRatingSets)
                .WithRequired(e => e.CarSet)
                .HasForeignKey(e => e.CarId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LocationSet>()
                .Property(e => e.Latitude)
                .HasPrecision(10, 8);

            modelBuilder.Entity<LocationSet>()
                .Property(e => e.Longitude)
                .HasPrecision(11, 8);

            modelBuilder.Entity<LocationSet>()
                .HasMany(e => e.BookingSets)
                .WithRequired(e => e.LocationSet)
                .HasForeignKey(e => e.LocationId)
                .WillCascadeOnDelete(false);
        }
    }
}
