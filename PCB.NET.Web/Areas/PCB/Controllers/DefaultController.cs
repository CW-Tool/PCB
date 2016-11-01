using NLog;
using PCB.NET.Domain.Abstract.PCB;
using System.Web.Mvc;

namespace PCB.NET.Web.Areas.PCB.Controllers
{
    public class DefaultController : Controller
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();
        public IRepositoryPCBmachine _repositoryPCBmachine;
        public IRepositoryPCBwarehouse _repositoryPCBwarehouse;
        public IRepositoryPCBmap _repositoryPCBmap;
        public IRepositoryPCBemployee _repositoryPCBemployee;
    }
}