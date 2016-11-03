using PCB.NET.Domain.Abstract.PCB;
using System.Linq;
using PCB.NET.Domain.Model.WorkshopPCB.Machine;
using PCB.NET.Domain.Model;
using System;
using System.Threading.Tasks;

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
        public Task AddDvcAsync(Dvc context)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDvcAsync(Dvc context)
        {
            throw new NotImplementedException();
        }

        public Task EditDvcAsync(Dvc context)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region EBSO
        public Task AddEbsoAsync(Ebso context)
        {
            throw new NotImplementedException();
        }

        public Task EditEbsoAsync(Ebso context)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEbsoAsync(Ebso context)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
