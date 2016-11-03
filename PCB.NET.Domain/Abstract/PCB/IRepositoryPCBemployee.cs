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
        #region Properties
        IQueryable<Employee> Employee { get; }
        IQueryable<DoneWork> DoneWork { get; }
        IQueryable<Position> Position { get; }
        #endregion

        #region Methods
        Task DeleteEmployeeAsync(Employee context);
        Task EditEmployeeAsync(Employee context);
        Task AddEmployeeAsync(Employee context);
        Task DeleteDoneWorkAsync(DoneWork context);
        Task EditDoneWorkAsync(DoneWork context);
        Task AddDoneWorkAsync(DoneWork context);
        Task DeletePositionAsync(Position context);
        Task EditPositionAsync(Position context);
        Task AddPositionAsync(Position context);
        #endregion
    }
}
