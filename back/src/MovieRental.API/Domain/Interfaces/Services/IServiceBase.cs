using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieRental.API.Domain.Interfaces.Services {
    public interface IServiceBase<TEntity> where TEntity : class {        

        Task<bool> Change(TEntity obj);

        Task<bool> Save(TEntity obj);

        Task<bool> Delete(int id);
    }
}