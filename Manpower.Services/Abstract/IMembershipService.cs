using Manpower.Entities;
using Manpower.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manpower.Services
{
    public interface IMembershipService
    {
        MembershipContext ValidateUser(string username, string password);
        User CreateUser(string username, string email, string password, string phone,
                                            string sex, string remarks, string address,int roleId,int companyInfoId, int clientNoticeId, int[] roles);
        User GetUser(int userId);
        List<Role> GetUserRoles(string username);
        List<Role> GetRoles();
    }
}
