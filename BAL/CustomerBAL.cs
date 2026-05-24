using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using CarSystem.DAL;
using CarSystem.Models;

namespace CarSystem.BAL
{
    public class CustomerBAL
    {
        private CustomerDAL dal = new CustomerDAL();

        public void Save(CustomerModel c)
        {
            dal.Insert(c);
            MessageBox.Show("Record Saved Successfully");
        }

        public void Update(CustomerModel c)
        {
            dal.Update(c);
            MessageBox.Show("Record Updated Successfully");
        }

        public void Delete(int customerID)
        {
            dal.Delete(customerID);
            MessageBox.Show("Record Deleted Successfully");
        }

        public DataTable GetAll()
        {
            return dal.GetAll();
        }
    }
}
internal class CustomerBALcs
{
}

