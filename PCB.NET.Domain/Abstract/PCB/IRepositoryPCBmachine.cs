using PCB.NET.Domain.Model.WorkshopPCB.Machine;
using System.Linq;
using System.Threading.Tasks;

namespace PCB.NET.Domain.Abstract.PCB
{
    public interface IRepositoryPCBmachine
    {
        IQueryable<Ebso> Ebso { get; }
        IQueryable<Dvc> Dvc { get; }

        Task EditEbsoAsync(Ebso context);
        Task AddEbsoAsync(Ebso context);
        Task DeleteEbsoAsync(Ebso context);
        Task DeleteDvcAsync(Dvc context);
        Task EditDvcAsync(Dvc context);
        Task AddDvcAsync(Dvc context);
    }
}
