using Microsoft.EntityFrameworkCore;
using MovieRental.API.Models;

namespace MovieRental.API.Data {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ClientModel> ClientModels { get; set; }

        public DbSet<MovieModel> MovieModels { get; set; }

        public DbSet<RentalModel> RentalModels { get; set; }
    }
}