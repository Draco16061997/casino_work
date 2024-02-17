using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casino_Work
{
    internal class Balance
   {
        public int balance { get; set; }

        public List<int> BalanceHistory = new List<int>();
        public void ChangeBalance(int x)
        {
            balance = balance + x;
        }
        public void BalanceHistoryUpDate(int balance)
        {
            BalanceHistory.Add(balance);
        }
    }
}
