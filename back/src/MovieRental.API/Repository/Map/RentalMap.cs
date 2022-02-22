using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieRental.API.Models;

namespace MovieRental.API.Repository.Map
{
    public class RentalMap : IEntityTypeConfiguration<RentalModel> {
        public void Configure(EntityTypeBuilder<RentalModel> builder) {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Client)
                   .WithMany(x => x.Rentals)
                   .HasForeignKey(x => x.FKClientId);

            builder.HasOne(x => x.Movie)
                   .WithMany(x => x.Rentals)
                   .HasForeignKey(x => x.FKMovieId);

            builder.Property(x => x.RentalDate)
                .HasColumnType("Datetime");

            builder.Property(x => x.ReturnDate)
                .HasColumnType("Datetime");

            builder.ToTable("Rental");
        }
    }
}