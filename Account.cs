using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casino_Work
{
    internal class Account : Balance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; } 
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public Balance balance { get; set; }

        public List<int> BalanceHistory;

        //List<Game> GameHistory { get; set; } заготовка для gameHistory
        

        public void Print()
        {
            Console.WriteLine($"Account id: {Id}\nAccount Name: {Name}\nAccount balance: {balance} ");
        }

    }
}
