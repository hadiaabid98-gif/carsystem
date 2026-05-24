using System.Data;
using System.Windows.Forms;
using CarSystem.DAL;
using CarSystem.Models;

namespace CarSystem.BAL
{
    public class MaintenanceBAL
    {
        private MaintenanceDAL dal = new MaintenanceDAL();

        public void Save(MaintenanceModel m)
        {
            dal.Insert(m);
            MessageBox.Show("Record Saved Successfully");
        }

        public void Update(MaintenanceModel m)
        {
            dal.Update(m);
            MessageBox.Show("Record Updated Successfully");
        }

        public void Delete(int maintenanceID)
        {
            dal.Delete(maintenanceID);
            MessageBox.Show("Record Deleted Successfully");
        }

        public DataTable GetAll()
        {
            return dal.GetAll();
        }
    }
}