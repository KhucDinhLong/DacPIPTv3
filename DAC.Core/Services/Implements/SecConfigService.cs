using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAC.Core.Services.Implements
{
    public class SecConfigService : ISecConfigService
    {
        public BaseViewModel<SecConfig> Create(SecConfig NewConfig)
        {
            var response = new BaseViewModel<SecConfig>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    db.SecConfig.Add(NewConfig);
                    db.SaveChanges();
                    response.ResponseData = NewConfig;
                }
            }
            catch (Exception ex) { response.ex = ex; }
            return response;
        }

        public BaseViewModel<bool> Delete(int Id)
        {
            var response = new BaseViewModel<bool>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    var entity = db.SecConfig.FirstOrDefault(x => x.Id == Id);
                    if (entity != null)
                    {
                        db.SecConfig.Remove(entity);
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

        public BaseViewModel<SecConfig> Edit(SecConfig secConfig)
        {
            var response = new BaseViewModel<SecConfig>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    db.Entry(secConfig).State = EntityState.Modified;
                    db.SaveChanges();
                    response.ResponseData = secConfig;
                }
            }
            catch (Exception ex) { response.ex = ex; }
            return response;
        }

        public BaseViewModel<List<SecConfig>> GetAll()
        {
            var response = new BaseViewModel<List<SecConfig>>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    response.ResponseData = db.SecConfig.ToList();
                }
            }
            catch (Exception ex) { response.ex = ex; }
            return response;
        }

        public BaseViewModel<SecConfig> GetByCode(string ConfigCode)
        {
            var response = new BaseViewModel<SecConfig>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    response.ResponseData = db.SecConfig.FirstOrDefault(x => x.Code == ConfigCode);
                }
            }
            catch (Exception ex) { response.ex = ex; }
            return response;
        }
    }
}
