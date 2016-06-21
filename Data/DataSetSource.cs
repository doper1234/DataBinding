using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data
{
    class DataSetSource : ISource
    {
        private DataSet _dataSet;

        public DataSetSource()
        {
            _dataSet = new DataSet();
            var cn = new SqlConnection(Properties.Settings.Default.NorthwindConnection);
            var da = new SqlDataAdapter("Select Id, CategoryName From Categories", cn);
            da.Fill(_dataSet, "Categories");

            var pda = new SqlDataAdapter("Select * From Products", cn);
            da.Fill(_dataSet, "Products");
        }
        public void AddProduct(BindingSource bs, Product p)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(BindingSource bs, Product p)
        {
            throw new NotImplementedException();
        }

        public object GetCategories()
        {
            var table = _dataSet.Tables["Categories"];
            return table;
        }

        public object GetProducts(int categoryID)
        {
            var table = _dataSet.Tables["Products"];
            table.DefaultView.RowFilter = "CategoryID = " + categoryID;
            return table;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
