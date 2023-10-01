using Otel.BL.Abstract;
using Otel.DAL.Repository.Abstract;
using Otel.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Otel.BL.Concrete
{
    public class CustomerManager : ManagerBase<Customer>, ICustomerManager
    {
       

        public async Task<Customer?> Login(string email, string password)
        {

            var customer=await base.GetBy(p => p. Email== email && p.Password == password);
            if (customer != null)
            {
                return customer;
            }
            return null;

        }

        public Task<bool> Logout(Customer customer)
        {
            throw new NotImplementedException();
        }
    }


}