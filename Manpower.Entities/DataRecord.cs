﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manpower.Entities
{
    public class DataRecord : IEntityBase
    {
       
        public int ID { get; set; }
     
        public bool Cancel { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }
        public string Email { get; set; }
        public string DateJoined { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        public string Subject { get; set; }

    }
}