using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryForm
{
    class User
    {
        public string _name = "";
        private Dictionary<string, decimal> balance = new Dictionary<string, decimal>();

        public User(string name, List<string> roomates)
        {
            _name = name;
            foreach(string roomate in roomates)
            {
                balance.Add(roomate, 0);
            }
        }

        public User(string name, Dictionary<string, decimal> roomates)
        {
            _name = name;
            balance = roomates;
        }

        public void addRoomate(string name)
        {
            balance.Add(name, 0);
        }

        public void changeBalance(string name, decimal value)
        {
            balance[name] += value;
        }

        public string getName()
        {
            return _name;
        }

        public decimal getIndvBalance(string name)
        {
            return balance[name];
        }

        public decimal getTotBalance()
        {
            decimal total = 0;
            foreach(KeyValuePair<string, decimal> indvBalance in balance)
            {
                total += indvBalance.Value;
            }

            return total;
        }

        public Dictionary<string, decimal> returnBalance()
        {
            return balance;
        }
    }
}
