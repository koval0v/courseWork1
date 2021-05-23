using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWork_KovalVadim_IS01
{
    interface IRoom
    {
        void Book(Guest[] guestsArray, int fromDay, int toDay, int fromMonth, int toMonth, int fromYear, int toYear)
        { }

        void Rent(Guest[] guestsArray, int toDay, int toMonth, int toYear)
        { }
    }
}
