using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentX.Models
{
    public class QueueRenter
    {
        //primary key or composite key
        public int QueueRenterId { get; set; }


        [ForeignKey("Queue")]
        public int QueueId { get; set; }
        public Queue Queue { get; set; }

        [ForeignKey("Renter")]
        public int RenterId { get; set; }
        public Renter Renter { get; set; }
    }
}