using System.Collections.Generic;
using System.Threading.Tasks;
using MovieRental.API.Models;

namespace MovieRental.API.Domain.Interfaces {
    public interface IRentalRepository : IRepositoryBase<RentalModel> { 
        Task<List<RentalModel>> GetLateReturnMovies();
    }
}