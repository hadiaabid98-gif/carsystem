using System.Data;
using System.Windows.Forms;
using CarSystem.DAL;
using CarSystem.Models;

namespace CarSystem.BAL
{
    public class PaymentBAL
    {
        private PaymentDAL dal = new PaymentDAL();

        public DataTable GetAll()
        {
            return dal.GetAll();
        }

        public void Save(PaymentModel payment)
        {
            dal.Insert(payment); 
            MessageBox.Show("Payment Saved Successfully");
        }

        public void Update(PaymentModel payment)
        {
            dal.Update(payment); 
            MessageBox.Show("Payment Updated Successfully");
        }

        public void Delete(int id)
        {
            dal.Delete(id); 
            MessageBox.Show("Payment Deleted Successfully");
        }
    }
}