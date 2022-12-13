namespace RoomReservationSystem.Models;

public class Series
{
	public Guid Id { get; private set; } = Guid.NewGuid();

	public required List<Reservation> Reservations { get; init; }
}