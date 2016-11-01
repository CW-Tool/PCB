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

            using (var contextDb = db.Database.BeginTransaction())
            {
                try
                {
                    db.GasBalloons.Add(model);
                    await db.SaveChangesAsync();

                    contextDb.Commit();
                }
                catch (Exception ex)
                {
                    // TODO: exception
                    contextDb.Rollback();
                }
            }
        }

        /// <summary>
        /// Deletes the gas balloon asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task DeleteGasBalloonAsync(GasBalloon model)
        {
            using (var contextDb = db.Database.BeginTransaction())
            {
                try
                {
                    db.GasBalloons.Remove(model);
                    await db.SaveChangesAsync();
                    contextDb.Commit();
                }
                catch (Exception ex)
                {
                    // TODO: exception
                    contextDb.Rollback();
                }
            }
        }

        /// <summary>
        /// Edits the gas balloon asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task EditGasBalloonAsync(GasBalloon model)
        {
            using (var contextDb = db.Database.BeginTransaction())
            {
                try
                {
                    // 
                    db.Entry(model).State = EntityState.Modified;
                    // 
                    await db.SaveChangesAsync();
                    // 
                    contextDb.Commit();
                }
                catch (Exception ex)
                {
                    // TODO: exception
                    contextDb.Rollback();
                }
            }
        }
        #endregion

    }
}
