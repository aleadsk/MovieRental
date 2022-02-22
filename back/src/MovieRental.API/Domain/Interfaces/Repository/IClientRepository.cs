using System.Collections.Generic;
using System.Threading.Tasks;
using MovieRental.API.Models;

namespace MovieRental.API.Domain.Interfaces {
    public interface IClientRepository : IRepositoryBase<ClientModel> { }
}