using PCB.NET.Domain.Abstract.PCB;
using PCB.NET.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCB.NET.Domain.Model.WorkshopPCB.Map;
using System.Data.Entity;

namespace PCB.NET.Domain.Repository.RepositoryPCB
{
    public class RepositoryPCBmap : IRepositoryPCBmap
    {
        private ModelContext db = new ModelContext();

        #region Properties
        public IQueryable<MapBoard> MapBoard
        {
            get
            {
                return db.MapBoards;
            }
        }

        public IQueryable<Map> Map
        {
            get
            {
                return db.Maps;
            }
        }
        #endregion

        #region Map
        public async Task AddMapAsync(Map context)
        {
            try
            {
                context.Modified = DateTime.Now;

                db.Maps.Add(context);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteMapAsync(Map context)
        {
            try
            {
                db.Maps.Remove(context);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task EditMapAsync(Map context)
        {
            try
            {
                context.Modified = DateTime.Now;

                db.Entry(context).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region MapBoard

        public async Task AddMapBoardAsync(MapBoard context)
        {
            try
            {
                db.MapBoards.Add(context);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task EditMapBoardAsync(MapBoard context)
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

        public async Task DeleteMapBoardAsync(MapBoard context)
        {
            try
            {
                db.MapBoards.Remove(context);
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
