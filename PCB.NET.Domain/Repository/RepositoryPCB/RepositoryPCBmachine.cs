using PCB.NET.Domain.Abstract.PCB;
using System.Linq;
using PCB.NET.Domain.Model.WorkshopPCB.Machine;
using PCB.NET.Domain.Model;
using System;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PCB.NET.Domain.Repository.RepositoryPCB
{
    public class RepositoryPCBmachine : IRepositoryPCBmachine
    {
        private ModelContext db = new ModelContext();

        #region Properies
        public IQueryable<Dvc> Dvc
        {
            get
            {
                return db.Dvcs;
            }
        }

        public IQueryable<Ebso> Ebso
        {
            get
            {
                return db.Ebsos;
            }
        }
        #endregion

        #region DVC
        public async Task AddDvcAsync(Dvc context)
        {
            try
            {
                db.Dvcs.Add(context);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteDvcAsync(Dvc context)
        {
            try
            {
                db.Dvcs.Remove(context);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task EditDvcAsync(Dvc context)
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

        #region EBSO
        public async Task AddEbsoAsync(Ebso context)
        {
            try
            {
                db.Ebsos.Add(context);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task EditEbsoAsync(Ebso context)
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

        public async Task DeleteEbsoAsync(Ebso context)
        {
            try
            {
                db.Ebsos.Remove(context);
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
