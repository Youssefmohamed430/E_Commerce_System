using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace E_Commerce_System
{
    public class Product
    {
        public Dictionary<int, KeyValuePair<string, int>> Products { get; set; }
        public Product() 
        {
        //-----------------------------ID---------------Name----Price-----------
            Products = new Dictionary<int, KeyValuePair<string, int>>
            {
                {123 , new KeyValuePair<string, int>("iphone 15" , 30000)  },
                {124 , new KeyValuePair<string, int>("iphone 13" , 20000)  },
                {125 , new KeyValuePair<string, int>("Lenovo LOQ", 35000)  },
                {126 , new KeyValuePair<string, int>( "Headset"  , 1000)   },
                {127 , new KeyValuePair<string, int>("Keyboard aula", 700) },
                {128 , new KeyValuePair<string, int>("Mouse"    ,  600)    },
                {129 , new KeyValuePair<string, int>("Samsung A15",10000)  },
                {130 , new KeyValuePair<string, int>("Keyboard lenovo",700)}
            };
        }
        public void Add_product(int id,string name,int price) // for employee
        {
            Products.Add(id, new KeyValuePair<string, int>(name, price));
        }
        public void Remove_product(int id) { Products.Remove(id); }
        public void Update_product_price(int id, int price)
        {
            if (Products.ContainsKey(id))
            {
                var product = Products[id];
                Products[id] = new KeyValuePair<string, int>(product.Key, price);
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

    }
}
