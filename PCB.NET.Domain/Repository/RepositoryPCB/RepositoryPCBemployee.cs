using PCB.NET.Domain.Abstract.PCB;
using PCB.NET.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCB.NET.Domain.Model.WorkshopPCB.Employee;

namespace PCB.NET.Domain.Repository.RepositoryPCB
{
    public class RepositoryPCBemployee : IRepositoryPCBemployee
    {
        private ModelContext dbd = new ModelContext();

        public IQueryable<DoneWork> DoneWork
        {
            get
            {
                return dbd.DoneWorks;
            }
        }

        public IQueryable<Employee> Employee
        {
            get
            {
                return dbd.Employees;
            }
        }

        public IQueryable<Position> Position
        {
            get
            {
                return dbd.Positions;
            }
        }
    }
}
