using PCB.NET.Domain.Abstract.PCB;
using System.Web.Mvc;

namespace PCB.NET.Web.Areas.PCB.Controllers
{
    public class DefaultController : Controller
    {
        public IRepositoryPCBmachine _repositoryPCBmachine;
        public IRepositoryPCBwarehouse _repositoryPCBwarehouse;
    }
}