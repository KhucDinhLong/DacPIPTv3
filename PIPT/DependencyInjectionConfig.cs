using DAC.Core.Services.Interfaces;
using DAC.Core.Services.Implements;
using Unity;

namespace PIPT
{
    public static class DependencyInjectionConfig
    {
        public static IUnityContainer RegisterDependencies()
        {
            var container = new UnityContainer();

            // Đăng ký service vào DI container
            container.RegisterType<IDacProductService, DacProductService>();
            container.RegisterType<IDacPackageService, DacPackageService>();
            container.RegisterType<IDacPackageDetailService, DacPackageDetailService>();
            container.RegisterType<IDacProductCategoryService, DacProductCategoryService>();
            container.RegisterType<IDacProductUnitService, DacProductUnitService>();
            container.RegisterType<IDacAgencyService, DacAgencyService>();
            container.RegisterType<IProvinceService, ProvinceService>();
            container.RegisterType<IDacRegionService, DacRegionService>();
            container.RegisterType<INationalityService, NationalityService>();
            container.RegisterType<IDacStoreService, DacStoreService>();
            container.RegisterType<IDistrictService, DistrictService>();
            container.RegisterType<ISecUsersService, SecUsersService>();
            container.RegisterType<IAuthenticationService, AuthenticationService>();
            container.RegisterType<ISecGroupsService, SecGroupsService>();
            container.RegisterType<ISecGroupUserService, SecGroupUserService>();
            container.RegisterType<IDacInsertToWarehouseService, DacInsertToWarehouseService>();
            container.RegisterType<IDacInsertToWarehouseDetailsService, DacInsertToWarehouseDetailsService>();
            container.RegisterType<ISecConfigService, SecConfigService>();
            container.RegisterType<IDacStockService, DacStockService>();
            container.RegisterType<IDacDistributeToAgencyService, DacDistributeToAgencyService>();
            container.RegisterType<IDacDistributeToAgencyDetailsService, DacDistributeToAgencyDetailsService>();
            container.RegisterType<IDacDistributeToStoreService, DacDistributeToStoreService>();
            container.RegisterType<IDacDistributeToStoreDetailsService, DacDistributeToStoreDetailsService>();

            return container;
        }
    }
}
