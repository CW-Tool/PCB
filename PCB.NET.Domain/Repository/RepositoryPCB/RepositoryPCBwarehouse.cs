using PCB.NET.Domain.Abstract.PCB;
using PCB.NET.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;

namespace PCB.NET.Domain.Repository.RepositoryPCB
{
    public class RepositoryPCBwarehouse : IRepositoryPCBwarehouse
    {
        private ModelContext db = new ModelContext();

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
    }
}
