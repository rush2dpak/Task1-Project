using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manpower.Entities
{
    public class AccountType : IEntityBase
    {
        public int ID { get; set; }
        public string AccountName { get; set; }
    }
}