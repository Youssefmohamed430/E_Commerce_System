using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_System
{
    internal class Program
    {
        static void Main()
        {
            Display d1, d2;
            Console.WriteLine("Enter your option : ");
            Console.WriteLine("1.products\n2.orders");
            int op = Convert.ToInt32(Console.ReadLine());
            if (op == 1)
            {
                d1 = new Dispaly_product();
                d1.display();
            }
            else if (op == 2) 
            {
                d2 = new Display_Order();
                d2.display();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("======>> Invalid answer <<<=====");
                Main();
            }
        }
    }
}
