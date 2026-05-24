namespace CarSystem.Models
{
    public class PaymentModel
    {
        public int PaymentID { get; set; }
        public string CustomerName { get; set; }
        public int Amount { get; set; }
        public string PaymentMethod { get; set; }
    }
}