using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace E_Commerce_System
{
    public class Product
    {
        public SortedDictionary<int, KeyValuePair<string, int>> Products { get; set; }
        public Product()
        {
            //-----------------------------ID---------------Name----Price-----------
            Products = new SortedDictionary<int, KeyValuePair<string, int>>
            {
                {120 , new KeyValuePair<string, int>("iphone 15" , 30000)  },
                {121 , new KeyValuePair<string, int>("iphone 13" , 20000)  },
                {122 , new KeyValuePair<string, int>("samsung a15",10000)  },
                {123 , new KeyValuePair<string, int>("AirPods" ,   800  )  },
                {124 , new KeyValuePair<string, int>("lenovo loq", 35000)  },
                {125 , new KeyValuePair<string, int>( "headset"  , 1000 )  },
                {126 , new KeyValuePair<string, int>("keyboard aula",700)  },
                {127 , new KeyValuePair<string, int>("mouse"    ,  600  )  },
                {128 , new KeyValuePair<string, int>("keyboard lenovo",700)},
                {129 , new KeyValuePair<string, int>("stand laptob",250 )  },
                {130 , new KeyValuePair<string, int>("Mouse Pad" , 100  )  }
            };
        }
          public void Add_product(int id, string name, int price) // for employee
                => Products.Add(id, new KeyValuePair<string, int>(name, price));
            public void Remove_product(int id) => Products.Remove(id); 
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
            public void Filter_Products(int pri1,int pri2)
            {
                var query = Products.
                    Where(p => p.Value.Value >= Math.Min(pri1, pri2) && p.Value.Value <= Math.Max(pri1, pri2));
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                if (query.Count() != 0)
                    foreach (var item in query)
                        Console.WriteLine($"Name : {item.Value.Key} | Price : {item.Value.Value}");
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No Products in this Range");
                }
            }

        }
     } 
