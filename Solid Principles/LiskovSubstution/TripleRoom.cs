using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstution
{
    public class TripleRoom : IHotelRoom
    {
        public DateTime ReservationStartDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ReservationDuration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Code { get; set; }

    }
}
