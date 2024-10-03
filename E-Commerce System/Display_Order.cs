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
        // To show anything related with order  
    {

        public override void display()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Enter Your Option : ");
            Console.WriteLine("1.Create order\n" +
                "2.Search order\n" +
                "3.Add in order\n" +
                "4.Delete from order\n" +
                "5.Show Orders of day\n" +
                "6.Arrange Resets with total price\n" +
                "7.Show Income for Today\n" +
                "8.Group Resets By PaymentWay");
            int op = Convert.ToInt32(Console.ReadLine());
            if (op == 1)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("Enter Your Name : ");
                base.client.Name = Console.ReadLine();
                Console.Write("Enter Your Phone : ");
                base.client.phone = Console.ReadLine();
                Console.Write("Enter Payment Way : ");
                string way = Console.ReadLine();
                base.Neworder.Create_order(base.client.Name, base.client.phone, way);
                print_menu();
                while (true)
                {
                    Console.Write("Enter The Name of product (Enter '0' If you finished): ");
                    string namep = Console.ReadLine();
                    if (namep != "0") {
                        if (base.Neworder.Add_product_in_order(namep.ToLower()))
                            continue;
                        else
                            Console.WriteLine("This product not found");
                    }
                    else break;
                }
                base.Neworder.adding_orders_in_database();
                Console.Clear();
                order lastorder = base.Neworder._order;
                Print_Reset(lastorder,base.Neworder.no_order);
            }
            else if (op == 2)
            {
                Console.Clear();
                Console.WriteLine("Enter Number of order : ");
                int num = Convert.ToInt32(Console.ReadLine());
                order searchorder = base.Neworder.search_of_order(num);
                Console.Clear();
                Print_Reset(searchorder,num);
            }
            else if (op == 3)
            {
                Console.Clear();
                Console.WriteLine("Enter Number of order : ");
                int num = Convert.ToInt32(Console.ReadLine());
                print_menu();
                Console.WriteLine("Enter Name of product : ");
                string name = Console.ReadLine();
                base.Neworder.Add_product_in_order(num, name.ToLower());
                order TempOrder = base.Neworder.search_of_order(num);
                Console.Clear();
                Print_Reset(TempOrder, num);
            }
            else if (op == 4)
            {
                Console.Clear();
                Console.WriteLine("Enter Number of order : ");
                int num = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Name of product : ");
                string name = Console.ReadLine();
                base.Neworder.Delete_product_from_order(num, name.ToLower());
                order TempOrder = base.Neworder.search_of_order(num);
                Console.Clear();
                Print_Reset(TempOrder,num);
            }
            else if(op == 5) 
            {
                Console.Clear();
                Console.WriteLine("---------------------------->> Order of day <<---------------------------------");
                foreach (var i in base.Neworder.Data_of_orders)
                {
                    Print_Reset(i.Value, i.Key);    
                }
            }
            else if(op == 6)
            {
                Console.Clear();
                var temp = base.Neworder.ArrangeWithTotalPrice();
                foreach (var i in temp)
                    Print_Reset(i.Value, i.Key);
            }
            else if(op == 7)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nTotal Income for Taday is : {base.Neworder.GetIncome()}\n");
            }
            else if(op == 8)
            {
                Console.Clear();
                var temp = base.Neworder.GroupByPaymentWay();
                var Dic = base.Neworder.Data_of_orders;
                foreach (var group in temp)
                {
                    Console.ForegroundColor= ConsoleColor.Blue;
                    string key = group.Key;
                    int boxWidth = Math.Max(40, key.Length + 10);  
                    int padding = (boxWidth - key.Length) / 2;
                    string formattedKey = key.PadLeft(key.Length + padding).PadRight(boxWidth);
                    Console.WriteLine($"\t\t\t\t\t┌{new string('─', boxWidth)}┐");
                    Console.WriteLine($"\t\t\t\t\t│{formattedKey}│");
                    Console.WriteLine($"\t\t\t\t\t└{new string('─', boxWidth)}┘");
                    foreach (var item in group)
                    {
                        Print_Reset(item, Dic.FirstOrDefault(x => x.Value.Equals(item)).Key);
                    }
                }
            }
            else
            {
                Console.Write("Invalid answer");
                display();
            }
            AnotherOperation();
        }
        public void Print_Reset(order reset,int num)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"------------------------------------- Reset {num} ---------------------------------");
            Console.WriteLine($"Name : {reset.nameofclient} | Phone : {reset.phone}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var i in reset.BuyProduct)
            {
                Console.WriteLine($"Product ID : {i.Key} | Product : {i.Value.Key} | Price : {i.Value.Value}");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Total Price : {reset.Total_price} | Payment way : {reset.paymentway}");
        }
        public void print_menu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------------- Menu Products ------------------");
            foreach (var i in base.product.Products)
            {
                Console.WriteLine($"Name : {i.Value.Key} | Price : {i.Value.Value}");
            }
            Console.WriteLine("----------------------------------------------------------");
        }
        public void AnotherOperation()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Are you need to do any operation? ");
            string opp = Console.ReadLine();
            if (opp.ToLower() == "yes") { Console.Clear(); display(); }
            else return;
        }
    }
}
