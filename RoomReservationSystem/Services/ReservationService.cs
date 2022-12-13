using Microsoft.EntityFrameworkCore;
using RoomReservationSystem.DatabaseAccess;
using RoomReservationSystem.Models;
using RoomReservationSystem.Models.CustomExceptions;

namespace RoomReservationSystem.Services;

public class ReservationService : IReservationService
{
	private readonly DatabaseContext _dbContext;

	public ReservationService(DatabaseContext dbContext)
	{
		_dbContext = dbContext;
	}

	public Reservation AddReservation(Reservation reservation)
	{
		CheckDateAvailability(reservation);
		_dbContext.Reservations.Add(reservation);
		_dbContext.SaveChanges();
		return reservation;
	}

	public Reservation? GetReservation(Guid id)
	{
		return _dbContext.Reservations.AsNoTracking().FirstOrDefault(r => r.Id == id);
	}

	public IEnumerable<Reservation> GetReservations(DateTime startSince, DateTime startUntil)
	{
		return _dbContext.Reservations.Where(r => r.Start >= startSince && r.Start <= startUntil).AsEnumerable();
	}

	public Reservation UpdateReservation(Reservation reservation)
	{
		_dbContext.Reservations.Update(reservation);
		_dbContext.SaveChanges();
		return reservation;
	}

	public void RemoveReservation(Guid id)
	{
		var deletedCount = _dbContext.Reservations.Where(r => r.Id == id).ExecuteDelete();
		if (deletedCount < 1) throw new Exception("Object with given id was not found");
	}

	private bool IsDateAvailable(Reservation reservation)
	{
		var isAvailable = !_dbContext.Reservations
			.Where(r => r.Room.Id == reservation.Room.Id)
			.Any(r => (r.Start >= reservation.Start && r.Start < reservation.End)
			|| (r.End <= reservation.End && r.End > reservation.Start)
			|| (r.Start <= reservation.Start && r.End >= reservation.End));
		return isAvailable;
	}

	private void CheckDateAvailability(Reservation reservation)
	{
		var isAvailable = IsDateAvailable(reservation);
		if (!isAvailable) throw new DateAvailabilityException();
	}
}

public interface IReservationService
{
	Reservation? GetReservation(Guid id);
	IEnumerable<Reservation> GetReservations(DateTime since, DateTime until);
	Reservation AddReservation(Reservation reservation);
	Reservation UpdateReservation(Reservation reservation);
	void RemoveReservation(Guid id);
}