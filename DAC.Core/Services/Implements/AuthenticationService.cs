using DAC.Core.Common;
using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.ViewModels;
using System;
using System.Linq;

namespace DAC.Core.Services.Implements
{
    public class AuthenticationService : IAuthenticationService
    {
        public BaseViewModel<SecUsersVM> Login(string loginId, string Password)
        {
            var response = new BaseViewModel<SecUsersVM>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var user = dbContext.SecUsers.FirstOrDefault(x => x.LoginId == loginId && x.Password == Password);
                    if (user != null)
                    {
                        response.ResponseData = new SecUsersVM
                        {
                            LoginID = user.LoginId,
                            AgencyName = dbContext.DacCustomer.FirstOrDefault(x => x.Code == user.AgencyCode)?.Name,
                            CreatedDate = user.CreatedDate,
                            DeadlineOfUsing = user.DeadlineOfUsing,
                            Email = user.Email,
                            FullName = user.FullName,
                            LastChangedPassword = user.LastChangedPassword,
                            LastLogin = user.LastLogin,
                            LockedDate = user.LockedDate,
                            LockedReason = user.LockedReason,
                            LockedUser = user.LockedUser,
                            AgencyCode = user.AgencyCode
                        };
                        response.ResponseData.LstGroup = (from g in dbContext.SecGroups
                                                          join gu in dbContext.SecGroupUser on g.GroupId equals gu.GroupId
                                                          where gu.LoginId == user.LoginId
                                                          select g)?.ToList();
                        response.ResponseData.isAdmin = response.ResponseData.LstGroup != null && response.ResponseData.LstGroup.FirstOrDefault(x => x.IsAdmin.HasValue && x.IsAdmin.Value) != null;
                    }
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }
    }
}
