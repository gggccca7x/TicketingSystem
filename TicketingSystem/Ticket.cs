using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem
{
    //class to store information about a single ticket
    class Ticket
    {
        //all tickets should have a unique id
        public int Id { get; set; }

        public string Name { get; set; }

        //date and time the ticket is valid
        public DateTime Date { get; set; }

        public float Price { get; set; }

        public string Information { get; set; }

        public bool IsForSale { get; set; }

        public Ticket(int id, string name, DateTime date, float price, string info, bool forSale)
        {
            this.Id = id;
            this.Name = name;
            this.Date = date;
            this.Price = price;
            this.Information = info;
            this.IsForSale = forSale;
        }
    }
}
