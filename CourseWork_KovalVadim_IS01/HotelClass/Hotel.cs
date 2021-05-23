using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWork_KovalVadim_IS01
{
    class Hotel
    {
        public string HotelName { get; private set; }
        public static DateTime nowDate = DateTime.Today;
        private int mainAccount;
        public static NextDayHandler nextDayDelegate = null;
        public Room[] roomsArray;
        private static int orderNumber = 0;
        public string[] ordersArray = new string[orderNumber + 1];

        public Hotel(string hotelName)
        {
            HotelName = hotelName;
            nextDayDelegate += ChangeDate;
            nextDayDelegate += CheckRooms;
        }

        public int Price(int roomNumber, Guest[] guestsArray, DateTime fromDate, DateTime toDate)
        {
            Room nowRoom = FindRoom(roomNumber);
            if (nowRoom == null)
            {
                throw new RoomNotFound("This number`s room not found!");
            }
            else
            {
                return roomsArray[roomNumber - 1].GetPrice(guestsArray, fromDate, toDate);
            }
        }

        public void Book(RoomStateHandler bookHandler, int roomNumber, Guest[] guestsArray, int fromYear, int fromMonth, int fromDay, int toYear, int toMonth, int toDay)
        {
            Room nowRoom = FindRoom(roomNumber);
            if (nowRoom == null)
            {
                throw new RoomNotFound("This number`s room not found!");
            }

            else
            {
                bool freeRoom = true;
                DateTime fromDate = new DateTime(fromYear, fromMonth, fromDay);
                DateTime toDate = new DateTime(toYear, toMonth, toDay);
                for (int i = 0; i < nowRoom.bookingData.Length - 1; i++)
                {
                    if ((toDate > nowRoom.bookingData[i].FromDate && toDate < nowRoom.bookingData[i].ToDate) || (fromDate > nowRoom.bookingData[i].FromDate && fromDate < nowRoom.bookingData[i].ToDate) || (fromDate == nowDate))
                    {
                        freeRoom = false;
                    }
                }

                if (freeRoom == true)
                {
                    nowRoom.Booked += bookHandler;
                    nowRoom.Book(guestsArray, fromDay, toDay, fromMonth, toMonth, fromYear, toYear);
                    int s = nowRoom.bookingData.Length - 2;
                    nowRoom.PayFor(ref this.mainAccount, nowRoom.bookingData[s].guestsArray, nowRoom.bookingData[s].FromDate, nowRoom.bookingData[s].ToDate);
                    nowRoom.Booked -= bookHandler;
                }

                else
                {
                    throw new RoomAlreadybooked("This room is already booked!");
                }

            }
        }

        public void Rent(RoomStateHandler rentHandler, int roomNumber, Guest[] guestsArray, int toYear, int toMonth, int toDay)
        {
            Room nowRoom = FindRoom(roomNumber);
            if (nowRoom == null)
            {
                throw new RoomNotFound("This number`s room not found!");
            }
            else
            {
                if (nowRoom.rentingData.Rented == false)
                {
                    nowRoom.Rented += rentHandler;
                    nowRoom.Rent(guestsArray, toYear, toMonth, toDay);
                    nowRoom.PayFor(ref this.mainAccount, nowRoom.rentingData.guestsArray, nowRoom.rentingData.FromDate, nowRoom.rentingData.ToDate);
                    nowRoom.Rented -= rentHandler;
                }
                else
                {
                    throw new RoomAlreadybooked("This room is already rented!");
                }
            }
        }

        public void CheckRooms()
        {
            for (int i = 0; i < roomsArray.Length; i++)
            {
                if (roomsArray[i].rentingData.ToDate == nowDate)
                {
                    roomsArray[i].rentingData.Rented = false;
                }
            }

            for (int i = 0; i < roomsArray.Length; i++)
            {
                for (int j = 0; j < roomsArray[i].bookingData.Length; j++)
                {
                    roomsArray[i].rentingData.Rented = true;
                    roomsArray[i].rentingData.FromDate = nowDate;
                    roomsArray[i].rentingData.ToDate = roomsArray[i].bookingData[j].ToDate;
                    roomsArray[i].rentingData.guestsArray = roomsArray[i].bookingData[j].guestsArray;

                    for (int l = 0; l < roomsArray[i].bookingData.Length - 1; l++)
                    {
                        roomsArray[i].bookingData[l] = roomsArray[i].bookingData[l + 1];
                    }

                    Array.Resize(ref roomsArray[i].bookingData, roomsArray[i].bookingData.Length - 1);
                }
            }
        }

        public Room FindRoom(int roomNumber)
        {
            for (int i = 0; i < roomsArray.Length; i++)
            {
                if (roomsArray[i].RoomNumber == roomNumber)
                {
                    return roomsArray[i];
                }
            }
                return null;
        }

        public static void ChangeDate()
        {
            nowDate = nowDate.AddDays(1);
        }

        public int GetMainAccount()
        {
            return mainAccount;
        }

        public void PutMainAccount(int sumMoney)
        {
            mainAccount += sumMoney;
        }

        public void AddOrder(string roomType, int roomNumber, string[] guestsInfo, DateTime fromDate, DateTime toDate, DateTime nowDate)
        {
            orderNumber++;
            Array.Resize(ref ordersArray, orderNumber);
            string aboutOrder = $"{nowDate}:   Room #{roomNumber}; Type: {roomType}; From {fromDate} to {toDate}\n";
            aboutOrder += "Guests:\n:";
            for (int i = 0; i < guestsInfo.Length; i++)
            {
                aboutOrder += guestsInfo[i];
                aboutOrder += "\n";
            }
            ordersArray[orderNumber - 1] = aboutOrder;
        }

        public int GetOrderNumber()
        {
            return orderNumber;
        }

        public string[] GetLastOrders()
        {
            return ordersArray;
        }
            
    }
}
