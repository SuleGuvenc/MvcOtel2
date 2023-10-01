using Otel.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.BL.Abstract
{
    public interface ICustomerManager:IManagerBase<Customer>
    {
        Task<Customer?> Login(string email, string password);
        Task<bool> Logout(Customer customer);
    }
}
