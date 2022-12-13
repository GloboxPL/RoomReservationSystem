using System.Text.Json.Serialization;

namespace RoomReservationSystem.Models;

public class Room
{
	public Guid Id { get; set; } = Guid.NewGuid();
	public string Name { get; set; }

	[JsonIgnore]
	public virtual List<Reservation> Reservations { get; } = new List<Reservation>();

	public Room(string name)
	{
		Name = name;
	}
}
