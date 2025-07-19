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
                            CustomerName = dbContext.DacCustomer.FirstOrDefault(x => x.Code == user.CustomerCode)?.Name,
                            CreatedDate = user.CreatedDate,
                            DeadlineOfUsing = user.DeadlineOfUsing,
                            Email = user.Email,
                            FullName = user.FullName,
                            LastChangedPassword = user.LastChangedPassword,
                            LastLogin = user.LastLogin,
                            LockedDate = user.LockedDate,
                            LockedReason = user.LockedReason,
                            LockedUser = user.LockedUser,
                            CustomerCode = user.CustomerCode
                        };
                        response.ResponseData.LstGroup = (from g in dbContext.SecGroups
                                                          join gu in dbContext.SecGroupUser on g.GroupId equals gu.GroupId
                                                          where gu.LoginId == user.LoginId
                                                          select g)?.ToList();
                        response.ResponseData.isAdmin = response.ResponseData.LstGroup != null && response.ResponseData.LstGroup.FirstOrDefault(x => x.IsAdmin.HasValue && x.IsAdmin.Value) != null;
                        response.ResponseData.Level = GetUserLevel(response.ResponseData.CustomerCode, response.ResponseData.isAdmin.HasValue ? response.ResponseData.isAdmin.Value : false);
                    }
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }

        private int? GetUserLevel(string CustomerCode, bool isAdmin)
        {
            if (isAdmin)
            {
                return 0;
            }
            if (string.IsNullOrWhiteSpace(CustomerCode))
            {
                return 1;
            }
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var customer = dbContext.DacCustomer.FirstOrDefault(x => x.Code == CustomerCode);
                    if (customer != null)
                    {
                        var parent = dbContext.DacCustomer.FirstOrDefault(x => x.Code == customer.DependCode);
                        if (parent != null)
                        {
                            return GetUserLevel(parent.Code, false).HasValue ? 1 + GetUserLevel(parent.Code, false).Value : null;
                        }
                        return 2;
                    }
                    return -1;
                }
            }
            catch 
            {
                return null;
            }
        }
    }
}
