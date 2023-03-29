using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstution
{
    public static class Reservation
    {
        public static ISeminarHall ReserveSeminarHall(int numOfParticipants)
        {
            if(numOfParticipants > 100)
            {
                return new TheaterStyleConferenceHall();
            }
            return new UShapedSeminarHall();
        }
    }
}
