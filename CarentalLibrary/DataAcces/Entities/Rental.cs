using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarentalLibrary.DataAcces.Entities
{
    public class Rental
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        public int CustomerId { get; set; }
        public int CarId { get; set; }

        public float TotalPrice { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        public DateTime? RentBegin { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        public DateTime? RentEnd { get; set; }
    }
}
