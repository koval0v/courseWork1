using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWork_KovalVadim_IS01
{
    public delegate void RoomStateHandler(object sender, RoomEventArgs e);
    public delegate void NextDayHandler();
    public class RoomEventArgs
    {
        public string Message { get; private set; }
        public int RoomNumber { get; private set; }
        public RoomEventArgs(string message, int roomNumber)
        {
            Message = message;
            RoomNumber = roomNumber;
        }
    }


}
