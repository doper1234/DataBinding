using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Product
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public int categoryID { get; set; }
        public string quantityPerUnit { get; set; }
        public decimal unitPrice { get; set; }
        public int unitsInStock { get; set; }
        public int unitsOnOrder {get; set;}
        public bool discontinued { get; set; }

        public Product(int id, string name, int catId, string unitQuant, decimal price,
                        int inStock, int onOrder, bool discont)
        {
            productID = id;
            productName = name;
            categoryID = catId;
            quantityPerUnit = unitQuant;
            unitPrice = price;
            unitsInStock = inStock;
            unitsOnOrder = onOrder;
            discontinued = discont;
        }
    }
}
