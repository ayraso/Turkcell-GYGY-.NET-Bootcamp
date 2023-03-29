// See https://aka.ms/new-console-template for more information
using LiskovSubstution;

Console.WriteLine("Hello, World!");

Reservation.ReserveSeminarHall(150);

ISeminarHall paidHall = Reservation.ReserveSeminarHall(70);
paidHall.Code = "VM302";
Console.WriteLine(paidHall.Code);
