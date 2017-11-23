using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manpower.Entities
{
    public class User: IEntityBase
    {
        public User()
        {
            UserRoles = new List<UserRole>();
        }
        public int ID { get; set; }
        public int RoleId { get; set; }
        public int CompanyInfoId { get; set; }
        public int ClientNoticeId { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public string Remarks { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Cancel { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
        public bool IsLocked { get; set; }    
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}