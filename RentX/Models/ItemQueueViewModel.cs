using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentX.Models
{
    public class ItemQueueViewModel
    {
        //public List<string> RenterFirstNames { get; set; }

        //public List<string> RenterLastNames { get; set; }
        public int ItemId { get; set; }
        public List<Renter> Renters { get; set; }
    }
}