using DAC.Core.Services.Interfaces;
using DAC.DAL.ViewModels;
using System.Collections.Generic;

namespace DAC.Core.Services.Implements
{
    public class DacExportDetailProcessService : IDacExportDetailProcessService
    {
        public BaseViewModel<bool> AddRange(List<DacExportDetailVM> LstDetail, int CustomerLevel)
        {
            switch (CustomerLevel)
            {
                case 1:
                    return DacExportDetailService.AddRange(LstDetail);
                case 2:
                    return DacExportDetail1Service.AddRange(LstDetail);
                case 3:
                    return DacExportDetail2Service.AddRange(LstDetail);
                case 4:
                    return DacExportDetail3Service.AddRange(LstDetail);
                default:
                    return null;
            }
        }

        public BaseViewModel<bool> Exportable(string DacCode, string CustomerCode, int CustomerLevel)
        {
            switch (CustomerLevel)
            {
                case 1:
                    return DacExportDetailService.Exportable(DacCode, CustomerCode);
                case 2:
                    return DacExportDetail1Service.Exportable(DacCode, CustomerCode);
                case 3:
                    return DacExportDetail2Service.Exportable(DacCode, CustomerCode);
                case 4:
                    return DacExportDetail3Service.Exportable(DacCode, CustomerCode);
                default:
                    return null;
            }
        }

        public BaseViewModel<bool> DeleteByDacCode(List<string> LstDacCode, int CustomerLevel)
        {
            switch (CustomerLevel)
            {
                case 1:
                    return DacExportDetailService.DeleteByDacCode(LstDacCode);
                case 2:
                    return DacExportDetail1Service.DeleteByDacCode(LstDacCode);
                case 3:
                    return DacExportDetail2Service.DeleteByDacCode(LstDacCode);
                case 4:
                    return DacExportDetail3Service.DeleteByDacCode(LstDacCode);
                default:
                    return null;
            }
        }

        public BaseViewModel<bool> DeleteByDacCode(string DacCode, int CustomerLevel)
        {
            switch (CustomerLevel)
            {
                case 1:
                    var exported1 = DacExportDetailService.Exported(DacCode);
                    if (exported1.ResponseData)
                    {
                        return exported1;
                    }
                    return DacExportDetailService.DeleteByDacCode(DacCode);
                case 2:
                    var exported2 = DacExportDetail1Service.Exported(DacCode);
                    if (exported2.ResponseData)
                    {
                        return exported2;
                    }
                    return DacExportDetail1Service.DeleteByDacCode(DacCode);
                case 3:
                    var exported3 = DacExportDetail2Service.Exported(DacCode);
                    if (exported3.ResponseData)
                    {
                        return exported3;
                    }
                    return DacExportDetail2Service.DeleteByDacCode(DacCode);
                case 4:
                    return DacExportDetail3Service.DeleteByDacCode(DacCode);
                default:
                    return null;
            }
        }

        public BaseViewModel<DacExportDetailVM> GetByDacCode(string DacCode, int CustomerLevel)
        {
            switch (CustomerLevel)
            {
                case 1:
                    return DacExportDetailService.GetByDacCode(DacCode);
                case 2:
                    return DacExportDetail1Service.GetByDacCode(DacCode);
                case 3:
                    return DacExportDetail2Service.GetByDacCode(DacCode);
                case 4:
                    return DacExportDetail3Service.GetByDacCode(DacCode);
                default:
                    return null;
            }
        }

        public BaseViewModel<DacExportVM> GetExportInfo(string DacCode, int CustomerLevel)
        {
            switch (CustomerLevel)
            {
                case 1:
                    return DacExportDetailService.GetExportInfo(DacCode);
                case 2:
                    return DacExportDetail1Service.GetExportInfo(DacCode);
                case 3:
                    return DacExportDetail2Service.GetExportInfo(DacCode);
                case 4:
                    return DacExportDetail3Service.GetExportInfo(DacCode);
                default:
                    return null;
            }
        }
    }
}
