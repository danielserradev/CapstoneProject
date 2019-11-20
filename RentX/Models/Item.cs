using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentX.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        [Display(Name = "Item Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Item Price")]
        public decimal Price { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }

        [Display(Name = "Rent Counter")]
        public int? RentCounter { get; set; }

        [Required]
        [Display(Name = "Item Availability")]
        public bool Availability { get; set; }

        [Required]
        [Display(Name = "Rent Duration By Months")]
        public int NumOfMonthsForRent { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please select the Type")]
        [System.ComponentModel.DataAnnotations.Display(Name = "Type of Transport Method")]
        public DeliveryOptions? DeliveryOption { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        public List<Transaction> Transactions { get; set; }

        [ForeignKey("Leasor")]
        public int LeasorId { get; set; }
        public Leasor Leasor { get; set; }

        [ForeignKey("Renter")]
        public int? RenterId { get; set; }
        public Renter Renter { get; set; }

        public enum DeliveryOptions
        {
            SelfDelivery = 0,
            Pickup = 1,
            Mail = 2
        }




    }
}