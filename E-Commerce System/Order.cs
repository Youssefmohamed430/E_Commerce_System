using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_type;

namespace E_Commerce_System
{
    internal class Order : Product // Mange things that is related with order 
    {
        public int no_order {  get; set; }
        public order _order;
        public Dictionary<int, order> Data_of_orders { get; set; }
        public Order() { 
            no_order = 0;
            _order = new order();
            Data_of_orders = new Dictionary<int, order>();
        }
        public void Create_order(string n , string ph ,string pay)
        {
            no_order++;
            _order.Total_price = 0;
            _order.BuyProduct = new SortedDictionary<int , KeyValuePair<string, int>>();
            _order.nameofclient = n;
            _order.phone = ph;
            _order.paymentway = pay;
        }
        public order search_of_order(int noorder)
            // To search for orders with Binary search 
        {
            //-------------------- Binary search --------------------------- 

            int n = Data_of_orders.Count;
            int[] keys = Data_of_orders.Keys.ToArray();
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
        // To add new product in old order 
        {
            var temporder = Data_of_orders[noorder]; 
            foreach (var i in base.Products)
            {
                if(i.Value.Key == nameofproduct)
                {
                    temporder.BuyProduct.Add (i.Key,i.Value);
                    temporder.Total_price += i.Value.Value;
                    Data_of_orders[noorder] = temporder;
                    return;
                }
            }   
        }   
        public bool Add_product_in_order(string nameofproduct)
         // to add products in new order
        {
            foreach(var i in base.Products)
            {
                if (i.Value.Key == nameofproduct)
                {
                    _order.BuyProduct.Add(i.Key, i.Value);
                    _order.Total_price += i.Value.Value;
                    return true;
                }
            }
            return false;
        }
        public void adding_orders_in_database()
         //to store order after creating and add products in it 
        {
            Data_of_orders.Add(no_order, _order);
        }
        public void Delete_product_from_order(int noorder, string nameofproduct)
            // to remove product from old order
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
        public List<KeyValuePair<int , order>> ArrangeWithTotalPrice()
        {
            var query = Data_of_orders.OrderBy(x => x.Value.Total_price).ToList();
            return query;
        }
        public int GetIncome()
        {
            var query = Data_of_orders.Select(x => x.Value.Total_price);
            var income = query.Aggregate(0,(a, b) => a + b);    
            return income;
        }
        public List<IGrouping<string,order>> GroupByPaymentWay()
        {
            var query = Data_of_orders.Select(x => x.Value);
            var Groups = query.GroupBy(a => a.paymentway).ToList();
            return Groups;
        }
    }
}
