public partial class Guest
{
    public int GuestId { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
