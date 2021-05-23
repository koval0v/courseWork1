using System;
using System.IO;

namespace CourseWork_KovalVadim_IS01
{
    public enum MealType
    {
        Breakfast,
        BreakfastAndSupper,
        AllInclusive
    }

    class Program
    {

        static void Main(string[] args)
        {
            Hotel Weekends = new Hotel("Weekends");
            Weekends.roomsArray = new Room[3];
            Weekends.roomsArray[0] = new StandartRoom(15, 1, 1, true, true, true, MealType.Breakfast);
            Weekends.roomsArray[1] = new MiddleRoom(40, 2, 2, true, true, true, MealType.BreakfastAndSupper, true);
            Weekends.roomsArray[2] = new LuxRoom(100, 3, 3, true, true, true, MealType.AllInclusive, true, true);
            bool welcomeShowed = false;
            bool activeWork = true;
            int accountType;
            int nowPassword = 1111;
            while (activeWork)
            {
                try
                {
                    if (welcomeShowed == false)
                    {
                        ConsoleColor colorNow = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("--------   WELCOME TO THE \"WEEKENDS\"   --------");
                        Console.ForegroundColor = colorNow;
                        welcomeShowed = true;
                        Console.WriteLine("\n1 - Guest \t 2 - Admin \t 3 - Exit the menu");
                        Console.WriteLine("Choose the type of your account or action:");
                        accountType = Convert.ToInt32(Console.ReadLine());
                    }

                    else
                    {
                        Console.WriteLine("\n1 - Guest \t 2 - Admin \t 3 - Exit the menu");
                        Console.WriteLine("Choose the type of your account or action:");
                        accountType = Convert.ToInt32(Console.ReadLine());
                    }

                    if (accountType == 2)
                    {
                        int password;
                        bool adminWork = true;
                        Console.WriteLine("Enter the password to log in: ");
                        password = Convert.ToInt32(Console.ReadLine());
                        if (password == nowPassword)
                        {
                            Console.WriteLine();
                            ShowMessage("You logged in.");
                            Console.WriteLine("Welcome, Admin!");
                            while (adminWork)
                            {
                                Console.WriteLine("\n1 - See main count \t 2 - See info about rooms");
                                Console.WriteLine("3 - Date to the next day 4 - See the last orders");
                                Console.WriteLine("5 - Change the password  6 - Log out");
                                Console.WriteLine("Choose a number:");
                                try
                                {
                                    int choice = Convert.ToInt32(Console.ReadLine());

                                    switch (choice)
                                    {
                                        case 1:
                                            MainAccount(Weekends);
                                            break;
                                        case 2:
                                            RoomsInfo(Weekends);
                                            break;
                                        case 3:
                                            Hotel.nextDayDelegate?.Invoke();
                                            ShowMessage($"You changed the date successfully. Now date is {Hotel.nowDate}");
                                            break;
                                        case 4:
                                            ConsoleColor colorNow = Console.ForegroundColor;
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine($"Total orders quantity is {Weekends.GetOrderNumber()}.");
                                            Console.WriteLine($"This is info about the last five orders in {Weekends.HotelName}:");
                                            Console.ForegroundColor = colorNow;
                                            string[] orders = Weekends.GetLastOrders();
                                            if (orders.Length > 5)
                                            {
                                                for (int i = orders.Length - 1; i > orders.Length - 6; i--)
                                                {
                                                    Console.WriteLine(orders[i]);
                                                }
                                            }
                                            else
                                            {
                                                for (int i = orders.Length - 1; i >= 0; i--)
                                                {
                                                    Console.WriteLine(orders[i]);
                                                }
                                            }
                                            break;
                                        case 5:
                                            Console.WriteLine("Write your last password: ");
                                            int checkPassword = Convert.ToInt32(Console.ReadLine());
                                            if (checkPassword == nowPassword)
                                            {
                                                Console.WriteLine("Ok! Write your new password: ");
                                                int newPassword = Convert.ToInt32(Console.ReadLine());
                                                nowPassword = newPassword;
                                                ShowMessage("The password was successfully changed.");
                                            }
                                            else
                                            {
                                                throw new WrongPassword("The password was written by you is wrong!");
                                            }
                                            break;
                                        case 6:
                                            adminWork = false;
                                            ShowMessage("You logged out.");
                                            continue;
                                        default:
                                            throw new IncorrectNumber("You choose the incorrect number!");

                                    }
                                }
                                catch (WrongPassword e)
                                {
                                    ShowException(e);
                                }
                                catch (IncorrectNumber e)
                                {
                                    ShowException(e);
                                }
                            }
                        }
                        else
                        {
                            throw new WrongPassword("The password was written by you is wrong!");
                        }

                    }

                    else if (accountType == 1)
                    {
                        bool guestWork = true;
                        Console.WriteLine();
                        ShowMessage("You logged in.");
                        Console.WriteLine("Welcome, Guest!");
                        while (guestWork)
                        {
                            Console.WriteLine("\n1 - Book the room \t 2 - Rent the room");
                            Console.WriteLine("3 - Continue the room \t 4 - See info about rooms");
                            Console.WriteLine("5 - Log out");
                            Console.WriteLine("Choose a number:");
                            try
                            {
                                int choice = Convert.ToInt32(Console.ReadLine());

                                switch (choice)
                                {
                                    case 1:
                                        ShowMessage("Fill the form for booking.");
                                        Console.WriteLine("Enter the room`s number: ");
                                        int roomNumber = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Enter the quantity of guests: ");
                                        int guestsNumber = Convert.ToInt32(Console.ReadLine());
                                        Guest[] guestsArray = new Guest[guestsNumber];
                                        string[] guestsInfo = null;
                                        guestsInfo = new string[guestsNumber];
                                        string nowGuestInfo = "";
                                        for (int i = 0; i < guestsNumber; i++)
                                        {

                                            ShowMessage($"Fill the info about {i + 1} guest.");
                                            Console.WriteLine("Name: ");
                                            string name = Console.ReadLine();
                                            nowGuestInfo += name;
                                            nowGuestInfo += "   ";
                                            Console.WriteLine("Year of birth: ");
                                            int birthYear = Convert.ToInt32(Console.ReadLine());
                                            nowGuestInfo += Convert.ToString(birthYear);
                                            nowGuestInfo += " ";
                                            Console.WriteLine("Month of birth: ");
                                            int birthMonth = Convert.ToInt32(Console.ReadLine());
                                            nowGuestInfo += Convert.ToString(birthMonth);
                                            nowGuestInfo += " ";
                                            Console.WriteLine("Day of birth: ");
                                            int birthDay = Convert.ToInt32(Console.ReadLine());
                                            nowGuestInfo += Convert.ToString(birthDay);
                                            nowGuestInfo += "   ";
                                            Console.WriteLine("Passport ID: ");
                                            int passportID = Convert.ToInt32(Console.ReadLine());
                                            nowGuestInfo += Convert.ToString(passportID);
                                            nowGuestInfo += "   ";
                                            Console.WriteLine("Gender (male or female): ");
                                            string gender = Console.ReadLine();
                                            nowGuestInfo += gender;
                                            nowGuestInfo += "   ";
                                            Guest thisGuest = new Guest(name, birthDay, birthMonth, birthYear, gender, passportID);
                                            guestsArray[i] = thisGuest;
                                            guestsInfo[i] = nowGuestInfo;
                                        }
                                        Console.WriteLine("Arrival day: ");
                                        int arrivalDay = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Arrival month: ");
                                        int arrivalMonth = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Arrival year: ");
                                        int arrivalYear = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Departure day: ");
                                        int departureDay = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Departure month: ");
                                        int departureMonth = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Departure year: ");
                                        int departureYear = Convert.ToInt32(Console.ReadLine());
                                        DateTime fromDate = new DateTime(arrivalYear, arrivalMonth, arrivalDay);
                                        DateTime toDate = new DateTime(departureYear, departureMonth, departureDay);
                                        Console.WriteLine($"You want to book the room number {roomNumber} from {fromDate} to {toDate}");
                                        Console.WriteLine($"Price of order is {Weekends.Price(roomNumber, guestsArray, fromDate, toDate)}");
                                        Console.WriteLine("Please, confirm this by writing '+'");
                                        char confirmSymbol = Convert.ToChar(Console.ReadLine());
                                        if (confirmSymbol == '+')
                                        {
                                            Weekends.Book(BookHandler, roomNumber, guestsArray, arrivalYear, arrivalMonth, arrivalDay, departureYear, departureMonth, departureDay);

                                            string typeOfRoomSystem = Convert.ToString(Weekends.roomsArray[roomNumber - 1].GetType());
                                            int indexOfDot = typeOfRoomSystem.IndexOf('.') + 1;
                                            string typeOfRoom = typeOfRoomSystem.Substring(indexOfDot);
                                            DateTime onDate = new DateTime(arrivalYear, arrivalMonth, arrivalDay);
                                            DateTime outDate = new DateTime(departureYear, departureMonth, departureDay);
                                            Weekends.AddOrder(typeOfRoom, roomNumber, guestsInfo, onDate, outDate, DateTime.Now);
                                        }
                                        else
                                        {
                                            throw new IncorrectOrder("This order was canceled!");
                                        }

                                        break;
                                    case 2:
                                        ShowMessage("Fill the form for renting.");
                                        Console.WriteLine("Enter the room`s number: ");
                                        int roomNumber1 = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Enter the quantity of guests: ");
                                        int guestsNumber1 = Convert.ToInt32(Console.ReadLine());
                                        Guest[] guestsArray1 = new Guest[guestsNumber1];
                                        string[] guestsInfo1 = null;
                                        guestsInfo1 = new string[guestsNumber1];
                                        string nowGuestInfo1 = "";
                                        for (int i = 0; i < guestsNumber1; i++)
                                        {

                                            ShowMessage($"Fill the info about {i + 1} guest.");
                                            Console.WriteLine("Name: ");
                                            string name = Console.ReadLine();
                                            nowGuestInfo1 += name;
                                            nowGuestInfo1 += "   ";
                                            Console.WriteLine("Year of birth: ");
                                            int birthYear = Convert.ToInt32(Console.ReadLine());
                                            nowGuestInfo1 += Convert.ToString(birthYear);
                                            nowGuestInfo1 += " ";
                                            Console.WriteLine("Month of birth: ");
                                            int birthMonth = Convert.ToInt32(Console.ReadLine());
                                            nowGuestInfo1 += Convert.ToString(birthMonth);
                                            nowGuestInfo1 += " ";
                                            Console.WriteLine("Day of birth: ");
                                            int birthDay = Convert.ToInt32(Console.ReadLine());
                                            nowGuestInfo1 += Convert.ToString(birthDay);
                                            nowGuestInfo1 += "   ";
                                            Console.WriteLine("Passport ID: ");
                                            int passportID = Convert.ToInt32(Console.ReadLine());
                                            nowGuestInfo1 += Convert.ToString(passportID);
                                            nowGuestInfo1 += "   ";
                                            Console.WriteLine("Gender (male or female): ");
                                            string gender = Console.ReadLine();
                                            nowGuestInfo1 += gender;
                                            nowGuestInfo1 += "   ";
                                            Guest thisGuest = new Guest(name, birthDay, birthMonth, birthYear, gender, passportID);
                                            guestsArray1[i] = thisGuest;
                                            guestsInfo1[i] = nowGuestInfo1;
                                        }
                                        Console.WriteLine($"Arrival date: {DateTime.Now}");
                                        Console.WriteLine("Departure day: ");
                                        int departureDay1 = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Departure month: ");
                                        int departureMonth1 = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Departure year: ");
                                        int departureYear1 = Convert.ToInt32(Console.ReadLine());
                                        DateTime toDate1 = new DateTime(departureYear1, departureMonth1, departureDay1);
                                        Console.WriteLine($"You want to rent the room number {roomNumber1} from {DateTime.Now} to {toDate1}");
                                        Console.WriteLine($"Price of order is {Weekends.Price(roomNumber1, guestsArray1, DateTime.Now, toDate1)}");
                                        Console.WriteLine("Please, confirm this by writing '+'");
                                        char confirmSymbol1 = Convert.ToChar(Console.ReadLine());
                                        if (confirmSymbol1 == '+')
                                        {
                                            Weekends.Rent(RentHandler, roomNumber1, guestsArray1, departureDay1, departureMonth1, departureYear1);

                                            string typeOfRoomSystem1 = Convert.ToString(Weekends.roomsArray[roomNumber1 - 1].GetType());
                                            int indexOfDot1 = typeOfRoomSystem1.IndexOf('.') + 1;
                                            string typeOfRoom1 = typeOfRoomSystem1.Substring(indexOfDot1);
                                            DateTime onDate1 = DateTime.Now;
                                            DateTime outDate1 = new DateTime(departureYear1, departureMonth1, departureDay1);
                                            Weekends.AddOrder(typeOfRoom1, roomNumber1, guestsInfo1, onDate1, outDate1, DateTime.Now);
                                        }
                                        else
                                        {
                                            throw new IncorrectOrder("This order was canceled!");
                                        }
                                        break;
                                    case 3:
                                        ContinueRoom(Weekends);
                                        break;
                                    case 4:
                                        RoomsInfo(Weekends);
                                        break;
                                    case 5:
                                        guestWork = false;
                                        ShowMessage("You logged out.");
                                        continue;
                                    default:
                                        throw new IncorrectNumber("You choose the incorrect number!");

                                }
                            }

                            catch (IncorrectNumber e) { ShowException(e); }
                            catch (IncorrectOrder e) { ShowException(e); }
                            catch (RoomNotFound e) { ShowException(e); }
                            catch (GreatAgeException e) { ShowException(e); }
                            catch (SmallAgeException e) { ShowException(e); }
                            catch (WrongDayException e) { ShowException(e); }
                            catch (WrongMonthException e) { ShowException(e); }
                            catch (WrongGender e) { ShowException(e); }
                            catch (IncorrectID e) { ShowException(e); }
                            catch (IncorrectName e) { ShowException(e); }
                            catch (TooMuchGuests e) { ShowException(e); }
                            catch (TooLittleGuests e) { ShowException(e); }
                            catch (EndDateIsLessThanStartDate e) { ShowException(e); }
                            catch (RoomAlreadybooked e) { ShowException(e); }
                            catch (WrongPassword e) { ShowException(e); }

                        }
                    }
            
                    else if (accountType == 3)
                    {
                        ShowMessage("You exit the menu.");
                        activeWork = false;
                    }

                    else
                    {
                        throw new IncorrectNumber("You choose the incorrect number!");
                    }
                }

                catch (System.FormatException)
                {
                    ConsoleColor colorNow = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Format of data is wrong. Try again!");
                    Console.ForegroundColor = colorNow;
                }

                catch (WrongPassword e)
                {
                    ShowException(e);
                }

                catch (IncorrectNumber e)
                {
                    ShowException(e);
                }
                
            }
        }

