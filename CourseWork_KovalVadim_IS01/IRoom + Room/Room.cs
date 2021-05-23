using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWork_KovalVadim_IS01
{

    abstract class Room : IRoom
    {
        protected internal event RoomStateHandler Booked;
        protected internal event RoomStateHandler Rented;

        public int Area { get; internal set; }
        public int RoomNumber { get; internal set; }
        public int PlacesNumber { get; internal set; }
        public bool Pets { get; internal set; }
        public bool WiFi { get; internal set; }
        public MealType Food { get; internal set; }

        public RentedRoom rentingData;
        public BookedRoom[] bookingData = new BookedRoom[1];

        public class RentedRoom
        {
            public Guest[] guestsArray;
            public bool Rented { get; internal set; }
            public DateTime FromDate { get; internal set; }
            public DateTime ToDate { get; internal set; }

            public static RentedRoom operator+(RentedRoom room, int daysNumber)
            {
                room.ToDate = room.ToDate.AddDays(daysNumber);
                return room;
            }
        }

        public class BookedRoom
        {
            internal Guest[] guestsArray;
            public bool Booked { get; internal set; }
            public DateTime FromDate { get; internal set; }
            public DateTime ToDate { get; internal set; }
        }

        public virtual void Book(Guest[] guestsArr, int fromDay, int toDay, int fromMonth, int toMonth, int fromYear, int toYear)
        {
            DateTime dateFrom = new DateTime(fromYear, fromMonth, fromDay);
            DateTime dateTo = new DateTime(toYear, toMonth, toDay);

            if (guestsArr.Length > PlacesNumber)
            {
                throw new TooMuchGuests("Too much guests! Choose another available number");
            }

            else if (guestsArr.Length < PlacesNumber)
            {
                throw new TooMuchGuests("Too little guests! Choose another available number");
            }

            else if (dateTo < DateTime.Today.AddDays(1))
            {
                throw new EndDateIsLessThanStartDate("End date cann`t be less than tomorrow!");
            }

            else
            {
                int lastIndex = bookingData.Length - 1;
                Array.Resize(ref bookingData, bookingData.Length + 1);
                bookingData[lastIndex] = new BookedRoom();
                bookingData[lastIndex].Booked = true;
                bookingData[lastIndex].guestsArray = new Guest[guestsArr.Length];
                for (int i = 0; i < guestsArr.Length; i++)
                {
                    bookingData[lastIndex].guestsArray[i] = guestsArr[i];
                }
                bookingData[lastIndex].FromDate = dateFrom;
                bookingData[lastIndex].ToDate = dateTo;
            }
        }

        public virtual void Rent(Guest[] guestsArr, int toDay, int toMonth, int toYear)
        {
            DateTime dateTo = new DateTime(toYear, toMonth, toDay);

            if (guestsArr.Length > PlacesNumber)
            {
                throw new TooMuchGuests("Too much guests! Choose another available number");
            }

            else if (guestsArr.Length < PlacesNumber)
            {
                throw new TooMuchGuests("Too little guests! Choose another available number");
            }

            else if (dateTo < DateTime.Today.AddDays(1))
            {
                throw new EndDateIsLessThanStartDate("End date cann`t be less than today!");
            }

            else
            {
                rentingData.Rented = true;
                rentingData.guestsArray = new Guest[guestsArr.Length];
                for (int i = 0; i < guestsArr.Length; i++)
                {
                    rentingData.guestsArray[i] = guestsArr[i];
                }
                rentingData.FromDate = DateTime.Today;
                rentingData.ToDate = dateTo;
            }
        }

        public abstract int GetPrice(Guest[] guestsArr, DateTime fromDate, DateTime toDate);
        public abstract void PayFor(ref int sum, Guest[] guestsArr, DateTime fromDate, DateTime toDate);

        private void EventOn(RoomEventArgs e, RoomStateHandler handler)
        {
            if (e != null && handler != null)
            {
                handler(handler, e);
            }
        }

        protected void BookedOn(RoomEventArgs e)
        {
            ConsoleColor colorNow = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            EventOn(e, Booked);
            Console.ForegroundColor = colorNow;
        }

        protected void RentedOn(RoomEventArgs e)
        {
            ConsoleColor colorNow = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            EventOn(e, Rented);
            Console.ForegroundColor = colorNow;
        }
    }
}
