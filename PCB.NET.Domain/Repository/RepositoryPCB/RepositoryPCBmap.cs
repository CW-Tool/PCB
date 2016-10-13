using PCB.NET.Domain.Abstract.PCB;
using PCB.NET.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCB.NET.Domain.Model.WorkshopPCB.Map;

namespace PCB.NET.Domain.Repository.RepositoryPCB
{
    public class RepositoryPCBmap : IRepositoryPCBmap
    {
        private ModelContext db = new ModelContext();

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
    }
}
