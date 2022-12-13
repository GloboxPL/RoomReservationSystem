using Microsoft.EntityFrameworkCore;
using RoomReservationSystem.DatabaseAccess;
using RoomReservationSystem.DTOs;
using RoomReservationSystem.Models;

namespace RoomReservationSystem.Services;

public interface IReservationCreator
{
	Reservation Create(ReservationDTO dto);
}

public class ReservationCreator : IReservationCreator
{
	private readonly DatabaseContext _dbContext;

	public ReservationCreator(DatabaseContext dbContext)
	{
		_dbContext = dbContext;
	}

	public Reservation Create(ReservationDTO dto)
	{
		return new Reservation(dto.Name, dto.Start, dto.End)
		{
			Room = _dbContext.Rooms.AsNoTracking().First(r => r.Id == dto.RoomId)
		};
	}
}