        private static void ShowException(Exception e)
        {
            ConsoleColor colorNow = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
            Console.ForegroundColor = colorNow;
        }

        private static void MainAccount(Hotel hotelObject)
        {
            Console.WriteLine($"Hotel {hotelObject.HotelName} count is {hotelObject.GetMainAccount()} state of {Hotel.nowDate}.");
        }

        private static void RoomsInfo(Hotel hotelObject)
        {
            ConsoleColor colorNow = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nThis is info about {hotelObject.roomsArray.Length} available rooms in {hotelObject.HotelName}.");
            Console.ForegroundColor = colorNow;
            for (int i = 0; i < hotelObject.roomsArray.Length; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Room {i + 1}:");
                if (hotelObject.roomsArray[i].rentingData.Rented == true)
                {
                    Console.WriteLine($"Rented: yes");
                }
                else
                {
                    Console.WriteLine($"Rented: no");
                }
                Console.WriteLine($"Number: {hotelObject.roomsArray[i].RoomNumber}");
                Console.WriteLine($"Area: {hotelObject.roomsArray[i].Area} Places: {hotelObject.roomsArray[i].PlacesNumber}");

                if (hotelObject.roomsArray[i] is StandartRoom)
                {
                    StandartRoom roomCheck1 = (StandartRoom)hotelObject.roomsArray[i];
                    if (roomCheck1.Coffemachine == true)
                    {
                        Console.WriteLine($"Coffeemachine: +");
                    }
                    else
                    {
                        Console.WriteLine($"Coffeemachine: -");
                    }

                    if (roomCheck1.WiFi == true)
                    {
                        Console.WriteLine($"WiFi: +");
                    }
                    else
                    {
                        Console.WriteLine($"WiFi: -");
                    }

                    if (roomCheck1.Pets == true)
                    {
                        Console.WriteLine($"Pets: +");
                    }
                    else
                    {
                        Console.WriteLine($"Pets: -");
                    }
                }

                if (hotelObject.roomsArray[i] is MiddleRoom)
                {
                    MiddleRoom roomCheck2 = (MiddleRoom)hotelObject.roomsArray[i];
                    if (roomCheck2.Coffemachine == true)
                    {
                        Console.WriteLine($"Coffeemachine: +");
                    }
                    else
                    {
                        Console.WriteLine($"Coffeemachine: -");
                    }

                    if (roomCheck2.WiFi == true)
                    {
                        Console.WriteLine($"WiFi: +");
                    }
                    else
                    {
                        Console.WriteLine($"WiFi: -");
                    }

                    if (roomCheck2.Pets == true)
                    {
                        Console.WriteLine($"Pets: +");
                    }
                    else
                    {
                        Console.WriteLine($"Pets: -");
                    }

                    if (roomCheck2.Minibar == true)
                    {
                        Console.WriteLine($"Minibar: +");
                    }
                    else
                    {
                        Console.WriteLine($"Minibar: -");
                    }
                }

                if (hotelObject.roomsArray[i] is LuxRoom)
                {
                    LuxRoom roomCheck3 = (LuxRoom)hotelObject.roomsArray[i];
                    if (roomCheck3.Coffemachine == true)
                    {
                        Console.WriteLine($"Coffeemachine: +");
                    }
                    else
                    {
                        Console.WriteLine($"Coffeemachine: -");
                    }

                    if (roomCheck3.WiFi == true)
                    {
                        Console.WriteLine($"WiFi: +");
                    }
                    else
                    {
                        Console.WriteLine($"WiFi: -");
                    }

                    if (roomCheck3.Pets == true)
                    {
                        Console.WriteLine($"Pets: +");
                    }
                    else
                    {
                        Console.WriteLine($"Pets: -");
                    }
                    if (roomCheck3.Minibar == true)
                    {
                        Console.WriteLine($"Minibar: +");
                    }
                    else
                    {
                        Console.WriteLine($"Minibar: -");
                    }

                    if (roomCheck3.Condition == true)
                    {
                        Console.WriteLine($"Condition: +");
                    }
                    else
                    {
                        Console.WriteLine($"Condition: -");
                    }
                }
            }
        }
        private static void ShowMessage(string message)
        {
            ConsoleColor colorNow = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ForegroundColor = colorNow;
        }

