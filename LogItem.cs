using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryForm
{
    class LogItem
    {
        public string _date;
        public string _item;
        public string _decription;
        public decimal _cost;
        public List<string> _splitWith;

        public LogItem(string date, string item, string description, 
            decimal cost, List<string> splitWith)
        {
            _date = date;
            _item = item;
            _decription = description;
            _cost = cost;
            _splitWith = splitWith;
        }
    }
}
