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
        public Task AddMapAsync(Map context)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMapAsync(Map context)
        {
            throw new NotImplementedException();
        }

        public Task EditMapAsync(Map context)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region MapBoard

        public Task AddMapBoardAsync(MapBoard context)
        {
            throw new NotImplementedException();
        }

        public Task EditMapBoardAsync(MapBoard context)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMapBoardAsync(MapBoard context)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
