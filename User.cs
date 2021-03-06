﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryForm
{
    class User
    {
        public string _name;
        public Dictionary<string, decimal> balance;

        public User(string name, List<string> roomates)
        {
            balance = new Dictionary<string, decimal>();
            _name = name;
            foreach(string roomate in roomates)
            {
                balance.Add(roomate, 0);
            }
        }

        public User(string name, Dictionary<string, decimal> roomates)
        {
            _name = name;
            balance = new Dictionary<string, decimal>(roomates);
        }

        public User(User pUser)
        {
            _name = pUser._name;
            balance = new Dictionary<string, decimal>(pUser.balance);
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
            return new Dictionary<string, decimal>(balance);
        }

    }
}
