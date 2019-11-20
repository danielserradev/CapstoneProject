using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentX.Models
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }

        public int NumOfStars { get; set; }

        public string Review { get; set; }

        [ForeignKey("Leasor")]
        public int? LeasorId { get; set; }
        public Leasor Leasor { get; set; }

        [ForeignKey("Renter")]
        public int? RenterId { get; set; }
        public Renter Renter { get; set; }
    }
}