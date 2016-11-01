using AutoMapper;
using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;
using PCB.NET.Web.Areas.PCB.Models.WarehouseViewModel;

namespace PCB.NET.Web
{
    public class MappingConfig
    {
        internal static MapperConfiguration MapperConfigGasBalloon;
        internal static MapperConfiguration MapperConfigHanging;
        public static void RegisterMapping()
        {
            MapperConfigGasBalloon = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GasBalloon, GasBalloonViewModel>().ReverseMap();
                cfg.CreateMap<Hanging, HangingViewModel>().ReverseMap();

            });
        }
    }
}