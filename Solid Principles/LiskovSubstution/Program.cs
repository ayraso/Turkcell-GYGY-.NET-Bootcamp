using LiskovSubstution;

Reservation.ReserveSeminarHall(150);

ISeminarHall paidHall = Reservation.ReserveSeminarHall(70);
paidHall.Code = "VM302";
Console.WriteLine(paidHall.Code);

IHotelRoom paidRoom = Reservation.ReserveHotelRoom(6);
paidRoom.Code = "BL214";
Console.WriteLine(paidRoom.Code);


