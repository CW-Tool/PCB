using PCB.NET.Domain.Abstract.PCB;
using PCB.NET.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCB.NET.Domain.Model.WorkshopPCB.Employee;
using System.Data.Entity;

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
        public async Task AddEmployeeAsync(Employee context)
        {
            try
            {
                db.Employees.Add(context);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteEmployeeAsync(Employee context)
        {
            try
            {
                db.Employees.Remove(context);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task EditEmployeeAsync(Employee context)
        {
            try
            {
                db.Entry(context).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Methods DoneWork
        public async Task AddDoneWorkAsync(DoneWork context)
        {
            try
            {
                db.DoneWorks.Add(context);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task EditDoneWorkAsync(DoneWork context)
        {
            try
            {
                db.Entry(context).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteDoneWorkAsync(DoneWork context)
        {
            try
            {
                db.DoneWorks.Remove(context);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Methods Position
        public async Task EditPositionAsync(Position context)
        {
            try
            {
                db.Entry(context).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeletePositionAsync(Position context)
        {
            try
            {
                db.Positions.Remove(context);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddPositionAsync(Position context)
        {
            try
            {
                db.Positions.Add(context);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
