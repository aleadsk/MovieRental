using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieRental.API.Models;

namespace MovieRental.API.Repository.Map {
    public class ClientMap : IEntityTypeConfiguration<ClientModel> {
        public void Configure(EntityTypeBuilder<ClientModel> builder) {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Cpf)
                .HasColumnType("varchar(100)");

            builder.Property(x => x.BirthDate)
                .HasColumnType("Datetime");

            builder.ToTable("ClientModels");
        }
    }
}