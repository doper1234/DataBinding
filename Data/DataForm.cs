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
    public partial class DataForm : Form
    {
        ObjectSource _source;
        ISource _currentSource;
        BindingSource _categoriesBindingSource = new BindingSource();
        BindingSource _productsBindingSource = new BindingSource();
        DataSetSource _dataSetSource;
        public DataForm()
        {
            InitializeComponent();
        }

        private void DataForm_Load(object sender, EventArgs e)
        {
            sourceToolStripComboBox.SelectedIndex = 0;
            SetSource();
            //BindCategories();
            _categoriesBindingSource.DataSource = _source.GetCategories();
            categoryToolStripComboBox.ComboBox.DisplayMember = "categoryName";
            categoryToolStripComboBox.ComboBox.ValueMember = "categoryID";
            categoryToolStripComboBox.ComboBox.DataSource = _categoriesBindingSource;

            var products = _productsBindingSource;
            productDataGridView.DataSource = products;
            productsListBox.DataSource = products;
            productsListBox.DisplayMember = "productName";
            
            nameTextBox.DataBindings.Add("Text", products, "productName");
            quantityTextBox.DataBindings.Add("Text", products, "quantityPerUnit");
            priceTextBox.DataBindings.Add("Text", products, "unitPrice");
            stockTextBox.DataBindings.Add("Text", products, "unitsInStock");
            orderTextBox.DataBindings.Add("Text", products, "unitsOnOrder");
            discontinuedCheckBox.DataBindings.Add("Checked", products, "discontinued");
        }

        private void categoriesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var catId = (int)categoryToolStripComboBox.ComboBox.SelectedValue;
            _productsBindingSource.DataSource = _source.GetProducts(catId);

        }
        

        private void addToolStripButton_Click(object sender, EventArgs e)
        {
            var category = (Category)categoryToolStripComboBox.SelectedItem;
            var form = new AddProduct(category);
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                // _source.AddProduct(form.Product);
                _productsBindingSource.Add(form.Product);
                //SetBoxes();
            }
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            var product = (Product)productsListBox.SelectedItem;
            _productsBindingSource.Remove(product);
            //_source.DeleteProduct(product);
            //SetBoxes();
        }

        private void backToolStripButton_Click(object sender, EventArgs e)
        {
            _productsBindingSource.MovePrevious();
        }

        private void forewardToolStripButton_Click(object sender, EventArgs e)
        {
            _productsBindingSource.MoveNext();
        }

        private void sourceToolStripComboBox_Click(object sender, EventArgs e)
        {
            SetSource();
            BindCategories();
            BindProducts();
        }

        private void categoryToolStripComboBox_Click(object sender, EventArgs e)
        {
            BindProducts();
        }

        void SetSource()
        {
            int sourceCode = sourceToolStripComboBox.SelectedIndex;

            switch (sourceCode)
            {
                case 0 :
                    if (_source == null)
                    {
                        _source = new ObjectSource();
                    }
                    _currentSource = _source;
                    break;
                case 1:
                    if (_dataSetSource == null)
                    {
                        _dataSetSource = new DataSetSource();
                    }
                    _currentSource = _dataSetSource;

                    break;
            }
            

        }

        void BindCategories()
        {
            Console.WriteLine("selected index: " + _categoriesBindingSource.DataSource);
            _categoriesBindingSource.DataSource = _currentSource.GetCategories();
        }

        void BindProducts()
        {
            var catId = (int)categoryToolStripComboBox.ComboBox.SelectedValue;
            _productsBindingSource.DataSource = _currentSource.GetProducts(catId);
        }

    }
}
