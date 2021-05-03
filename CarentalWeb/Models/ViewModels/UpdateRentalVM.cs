using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarentalWeb.Models.ViewModels
{
    public class UpdateRentalVM
    {


        public int Id { get; set; }


        public int CustomerId { get; set; }
        public int CarId { get; set; }

        public float TotalPrice { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        public DateTime? RentBegin { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        public DateTime? RentEnd { get; set; }

    }
}
