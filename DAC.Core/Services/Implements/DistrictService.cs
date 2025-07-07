using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAC.Core.Services.Implements
{
    public class DistrictService : IDistrictService
    {
        public BaseViewModel<List<District>> GetAll()
        {
            var response = new BaseViewModel<List<District>>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    response.ResponseData = db.District.OrderByDescending(x => x.Id).ToList();
                }
            }
            catch (Exception ex) { response.ex = ex; }
            return response;
        }

        public BaseViewModel<District> GetById(int id)
        {
            var response = new BaseViewModel<District>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    response.ResponseData = db.District.FirstOrDefault(x => x.Id == id);
                }
            }
            catch (Exception ex) { response.ex = ex; }
            return response;
        }

        public BaseViewModel<District> Create(District district)
        {
            var response = new BaseViewModel<District>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    db.District.Add(district);
                    db.SaveChanges();
                    response.ResponseData = district;
                }
            }
            catch (Exception ex) { response.ex = ex; }
            return response;
        }

        public BaseViewModel<District> Edit(District district)
        {
            var response = new BaseViewModel<District>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    db.Entry(district).State = EntityState.Modified;
                    db.SaveChanges();
                    response.ResponseData = district;
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
                    var entity = db.District.FirstOrDefault(x => x.Id == id);
                    if (entity != null)
                    {
                        db.District.Remove(entity);
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
