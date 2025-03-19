using Microsoft.EntityFrameworkCore;

public partial class HotelDbContext : DbContext
{
    public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options) { }

    public virtual DbSet<Guest> Guests { get; set; } = null!;
    public virtual DbSet<Room> Rooms { get; set; } = null!;
    public virtual DbSet<Reservation> Reservations { get; set; } = null!;
}
