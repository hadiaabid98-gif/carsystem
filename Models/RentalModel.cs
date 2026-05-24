using System;
namespace CarSystem.Models
{
    public class RentalModel
    {
        public int RentalID { get; set; }
        public string CustomerName { get; set; }
        public string CarName { get; set; }
        public string Model { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RentalStatus { get; set; }
    }
}