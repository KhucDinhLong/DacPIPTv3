using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAC.Core.Services.Implements
{
    public class SecGroupsService : ISecGroupsService
    {
        public BaseViewModel<List<SecGroups>> GetAll()
        {
            var result = new BaseViewModel<List<SecGroups>>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    result.ResponseData = db.SecGroups.ToList();
                }
            }
            catch (Exception ex)
            {
                result.ex = ex;
            }
            return result;
        }

        public BaseViewModel<SecGroups> GetById(Guid groupId)
        {
            var result = new BaseViewModel<SecGroups>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    result.ResponseData = db.SecGroups.Find(groupId);
                }
            }
            catch (Exception ex)
            {
                result.ex = ex;
            }
            return result;
        }

        public BaseViewModel<bool> Add(SecGroups entity)
        {
            var result = new BaseViewModel<bool>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    db.SecGroups.Add(entity);
                    db.SaveChanges();
                    result.ResponseData = true;
                }
            }
            catch (Exception ex)
            {
                result.ex = ex;
            }
            return result;
        }

        public BaseViewModel<bool> Update(SecGroups entity)
        {
            var result = new BaseViewModel<bool>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    db.Entry(entity).State = EntityState.Modified;
                    db.SaveChanges();
                    result.ResponseData = true;
                }
            }
            catch (Exception ex)
            {
                result.ex = ex;
            }
            return result;
        }

        public BaseViewModel<bool> Delete(SecGroups entity)
        {
            var result = new BaseViewModel<bool>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    db.Entry(entity).State = EntityState.Deleted;
                    db.SaveChanges();
                    result.ResponseData = true;
                }
            }
            catch (Exception ex)
            {
                result.ex = ex;
            }
            return result;
        }
    }
}
