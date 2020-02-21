using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * This project is an event Ticketing System.
 * It allows a user to view their reserved tickets, add or delete a ticket, and view information on a ticket.
 * 
 * This project is incomplete. I can add tickets to the current List of tickets, but I have not completed removing tickets or viewing more information about a ticket.
 * I have not tidied up the UI or formatted my Strings.
 * A also have not done any exception handling, I am aware that the program would crash if the user inputs a letter. 
 * I don't think it show much wrapping everything with try/catch blocks and I didn't want to spend too much time on this project considering I spent about 4 hours and the documentation recommended 2/3.
 * 
 * The first thing I did was write a 'User' class. This class holds information about the user, such as name. 
 * It also holds a List of tickets, I chose List as the size of tickets the user has will vary with adding/removing of tickets.
 * From the list of tickets, you can get and display information such as the total price and the total number of tickets the user has.
 * 
 * The next thing I did was make a 'Ticket' class. This class holds inforamtion - such as name, price, additional info - of a ticket.
 * It also has a bool 'forSale' to indicate if the ticket is for sale or not. If it is for sale when the user wants to buy a new ticket it will appear in the List.
 * 
 * The 'UI' class was the next class I made. This controls what text comes up on the console. Using an Enum, and I able to control the 'state'.
 * For example, the state 'HOME_SCREEN' gives the user options to reserve a new ticket, view their purchased tickets and exit.
 * The UI has 2 public methods, one to listen to the user input and update the backend information, and one to change the UI based on the selection.
 * 
 * To simulate getting the data from a data store, I used JSON.
 * 
 * Scaleability: If the user purchases a lot of tickets, there's no way to ordering them. To order my tickets I would implement Comparable interface and override the CompareTo method.
 * 
 */

namespace TicketingSystem
{
    class Program
    {
        public static List<Ticket> AllTickets = new List<Ticket>();

        //while isRunning is true, the application will prompt the user for an integer input until the user exits the with the exit option in the main menu
        public static bool IsRunning = true;

        static async void Test()
        {
            //await REST.HttpGet();
            //await REST.HttpPost();
            Task.Run(() => REST.HttpGet());
            //REST.HttpPost();
        }
        static async Task Test2()
        {
            //await REST.HttpGet();
            //await REST.HttpPost();
            //REST.HttpGet();
            Task.Run(() => REST.HttpPost());
        }

        //user signs in a gets list of tickets, displayed is the users name, number of tickets currently owned and sum price of these tickets
        //actions user can take: 1) reserve new ticket, 2) view purchased tickets, 3) exit
        //if 1) - user can select from a list of tickets or go back
        //if 2) - user can select a ticket to open or go back
        //if open ticket - can see additional information about the ticket and can either amend details or cancel or go back
        static void Main(string[] args)
        {
            Test();
            Test2();

            PopulateTicketList();
            //getting persistent data from a database
            User user = Program.GetUserFromJSON("{\"Id\":1,\"Name\":\"George Cox\",\"TicketIDs\":\"2,1,4\"}");
            UI ui = new UI();
            string input = "-1";
            while (IsRunning)
            {

                ui.ChangeDisplay(Convert.ToInt32(input), ref user.Tickets, ref user);
                Console.Write("Input:");
                input = Console.ReadLine();
                ui.ProcessInput(Convert.ToInt32(input), ref user);

                //IsRunning = false;
            }
        }

        //populate the arraylist of the avaiable tickets - *simulating getting from a persistent data store*
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
