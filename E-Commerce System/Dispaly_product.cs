using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_System
{
    internal class Dispaly_product : Display
    {
        public override void display()
        {
            Console.WriteLine("Are you employee ? ");
            string x = Console.ReadLine();
            if(x == "yes")
            {
                Console.WriteLine("Hello enter your option : ");
                Console.WriteLine("1.Show Menu\n2.Add product\n3.Remove product\n4.Update price");
                int op = Convert.ToInt32(Console.ReadLine());

                if (op == 1)
                {
                    foreach (var i in base.product.Products)
                    {
                        Console.WriteLine($"ID : {i.Key} | Name : {i.Value.Key} | Price : {i.Value.Value}");
                    }
                }
                else if (op == 2)
                {
                    Console.Write("Enter ID : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Name : ");
                    string name = Console.ReadLine();
                    Console.Write("Enter price : ");
                    int pr = Convert.ToInt32(Console.ReadLine());
                    base.product.Add_product(id, name, pr);
                }
                else if (op == 3) {
                    Console.Write("Enter ID : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    base.product.Remove_product(id);
                }
                else {
                    Console.Write("Enter ID : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter price : ");
                    int pr = Convert.ToInt32(Console.ReadLine());
                    base.product.Update_product_price(id, pr);
                }
            }
            else
            {
                Console.WriteLine("------------- Menu --------------");
                foreach (var i in base.product.Products)
                {
                    Console.WriteLine($"ID : {i.Key} | Name : {i.Value.Key} | Price : {i.Value.Value}");
                }
            }
            Console.WriteLine("Are you need to do anything ?");
            string anything = Console.ReadLine();
            if (anything == "yes")
                display();
            else
                return;
        }
    }
}
