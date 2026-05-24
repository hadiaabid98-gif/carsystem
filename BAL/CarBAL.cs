using System.Data;
using System.Windows.Forms;
using CarSystem.DAL;
using CarSystem.Models;

namespace CarSystem.BAL
{
    public class CarBAL
    {
        private CarDAL dal = new CarDAL();

        public void Save(CarModel car)
        {
            dal.Insert(car);
            MessageBox.Show("Record Saved Successfully");
        }

        public void Update(CarModel car)
        {
            dal.Update(car);
            MessageBox.Show("Record Updated Successfully");
        }

        public void Delete(int carID)
        {
            dal.Delete(carID);
            MessageBox.Show("Record Deleted Successfully");
        }

        public DataTable GetAll()
        {
            return dal.GetAll();
        }

        public DataTable Search(string keyword)
        {
            return dal.Search(keyword);
        }
    }
}
