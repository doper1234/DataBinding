using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data
{
    public interface ISource
    {
        object GetCategories();
        object GetProducts(int categoryID);
        void DeleteProduct(BindingSource bs, Product p);
        void AddProduct(BindingSource bs, Product p);
        void Save(); 
    }
}
