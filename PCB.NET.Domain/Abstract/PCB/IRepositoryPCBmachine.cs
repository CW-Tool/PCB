using PCB.NET.Domain.Model.WorkshopPCB.Machine;
using System.Linq;

namespace PCB.NET.Domain.Abstract.PCB
{
    public interface IRepositoryPCBmachine
    {
        IQueryable<Ebso> Ebso { get; }
        IQueryable<Dvc> Dvc { get; }
    }
}
