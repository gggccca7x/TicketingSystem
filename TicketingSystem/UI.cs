using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem
{
    //handles what the user sees, and the user input to change the display of the console.
    class UI
    {
        private Display CurrentDisplay;

        //different screen displays
        private enum Display
        {
            HOME_SCREEN, RESERVE_TICKET, VIEWING_TICKETS, VIEW_SINGLE_TICKET
        }

        public UI()
        {
            CurrentDisplay = Display.HOME_SCREEN;
        }

        public void ChangeDisplay(int input, ref List<Ticket> tickets, ref User user)
        {
            Console.WriteLine();
            switch (CurrentDisplay)
            {
                case Display.HOME_SCREEN:
                    Console.WriteLine("Name: " + user.Name + " , total tickets: " + user.TotalTickets + " , price: " + user.Price);
                    Console.WriteLine("Home Screen - choose an action");
                    Console.WriteLine("1) Reserve new ticket");
                    Console.WriteLine("2) View tickets");
                    Console.WriteLine("3) Exit");
                    //ProcessInputHomeScreen(input);
                    break;
                case Display.RESERVE_TICKET:
                    Console.WriteLine("Choose a ticket to reserve");
                    //displays a list of avaibale to purchase tickets
                    int i = 1;
                    foreach(Ticket t in Program.AllTickets)
                    {
                        if (t.IsForSale)
                        {
                            Console.WriteLine(i + ") " + t.Name);
                            Console.WriteLine(t.Price);
                            Console.WriteLine(t.Date);
                            Console.WriteLine("------------");
                            i++;
                        }
                    }
                    Console.WriteLine(i + ") Cancel");
                    ProcessInputReserveTicket(input, ref tickets, ref user, i);
                    break;
                case Display.VIEWING_TICKETS:
                    Console.WriteLine("Choose a ticket to view or go back");
                    //loop through your tickets and give number before them - choosing one with go into detail about it
                    
                    Console.WriteLine("Exit");
                    break;
                case Display.VIEW_SINGLE_TICKET:
                    Console.WriteLine("Ticket Information");
                    //Displays information about the current select ticket and gives option to cancel it
                    Ticket ticket = tickets.ElementAt(input);
                    Console.WriteLine(ticket.Name);
                    Console.WriteLine(ticket.Date);
                    Console.WriteLine(ticket.Price);
                    Console.WriteLine(ticket.Information);
                    Console.WriteLine("1) Cancel Ticket");
                    Console.WriteLine("2) Back");
                    break;
            }
        }

        public void ProcessInput(int input, ref List<Ticket> tickets, ref User user)
        {
            Console.WriteLine();
            switch (CurrentDisplay)
            {
                case Display.HOME_SCREEN:
                    ProcessInputHomeScreen(input);
                    break;
                case Display.RESERVE_TICKET:
                    int i = 1;
                    foreach (Ticket t in Program.AllTickets)
                    {
                        if (t.IsForSale)
                        {
                            i++;
                        }
                    }
                    ProcessInputReserveTicket(input, ref tickets, ref user, i);
                    break;
                case Display.VIEWING_TICKETS:
                    break;
                case Display.VIEW_SINGLE_TICKET:
                    break;
            }
        }

        //change the UI when from the home screen
        private void ProcessInputHomeScreen(int input)
        {
            switch (input)
            {
                case 1: //reserve new ticket
                    CurrentDisplay = Display.RESERVE_TICKET;
                    break;
                case 2: //view tickets
                    CurrentDisplay = Display.VIEWING_TICKETS;
                    break;
                case 3: //exit
                    Program.IsRunning = false;
                    break;
                default: //invalid input
                    break;
            }
        }

        //change the UI from the reserve ticket screen, 1st few inputs are the list of tickets, last input is cancel
        private void ProcessInputReserveTicket(int input, ref List<Ticket> tickets, ref User user, int lastInput)
        {
            if(input < lastInput) //one of the tickets selected
            {
                CurrentDisplay = Display.VIEW_SINGLE_TICKET;
            }
            else if(input == lastInput) //go back selected
            {
                CurrentDisplay = Display.HOME_SCREEN;
            }
            else //invalid input
            {

            }
        }
    }
}
