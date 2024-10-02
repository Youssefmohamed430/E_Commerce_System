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
            if(x.ToLower() == "yes")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Hello enter your option : ");
                Console.WriteLine("1.Show Menu\n" +
                    "2.Add product\n" +
                    "3.Remove product\n" +
                    "4.Update price\n" +
                    "5.Filter Products with Price");
                Console.WriteLine("-------------------------------------------");
                int op = Convert.ToInt32(Console.ReadLine());
                if (op == 1)
                {
                    Console.Clear();
                    menu();
                }
                else if (op == 2)
                {
                    Console.Clear();
                    Console.ForegroundColor= ConsoleColor.DarkBlue;
                    Console.Write("Enter ID : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Name : ");
                    string name = Console.ReadLine();
                    Console.Write("Enter price : ");
                    int pr = Convert.ToInt32(Console.ReadLine());
                    base.product.Add_product(id, name.ToLower(), pr);
                    menu();
                }
                else if (op == 3) {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("Enter ID : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    base.product.Remove_product(id);
                    menu();
                }
                else if (op == 4) {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("Enter ID : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter price : ");
                    int pr = Convert.ToInt32(Console.ReadLine());
                    base.product.Update_product_price(id, pr);
                    menu();
                }
                else if(op == 5)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Enter Lower Range Price : ");
                    int pri1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Higher Range Price : ");
                    int pri2 = Convert.ToInt32(Console.ReadLine());
                    base.product.Filter_Products(pri1, pri2);
                }
                else
                {
                    Console.WriteLine("Invalid answer");
                    display();
                }
            }
            else if(x.ToLower() == "no")   
            {
                Console.Clear ();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Enter your option : \n" +   
                    "1.Show Menu\n" +
                    "2.Filter Products with Price");
                string ans1 = Console.ReadLine();
                if(ans1 == "1")
                    menu();
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Enter Lower Range Price : ");
                    int pri1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Higher Range Price : ");
                    int pri2 = Convert.ToInt32(Console.ReadLine());
                    base.product.Filter_Products(pri1, pri2);
                }
            }
            else
            {
                Console.WriteLine ("Invalid answer");
                display();
            }
            AnotherOperation();
        }
        public void AnotherOperation()
        {
            Console.WriteLine("-----------------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Are you need to do anything ?");
            string ans = Console.ReadLine();
            if (ans.ToLower() == "yes")
            {
                Console.Clear();
                display();
            }
            else if (ans.ToLower() == "no")
                return;
            else
            {
                Console.WriteLine("Invalid answer");
                return;
            }
        }
        public void menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("----------------->> Menu <<------------------");
            foreach (var i in base.product.Products)
            {
                Console.WriteLine($"ID : {i.Key} | Name : {i.Value.Key} | Price : {i.Value.Value}");
            }
            Console.WriteLine("---------------------------------------------");
        }
    }
}
