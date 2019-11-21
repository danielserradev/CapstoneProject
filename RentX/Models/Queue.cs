using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentX.Models
{
    public class Queue
    {
        [Key]
        public int QueueId { get; set; }

        [NotMapped]
        public List<Renter> RenterQueue { get; set; }

        [ForeignKey("Item")]
        public int? ItemId { get; set; }
        public Item Item { get; set; }
    }
}