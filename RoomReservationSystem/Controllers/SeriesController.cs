using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoomReservationSystem.DatabaseAccess;
using RoomReservationSystem.DTOs;
using RoomReservationSystem.Models;

namespace RoomReservationSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class SeriesController : ControllerBase
{
	private readonly ILogger<SeriesController> _logger;
	private readonly DatabaseContext _dbContext;

	public SeriesController(ILogger<SeriesController> logger, DatabaseContext dbContext)
	{
		_logger = logger;
		_dbContext = dbContext;
	}

	//[HttpPost("series")]
	//public async Task<Series> PostSeries([FromBody] IEnumerable<ReservationDTO> dto)
	//{
	//	var reservations = new List<Reservation>();
	//	foreach (var item in dto)
	//	{
	//		reservations.Add(new Reservation(item.Name, item.Start, item.End));
	//	}
	//	var series = new Series(reservations);
	//	// add to db
	//	Response.StatusCode = StatusCodes.Status201Created;
	//	return series;
	//}
}