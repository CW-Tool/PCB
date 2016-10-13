using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;
using System.Linq;

namespace PCB.NET.Domain.Abstract.PCB
{
    public interface IRepositoryPCBwarehouse
    {
        IQueryable<Board> Board { get; }
        IQueryable<GasBalloon> GasBalloon { get; }
        IQueryable<Hanging> Hanging { get; }
        IQueryable<SMD> SMD { get; }
        IQueryable<Size> Size { get; }
        IQueryable<Package> Package { get; }
        IQueryable<HangingItem> HangingItem { get; }
        IQueryable<SMDItem> SMDItem { get; }
    }
}
