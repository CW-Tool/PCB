using PCB.NET.Domain.Abstract.PCB;
using System.Web.Mvc;

namespace PCB.NET.Web.Areas.PCB.Controllers
{
    [Authorize]
    public class DefaultController : Controller
    {
        public IRepositoryPCBmachine _repositoryPCBmachine;
        public IRepositoryPCBwarehouse _repositoryPCBwarehouse;
    }
}