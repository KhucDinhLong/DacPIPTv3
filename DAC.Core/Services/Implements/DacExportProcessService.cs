using DAC.Core.Services.Interfaces;
using DAC.DAL.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace DAC.Core.Services.Implements
{
    public class DacExportProcessService : IDacExportProcessService
    {
        public int UserLevel { get; set; }
        public BaseViewModel<DacExportVM> Create(DacExportVM exportInfoVM)
        {
            switch (exportInfoVM.CustomerLevel)
            {
                case 1:
                    return DacExportService.Create(exportInfoVM);
                case 2:
                    return DacExport1Service.Create(exportInfoVM);
                case 3:
                    return DacExport2Service.Create(exportInfoVM);
                case 4:
                    return DacExport3Service.Create(exportInfoVM);
                default:
                    return null;
            }
        }

        public BaseViewModel<bool> Delete(int exportInfoId, int CustomerLevel)
        {
            switch (CustomerLevel)
            {
                case 1:
                    return DacExportService.Delete(exportInfoId);
                case 2:
                    return DacExport1Service.Delete(exportInfoId);
                case 3:
                    return DacExport2Service.Delete(exportInfoId);
                case 4:
                    return DacExport3Service.Delete(exportInfoId);
                default:
                    return null;
            }
        }

        public BaseViewModel<DacExportVM> Edit(DacExportVM exportInfoVM)
        {
            switch (exportInfoVM.CustomerLevel)
            {
                case 1:
                    return DacExportService.Edit(exportInfoVM);
                case 2:
                    return DacExport1Service.Edit(exportInfoVM);
                case 3:
                    return DacExport2Service.Edit(exportInfoVM);
                case 4:
                    return DacExport3Service.Edit(exportInfoVM);
                default:
                    return null;
            }
        }

        public BaseViewModel<string> GenerateNewCode(int CustomerLevel)
        {
            switch (CustomerLevel)
            {
                case 1:
                    return DacExportService.GenerateNewCode();
                case 2:
                    return DacExport1Service.GenerateNewCode();
                case 3:
                    return DacExport2Service.GenerateNewCode();
                case 4:
                    return DacExport3Service.GenerateNewCode();
                default:
                    return null;
            }
        }

        public BaseViewModel<List<DacExportVM>> GetAll()
        {
            switch (UserLevel)
            {
                case 0:
                    var exportData = DacExportService.GetAll().ResponseData;
                    var export1Data = DacExport1Service.GetAll().ResponseData;
                    var export2Data = DacExport2Service.GetAll().ResponseData;
                    var export3Data = DacExport3Service.GetAll().ResponseData;
                    BaseViewModel<List<DacExportVM>> response = new BaseViewModel<List<DacExportVM>>();
                    response.ResponseData = exportData?.Union(export1Data)?.Union(export2Data)?.Union(export3Data)?.ToList();
                    return response;
                case 1:
                    return DacExportService.GetAll();
                case 2:
                    return DacExport1Service.GetAll();
                case 3:
                    return DacExport2Service.GetAll();
                case 4:
                    return DacExport3Service.GetAll();
                default:
                    return null;
            }
        }

        public BaseViewModel<DacExportVM> GetByCode(string OrderNumber, int CustomerLevel)
        {
            switch (CustomerLevel)
            {
                case 1:
                    return DacExportService.GetByCode(OrderNumber);
                case 2:
                    return DacExport1Service.GetByCode(OrderNumber);
                case 3:
                    return DacExport2Service.GetByCode(OrderNumber);
                case 4:
                    return DacExport3Service.GetByCode(OrderNumber);
                default:
                    return null;
            }
        }

        public BaseViewModel<DacExportVM> GetDetail(int Id, int CustomerLevel)
        {
            switch (CustomerLevel)
            {
                case 1:
                    return DacExportService.GetDetail(Id);
                case 2:
                    return DacExport1Service.GetDetail(Id);
                case 3:
                    return DacExport2Service.GetDetail(Id);
                case 4:
                    return DacExport3Service.GetDetail(Id);
                default:
                    return null;
            }
        }

        public BaseViewModel<bool> InvalidProductCode(string DacCode, string ProductCode, int CustomerLevel)
        {
            switch (CustomerLevel)
            {
                case 1:
                    return DacExportService.InvalidProductCode(DacCode, ProductCode);
                case 2:
                    return DacExport1Service.InvalidProductCode(DacCode, ProductCode);
                case 3:
                    return DacExport2Service.InvalidProductCode(DacCode, ProductCode);
                case 4:
                    return DacExport3Service.InvalidProductCode(DacCode, ProductCode);
                default:
                    return null;
            }
        }

        public bool RestoreData(int CustomerLevel)
        {
            switch (CustomerLevel)
            {
                case 1:
                    return DacExportService.RestoreData();
                case 2:
                    return DacExport1Service.RestoreData();
                case 3:
                    return DacExport2Service.RestoreData();
                case 4:
                    return DacExport3Service.RestoreData();
                default:
                    return false;
            }
        }
    }
}
