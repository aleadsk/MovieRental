using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieRental.API.Models;

namespace MovieRental.API.Repository.Map {
    public class MovieMap : IEntityTypeConfiguration<MovieModel> {
        public void Configure(EntityTypeBuilder<MovieModel> builder) {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .HasColumnType("varchar(100)");

            builder.Property(x => x.ParentalRating)
                .HasColumnType("int");

            builder.Property(x => x.LauchMovie)
                .HasColumnType("Datetime");

            builder.ToTable("Movie");
        }
    }
}