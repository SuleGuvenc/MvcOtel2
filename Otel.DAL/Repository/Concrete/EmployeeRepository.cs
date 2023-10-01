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
    public class EmployeeRepository : BaseConfig<Employee>, IEmployeeRepository
    {
        public Task<int> DeleteAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Employee>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Employee>> GetAllAsync(Expression<Func<Employee, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Employee>> GetAllInclude(Expression<Func<Employee, bool>>? filter = null, params Expression<Func<Employee, object>>[] include)
        {
            throw new NotImplementedException();
        }

        public Task<Employee?> GetBy(Expression<Func<Employee, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<Employee?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
