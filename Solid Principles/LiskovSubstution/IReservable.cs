using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstution
{
    public interface IReservable
    {
        public DateTime? ReservationStartDate { get; set; }
        public int? ReservationDuration { get; set; } 
    }
}
