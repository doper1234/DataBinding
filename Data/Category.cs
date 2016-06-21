using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Category
    {
        public int categoryID { get; set; }
        public string categoryName { get; set; }

        public enum ID
        {
            Beverage,
            Condiments,
            Confections,
            DairyProducts,
            GrainsCereals,
            MeatPoultry,
            Produce,
            Seafood,
        }

        public Category(int id, string name)
        {
            categoryID = id;
            categoryName = name;
        }
    }
}
