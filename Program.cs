//using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

// mevcut odaları listeleme
using (var context = new HotelDbContext(options))
{
    var rooms = context.Rooms.Select(r => new
    {
        r.RoomId,
        r.RoomType,
        r.PricePerNight
    }).ToList();

    foreach (var room in rooms)
    {
        Console.WriteLine($"Oda: {room.RoomId}, Tür: {room.RoomType}, Fiyat: {room.PricePerNight} TL");
    }
}

// belirli bir misafirin rezervasyonlarını getirme
using (var context = new HotelDbContext(options))
{
    var guestName = "Ali Veli";
    var reservations = context.Reservations
        .Where(r => r.Guest.FullName == guestName)
        .Select(r => new
        {
            r.Guest.FullName,
            r.Room.RoomType,
            r.CheckIn,
            r.CheckOut
        })
        .ToList();

    foreach (var res in reservations)
    {
        Console.WriteLine($"Misafir: {res.FullName}, Oda Türü: {res.RoomType}, Giriş: {res.CheckIn}, Çıkış: {res.CheckOut}");
    }
}

//boş odaları listeleme
using (var context = new HotelDbContext(options))
{
    var bookedRoomIds = context.Reservations.Select(r => r.RoomId).Distinct().ToList();

    var availableRooms = context.Rooms
        .Where(r => !bookedRoomIds.Contains(r.RoomId))
        .ToList();

    foreach (var room in availableRooms)
    {
        Console.WriteLine($"Boş Oda: {room.RoomId}, Tür: {room.RoomType}, Fiyat: {room.PricePerNight} TL");
    }
}

//yeni bir rezervasyon ekleme
using (var context = new HotelDbContext(options))
{
    var newReservation = new Reservation
    {
        GuestId = 1,
        RoomId = 2,
        CheckIn = DateTime.Now.AddDays(1),
        CheckOut = DateTime.Now.AddDays(5)
    };

    context.Reservations.Add(newReservation);
    context.SaveChanges();
}

//rezervasyonu güncelleme
using (var context = new HotelDbContext(options))
{
    var reservation = context.Reservations.FirstOrDefault(r => r.ReservationId == 1);

    if (reservation != null)
    {
        reservation.CheckOut = reservation.CheckOut.AddDays(2);
        context.SaveChanges();
    }
}

//rezervasyonu silme
using (var context = new HotelDbContext(options))
{
    var reservation = context.Reservations.FirstOrDefault(r => r.ReservationId == 1);

    if (reservation != null)
    {
        context.Reservations.Remove(reservation);
        context.SaveChanges();
    }
}
