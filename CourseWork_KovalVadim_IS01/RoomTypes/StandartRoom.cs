using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWork_KovalVadim_IS01
{ 
    class StandartRoom : Room
    {
        public bool Coffemachine { get; private set; }

        public StandartRoom(int area, int roomNumber, int placesNumber, bool coffeeMachine, bool wifi, bool pets, MealType type)
        {
            Area = area;
            RoomNumber = roomNumber;
            PlacesNumber = placesNumber;
            Coffemachine = coffeeMachine;
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
            RentedOn(new RoomEventArgs("Thank you! You successfully rented a room. Type: standart. Room number: " + this.RoomNumber, this.RoomNumber));
        }

        public override void Book(Guest[] guestsArr, int fromDay, int toDay, int fromMonth, int toMonth, int fromYear, int toYear)
        {
            base.Book(guestsArr, fromDay, toDay, fromMonth, toMonth, fromYear, toYear);
            BookedOn(new RoomEventArgs("Thank you! You successfully booked a room. Type: standart. Room number: " + this.RoomNumber, this.RoomNumber));
        }

        public override void PayFor(ref int sum, Guest[] guestsArr, DateTime fromDate, DateTime toDate)
        {
            sum += 500 * guestsArr.Length * toDate.Subtract(fromDate).Days;
            if (Coffemachine == true)
            {
                sum += 20 * toDate.Subtract(fromDate).Days;
            }

            if (Pets == true)
            {
                sum += 20 * toDate.Subtract(fromDate).Days;
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
            int nowSum = 500 * guestsArr.Length * toDate.Subtract(fromDate).Days;
            if (Coffemachine == true)
            {
                nowSum += 20 * toDate.Subtract(fromDate).Days;
            }

            if (Pets == true)
            {
                nowSum += 20 * toDate.Subtract(fromDate).Days;
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

    }
}
