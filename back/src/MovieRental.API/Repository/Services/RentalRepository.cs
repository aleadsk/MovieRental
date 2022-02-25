using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieRental.API.Commom;
using MovieRental.API.Data;
using MovieRental.API.Domain.Interfaces;
using MovieRental.API.Models;

namespace MovieRental.API.Repository.Services {
    public class RentalRepository : IRentalRepository {
        private readonly DataContext _context;
        public RentalRepository(DataContext context) {
            _context = context;
        }
        
        public async void Create(RentalModel obj) {
            await _context.AddAsync(obj);
        }

        public void Delete(RentalModel obj) {
            _context.Remove(obj);
        }

        public async Task<RentalModel> Get(int id) {
            return await _context.RentalModels
                .Include(x => x.Client)
                .Include(x => x.Movie)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<RentalModel>> GetAll() {
            return await _context.RentalModels
                .Include(x => x.Client)
                .Include(x => x.Movie)
                .ToListAsync();
        }

        public async Task<List<RentalModel>> GetLateReturnMovies() {
            return await _context.RentalModels.Where(x => x.ReturnDate < DateTime.Now)
                .Include(x => x.Client)
                .Include(x => x.Movie)
                .ToListAsync();
        }

        public async Task<bool> SaveChangesAsync() {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update(RentalModel obj) {
            _context.Update(obj);
        }
    }
}