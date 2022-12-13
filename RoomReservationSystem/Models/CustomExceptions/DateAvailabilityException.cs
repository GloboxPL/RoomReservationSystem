namespace RoomReservationSystem.Models.CustomExceptions
{
	public class DateAvailabilityException : Exception
	{
		public override string Message => "Given date is not available";
	}
}
