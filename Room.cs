public partial class Room
{
    public int RoomId { get; set; }
    public string RoomType { get; set; } = null!;
    public decimal PricePerNight { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
