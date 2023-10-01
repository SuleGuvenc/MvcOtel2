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
    public class EmployeeManager : ManagerBase<Employee>, IEmployeeManager
    {
        
    }
}
