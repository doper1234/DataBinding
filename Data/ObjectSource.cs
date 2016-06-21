using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data
{
    public class ObjectSource : ISource
    {
        List<Category> _categories;
        List<Product> _products;
        int productID = 1;
        public ObjectSource()
        {
            _categories = new List<Category>();
            _categories.Add(new Category((int)Category.ID.Beverage, "Beverages"));
            _categories.Add(new Category((int)Category.ID.Condiments, "Condiments"));
            _categories.Add(new Category((int)Category.ID.Confections, "Confections"));
            _categories.Add(new Category((int)Category.ID.DairyProducts, "Dairy Products"));
            _categories.Add(new Category((int)Category.ID.GrainsCereals, "Grains/Cereals"));
            _categories.Add(new Category((int)Category.ID.Produce, "Produce"));
           
            _products = new List<Product>();
            atp("Iced Tea", (int)Category.ID.Beverage, "500ml", 1.99m, 12, 22, false);
            atp("Pepsi", (int)Category.ID.Beverage, "2l", 3.99m, 6, 33, false);
            atp("Ketchup", (int)Category.ID.Condiments, "250ml", 2.99m, 12, 22, false);
            atp("Mustard", (int)Category.ID.Condiments, "250ml", 2.99m, 12, 22, false);
            atp("Smarties", (int)Category.ID.Confections, "200g", 4.99m, 12, 22, false);
            atp("M & M's", (int)Category.ID.Confections, "200g", 4.99m, 12, 22, false);
            atp("Milk", (int)Category.ID.DairyProducts, "1l", 1.99m, 12, 22, false);
            atp("Cheese", (int)Category.ID.DairyProducts, "500g", 3.49m, 12, 22, false);
            atp("Whole Wheat", (int)Category.ID.GrainsCereals, "1kg", 5.49m, 12, 22, false);
            atp("Honey Nut Cheerios", (int)Category.ID.GrainsCereals, "2kg", 6.99m, 12, 22, false);
            atp("Apples", (int)Category.ID.Produce, "pc", 0.49m, 12, 22, false);
            atp("Pears", (int)Category.ID.Produce, "pc", 0.49m, 12, 22, false);

            atp("Iced Tea", (int)Category.ID.Beverage, "500ml", 1.99m, 12, 22, false);
            atp("Pepsi", (int)Category.ID.Beverage, "2l", 3.99m, 6, 33, false);
            atp("Ketchup", (int)Category.ID.Condiments, "250ml", 2.99m, 12, 22, false);
            atp("Mustard", (int)Category.ID.Condiments, "250ml", 2.99m, 12, 22, false);
            atp("Smarties", (int)Category.ID.Confections, "200g", 4.99m, 12, 22, false);
            atp("M & M's", (int)Category.ID.Confections, "200g", 4.99m, 12, 22, false);
            atp("Milk", (int)Category.ID.DairyProducts, "1l", 1.99m, 12, 22, false);
            atp("Cheese", (int)Category.ID.DairyProducts, "500g", 3.49m, 12, 22, false);
            atp("Whole Wheat", (int)Category.ID.GrainsCereals, "1kg", 5.49m, 12, 22, false);
            atp("Honey Nut Cheerios", (int)Category.ID.GrainsCereals, "2kg", 6.99m, 12, 22, false);
            atp("Apples", (int)Category.ID.Produce, "pc", 0.49m, 12, 22, false);
            atp("Pears", (int)Category.ID.Produce, "pc", 0.49m, 12, 22, false);

            atp("Iced Tea", (int)Category.ID.Beverage, "500ml", 1.99m, 12, 22, false);
            atp("Pepsi", (int)Category.ID.Beverage, "2l", 3.99m, 6, 33, false);
            atp("Ketchup", (int)Category.ID.Condiments, "250ml", 2.99m, 12, 22, false);
            atp("Mustard", (int)Category.ID.Condiments, "250ml", 2.99m, 12, 22, false);
            atp("Smarties", (int)Category.ID.Confections, "200g", 4.99m, 12, 22, false);
            atp("M & M's", (int)Category.ID.Confections, "200g", 4.99m, 12, 22, false);
            atp("Milk", (int)Category.ID.DairyProducts, "1l", 1.99m, 12, 22, false);
            atp("Cheese", (int)Category.ID.DairyProducts, "500g", 3.49m, 12, 22, false);
            atp("Whole Wheat", (int)Category.ID.GrainsCereals, "1kg", 5.49m, 12, 22, false);
            atp("Honey Nut Cheerios", (int)Category.ID.GrainsCereals, "2kg", 6.99m, 12, 22, false);
            atp("Apples", (int)Category.ID.Produce, "pc", 0.49m, 12, 22, false);
            atp("Pears", (int)Category.ID.Produce, "pc", 0.49m, 12, 22, false);
            string result = "";
            for (int i = 0; i < _categories.Count; i++)
            {
                result += _categories[i].categoryName;
            }
            MessageBox.Show(result);
            //populate lists with new objects
        }

        public List<Category> GetCategories()
        {
            return _categories;
        }

        public List<Product> GetProducts(int categoryID)
        {
            var result = new List<Product>();
            foreach (var p in _products)
            {
                if(p.categoryID == categoryID)
                {
                    result.Add(p);
                }
            }
            return result;
            
        }

        public void DeleteProduct(Product p)
        {
            _products.Remove(p);
        }

        public void AddProduct(Product p)
        {
            _products.Add(p);
        }
        
        void atp(string name, int catId, string unitQuant, decimal price,int inStock, int onOrder, bool discont)
        {
            _products.Add(new Product(productID++, name, catId, unitQuant, price, inStock, onOrder, discont));
            
        }

        object ISource.GetCategories()
        {
            return _categories;
        }

        object ISource.GetProducts(int categoryID)
        {
            var results = new List<Product>();
            foreach (var p in _products)
            {
                
                if(p.categoryID == categoryID)
                {
                    results.Add(p);
                }
            }

            return results;
        }

        public void DeleteProduct(BindingSource bs, Product p)
        {
            bs.Remove(p);
        }

        public void AddProduct(BindingSource bs, Product p)
        {
            bs.Add(p);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
