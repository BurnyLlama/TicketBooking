using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking
{
    internal class Booking
    {
        private List<Show> shows;

        /// <summary>
        /// Create a booking system.
        /// </summary>
        public Booking() 
        {
            shows = new List<Show>();
        }

        /// <summary>
        /// Adds a show to this.shows
        /// </summary>
        /// <param name="show"></param>
        public void AddShow(Show show)
        {
            shows.Add(show);
        }

        /// <summary>
        /// Get all shows.
        /// FIXME: This should be a deep copy.
        /// </summary>
        /// <returns></returns>
        public List<Show> GetShows()
        {
            return shows;
        }

        /// <summary>
        /// Prints all shows with their index, description, etc.
        /// </summary>
        public void PrintShows()
        {
            for (int i = 0; i < shows.Count; i++)
            {
                Show show = shows[i];
                Console.WriteLine($"{i + 1}: {show.Title}, {show.DateTime}, {show.TicketsLeft}/{show.Seats} seats left\n{show.Description}\n");
            }
        }

        /// <summary>
        /// Books a show, see Show.Book().
        /// </summary>
        /// <param name="idx">The index of the show in this.shows</param>
        /// <param name="holder"></param>
        /// <param name="amount"></param>
        public void BookShow(int idx, string holder, int amount)
        {
            shows.ElementAt(idx).Book(holder, amount);
        }
    }
}
