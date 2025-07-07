using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAC.Core.Services.Implements
{
    public class SecGroupUserService : ISecGroupUserService
    {
        public BaseViewModel<List<SecGroupUser>> GetAll()
        {
            var result = new BaseViewModel<List<SecGroupUser>>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    result.ResponseData = db.SecGroupUser.ToList();
                }
            }
            catch (System.Exception ex)
            {
                result.ex = ex;
            }
            return result;
        }

        public BaseViewModel<List<SecGroupUser>> GetByLoginID(string loginID)
        {
            var result = new BaseViewModel<List<SecGroupUser>>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    result.ResponseData = db.SecGroupUser.Where(x => x.LoginId == loginID).ToList();
                }
            }
            catch (System.Exception ex)
            {
                result.ex = ex;
            }
            return result;
        }

        public BaseViewModel<bool> Add(SecGroupUser entity)
        {
            var result = new BaseViewModel<bool>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    db.SecGroupUser.Add(entity);
                    db.SaveChanges();
                    result.ResponseData = true;
                }
            }
            catch (System.Exception ex)
            {
                result.ex = ex;
            }
            return result;
        }

        public BaseViewModel<bool> Delete(SecGroupUser entity)
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
            catch (System.Exception ex)
            {
                result.ex = ex;
            }
            return result;
        }
    }
}