        private static void BookHandler(object sender, RoomEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private static void RentHandler(object sender, RoomEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private static void ContinueRoom(Hotel hotelObject)
        {
            ShowMessage("Fill the form for continuing.");
            Console.WriteLine("Enter the room`s number: ");
            int roomNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the quantity of days: ");
            int daysNumber = Convert.ToInt32(Console.ReadLine());
            if (hotelObject.FindRoom(roomNumber) != null)
            {
                if (hotelObject.roomsArray[roomNumber - 1].rentingData.Rented == true)
                {
                    Room addRoom = hotelObject.roomsArray[roomNumber - 1];
                    DateTime tempData = addRoom.rentingData.ToDate;
                    addRoom.rentingData = addRoom.rentingData + daysNumber;
                    hotelObject.PutMainAccount(hotelObject.Price(roomNumber, addRoom.rentingData.guestsArray, tempData, addRoom.rentingData.ToDate));
                    ShowMessage("The renting of room was successfully changed.");
                    ShowMessage($"New date of departure is {hotelObject.roomsArray[roomNumber - 1].rentingData.ToDate}");
                }
                else
                {
                    throw new EndDateIsLessThanStartDate("This number`s room is not in rent now!");
                }
            }
            else
            {
                throw new RoomNotFound("This number`s room not found!");
            }
        }

    }
}
