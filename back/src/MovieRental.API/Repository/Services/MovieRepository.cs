using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieRental.API.Data;
using MovieRental.API.Domain.Interfaces;
using MovieRental.API.Models;

namespace MovieRental.API.Repository.Services {
    public class MovieRepository : IMovieRepository {
        private readonly DataContext _context;
        public MovieRepository(DataContext context) {
            _context = context;
        }
        
        public async void Create(MovieModel obj) {
            await _context.AddAsync(obj);
        }

        public void Delete(MovieModel obj) {
            _context.Remove(obj);
        }

        public async Task<MovieModel> Get(int id) {
            return await _context.MovieModels.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<MovieModel>> GetAll() {
            return await _context.MovieModels.ToListAsync();
        }

        public async Task<List<MovieModel>> GetNeverRentalMovies() {
            return await _context.MovieModels.Where(x => x.Rental == 0).ToListAsync();
        }

        public async Task<bool> SaveChangesAsync() {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update(MovieModel obj) {
            _context.Update(obj);
        }
    }
}