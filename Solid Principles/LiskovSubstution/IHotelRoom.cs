﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstution
{
    public interface IHotelRoom : IReservable
    {
        public string Code { get; set; }

    }
}
