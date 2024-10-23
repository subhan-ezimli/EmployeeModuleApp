using Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeModuleApp.Application.Abstractions
{
    internal abstract class Repository<T> where T : EntityBase<T>
    {

    }
}
