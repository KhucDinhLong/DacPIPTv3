using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAC.Core.Services.Implements
{
    public class DacRegionService : IDacRegionService
    {
        public BaseViewModel<List<DacRegion>> GetAll()
        {
            var response = new BaseViewModel<List<DacRegion>>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    response.ResponseData = db.DacRegion.OrderByDescending(x => x.CreatedDate).ToList();
                }
            }
            catch (Exception ex) { response.ex = ex; }
            return response;
        }

        public BaseViewModel<DacRegion> GetById(int id)
        {
            var response = new BaseViewModel<DacRegion>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    response.ResponseData = db.DacRegion.FirstOrDefault(x => x.ID == id);
                }
            }
            catch (Exception ex) { response.ex = ex; }
            return response;
        }

        public BaseViewModel<DacRegion> Create(DacRegion region)
        {
            var response = new BaseViewModel<DacRegion>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    region.CreatedDate = DateTime.Now;
                    db.DacRegion.Add(region);
                    db.SaveChanges();
                    response.ResponseData = region;
                }
            }
            catch (Exception ex) { response.ex = ex; }
            return response;
        }

        public BaseViewModel<DacRegion> Edit(DacRegion region)
        {
            var response = new BaseViewModel<DacRegion>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    region.ModifiedDate = DateTime.Now;
                    db.Entry(region).State = EntityState.Modified;
                    db.SaveChanges();
                    response.ResponseData = region;
                }
            }
            catch (Exception ex) { response.ex = ex; }
            return response;
        }

        public BaseViewModel<bool> Delete(int id)
        {
            var response = new BaseViewModel<bool>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    var entity = db.DacRegion.FirstOrDefault(x => x.ID == id);
                    if (entity != null)
                    {
                        db.DacRegion.Remove(entity);
                        db.SaveChanges();
                        response.ResponseData = true;
                    }
                    else response.ResponseData = false;
                }
            }
            catch (Exception ex)
            {
                response.ResponseData = false;
                response.ex = ex;
            }
            return response;
        }
    }
}
