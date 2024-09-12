using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_type;

namespace E_Commerce_System
{
    internal class Order : Product
    {
        public int no_order {  get; set; }
        public order order1;
        public Dictionary<int, order> Data_of_orders { get; set; }
        public Order() { 
            no_order = 0;
            order1 = new order();
            Data_of_orders = new Dictionary<int, order>();
        }
        public void Create_order(string n , string ph ,string pay)
        {
            no_order++;
            order1.Total_price = 0;
            order1.BuyProduct = new SortedDictionary<int , KeyValuePair<string, int>>();
            order1.nameofclient = n;
            order1.phone = ph;
            order1.paymentway = pay;
        }
//--------------------------- Binary search ----------------------------------- 
        public order search_of_order(int noorder)
        {
            int n = Data_of_orders.Count;
            int[] keys = Data_of_orders.Keys.ToArray();//1 2 3 4 5 6
            int left = 0, right = n-1, midd;
            while(left <= right)
            {
                midd = (left+right)/2;
                if (keys[midd] == noorder)
                    return Data_of_orders[keys[midd]];
                else if(keys[midd] < noorder)
                    left = midd+1;
                else 
                    right = midd-1;
            }
            throw new Exception($"order {noorder} not found");
        }
        public void Add_product_in_order(int noorder,string nameofproduct)
        {
            var temporder = Data_of_orders[noorder]; 
            foreach (var i in base.Products)
            {
                if(i.Value.Key == nameofproduct)
                {
                    temporder.BuyProduct.Add (i.Key,i.Value);
                    temporder.Total_price += i.Value.Value;
                    Data_of_orders[noorder] = temporder;
                }
            }   
        }   
        public void Add_product_in_order(string nameofproduct)
        {
            foreach(var i in base.Products)
            {
                if(i.Value.Key == nameofproduct)
                {
                    order1.BuyProduct.Add (i.Key,i.Value);
                    order1.Total_price += i.Value.Value;
                }
            }   
        }
        public void adding_orders_in_database()
        {
            Data_of_orders.Add(no_order, order1);
        }
        public void Delete_product_from_order(int noorder, string nameofproduct)
        {
            order temporder = Data_of_orders[noorder];
            foreach (var i in base.Products)
            {
                if (i.Value.Key == nameofproduct)
                {
                    temporder.BuyProduct.Remove(i.Key);
                    temporder.Total_price -= i.Value.Value;
                    Data_of_orders[noorder] = temporder;
                }
            }
        }
    }
}
