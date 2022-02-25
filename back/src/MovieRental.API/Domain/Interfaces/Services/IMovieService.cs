using System.Collections.Generic;
using System.Threading.Tasks;
using MovieRental.API.Commom.Dtos;
using MovieRental.API.Models;

namespace MovieRental.API.Domain.Interfaces.Services {
    public interface IMovieService : IServiceBase<MovieDto> {
        Task<MovieModel> Get(int id);

        Task<List<MovieModel>> GetAll(); 
        
        Task<List<MovieModel>> GetNeverRentalMovie();
    }
}