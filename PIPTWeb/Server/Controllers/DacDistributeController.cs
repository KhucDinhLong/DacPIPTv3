using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIPTWeb.Shared;
using PIPTWeb.Shared.Data;
using PIPTWeb.Shared.Models;
using PIPTWeb.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIPTWeb.Server.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DacDistributeController : PIPTBaseController
    {
        private readonly PIPTDbContext _dbContext;
        private readonly UserManager<SecUsers> _userManager;
        public DacDistributeController(PIPTDbContext dbContext, UserManager<SecUsers> userManager) :base(dbContext, userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<ResultApiModel<DacDistributeModel>> GetPagingDistribute([FromBody] PaginatedInputModel pagination)
        {
            PaginatedList<DacDistributeModel> paginatedList;
            var resultApiModel = new ResultApiModel<DacDistributeModel>();
            try
            {
                var queryable = from d in _dbContext.DacDistributeToAgency
                                join asrc in _dbContext.DacAgency on d.SrcAgencyId equals asrc.ID
                                join ades in _dbContext.DacAgency on d.DesAgencyId equals ades.ID
                                select new DacDistributeModel
                                {
                                    dacDistributeToAgency = new DacDistributeToAgencyModel
                                    {
                                        ID = d.ID,
                                        OrderNumber = d.OrderNumber,
                                        CreatedDate = d.CreatedDate,
                                        ProductCode = d.ProductCode,
                                        SrcAgencyId = d.SrcAgencyId,
                                        DesAgencyId = d.DesAgencyId,
                                        ProvinceCode = d.ProvinceCode,
                                        Quantity = d.Quantity,
                                        Description = d.Description,
                                        Active = d.Active,
                                        StockID = d.StockID,
                                        CustomerId = d.CustomerId,
                                        SrcAgencyCode = asrc.Code,
                                        DesAgencyCode = ades.Code
                                    }
                                };

                #region [Filter]
                if (pagination != null)
                {
                    if (pagination.FilterParams != null)
                        queryable = FilterUtility.Filter<DacDistributeModel>.FilteredData(pagination.FilterParams, queryable) ?? queryable;
                }
                #endregion
                #region [Sorting]
                if (pagination != null && pagination.SortingParams != null)
                {
                    if (pagination.SortingParams.Count() > 0 && Enum.IsDefined(typeof(SortingUtility.SortOrders), pagination.SortingParams.Select(x => x.SortOrder)))
                        queryable = SortingUtility.Sorting<DacDistributeModel>.SortData(queryable, pagination.SortingParams);
                }
                #endregion
                #region [Grouping]
                if (pagination != null && pagination.GroupingColumns != null)
                {
                    if (pagination.GroupingColumns.Count() > 0)
                        queryable = SortingUtility.Sorting<DacDistributeModel>.GroupingData(queryable, pagination.GroupingColumns) ?? queryable;
                }
                #endregion
                #region [Paging]
                if (pagination != null)
                {
                    paginatedList = await PaginatedList<DacDistributeModel>.CreateAsync(queryable, pagination.PageNumber, pagination.PageSize);
                    pagination.PagesQuantity = paginatedList.TotalPages;
                    resultApiModel.Data = paginatedList.Data;
                    resultApiModel.Records = paginatedList.Data.Count();
                }
                else
                {
                    resultApiModel.Data = queryable;
                    resultApiModel.Records = queryable.Count();
                }
                #endregion
                resultApiModel.Status = "Success";
                resultApiModel.Code = "200";
                resultApiModel.Message = "Thành công";
                resultApiModel.Pagination = pagination;
            }
            catch (Exception ex)
            {

            }
            return resultApiModel;
        }

        [HttpPost("GetPagingDistributeByUserName")]
        public async Task<ResultApiModel<DacDistributeModel>> GetPagingDistributeByUserName([FromBody] PaginatedInputModel pagination, [FromQuery] string UserName)
        {
            var currentUser = this.User;
            PaginatedList<DacDistributeModel> paginatedList;
            var resultApiModel = new ResultApiModel<DacDistributeModel>();
            try
            {
                var queryable = from d in _dbContext.DacDistributeToAgency
                                join a in _dbContext.DacAgency on d.SrcAgencyId equals a.ID
                                join u in _dbContext.SecUsers on a.ID equals u.AgencyId
                                join ades in _dbContext.DacAgency on d.DesAgencyId equals ades.ID
                                where u.UserName == UserName
                                select new DacDistributeModel
                                {
                                    dacDistributeToAgency = new DacDistributeToAgencyModel
                                    {
                                        ID = d.ID,
                                        OrderNumber = d.OrderNumber,
                                        CreatedDate = d.CreatedDate,
                                        ProductCode = d.ProductCode,
                                        SrcAgencyId = d.SrcAgencyId,
                                        DesAgencyId = d.DesAgencyId,
                                        ProvinceCode = d.ProvinceCode,
                                        Quantity = d.Quantity,
                                        Description = d.Description,
                                        Active = d.Active,
                                        StockID = d.StockID,
                                        CustomerId = d.CustomerId,
                                        SrcAgencyCode = a.Code,
                                        DesAgencyCode = ades.Code
                                    }
                                };

                #region [Filter]
                if (pagination != null)
                {
                    if (pagination.FilterParams != null)
                        queryable = FilterUtility.Filter<DacDistributeModel>.FilteredData(pagination.FilterParams, queryable) ?? queryable;
                }
                #endregion
                #region [Sorting]
                if (pagination != null && pagination.SortingParams != null)
                {
                    if (pagination.SortingParams.Count() > 0 && Enum.IsDefined(typeof(SortingUtility.SortOrders), pagination.SortingParams.Select(x => x.SortOrder)))
                        queryable = SortingUtility.Sorting<DacDistributeModel>.SortData(queryable, pagination.SortingParams);
                }
                #endregion
                #region [Grouping]
                if (pagination != null && pagination.GroupingColumns != null)
                {
                    if (pagination.GroupingColumns.Count() > 0)
                        queryable = SortingUtility.Sorting<DacDistributeModel>.GroupingData(queryable, pagination.GroupingColumns) ?? queryable;
                }
                #endregion
                #region [Paging]
                if (pagination != null)
                {
                    paginatedList = await PaginatedList<DacDistributeModel>.CreateAsync(queryable, pagination.PageNumber, pagination.PageSize);
                    pagination.PagesQuantity = paginatedList.TotalPages;
                    resultApiModel.Data = paginatedList.Data;
                    resultApiModel.Records = paginatedList.Data.Count();
                }
                else
                {
                    resultApiModel.Data = queryable;
                    resultApiModel.Records = queryable.Count();
                }
                #endregion
                resultApiModel.Status = "Success";
                resultApiModel.Code = "200";
                resultApiModel.Message = "Thành công";
                resultApiModel.Pagination = pagination;
            }
            catch (Exception ex)
            {

            }
            return resultApiModel;
        }
        [HttpPost("Create")]
        public async Task<ResultApiModel<DacDistributeModel>> Create(DacDistributeModel request)
        {
            var resultApiModel = new ResultApiModel<DacDistributeModel>();
            try
            {
                _dbContext.DacDistributeToAgency.Add(request.dacDistributeToAgency);
                //await _dbContext.SaveChangesAsync();
                foreach (var item in request.LstDistributeDetail)
                {
                    item.DistributorID = request.dacDistributeToAgency.ID;
                }
                _dbContext.DacDistributeToAgencyDetails.AddRange(request.LstDistributeDetail);
                await _dbContext.SaveChangesAsync();
                resultApiModel.Status = "Success";
                resultApiModel.Code = "201";
                resultApiModel.Message = "Thêm mới thành công!";
                resultApiModel.Data = null;
                resultApiModel.Records = 1;
                resultApiModel.Pagination = null;
            }
            catch (Exception ex)
            {
                resultApiModel.Status = "Eror";
                resultApiModel.Code = "";
                resultApiModel.Message = "Có lỗi xảy ra trong quá trình thêm dữ liệu!";
                resultApiModel.Data = null;
                resultApiModel.Records = 0;
                resultApiModel.Pagination = null;
                
            }
            return resultApiModel;
        }

        [HttpPut]
        public async Task<ResultApiModel<DacDistributeModel>> Edit(DacDistributeModel request)
        {
            var resultApiModel = new ResultApiModel<DacDistributeModel>();
            try
            {
                _dbContext.Entry(request.dacDistributeToAgency).State = EntityState.Modified;
                foreach (var item in request.LstDistributeDetail)
                {
                    _dbContext.Entry(item).State = EntityState.Modified;
                }
                await _dbContext.SaveChangesAsync();
                resultApiModel.Status = "Success";
                resultApiModel.Code = "200";
                resultApiModel.Message = "Cập nhật thành công!";
                resultApiModel.Data = null;
                resultApiModel.Records = 1;
                resultApiModel.Pagination = null;
            }
            catch (Exception ex)
            {
                resultApiModel.Status = "Eror";
                resultApiModel.Code = "";
                resultApiModel.Message = "Cập nhật thất bại!";
                resultApiModel.Data = null;
                resultApiModel.Records = 0;
                resultApiModel.Pagination = null;
            }
            return resultApiModel;
        }

        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            try
            {
                var LstDistributeDetail = _dbContext.DacDistributeToAgencyDetails.Where(x => x.DistributorID == id);
                if (LstDistributeDetail != null && LstDistributeDetail.Count() > 0)
                {
                    _dbContext.DacDistributeToAgencyDetails.RemoveRange(LstDistributeDetail);
                }
                var distributeToAgency = await _dbContext.DacDistributeToAgency.FindAsync(id);
                DacLogBook logBook = new DacLogBook();
                logBook.IPAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
                logBook.LogAction = "DELETE";
                logBook.LogDescription = "DacDistributeToAgency";
                logBook.LogContent = Newtonsoft.Json.JsonConvert.SerializeObject(distributeToAgency);
                logBook.LogTime = DateTime.Now;
                _dbContext.DacDistributeToAgency.Remove(distributeToAgency);
                await _dbContext.SaveChangesAsync();
                await Log(logBook);
                return "204";
            }
            catch (Exception ex)
            {
                DacLogBook logBook = new DacLogBook();
                logBook.IPAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
                logBook.LogAction = "DELETE";
                logBook.LogDescription = "DacDistributeToAgency";
                logBook.LogContent = "Error";
                logBook.LogTime = DateTime.Now;
                logBook.Exception = ex.Message;
                logBook.StackTrace = ex.StackTrace;
                await Log(logBook);
                return "";
            }
        }
        [HttpPost("Save")]
        public async Task<string> Save([FromBody] DacDistributeModel distributeModel, [FromQuery] bool IsUpdate)
        {
            try
            {
                var currentDistribute = _dbContext.DacDistributeToAgency.Where(x => x.OrderNumber == distributeModel.dacDistributeToAgency.OrderNumber).ToList();
                if (currentDistribute != null)
                {
                    foreach (var item in currentDistribute)
                    {
                        var LstDetail = _dbContext.DacDistributeToAgencyDetails.Where(x => x.DistributorID == item.ID);
                        if (LstDetail != null)
                            _dbContext.DacDistributeToAgencyDetails.RemoveRange(LstDetail);
                    }
                    _dbContext.DacDistributeToAgency.RemoveRange(currentDistribute);
                }
                if (!IsUpdate)
                {
                    var maxOrder = _dbContext.DacDistributeToAgency.Max(x => x.OrderNumber);
                    if (string.IsNullOrWhiteSpace(maxOrder))
                    {
                        maxOrder = "00001";
                    }
                    else
                    {
                        var maxOrderValue = int.Parse(maxOrder) + 1;
                        maxOrder = string.Format("{0:00000}", maxOrderValue);
                    }
                    distributeModel.dacDistributeToAgency.OrderNumber = maxOrder;
                }
                distributeModel.dacDistributeToAgency.Quantity = distributeModel.LstDistributeDetail.Count;
                _dbContext.DacDistributeToAgency.Add(distributeModel.dacDistributeToAgency);
                await _dbContext.SaveChangesAsync();
                foreach (var item in distributeModel.LstDistributeDetail)
                {
                    item.ID = 0;
                    item.DistributorID = distributeModel.dacDistributeToAgency.ID;
                }
                _dbContext.DacDistributeToAgencyDetails.AddRange(distributeModel.LstDistributeDetail);
                await _dbContext.SaveChangesAsync();
                DacLogBook logBook = new DacLogBook();
                logBook.IPAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
                if (IsUpdate)
                {
                    logBook.LogAction = "EDIT";
                }
                else
                {
                    logBook.LogAction = "CREATE";
                }
                logBook.LogDescription = "DacDistributeToAgency";
                logBook.LogContent = Newtonsoft.Json.JsonConvert.SerializeObject(distributeModel);
                logBook.LogTime = DateTime.Now;
                await Log(logBook);
                return "200";
            }
            catch (Exception ex)
            {
                DacLogBook logBook = new DacLogBook();
                logBook.IPAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
                if (IsUpdate)
                {
                    logBook.LogAction = "EDIT";
                }
                else
                {
                    logBook.LogAction = "CREATE";
                }
                logBook.LogDescription = "DacDistributeToAgency";
                logBook.LogContent = "Error";
                logBook.LogTime = DateTime.Now;
                logBook.Exception = ex.Message;
                logBook.StackTrace = ex.StackTrace;
                await Log(logBook);
                return "400";
            }
        }
        [HttpGet("MaxOrder")]
        public async Task<string> GetMaxOrder()
        {
            var maxOrder = await _dbContext.DacDistributeToAgency.MaxAsync(x => x.OrderNumber);
            if (string.IsNullOrWhiteSpace(maxOrder))
            {
                maxOrder = "00001";
            }
            else
            {
                var maxOrderValue = int.Parse(maxOrder) + 1;
                maxOrder = string.Format("{0:00000}", maxOrderValue);
            }
            return maxOrder;
        }
        [HttpPost("Valid")]
        public async Task<List<string>> CheckValidDistribute([FromBody] DacDistributeModel currentDistribute, [FromQuery] string UserName, [FromQuery] bool isUpdate)
        {
            var result = new List<string>();
            var User = await _dbContext.SecUsers.SingleOrDefaultAsync(x => x.UserName == UserName);
            if (User == null)
            {
                result.Add("401");
                return result;
            }
            DacAgency agency;
            if (User.IsAdmin.HasValue && User.IsAdmin.Value)
            {
                agency = _dbContext.DacAgency.FirstOrDefault(x => x.ID == currentDistribute.dacDistributeToAgency.SrcAgencyId);
            }
            else
            {
                agency = _dbContext.DacAgency.SingleOrDefault(x => x.ID == User.AgencyId);
            }
            if (agency == null)
            {
                result.Add("404");
                return result;
            }

            if (!string.IsNullOrWhiteSpace(agency.DependCode))
            {
                foreach (var item in currentDistribute.LstDistributeDetail)
                {
                    var distribute = (from d in _dbContext.DacDistributeToAgency
                                      join dd in _dbContext.DacDistributeToAgencyDetails on d.ID equals dd.DistributorID
                                      where d.DesAgencyId == agency.ID && dd.DacCode == item.DacCode
                                      select dd).ToList();
                    if (distribute == null || distribute.Count <= 0)
                    {
                        result.Add(item.DacCode + ": " + "Seri chưa nhận được từ đại lý cấp trên");
                    }
                    else
                    {
                        List<DacDistributeToAgencyDetails> distributed;
                        if (isUpdate)
                        {
                            distributed = (from d in _dbContext.DacDistributeToAgency
                                           join dd in _dbContext.DacDistributeToAgencyDetails on d.ID equals dd.DistributorID
                                           where d.DesAgencyId != agency.ID && d.DesAgencyId != item.ID && dd.DacCode == item.DacCode
                                           select dd).ToList();
                        }
                        else
                        {
                            distributed = (from d in _dbContext.DacDistributeToAgency
                                           join dd in _dbContext.DacDistributeToAgencyDetails on d.ID equals dd.DistributorID
                                           where d.DesAgencyId != agency.ID && dd.DacCode == item.DacCode
                                           select dd).ToList();
                        } 
                        
                        if (distributed != null && distribute.Count > 0)
                        {
                            result.Add(item.DacCode + ": " + "Seri đã được xuất cho đại lý khác");
                        }
                    }
                }
            }
            else
            {
                foreach (var distributeDetail in currentDistribute.LstDistributeDetail)
                {
                    List<DacDistributeToAgencyDetails> distribute;
                    if (isUpdate)
                    {
                        distribute = (from d in _dbContext.DacDistributeToAgency
                                      join dd in _dbContext.DacDistributeToAgencyDetails on d.ID equals dd.DistributorID
                                      where d.DesAgencyId != currentDistribute.dacDistributeToAgency.DesAgencyId && dd.DacCode == distributeDetail.DacCode
                                      select dd).ToList();
                    }
                    else
                    {
                        distribute = _dbContext.DacDistributeToAgencyDetails.Where(x => x.DacCode == distributeDetail.DacCode).ToList();
                    } 
                    
                    if (distribute != null && distribute.Count > 0)
                    {
                        result.Add(distributeDetail.DacCode + ": " + "Seri đã được xuất cho đại lý khác");
                    }
                }
            }
            return result;
        }
        [HttpPost("DeleteSeri")]
        public async Task<string> DeleteSeri([FromBody] List<DacDistributeToAgencyDetails> LstDeleteSeri)
        {
            try
            {
                var distribute = await _dbContext.DacDistributeToAgency.FirstOrDefaultAsync(x => x.ID == LstDeleteSeri[0].DistributorID.Value);
                DacLogBook logBook = new DacLogBook();
                logBook.IPAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
                logBook.LogAction = "DELETEDETAIL";
                logBook.LogDescription = "DacDistributeToAgency";
                logBook.LogContent = Newtonsoft.Json.JsonConvert.SerializeObject(LstDeleteSeri) + "DistributeID: " + distribute.ID;
                logBook.LogTime = DateTime.Now;
                _dbContext.DacDistributeToAgencyDetails.RemoveRange(LstDeleteSeri);
                await _dbContext.SaveChangesAsync();
                var LstDetail = _dbContext.DacDistributeToAgencyDetails.Where(x => x.DistributorID == distribute.ID);
                if (LstDetail != null)
                {
                    distribute.Quantity = LstDetail.Count();
                }
                else
                {
                    distribute.Quantity = 0;
                }
                _dbContext.Entry(distribute).State = EntityState.Modified;  
                await _dbContext.SaveChangesAsync();
                await Log(logBook);
                return "204";
            }
            catch (Exception ex)
            {
                DacLogBook logBook = new DacLogBook();
                logBook.IPAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
                logBook.LogAction = "DELETEDETAIL";
                logBook.LogDescription = "DacDistributeToAgency";
                logBook.LogContent = "Error";
                logBook.LogTime = DateTime.Now;
                logBook.Exception = ex.Message;
                logBook.StackTrace = ex.StackTrace;
                await Log(logBook);
                return "";
            }
        }
        [HttpGet("GetDetailByDistributeId")]
        public async Task<List<DacDistributeToAgencyDetails>> GetDetailByDistributeId([FromQuery] int DistributeId)
        {
            var LstDetail = _dbContext.DacDistributeToAgencyDetails.Where(x => x.DistributorID == DistributeId);
            if (LstDetail != null)
                return await LstDetail.ToListAsync();
            return new List<DacDistributeToAgencyDetails>();
        }
    }
}
