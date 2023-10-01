using Otel.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.DAL.Repository.Abstract
{
    public interface ICustomerRepository:IBaseRepository<Customer>
    {
        //Task<Customer?> GetBy(Func<object, bool> value);
    }
}
