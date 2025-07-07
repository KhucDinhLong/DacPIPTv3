using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAC.Core.Services.Implements
{
    public class NationalityService : INationalityService
    {
        public BaseViewModel<List<Nationality>> GetAll()
        {
            var response = new BaseViewModel<List<Nationality>>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    response.ResponseData = db.Nationality.OrderByDescending(x => x.Id).ToList();
                }
            }
            catch (Exception ex) { response.ex = ex; }
            return response;
        }

        public BaseViewModel<Nationality> GetById(int id)
        {
            var response = new BaseViewModel<Nationality>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    response.ResponseData = db.Nationality.FirstOrDefault(x => x.Id == id);
                }
            }
            catch (Exception ex) { response.ex = ex; }
            return response;
        }

        public BaseViewModel<Nationality> Create(Nationality nationality)
        {
            var response = new BaseViewModel<Nationality>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    db.Nationality.Add(nationality);
                    db.SaveChanges();
                    response.ResponseData = nationality;
                }
            }
            catch (Exception ex) { response.ex = ex; }
            return response;
        }

        public BaseViewModel<Nationality> Edit(Nationality nationality)
        {
            var response = new BaseViewModel<Nationality>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    db.Entry(nationality).State = EntityState.Modified;
                    db.SaveChanges();
                    response.ResponseData = nationality;
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
                    var entity = db.Nationality.FirstOrDefault(x => x.Id == id);
                    if (entity != null)
                    {
                        db.Nationality.Remove(entity);
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
