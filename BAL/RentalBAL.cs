using System.Data;
using System.Windows.Forms;
using CarSystem.DAL;
using CarSystem.Models;

namespace CarSystem.BAL
{
    public class RentalBAL
    {
        private RentalDAL dal = new RentalDAL();

        public DataTable GetAll()
        {
            return dal.GetAll();
        }

        public void Save(RentalModel rental)
        {
            dal.Insert(rental);
            MessageBox.Show("Rental Saved Successfully");
        }

        public void Update(RentalModel rental)
        {
            dal.Update(rental); 
            MessageBox.Show("Rental Updated Successfully");
        }

        public void Delete(int id)
        {
            dal.Delete(id); 
            MessageBox.Show("Rental Deleted Successfully");
        }
    }
}