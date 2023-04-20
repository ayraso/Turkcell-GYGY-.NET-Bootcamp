using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
                return new TheaterStyleSeminarHall();
            }
            return new UShapedSeminarHall();
        }

        public static IHotelRoom ReserveHotelRoom(int numOfPerson)
        {
            switch (numOfPerson)
            {
                case 1:
                    return new SingleRoom();
                case 2:
                    return new DoubleRoom();
                case 3:
                    return new TripleRoom();
                default:
                    throw new NotImplementedException();
            }
        }


    }
}
