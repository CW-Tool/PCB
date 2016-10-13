using PCB.NET.Domain.Abstract.PCB;
using System.Linq;
using PCB.NET.Domain.Model.WorkshopPCB.Machine;
using PCB.NET.Domain.Model;

namespace PCB.NET.Domain.Repository.RepositoryPCB
{
    public class RepositoryPCBmachine : IRepositoryPCBmachine
    {
        private ModelContext db = new ModelContext();

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
    }
}
