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
        //information for from JSON object
        public int Id { get; set; }
        public string Name { get; set; }
        public string TicketIDs { get; set; }

        //information got from ticket ids string
        public List<Ticket> Tickets = new List<Ticket>();
        public int TotalTickets { get; set; } = 0;
        public float Price { get; set; } = 0.0f;

        public void GetInformationFromTicketIDs(string ids)
        {
            string[] idArray = ids.Split(',');
            foreach(string s in idArray)
            {
                int id = Convert.ToInt32(s);
                //Console.WriteLine(id);

                foreach (Ticket t in Program.AllTickets)
                {
                    if (id == t.Id)
                    {
                        AddTicket(t);
                        break;
                    }
                }
            }
        }

        //add ticket to the list
        public void AddTicket(Ticket ticket)
        {
            Tickets.Add(ticket);
            Price += ticket.Price;
            TotalTickets++;
        }

        //loop through list of tickets and remove first ticket matching id of parameter
        public void RemoveTicket(Ticket ticket)
        {
            int idToRemove = ticket.Id;
            foreach(Ticket t in Tickets)
            {
                if(t.Id == idToRemove)
                {
                    Tickets.Remove(t);
                    return;
                }
            }
        }
    }
}
