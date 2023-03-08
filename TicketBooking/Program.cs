using static TicketBooking.Show;

namespace TicketBooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Booking bookingSystem = new Booking();

            // Add some initial shows!
            bookingSystem.AddShow(new Show(
                "The Dance of the Glowing Stars",
                "A beautiful theatre piece directed by Stella d'Étoile about stars dancing in the sky.",
                "2023/03/12 16:00",
                24
            ));
            bookingSystem.AddShow(new Show(
                "The Dance of the Glowing Stars",
                "A beautiful theatre piece directed by Stella d'Étoile about stars dancing in the sky.",
                "2023/03/13 16:00",
                24
            ));
            bookingSystem.AddShow(new Show(
                "Romeo and Juliette",
                "The classical piece by William Shakespeare about two star crossed lovers.",
                "2023/03/13 18:00",
                64
            ));

            // This is a "bug" that should be solved.
            //bookingSystem.PrintShows(); // 1
            //bookingSystem.GetShows()[0].Tickets.Add(new Ticket("Name of ticket holder"));
            //bookingSystem.PrintShows(); // 2

            bool shouldLoop = true;

            // Define all possible actions, and what should happen if they are ran.
            // This structure is used because it can be nicely fed into Menu.ChooseOne()
            // to let the user select an action. It is also easily extendable.
            (string, Action)[] possibleActions = 
            { 
                (
                    "Show me all shows!", () =>
                    {
                        Console.WriteLine("Here are all the shows available:");
                        bookingSystem.PrintShows();
                    }
                ),
                (
                    "Book a show.", () => 
                    {
                        List<Show> shows = bookingSystem.GetShows();
                        int showIndex = Menu.ChooseOne("What show do you want to buy tickets for?", shows);
                        int amountOfTickets = Menu.AskNumber("How many tickets do you want?", 1, shows[showIndex].TicketsLeft);
                        string holder = Menu.AskString("What is your name?");
                        Show show = shows[showIndex];

                        bookingSystem.BookShow(showIndex, holder, amountOfTickets);

                        Console.WriteLine($"You bought {amountOfTickets} for '{show.Title}' at {show.DateTime} in the name of {holder}.");
                    }
                ),
                (
                    "Add a show.", () =>
                    {
                        Console.WriteLine("Let's add a show!");
                        string title = Menu.AskString("What is the title of the show you want to add?");
                        string description = Menu.AskString("Can you describe the show?");
                        string dateTime = Menu.AskString("What time and date is the show? YYYY/MM/DD HH:MM");
                        int amountOfSeats = Menu.AskNumber("How many seats are there?", 1, int.MaxValue);

                        Show show = new Show(title, description, dateTime, amountOfSeats);
                        bookingSystem.AddShow(show);
                        Console.WriteLine("You added the following show:");
                        Console.WriteLine(show.ToString());
                    }
                ),
                (
                    "Quit the application.", () =>
                    {
                        Console.WriteLine("Alright, then... Good bye!");
                        shouldLoop = false;
                    }
                )
            };

            while (shouldLoop)
            {
                // Let the user choose an action from the possible actions.
                int chosenAction = Menu.ChooseOne("Hello! What do you want to do today?", possibleActions.Select(possibleAction => possibleAction.Item1).ToArray());
                // Exceute chosen action.
                possibleActions[chosenAction].Item2();
            }

        }
    }
}