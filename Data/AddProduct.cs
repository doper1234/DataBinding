using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data
{
    public partial class AddProduct : Form
    {
        Category _category;
        public AddProduct(Category category)
        {
            InitializeComponent();
            _category = category;
            categoryTextBox.Text = _category.categoryName;
        }

        public Product Product
        {
            get
            {
                var result = new Product(0, nameTextBox.Text, _category.categoryID, quantityTextBox.Text, decimal.Parse(priceTextBox.Text), int.Parse(stockTextBox.Text), int.Parse(orderTextBox.Text), discontinuedCheckBox.Checked);

                return result;
            }
        }
    }
}
