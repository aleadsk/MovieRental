using Microsoft.EntityFrameworkCore;
using MovieRental.API.Models;
using MovieRental.API.Repository.Map;

namespace MovieRental.API.Data {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ClientModel> ClientModels { get; set; }

        public DbSet<MovieModel> MovieModels { get; set; }

        public DbSet<RentalModel> RentalModels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.ApplyConfiguration(new ClientMap());

            
            builder.ApplyConfiguration(new MovieMap());

            
            builder.ApplyConfiguration(new RentalMap());
        }
    }
}