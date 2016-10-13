using PCB.NET.Domain.Model.WorkshopPCB.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCB.NET.Domain.Abstract.PCB
{
    public interface IRepositoryPCBmap
    {
        IQueryable<Map> Map { get; }
        IQueryable<MapBoard> MapBoard { get; }
    }
}
