using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;
using System.Linq;
using System.Threading.Tasks;

namespace PCB.NET.Domain.Abstract.PCB
{
    /// <summary>
    /// interface IRepositoryPCBwarehouse
    /// </summary>
    public interface IRepositoryPCBwarehouse
    {
        /// <summary>
        /// Gets the board.
        /// </summary>
        /// <value>
        /// The board.
        /// </value>
        IQueryable<Board> Board { get; }
        /// <summary>
        /// Gets the gas balloon.
        /// </summary>
        /// <value>
        /// The gas balloon.
        /// </value>
        IQueryable<GasBalloon> GasBalloon { get; }
        /// <summary>
        /// Gets the hanging.
        /// </summary>
        /// <value>
        /// The hanging.
        /// </value>
        IQueryable<Hanging> Hanging { get; }
        /// <summary>
        /// Gets the SMD.
        /// </summary>
        /// <value>
        /// The SMD.
        /// </value>
        IQueryable<SMD> SMD { get; }
        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        IQueryable<Size> Size { get; }
        /// <summary>
        /// Gets the package.
        /// </summary>
        /// <value>
        /// The package.
        /// </value>
        IQueryable<Package> Package { get; }
        /// <summary>
        /// Gets the hanging item map.
        /// </summary>
        /// <value>
        /// The hanging item map.
        /// </value>
        IQueryable<HangingItemMap> HangingItemMap { get; }
        /// <summary>
        /// Gets the SMD item map.
        /// </summary>
        /// <value>
        /// The SMD item map.
        /// </value>
        IQueryable<SMDItemMap> SMDItemMap { get; }
        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <value>
        /// The item.
        /// </value>
        IQueryable<Item> Item { get; }
        /// <summary>
        /// Gets the other store.
        /// </summary>
        /// <value>
        /// The other store.
        /// </value>
        IQueryable<OtherStore> OtherStore { get; }

        /// <summary>
        /// Adds the gas balloon asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task AddGasBalloonAsync(GasBalloon model);
        /// <summary>
        /// Edits the gas balloon asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task EditGasBalloonAsync(GasBalloon model);
        /// <summary>
        /// Deletes the gas balloon asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task DeleteGasBalloonAsync(GasBalloon model);
        Task AddHangingAsync(Hanging context);
        Task EditHangingAsync(Hanging context);
        Task DeleteHangingAsync(Hanging context);
        Task AddSMDAsync(SMD context);
        Task DeleteSMDAsync(SMD context);
        Task EditSMDAsync(SMD context);
        Task DeleteOtherStoreAsync(OtherStore context);
        Task EditOtherStoreAsync(OtherStore context);
        Task AddOtherStoreAsync(OtherStore context);
        Task DeleteSizeAsync(Size context);
        Task EditSizeAsync(Size context);
        Task AddSizeAsync(Size context);
        Task DeletePackageAsync(Package context);
        Task EditPackageAsync(Package context);
        Task AddPackageAsync(Package context);
    }
}
