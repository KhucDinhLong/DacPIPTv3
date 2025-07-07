using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAC.Core.Services.Implements
{
    public class ProvinceService : IProvinceService
    {
        public BaseViewModel<List<Province>> GetAll()
        {
            var response = new BaseViewModel<List<Province>>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    response.ResponseData = db.Province.OrderByDescending(x => x.Id).ToList();
                }
            }
            catch (Exception ex) { response.ex = ex; }
            return response;
        }

        public BaseViewModel<Province> GetById(int id)
        {
            var response = new BaseViewModel<Province>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    response.ResponseData = db.Province.FirstOrDefault(x => x.Id == id);
                }
            }
            catch (Exception ex) { response.ex = ex; }
            return response;
        }

        public BaseViewModel<Province> Create(Province province)
        {
            var response = new BaseViewModel<Province>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    db.Province.Add(province);
                    db.SaveChanges();
                    response.ResponseData = province;
                }
            }
            catch (Exception ex) { response.ex = ex; }
            return response;
        }

        public BaseViewModel<Province> Edit(Province province)
        {
            var response = new BaseViewModel<Province>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    db.Entry(province).State = EntityState.Modified;
                    db.SaveChanges();
                    response.ResponseData = province;
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
                    var entity = db.Province.FirstOrDefault(x => x.Id == id);
                    if (entity != null)
                    {
                        db.Province.Remove(entity);
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
