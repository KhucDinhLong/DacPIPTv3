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
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly PIPTDbContext _dbContext;
        public CustomersController(PIPTDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public async Task<ResultApiModel<Customers>> GetPagingCustomers([FromBody] PaginatedInputModel pagination)
        {
            PaginatedList<Customers> paginatedList;
            var resultApiModel = new ResultApiModel<Customers>();
            try
            {
                var queryable = _dbContext.Customers.AsQueryable();
                #region [Filter]
                if (pagination != null)
                {
                    if (pagination.FilterParams != null)
                        queryable = FilterUtility.Filter<Customers>.FilteredData(pagination.FilterParams, queryable) ?? queryable;
                }
                #endregion
                #region [Sorting]
                if (pagination != null && pagination.SortingParams != null)
                {
                    if (pagination.SortingParams.Count() > 0 && Enum.IsDefined(typeof(SortingUtility.SortOrders), pagination.SortingParams.Select(x => x.SortOrder)))
                        queryable = SortingUtility.Sorting<Customers>.SortData(queryable, pagination.SortingParams);
                }
                #endregion
                #region [Grouping]
                if (pagination != null && pagination.GroupingColumns != null)
                {
                    if (pagination.GroupingColumns.Count() > 0)
                        queryable = SortingUtility.Sorting<Customers>.GroupingData(queryable, pagination.GroupingColumns) ?? queryable;
                }
                #endregion
                #region [Paging]
                if (pagination != null)
                {
                    paginatedList = await PaginatedList<Customers>.CreateAsync(queryable, pagination.PageNumber, pagination.PageSize);
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
        [HttpGet]
        public async Task<List<Customers>> GetCustomers([FromQuery] bool? Active)
        {
            if (!Active.HasValue)
            {
                try
                {
                    var customers = await _dbContext.Customers.ToListAsync();
                    return customers;
                }
                catch (Exception ex)
                {

                    return new List<Customers>();
                }
            }
            else
            {
                try
                {
                    var customers = await _dbContext.Customers.Where(x => x.Active == Active).ToListAsync();
                    return customers;
                }
                catch (Exception ex)
                {

                    return new List<Customers>();
                }
            }
        }
        [HttpGet("GetCustomerById")]
        public async Task<Customers> GetAgencyById([FromQuery] int CustomerId)
        {
            try
            {
                var customer = await _dbContext.Customers.FindAsync(CustomerId);
                return customer;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet("GetCustomerByCode")]
        public async Task<Customers> GetCustomerByCode([FromQuery] string CustomerCode)
        {
            try
            {
                var customer = await _dbContext.Customers.SingleOrDefaultAsync(x => x.Code == CustomerCode);
                return customer;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet("GetCustomerByUserName")]
        public async Task<Customers> GetCustomerByUserName([FromQuery] string UserName)
        {
            try
            {
                var customer = await ((from u in _dbContext.SecUsers
                                       join a in _dbContext.DacAgency on u.AgencyId equals a.ID
                                       join c in _dbContext.Customers on a.CustomerId equals c.Id
                                       where u.UserName == UserName
                                       select c).SingleOrDefaultAsync());
                return customer;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        [HttpPost("Create")]
        public async Task<ResultApiModel<Customers>> Create(Customers request)
        {
            var resultApiModel = new ResultApiModel<Customers>();
            try
            {
                var customer = _dbContext.Customers.FirstOrDefault(x => x.Code == request.Code);
                if (customer != null)
                {
                    resultApiModel.Status = "Eror";
                    resultApiModel.Code = "500";
                    resultApiModel.Message = "Mã khách hàng đã tồn tại!";
                    resultApiModel.Data = null;
                    resultApiModel.Records = 0;
                    resultApiModel.Pagination = null;
                    return resultApiModel;
                }
                _dbContext.Customers.Add(request);
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
        public async Task<ResultApiModel<Customers>> Edit(Customers request)
        {
            var resultApiModel = new ResultApiModel<Customers>();
            try
            {
                _dbContext.Entry(request).State = EntityState.Modified;
                _dbContext.Entry(request).Property(x => x.Code).IsModified = false;
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
                var customer = await _dbContext.Customers.FindAsync(id);
                if (customer != null)
                {
                    var ChildrenAgencies = _dbContext.DacAgency.Where(x => x.CustomerId == customer.Id);
                    if (ChildrenAgencies != null && ChildrenAgencies.Count() > 0)
                    {
                        return "500";
                    }
                    _dbContext.Customers.Remove(customer);
                    await _dbContext.SaveChangesAsync();
                    return "204";
                }
                else
                {
                    return "200";
                }

            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
