using System.Collections.Generic;
using System.Threading.Tasks;
using MovieRental.API.Models;

namespace MovieRental.API.Domain.Interfaces {
    public interface IMovieRepository : IRepositoryBase<MovieModel> { 
        Task<List<MovieModel>> GetNeverRentalMovies();
    }
}