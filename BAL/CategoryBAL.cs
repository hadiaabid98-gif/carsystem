using System.Data;
using System.Windows.Forms;
using CarSystem.DAL;
using CarSystem.Models;

namespace CarSystem.BAL
{
    public class CategoryBAL
    {
        private CategoryDAL dal = new CategoryDAL(); 

        public DataTable GetAll()
        {
            return dal.GetAll();
        }

        public void Save(CategoryModel category)
        {
            dal.Insert(category); 
            MessageBox.Show("Category Saved Successfully");
        }

        public void Update(CategoryModel category)
        {
            dal.Update(category);
            MessageBox.Show("Category Updated Successfully");
        }

        public void Delete(int id)
        {
            dal.Delete(id);
            MessageBox.Show("Category Deleted Successfully");
        }
    }
}