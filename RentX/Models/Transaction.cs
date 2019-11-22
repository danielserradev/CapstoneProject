using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentX.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        
        [Display(Name = "Time of Payment")]
        public DateTime? TimeOfPayment { get; set; }


       

        [ForeignKey("Renter")]
        public int? RenterId { get; set; }
        public Renter Renter { get; set; }



        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}