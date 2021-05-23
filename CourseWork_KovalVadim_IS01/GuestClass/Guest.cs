using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWork_KovalVadim_IS01
{
    class Guest
    {
        private string _name;
        private DateTime _birthDate;
        private string _gender;
        private int _passportID;
        public int Password { get; internal set; }

        public Guest(string name, int day, int month, int year, string gender, int id)
        {
            
            if (month > 13 || month < 1)
            {
                throw new WrongMonthException("Such month number is wrong!");
            }

            else if (day > 31 || day < 1)
            {
                throw new WrongDayException("Such day number is wrong!");
            }
            
            else
            {
                DateTime date_of_guest_birth = new DateTime(year, month, day);
                if ((DateTime.Today - date_of_guest_birth).TotalDays / 365 > 100)
                {
                    throw new GreatAgeException("Age is greater than 100!");
                }

                else if ((DateTime.Today - date_of_guest_birth).TotalDays / 365 < 18)
                {
                    throw new SmallAgeException("Age is smaller than 18!");
                }

                else if (gender != "male" && gender != "female")
                {
                    throw new WrongGender("Gender must be male or female!");
                }

                else if ((Convert.ToString(id)).Length < 5)
                {
                    throw new IncorrectID("ID must contains more than 5 numerals!");
                }

                else if (String.IsNullOrEmpty(name))
                {
                    throw new IncorrectName("Name of guest must not to be empty!");
                }

                else
                {
                    _name = name;
                    _birthDate = date_of_guest_birth;
                    _gender = gender;
                    _passportID = id;
                }
            }

        }

    }
}
