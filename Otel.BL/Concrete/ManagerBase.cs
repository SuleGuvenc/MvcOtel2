using Microsoft.EntityFrameworkCore.Migrations;
using Otel.BL.Abstract;
using Otel.DAL.Repository.Abstract;
using System.Linq.Expressions;

using Otel.BL.Abstract;
using Otel.DAL.Repository.Abstract;
using Otel.Entitiy.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Otel.Entitiy.Concrete;
using Otel.DAL.Repository.Concrete;

namespace Otel.BL.Concrete
{
    public class ManagerBase<T> : IManagerBase<T> where T :BaseEntity
    {

        public  IBaseRepository<T> repository;
        private IBookingRepository dbContext;
        private IBaseRepository<Customer> repository1;
        private IBaseRepository<Hotel> repository2;
        private IBaseRepository<Employee> repository3;


        // IOC Container icerisinde var olan dbcontext nesnesi buraya injet edilecek
        public ManagerBase()
        {

            this.repository = new BaseRepository<T>();
        }

        public ManagerBase(IBookingRepository dbContext)
        {
            this.dbContext = dbContext;
        }

        public ManagerBase(IBaseRepository<Customer> repository1)
        {
            this.repository1 = repository1;
        }

        public ManagerBase(IBaseRepository<Hotel> repository2)
        {
            this.repository2 = repository2;
        }

        public ManagerBase(IBaseRepository<Employee> repository3)
        {
            this.repository3 = repository3;
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            return await repository.DeleteAsync(entity);    
        }

        public  async Task<ICollection<T>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            return await repository.GetAllAsync(filter);
		}

        public async Task<T?> GetByIdAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }
        public async Task<T?> GetBy(Expression<Func<T, bool>> filter)
        {


            return await repository.GetBy(filter);

        }
        public async  Task<IQueryable<T>> GetAllInclude(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] include)
        {
            return await repository.GetAllInclude(filter, include);
        }

      

       



        
        public virtual async Task<int> InsertAsync(T entity)
        {
            return await repository.InsertAsync(entity);
        }

        public  virtual async Task<int> UpdateAsync(T entity)
        {
            return await repository.UpdateAsync(entity);
        }
    }
}
