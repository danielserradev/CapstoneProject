using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentX.Models
{
    public class PaymentRequest
    {
        [Key]
        public int PaymentRequestId { get; set; }

        [ForeignKey("Renter")]
        public int? RenterId { get; set; }
        public Renter Renter { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}