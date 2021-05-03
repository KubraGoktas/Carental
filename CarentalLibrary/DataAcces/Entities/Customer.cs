using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarentalLibrary.DataAcces.Entities
{
    public class Customer
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur")]
        public string Tel { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur")]
        public DateTime? BirthDate { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur")]
        public string CardNumber { get; set; }
    }
}
