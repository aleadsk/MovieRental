using System.Collections.Generic;
using System.Threading.Tasks;
using MovieRental.API.Commom.Dtos;
using MovieRental.API.Models;

namespace MovieRental.API.Domain.Interfaces.Services {
    public interface IClientService : IServiceBase<ClientDto> { 
        Task<ClientModel> Get(int id);

        Task<List<ClientModel>> GetAll();
    }
}