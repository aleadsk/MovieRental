using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieRental.API.Data;
using MovieRental.API.Domain.Interfaces;
using MovieRental.API.Models;

namespace MovieRental.API.Repository.Services {
    public class ClientRepository : IClientRepository {
        private readonly DataContext _context;

        public ClientRepository(DataContext context) {
            _context = context;
        }
        
        public async void Create(ClientModel obj) {
            await _context.AddAsync(obj);
        }

        public void Delete(ClientModel obj) {
            _context.Remove(obj);
        }

        public async Task<ClientModel> Get(int id) {
            return await _context.ClientModels.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ClientModel>> GetAll() {
            return await _context.ClientModels.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync() {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update(ClientModel obj) {
            _context.Update(obj);
        }
    }
}