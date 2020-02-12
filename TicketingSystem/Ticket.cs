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
        public long Date { get; set; }

        public int Price { get; set; }

        public string Information { get; set; }

        public bool ForSale { get; set; }

    }
}
