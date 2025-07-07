using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAC.Core.Services.Implements
{
    public class SecUsersService : ISecUsersService
    {
        public BaseViewModel<List<SecUsersVM>> GetAll()
        {
            var result = new BaseViewModel<List<SecUsersVM>>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    result.ResponseData = db.SecUsers.Select(u => new SecUsersVM
                    {
                        AgencyCode = u.AgencyCode,
                        CreatedDate = u.CreatedDate,
                        DeadlineOfUsing = u.DeadlineOfUsing,
                        Email = u.Email,
                        FullName = u.FullName,
                        LastChangedPassword = u.LastChangedPassword,
                        LastLogin = u.LastLogin,
                        LockedDate = u.LockedDate,
                        LockedReason = u.LockedReason,
                        LockedUser = u.LockedUser,
                        LoginID = u.LoginId
                    }).ToList();
                    foreach (var user in result.ResponseData)
                    {
                        var groups = db.SecGroupUser.Where(x => x.LoginId == user.LoginID)?.ToList();
                        if (groups != null && groups.Any())
                        {
                            user.LstGroup = (from gr in groups
                                             join g in db.SecGroups on gr.GroupId equals g.GroupId
                                             select g)?.ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.ex = ex;
            }
            return result;
        }

        public BaseViewModel<SecUsers> GetByLoginID(string loginID)
        {
            var result = new BaseViewModel<SecUsers>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    result.ResponseData = db.SecUsers.FirstOrDefault(x => x.LoginId == loginID);
                }
            }
            catch (Exception ex)
            {
                result.ex = ex;
            }
            return result;
        }

        public BaseViewModel<bool> Exists(string loginID)
        {
            var result = new BaseViewModel<bool>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    result.ResponseData = db.SecUsers.Any(x => x.LoginId == loginID);
                }
            }
            catch (Exception ex)
            {
                result.ex = ex;
            }
            return result;
        }

        public BaseViewModel<bool> ResetPassword(string loginID, string password)
        {
            var result = new BaseViewModel<bool>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    var user = db.SecUsers.FirstOrDefault(x => x.LoginId == loginID);
                    if (user != null)
                    {
                        user.Password = password;
                        db.SaveChanges();
                        result.ResponseData = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ex = ex;
            }
            return result;
        }

        public BaseViewModel<SecUsersVM> Create(SecUsersVM NewUser)
        {
            var result = new BaseViewModel<SecUsersVM>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    var entity = UpdateEntityProperty(NewUser, true);
                    db.SecUsers.Add(entity);
                    UpdateUserGroup(db, NewUser);
                    db.SaveChanges();
                    result.ResponseData = NewUser;
                }
            }
            catch (Exception ex)
            {
                result.ex = ex;
            }
            return result;
        }

        public BaseViewModel<SecUsersVM> Edit(SecUsersVM usersVM)
        {
            var result = new BaseViewModel<SecUsersVM>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    var entity = UpdateEntityProperty(usersVM, false);
                    db.Entry(entity).State = EntityState.Modified;
                    UpdateUserGroup(db, usersVM);
                    db.SaveChanges();
                    result.ResponseData = usersVM;
                }
            }
            catch (Exception ex)
            {
                result.ex = ex;
            }
            return result;
        }

        public BaseViewModel<bool> Delete(string LoginId)
        {
            var result = new BaseViewModel<bool>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    var user = db.SecUsers.FirstOrDefault(x => x.LoginId == LoginId);
                    if (user != null)
                    {
                        var userGroup = db.SecGroupUser.Where(x => x.LoginId == LoginId);
                        if (userGroup != null && userGroup.Any())
                        {
                            db.SecGroupUser.RemoveRange(userGroup);
                        }
                        db.SecUsers.Remove(user);
                        db.SaveChanges();
                    }
                    result.ResponseData = true;
                }
            }
            catch (Exception ex)
            {
                result.ex = ex;
            }
            return result;
        }

        private SecUsers UpdateEntityProperty(SecUsersVM usersVM, bool isCreate)
        {
            try
            {
                using (var db = new PIPTDbContext())
                {
                    SecUsers entity = isCreate ? new SecUsers() : db.SecUsers.FirstOrDefault(x => x.LoginId == usersVM.LoginID);
                    if (entity != null)
                    {
                        entity.AgencyCode = usersVM.AgencyCode;
                        entity.CreatedDate = usersVM.CreatedDate;
                        entity.DeadlineOfUsing = usersVM.DeadlineOfUsing;
                        entity.Email = usersVM.Email;
                        entity.FullName = usersVM.FullName;
                        entity.LastChangedPassword = usersVM.LastChangedPassword;
                        entity.LastLogin = usersVM.LastLogin;
                        entity.LockedDate = usersVM.LockedDate;
                        entity.LockedReason = usersVM.LockedReason;
                        entity.LockedUser = usersVM.LockedUser;
                        entity.LoginId = usersVM.LoginID;
                        entity.Password = isCreate ? usersVM.Password : entity.Password;
                    }
                    return entity;
                }
            }
            catch 
            {
                return null;
            }
        }

        private void UpdateUserGroup(PIPTDbContext db, SecUsersVM usersVM)
        {
            if (usersVM.LstGroup != null && usersVM.LstGroup.Any())
            {
                var OriginalGroup = db.SecGroupUser.Where(x => x.LoginId == usersVM.LoginID);
                if (OriginalGroup != null && OriginalGroup.Any())
                {
                    db.SecGroupUser.RemoveRange(OriginalGroup);
                }
                foreach (var group in usersVM.LstGroup)
                {
                    var groupUser = new SecGroupUser();
                    groupUser.LoginId = usersVM.LoginID;
                    groupUser.GroupId = group.GroupId;
                    db.SecGroupUser.Add(groupUser);
                }
            }
        }
    }
}
