using Otel.DAL.Repository.Abstract;
using Otel.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.DAL.Repository.Concrete
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        
    }
}
