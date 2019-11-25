using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentX.Models
{
    public class TransactionViewModel
    {
        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
        public int RenterId { get; set; }
    }
}