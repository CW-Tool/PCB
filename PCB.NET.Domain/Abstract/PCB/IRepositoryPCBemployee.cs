using PCB.NET.Domain.Model.WorkshopPCB.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCB.NET.Domain.Abstract.PCB
{
    public interface IRepositoryPCBemployee
    {
        IQueryable<Employee> Employee { get; }
        IQueryable<DoneWork> DoneWork { get; }
        IQueryable<Position> Position { get; }
    }
}
