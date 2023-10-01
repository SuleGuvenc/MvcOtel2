using Otel.BL.Abstract;
using Otel.DAL.Repository.Abstract;
using System.Linq.Expressions;
using Otel.Entitiy.Abstarct;
using Otel.DAL.Repository.Concrete;

namespace Otel.BL.Concrete
{
    public class ManagerBase<T> : IManagerBase<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> repository;

        public ManagerBase()
        {

            this.repository = new BaseRepository<T>();
        }

        public async Task<int> InsertAsync(T entity)
        {
            // Set metodu dbContex icerisndeki gelen T tipi ne ise ona konumlanir.
            return await repository.InsertAsync(entity);
        }

        public async Task<int> UpdateAsync(T entity)
        {
            return await repository.UpdateAsync(entity);
        }

        public async Task<int> DeleteAsync(T entity)
        {
            return await repository.DeleteAsync(entity);
        }

        public async Task<T?> GetBy(Expression<Func<T, bool>> filter)
        {
            return await repository.GetBy(filter);

        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }
        public async Task<ICollection<T>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            return await repository.GetAllAsync(filter);

        }

        public async Task<IQueryable<T>> GetAllInclude(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] include)
        {
            return await repository.GetAllInclude(filter, include);

        }
    }
}
