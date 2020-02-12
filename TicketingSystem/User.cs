using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem
{
    //information to store about a user:
    //unique id
    //name
    //list of tickets
    //total number of tickets
    //sum price of tickets
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Ticket[] Tickets { get; set; }
        public int TotalTickets { get; set; }
        public float Price { get; set; }
    }
}
