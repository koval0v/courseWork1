using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWork_KovalVadim_IS01
{
    class MiddleRoom : Room
    {
        public bool Coffemachine { get; private set; }
        public bool Minibar { get; private set; }

        public MiddleRoom(int area, int roomNumber, int placesNumber, bool coffeeMachine, bool wifi, bool pets, MealType type, bool minibar)
        {
            Area = area;
            RoomNumber = roomNumber;
            PlacesNumber = placesNumber;
            Coffemachine = coffeeMachine;
            Minibar = minibar;
            WiFi = wifi;
            Pets = pets;
            Food = type;
            RentedRoom rentingD = new RentedRoom();
            rentingD.Rented = false;
            rentingData = rentingD;
            BookedRoom bookingD = new BookedRoom();
            bookingD.Booked = false;
            bookingData[0] = bookingD;
        }

        public override void Rent(Guest[] guestsArr, int toDay, int toMonth, int toYear)
        {
            base.Rent(guestsArr, toDay, toMonth, toYear);
            RentedOn(new RoomEventArgs("Thank you! You successfully rented a room. Type: middle. Room number: " + this.RoomNumber, this.RoomNumber));
        }

        public override void Book(Guest[] guestsArr, int fromDay, int toDay, int fromMonth, int toMonth, int fromYear, int toYear)
        {
            base.Book(guestsArr, fromDay, toDay, fromMonth, toMonth, fromYear, toYear);
            BookedOn(new RoomEventArgs("Thank you! You successfully booked a room. Type: middle. Room number: " + this.RoomNumber, this.RoomNumber));
        }

        public override void PayFor(ref int sum, Guest[] guestsArr, DateTime fromDate, DateTime toDate)
        {
            sum += 750 * guestsArr.Length * toDate.Subtract(fromDate).Days;
            if (Coffemachine == true)
            {
                sum += 20 * toDate.Subtract(fromDate).Days;
            }

            if (Pets == true)
            {
                sum += 20 * toDate.Subtract(fromDate).Days;
            }

            if (Minibar == true)
            {
                int weeksNumber = toDate.Subtract(fromDate).Days / 7;
                if (weeksNumber >= 1)
                {
                    sum += 350 * weeksNumber;
                }
                else
                {
                    sum += 350;
                }
            }

            switch (Food)
            {
                case MealType.Breakfast:
                    sum += 70 * guestsArr.Length * toDate.Subtract(fromDate).Days;
                    break;
                case MealType.BreakfastAndSupper:
                    sum += 150 * guestsArr.Length * toDate.Subtract(fromDate).Days;
                    break;
                case MealType.AllInclusive:
                    sum += 230 * guestsArr.Length * toDate.Subtract(fromDate).Days;
                    break;
            }
        }

        public override int GetPrice(Guest[] guestsArr, DateTime fromDate, DateTime toDate)
        {
            int nowSum = 750 * guestsArr.Length * toDate.Subtract(fromDate).Days;
            if (Coffemachine == true)
            {
                nowSum += 20 * toDate.Subtract(fromDate).Days;
            }

            if (Pets == true)
            {
                nowSum += 20 * toDate.Subtract(fromDate).Days;
            }

            if (Minibar == true)
            {
                int weeksNumber = toDate.Subtract(fromDate).Days / 7;
                if (weeksNumber >= 1)
                {
                    nowSum += 350 * weeksNumber;
                }
                else
                {
                    nowSum += 350;
                }
            }

            switch (Food)
            {
                case MealType.Breakfast:
                    nowSum += 70 * guestsArr.Length * toDate.Subtract(fromDate).Days;
                    break;
                case MealType.BreakfastAndSupper:
                    nowSum += 150 * guestsArr.Length * toDate.Subtract(fromDate).Days;
                    break;
                case MealType.AllInclusive:
                    nowSum += 230 * guestsArr.Length * toDate.Subtract(fromDate).Days;
                    break;
            }

            return nowSum;
        }

        public bool CoffeMachine()
        {
            if (Coffemachine == true)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public bool MiniBar()
        {
            if (Minibar == true)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
