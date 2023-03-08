using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking
{
    /// <summary>
    /// A show contains information about a show, as well as handling the tickets for that show.
    /// </summary>
    internal class Show
    {
        /// <summary>
        /// A ticket; simply put this is just a wrapper around a string containing the holder.
        /// </summary>
        public struct Ticket
        {
            public readonly string Holder;

            public Ticket(string holder)
            {
                this.Holder = holder;
            }
        }

        public readonly string Title;
        public readonly string Description;
        public readonly string DateTime;
        public readonly int Seats;
        public List<Ticket> Tickets;

        // Make a nice getter for seeing the amount of tickets left. :)
        // This is so that you can write "show.TicketsLeft" instead of "show.ticketsLeft()".
        public int TicketsLeft
        {
            get
            {
                return this.Seats - this.Tickets.Count;
            }
        }

        /// <summary>
        /// Create a show with a given title, description, date and time, as well as the amount of seats.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="dateTime"></param>
        /// <param name="seats"></param>
        public Show(string title, string description, string dateTime, int seats)
        {
            this.Title = title;
            this.Description = description;
            this.DateTime = dateTime;
            this.Seats = seats;
            Tickets = new List<Ticket>();
        }

        /// <summary>
        /// Formats the Show as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.Title}, {this.DateTime}, {this.TicketsLeft}/{this.Seats} seats left\n{this.Description}\n";
        }

        /// <summary>
        /// Book a specified amount of tickets in the name of holder.
        /// </summary>
        /// <param name="holder"></param>
        /// <param name="amountOfTickets"></param>
        /// <exception cref="ArgumentException">If the ticket amount is larger than the tickets left for the show, this exception will be thrown.</exception>
        public void Book(string holder, int amountOfTickets)
        {
            if (amountOfTickets > this.TicketsLeft)
            {
                throw new ArgumentException($"Too many tickets! Wanted to book {amountOfTickets}, but only {this.TicketsLeft} left!");
            }

            for (int i = 0; i < amountOfTickets; i++)
            {
                Tickets.Add(new Ticket(holder));
            }
        }
    }
}
