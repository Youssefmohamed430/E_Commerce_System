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
        static void Main(string[] args)
        {
            Display_Order d1 = new Display_Order();
            Dispaly_product d2 = new Dispaly_product();
            Console.WriteLine("Enter your option : ");
            Console.WriteLine("1.products\n2.orders");
            int op = Convert.ToInt32(Console.ReadLine());
            if (op == 1)
                d2.display();
            else 
                d1.display();
        }
    }
}
