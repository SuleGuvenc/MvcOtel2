using Otel.DAL.EntityConfig.Abstract;
using Otel.DAL.Repository.Abstract;
using Otel.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Otel.DAL.Repository.Concrete
{
    public class HotelRepository : BaseConfig<Hotel>, IHotelRepository
    {
        public Task<int> DeleteAsync(Hotel entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Hotel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Hotel>> GetAllAsync(Expression<Func<Hotel, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Hotel>> GetAllInclude(Expression<Func<Hotel, bool>>? filter = null, params Expression<Func<Hotel, object>>[] include)
        {
            throw new NotImplementedException();
        }

        public Task<Hotel?> GetBy(Expression<Func<Hotel, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<Hotel?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(Hotel entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Hotel entity)
        {
            throw new NotImplementedException();
        }
    }
}
