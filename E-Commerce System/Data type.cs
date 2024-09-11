using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_type
{
        public struct order
        {
            public string nameofclient { get; set; }
            public string phone { get; set; }
            public string paymentway { get; set; }
            public  int Total_price { get; set; }
            public SortedDictionary<int, KeyValuePair<string, int>> BuyProduct { get; set; }
        }
}
