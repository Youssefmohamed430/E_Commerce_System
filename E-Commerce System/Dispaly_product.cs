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
                    Console.Clear();
                    menu();
                }
                else if (op == 2)
                {
                    Console.Clear();
                    Console.Write("Enter ID : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Name : ");
                    string name = Console.ReadLine();
                    Console.Write("Enter price : ");
                    int pr = Convert.ToInt32(Console.ReadLine());
                    base.product.Add_product(id, name, pr);
                }
                else if (op == 3) {
                    Console.Clear();
                    Console.Write("Enter ID : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    base.product.Remove_product(id);
                }
                else if (op == 4) {
                    Console.Clear();
                    Console.Write("Enter ID : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter price : ");
                    int pr = Convert.ToInt32(Console.ReadLine());
                    base.product.Update_product_price(id, pr);
                }
                else
                {
                    Console.WriteLine("Invalid answer");
                    display();
                }
            }
            else if(x == "no")   
            {
                Console.Clear ();
                menu();
            }
            else
            {
                Console.WriteLine ("Invalid answer");
                display();
            }
            Console.WriteLine("Are you need to do anything ?");
            string ans = Console.ReadLine();
            if (ans == "yes")
            {
                Console.Clear();
                display();
            }
            else if(ans == "no")
                return;
            else
            {
                Console.WriteLine("Invalid answer");
                return;
            }
        }
        public void menu()
        {
            Console.WriteLine("----------------->> Menu <<------------------");
            foreach (var i in base.product.Products)
            {
                Console.WriteLine($"ID : {i.Key} | Name : {i.Value.Key} | Price : {i.Value.Value}");
            }
        }
    }
}
