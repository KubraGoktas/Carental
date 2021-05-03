using System;
using System.Collections.Generic;
using System.Text;

namespace CarentalLibrary.DataAcces.Entities
{
    public class Car
    {

        public int Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int GearType { get; set; }
        public int ProYear { get; set; }
        public float Price { get; set; }
    }
}
