using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWork_KovalVadim_IS01
{
    class GreatAgeException : Exception
    {
        public GreatAgeException(string message) : base(message)
        { }
    }

    class SmallAgeException : Exception
    {
        public SmallAgeException(string message) : base(message)
        { }
    }

    class WrongMonthException : Exception
    {
        public WrongMonthException(string message) : base(message)
        { }
    }

    class WrongDayException : Exception
    {
        public WrongDayException(string message) : base(message)
        { }
    }

    class WrongGender : Exception
    {
        public WrongGender(string message) : base(message)
        { }
    }

    class IncorrectID : Exception
    {
        public IncorrectID(string message) : base(message)
        { }
    }

    class IncorrectName : Exception
    {
        public IncorrectName(string message) : base(message)
        { }
    }

    class TooMuchGuests : Exception
    {
        public TooMuchGuests(string message) : base(message)
        { }
    }

    class TooLittleGuests : Exception
    {
        public TooLittleGuests(string message) : base(message)
        { }
    }

    class EndDateIsLessThanStartDate : Exception
    {
        public EndDateIsLessThanStartDate(string message) : base(message)
        { }
    }

    class RoomNotFound : Exception
    {
        public RoomNotFound(string message) : base(message)
        { }
    }

    class RoomAlreadybooked : Exception
    {
        public RoomAlreadybooked(string message) : base(message)
        { }
    }

    class WrongPassword : Exception
    {
        public WrongPassword(string message) : base(message)
        { }
    }

    class IncorrectNumber : Exception
    {
        public IncorrectNumber(string message) : base(message)
        { }
    }

    class IncorrectOrder : Exception
    {
        public IncorrectOrder(string message) : base(message)
        { }
    }



}
