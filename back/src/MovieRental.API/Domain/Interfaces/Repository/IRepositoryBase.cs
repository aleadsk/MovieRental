using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieRental.API.Domain.Interfaces {
    public interface IRepositoryBase<TEntity> where TEntity : class {
        Task<TEntity> Get(int id);

        Task<List<TEntity>> GetAll();

        Task<bool> SaveChangesAsync();

        void Create(TEntity obj);

        void Update(TEntity obj);

        void Delete(TEntity obj);
    }
}