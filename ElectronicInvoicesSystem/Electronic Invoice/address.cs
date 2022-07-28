﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tidal_ERP_System.Electronic_Invoice
{
   public class address
    {
        public string branchID { get; set; }
        public string country { get; set; }
        public string governate { get; set; }
        public string regionCity { get; set; }
        public string street { get; set; }
        public string buildingNumber { get; set; }
        public string postalCode { get; set; }
        public string floor { get; set; }
        public string room { get; set; }
        public string landmark { get; set; }
        public string additionalInformation { get; set; }
    }
}
