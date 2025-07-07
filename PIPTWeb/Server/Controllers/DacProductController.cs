using Microsoft.AspNetCore.Authorization;
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
    public class DacProductController : ControllerBase
    {
        private readonly PIPTDbContext _dbContext;
        public DacProductController(PIPTDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public async Task<ResultApiModel<DacProduct>> GetPagingProducts([FromBody] PaginatedInputModel pagination)
        {
            PaginatedList<DacProduct> paginatedList;
            var resultApiModel = new ResultApiModel<DacProduct>();
            try
            {
                var queryable = _dbContext.DacProduct.AsQueryable();
                #region [Filter]
                if (pagination != null)
                {
                    if (pagination.FilterParams != null)
                        queryable = FilterUtility.Filter<DacProduct>.FilteredData(pagination.FilterParams, queryable) ?? queryable;
                }
                #endregion
                #region [Sorting]
                if (pagination != null && pagination.SortingParams != null)
                {
                    if (pagination.SortingParams.Count() > 0 && Enum.IsDefined(typeof(SortingUtility.SortOrders), pagination.SortingParams.Select(x => x.SortOrder)))
                        queryable = SortingUtility.Sorting<DacProduct>.SortData(queryable, pagination.SortingParams);
                }
                #endregion
                #region [Grouping]
                if (pagination != null && pagination.GroupingColumns != null)
                {
                    if (pagination.GroupingColumns.Count() > 0)
                        queryable = SortingUtility.Sorting<DacProduct>.GroupingData(queryable, pagination.GroupingColumns) ?? queryable;
                }
                #endregion
                #region [Paging]
                if (pagination != null)
                {
                    paginatedList = await PaginatedList<DacProduct>.CreateAsync(queryable, pagination.PageNumber, pagination.PageSize);
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
        public async Task<List<DacProduct>> GetProducts()
        {
            try
            {
                var Products = await _dbContext.DacProduct.ToListAsync();
                return Products;
            }
            catch (Exception ex)
            {
                return new List<DacProduct>();
            }
        }
        [HttpGet("GetProductById")]
        public async Task<DacProduct> GetProductById([FromQuery] int ProductId)
        {
            try
            {
                var Product = await _dbContext.DacProduct.FindAsync(ProductId);
                return Product;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet("GetProductByCode")]
        public async Task<DacProduct> GetProductByCode([FromQuery] string ProductCode)
        {
            try
            {
                var Product = await _dbContext.DacProduct.SingleOrDefaultAsync(x => x.Code == ProductCode);
                return Product;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet("GetProductByName")]
        public async Task<List<DacProduct>> GetProductByName([FromQuery] string ProductName)
        {
            try
            {
                var LstProduct = await _dbContext.DacProduct.Where(x => x.Name == ProductName).ToListAsync();
                return LstProduct;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet("GetProductByUserName")]
        public async Task<ResultApiModel<DacProduct>> GetChildrenAgencyByUserName([FromQuery] string UserName)
        {
            var resultApiModel = new ResultApiModel<DacProduct>();
            try
            {
                var queryable = await ((from u in _dbContext.SecUsers
                                        join a in _dbContext.DacAgency on u.AgencyId equals a.ID
                                        join p in _dbContext.DacProduct on a.CustomerId equals p.CustomerId
                                        where u.UserName == UserName
                                        select p).ToListAsync());
                resultApiModel.Data = queryable;
                resultApiModel.Status = "Success";
                resultApiModel.Code = "200";
                resultApiModel.Message = "Thành công";
                resultApiModel.Pagination = null;
            }
            catch (Exception ex)
            {
                resultApiModel.Status = "Eror";
                resultApiModel.Code = "";
                resultApiModel.Message = "Có lỗi xảy ra trong quá trình lấy dữ liệu!";
                resultApiModel.Data = null;
                resultApiModel.Records = 0;
                resultApiModel.Pagination = null;
            }
            return resultApiModel;
        }
        [HttpPost("Create")]
        public async Task<ResultApiModel<DacProduct>> Create(DacProduct request)
        {
            var resultApiModel = new ResultApiModel<DacProduct>();
            try
            {
                var product = _dbContext.DacProduct.FirstOrDefault(x => x.Code == request.Code);
                if (product != null)
                {
                    resultApiModel.Status = "Eror";
                    resultApiModel.Code = "500";
                    resultApiModel.Message = "Mã sản phẩm đã tồn tại!";
                    resultApiModel.Data = null;
                    resultApiModel.Records = 0;
                    resultApiModel.Pagination = null;
                    return resultApiModel;
                }
                _dbContext.DacProduct.Add(request);
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
        public async Task<ResultApiModel<DacProduct>> Edit(DacProduct request)
        {
            var resultApiModel = new ResultApiModel<DacProduct>();
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
                var Product = await _dbContext.DacProduct.FindAsync(id);
                if (Product != null)
                {
                    var Distribute = _dbContext.DacDistributeToAgency.Where(x => x.ProductCode == Product.Code);
                    if (Distribute != null && Distribute.Count() > 0)
                    {
                        return "500";
                    }
                    _dbContext.DacProduct.Remove(Product);
                    await _dbContext.SaveChangesAsync();
                    return "204";
                }
                else
                    return "200";
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
