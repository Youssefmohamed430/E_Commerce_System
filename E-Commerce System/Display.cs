using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_System
{
    internal abstract class Display 
    {
        protected Client client;
        protected Product product;
        protected Order Neworder;
        public Display()
        {
            client = new Client();
            product = new Product();    
            Neworder = new Order();

        }
        public abstract void display();
    }
}
