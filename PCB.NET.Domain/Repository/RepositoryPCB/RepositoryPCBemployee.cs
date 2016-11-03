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
        private ModelContext db = new ModelContext();

        #region Propertiees
        public IQueryable<DoneWork> DoneWork
        {
            get
            {
                return db.DoneWorks;
            }
        }

        public IQueryable<Employee> Employee
        {
            get
            {
                return db.Employees;
            }
        }

        public IQueryable<Position> Position
        {
            get
            {
                return db.Positions;
            }
        }
        #endregion

        #region Methods Employee
        public Task AddEmployeeAsync(Employee context)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployeeAsync(Employee context)
        {
            throw new NotImplementedException();
        }

        public Task EditEmployeeAsync(Employee context)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Methods DoneWork
        public Task AddDoneWorkAsync(DoneWork context)
        {
            throw new NotImplementedException();
        }

        public Task EditDoneWorkAsync(DoneWork context)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDoneWorkAsync(DoneWork context)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Methods Position
        public Task EditPositionAsync(Position context)
        {
            throw new NotImplementedException();
        }

        public Task DeletePositionAsync(Position context)
        {
            throw new NotImplementedException();
        }

        public Task AddPositionAsync(Position context)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
