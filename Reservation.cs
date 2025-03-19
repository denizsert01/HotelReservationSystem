public partial class Reservation
{
    public int ReservationId { get; set; }
    public int GuestId { get; set; }
    public int RoomId { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }

    public virtual Guest Guest { get; set; } = null!;
    public virtual Room Room { get; set; } = null!;
}
