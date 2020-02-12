using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
    JSON format: From the ticket id's I can get the other information
    "{
        "Id" : 1,
        "Name" : "George Cox",
        "TicketIDs" : "1,2,3",
    }"
*/

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
        public string TicketIDs { get; set; }

        private List<Ticket> Tickets { get; set; }
        private int TotalTickets { get; set; }
        private float Price { get; set; }

        public void getInformationFromTicketIDs(string ids)
        {
            string[] id = ids.Split(',');
            Console.WriteLine(id[0]);
            Console.WriteLine(id[1]);
            Console.WriteLine(id[2]);
        }
    }
}
