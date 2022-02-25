using System.Collections.Generic;
using System.Threading.Tasks;
using MovieRental.API.Commom;
using MovieRental.API.Models;

namespace MovieRental.API.Domain.Interfaces.Services {
    public interface IRentalService : IServiceBase<RentalDto> { 
        Task<RentalModel> Get(int id);

        Task<List<RentalModel>> GetAll(); 

        Task<List<RentalModel>> GetLateReturnMovie();
    }
}