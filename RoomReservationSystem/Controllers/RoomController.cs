using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoomReservationSystem.DatabaseAccess;
using RoomReservationSystem.Models;

namespace RoomReservationSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomController : ControllerBase
{
	private readonly DatabaseContext _dbContext;

	public RoomController(DatabaseContext dbContext)
	{
		_dbContext = dbContext;
	}

	[HttpGet]
	public async Task<Room?> GetRoom([FromQuery] Guid id)
	{
		var room = await _dbContext.Rooms.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
		if (room == null)
		{
			Response.StatusCode = StatusCodes.Status404NotFound;
		}
		return room;
	}

	[HttpPost]
	public async Task<Room> AddRoom([FromQuery] string name)
	{
		var room = new Room(name);
		await _dbContext.Rooms.AddAsync(room);
		await _dbContext.SaveChangesAsync();
		Response.StatusCode = StatusCodes.Status201Created;
		return room;
	}
}
