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

        private List<Ticket> Tickets = new List<Ticket>();
        private int TotalTickets { get; set; }
        private float Price { get; set; }

        public void getInformationFromTicketIDs(string ids)
        {
            string[] idArray = ids.Split(',');
            foreach(string s in idArray)
            {
                int id = Convert.ToInt32(s);
                Console.WriteLine(id);

                foreach (Ticket t in Program.AllTickets)
                {
                    if (id == t.Id)
                    {
                        Tickets.Add(t);
                        break;
                    }
                }
            }

            foreach (Ticket t in Tickets)
            {
                Console.WriteLine(t.Name);
            }
        }
    }
}
