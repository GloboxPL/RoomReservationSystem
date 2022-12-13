using System.Text.Json.Serialization;

namespace RoomReservationSystem.Models;

public class Reservation
{
	public Guid Id { get; set; } = Guid.NewGuid();

	public string Name { get; set; }

	public string Description { get; set; } = string.Empty;

	public Room Room { get; set; }

	public DateTime Start { get; set; }

	public DateTime End { get; set; }

	public TimeSpan Duration => End - Start;

	[JsonIgnore]
	public virtual Series? Series { get; set; }

	public bool IsSeries => Series != null;

	public Reservation(string name, DateTime start, DateTime end)
	{
		if (start > end) throw new ArgumentException("Start value is greater than end value");
		Name = name;
		Start = start;
		End = end;
	}
}
