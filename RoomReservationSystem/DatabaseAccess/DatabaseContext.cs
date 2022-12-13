using Microsoft.EntityFrameworkCore;
using RoomReservationSystem.Models;

namespace RoomReservationSystem.DatabaseAccess;

public class DatabaseContext : DbContext
{
	public DbSet<Reservation> Reservations { get; set; }
	public DbSet<Series> Series { get; set; }
	public DbSet<Room> Rooms { get; set; }

	public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
}
