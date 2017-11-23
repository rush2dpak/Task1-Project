using Manpower.Entities;
using Manpower.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manpower.Web.Infrastructure.Extensions
{
    public static class EntitiesExtentions
    {

        public static void UpdateUser(this User user, UserViewModel userVM)
        {
            user.ID = userVM.ID;
            user.RoleId = user.RoleId;
            user.UserRoles = user.UserRoles;
            user.UserName = userVM.UserName;
            user.HashedPassword = userVM.Password;
            user.Phone = userVM.Phone;
            user.Remarks = userVM.Remarks;
            user.Sex = userVM.Sex;
            user.Address = userVM.Address;
            user.Email = userVM.Email;
            user.DateCreated = userVM.DateCreated;
            user.Cancel = userVM.Cancel;
        }
        public static void UpdateData(this DataRecord data, DataRecordViewModel dataVM)
        {
            data.Name = dataVM.Name;
            data.Subject = dataVM.Subject;
            data.Zip = dataVM.Zip;
            data.Email = dataVM.Email;
            data.DateJoined = dataVM.DateJoined;
            data.Country = dataVM.Country;
            data.City = dataVM.City;
            data.Address = dataVM.Address;
            data.Grade = dataVM.Grade;
           
            data.Cancel = dataVM.Cancel;
            
        }



    }
}