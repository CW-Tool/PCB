using PCB.NET.Domain.Abstract.PCB;
using PCB.NET.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;
using System.Data.Entity;

namespace PCB.NET.Domain.Repository.RepositoryPCB
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="PCB.NET.Domain.Abstract.PCB.IRepositoryPCBwarehouse" />
    public class RepositoryPCBwarehouse : IRepositoryPCBwarehouse
    {
        private ModelContext db = new ModelContext();

        #region Properties Warehouse
        public IQueryable<Board> Board
        {
            get
            {
                return db.Boards;
            }
        }

        public IQueryable<GasBalloon> GasBalloon
        {
            get
            {
                return db.GasBalloons;
            }
        }

        public IQueryable<Hanging> Hanging
        {
            get
            {
                return db.Hangings;
            }
        }

        public IQueryable<HangingItemMap> HangingItemMap
        {
            get
            {
                return db.HangingItemMaps;
            }
        }

        public IQueryable<Item> Item
        {
            get
            {
                return db.Items;
            }
        }

        public IQueryable<OtherStore> OtherStore
        {
            get
            {
                return db.OtherStores;
            }
        }

        public IQueryable<Package> Package
        {
            get
            {
                return db.Packages;
            }
        }

        public IQueryable<Size> Size
        {
            get
            {
                return db.Sizes;
            }
        }

        public IQueryable<SMD> SMD
        {
            get
            {
                return db.SMDs;
            }
        }

        public IQueryable<SMDItemMap> SMDItemMap
        {
            get
            {
                return db.SMDItemMaps;
            }
        }
        #endregion

        #region GasBalloon
        /// <summary>
        /// Adds the gas balloon asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task AddGasBalloonAsync(GasBalloon model)
        {
            try
            {
                db.GasBalloons.Add(model);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes the gas balloon asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task DeleteGasBalloonAsync(GasBalloon model)
        {
            try
            {
                db.GasBalloons.Remove(model);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Edits the gas balloon asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task EditGasBalloonAsync(GasBalloon model)
        {
            try
            {
                db.Entry(model).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Hanging
        public async Task EditHangingAsync(Hanging context)
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

        public async Task DeleteHangingAsync(Hanging context)
        {
            try
            {
                db.Hangings.Remove(context);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddHangingAsync(Hanging context)
        {
            try
            {
                db.Hangings.Add(context);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region SMD
        public async Task EditSMDAsync(SMD context)
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

        public async Task DeleteSMDAsync(SMD context)
        {
            try
            {
                db.SMDs.Remove(context);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddSMDAsync(SMD context)
        {
            try
            {
                db.SMDs.Add(context);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region OtherStore
        public async Task EditOtherStoreAsync(OtherStore context)
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

        public async Task DeleteOtherStoreAsync(OtherStore context)
        {
            try
            {
                db.OtherStores.Remove(context);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddOtherStoreAsync(OtherStore context)
        {
            try
            {
                db.OtherStores.Add(context);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Size
        public async Task DeleteSizeAsync(Size context)
        {
            try
            {
                db.Sizes.Remove(context);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task EditSizeAsync(Size context)
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

        public async Task AddSizeAsync(Size context)
        {
            try
            {
                db.Sizes.Add(context);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Package
        public async Task DeletePackageAsync(Package context)
        {
            try
            {
                db.Packages.Remove(context);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task EditPackageAsync(Package context)
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

        public async Task AddPackageAsync(Package context)
        {
            try
            {
                db.Packages.Add(context);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Board
        public async Task AddBoardAsync(Board context)
        {
            try
            {
                db.Boards.Add(context);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteBoardAsync(Board context)
        {
            try
            {
                db.Boards.Remove(context);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task EditBoardAsync(Board context)
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

    }
}
