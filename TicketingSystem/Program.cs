using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem
{
    class Program
    {
        public static List<Ticket> AllTickets = new List<Ticket>();

        //while isRunning is true, the application will prompt the user for an integer input until the user exits the with the exit option in the main menu
        public static bool IsRunning = true;
        private static int Input = -1;

        //user signs in a gets list of tickets, displayed is the users name, number of tickets currently owned and sum price of these tickets
        //actions user can take: 1) reserve new ticket, 2) view purchased tickets, 3) exit
        //if 1) - user can select from a list of tickets or go back
        //if 2) - user can select a ticket to open or go back
        //if open ticket - can see additional information about the ticket and can either amend details or cancel or go back
        static void Main(string[] args)
        {
            PopulateTicketList();
            //getting persistent data from a database
            User user = Program.GetUserFromJSON("{\"Id\":1,\"Name\":\"George Cox\",\"TicketIDs\":\"2,1,4\"}");
            UI ui = new UI();
            while(IsRunning)
            {

                Console.Write("Input:");
                string input = Console.ReadLine();
                ui.ChangeDisplay(Convert.ToInt32(input), ref user.Tickets, ref user);

                //IsRunning = false;
            }
        }

        //populate the arraylist of the avaiable tickets
        private static void PopulateTicketList()
        {
            AllTickets.Add(new Ticket(1, "ticket", DateTime.Now, 10.00f, "additional info", false));
            AllTickets.Add(new Ticket(2, "ticket2", DateTime.Now.AddDays(2), 8.00f, "additional info", false));
            AllTickets.Add(new Ticket(3, "ticket3", DateTime.Now.AddDays(4), 12.00f, "additional info", false));
            AllTickets.Add(new Ticket(4, "ticket4", DateTime.Now.AddDays(6), 10.50f, "additional info", true));
            AllTickets.Add(new Ticket(5, "ticket5", DateTime.Now.AddDays(8), 10.00f, "additional info", true));
            AllTickets.Add(new Ticket(6, "ticket6", DateTime.Now.AddDays(10), 8.50f, "additional info", true));
            AllTickets.Add(new Ticket(7, "ticket7", DateTime.Now.AddDays(12), 10.00f, "additional info", true));
        }

        private static User GetUserFromJSON(string strJSON)
        {
            User user = null;
            try
            {
                user = JsonConvert.DeserializeObject<User>(strJSON);
                user.GetInformationFromTicketIDs(user.TicketIDs);
            }
            catch(Exception ex)
            {
                Console.Write("JSON deserialiation problem: " + ex.Message.ToString());
            }

            return user;
        }
    }
}
