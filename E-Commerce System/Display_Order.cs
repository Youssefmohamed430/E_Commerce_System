using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Data_type;
namespace E_Commerce_System
{
    internal class Display_Order : Display
    {

        public override void display()
        {
            Console.WriteLine("Enter Your Option : ");
            Console.WriteLine("1.Create order\n2.Search order\n3.Add in order\n4.Delete from order\n5.Show Orders of day");
            int op = Convert.ToInt32(Console.ReadLine());
            if (op == 1)
            {
                Console.Write("Enter Your Name : ");
                base.client.Name = Console.ReadLine();
                Console.Write("Enter Your Phone : ");
                base.client.phone = Console.ReadLine();
                Console.Write("Enter Payment Way : ");
                string way = Console.ReadLine();
                base.Neworder.Create_order(base.client.Name, base.client.phone, way);
                Console.Write("Enter Number of products : ");
                int num = Convert.ToInt32(Console.ReadLine());
                while (num > 0)
                {
                    Console.Write("Enter The Name of product : ");
                    string namep = Console.ReadLine();
                    base.Neworder.Add_product_in_order(namep);
                    num--;
                }
                base.Neworder.adding_orders_in_database();
                Console.Clear();
                order lastorder = base.Neworder.order1;
                Print_Reset(lastorder,base.Neworder.no_order);
            }
            else if (op == 2)
            {
                Console.WriteLine("Enter Number of order : ");
                int num = Convert.ToInt32(Console.ReadLine());
                order searchorder = base.Neworder.search_of_order(num);
                Console.Clear();
                Print_Reset(searchorder,num);
            }
            else if (op == 3)
            {
                Console.WriteLine("Enter Number of order : ");
                int num = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Name of product : ");
                string name = Console.ReadLine();
                base.Neworder.Add_product_in_order(num, name);
                order TempOrder = base.Neworder.search_of_order(num);
                Console.Clear();
                Print_Reset(TempOrder,num);
            }
            else if (op == 4)
            {
                Console.WriteLine("Enter Number of order : ");
                int num = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Name of product : ");
                string name = Console.ReadLine();
                base.Neworder.Delete_product_from_order(num, name);
                order TempOrder = base.Neworder.search_of_order(num);
                Console.Clear();
                Print_Reset(TempOrder,num);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("--------------------->> Order of day <<--------------------------");
                foreach (var i in base.Neworder.Data_of_orders)
                {
                    Console.WriteLine($"Number of order : {i.Key}\nName of client : {i.Value.nameofclient} | phone:{i.Value.phone}");
                    foreach (var ii in i.Value.BuyProduct)
                        Console.WriteLine($"id : {ii.Key} | Name of product : {ii.Value.Key} | Price : {ii.Value.Value}");
                    Console.WriteLine($"Total Price : {i.Value.Total_price} | Payment way : {i.Value.paymentway}");
                    Console.WriteLine("-----------------------------------------");
                }
                Console.WriteLine("Are you need to do any operation? ");
                string opp = Console.ReadLine();
                if (opp == "yes") { Console.Clear(); display(); }
                else return;
            }
        }
        public void Print_Reset(order reset,int num)
        {
            Console.WriteLine("           -------------------------Reset-----------------------           ");
            Console.WriteLine($"Number of order : {num}\nName : {base.client.Name} | Phone : {base.client.phone}");
            foreach (var i in reset.BuyProduct)
            {
                Console.WriteLine($"Product ID : {i.Key} | Product : {i.Value.Key} | Price : {i.Value.Value}");
            }
            Console.WriteLine($"Total Price : {reset.Total_price} | Payment way : {reset.paymentway}");
            Console.WriteLine("Are you need to do any operation? ");
            string opp = Console.ReadLine();
            if (opp == "yes") { Console.Clear(); display(); }
            else {
                Console.WriteLine("Thanks");
                return;
            }
        }
    }
}
