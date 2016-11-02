using AutoMapper;
using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;
using PCB.NET.Web.Areas.PCB.Models.WarehouseViewModel;

namespace PCB.NET.Web
{
    public class MappingConfig
    {
        #region Fields
        internal static MapperConfiguration MapperConfigGasBalloon;
        internal static MapperConfiguration MapperConfigHanging;
        internal static MapperConfiguration MapperConfigSMD;
        internal static MapperConfiguration MapperConfigOtherStore;
        internal static MapperConfiguration MapperConfigSize;
        internal static MapperConfiguration MapperConfigPackage;
        #endregion

        #region Mapping
        public static void RegisterMapping()
        {
            MapperConfigGasBalloon = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GasBalloon, GasBalloonViewModel>().ReverseMap();

            });
            MapperConfigHanging = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Hanging, HangingViewModel>().ReverseMap();

            });
            MapperConfigSMD = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<SMD, SMDViewModel>().ReverseMap();
            });
            MapperConfigOtherStore = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<OtherStore, OtherStoreViewModel>().ReverseMap();
            });
            MapperConfigSize = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<Size, SizeViewModel>().ReverseMap();
            });
            MapperConfigPackage = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Package, PackageViewModel>().ReverseMap();
            });
        }
        #endregion
    }
}