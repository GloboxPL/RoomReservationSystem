using Microsoft.AspNetCore.Mvc;
using RoomReservationSystem.DTOs;
using RoomReservationSystem.Models;
using RoomReservationSystem.Services;

namespace RoomReservationSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class ReservationController : ControllerBase
{
	private readonly ILogger<ReservationController> _logger;
	private readonly IReservationService _reservationService;
	private readonly IReservationCreator _reservationCreator;

	public ReservationController(ILogger<ReservationController> logger, IReservationService reservationService, IReservationCreator reservationCreator)
	{
		_logger = logger;
		_reservationService = reservationService;
		_reservationCreator = reservationCreator;
	}

	[HttpGet]
	public Task<Reservation?> GetReservation([FromQuery] Guid id)
	{
		var reservation = _reservationService.GetReservation(id);
		if (reservation == null)
		{
			_logger.LogInformation($"Reservation with id {id} was not found");
			Response.StatusCode = StatusCodes.Status404NotFound;
		}
		return Task.FromResult(reservation);
	}

	[HttpPost]
	public Task<Reservation> AddReservation([FromBody] ReservationDTO dto)
	{
		var reservation = _reservationCreator.Create(dto);
		_reservationService.AddReservation(reservation);

		Response.StatusCode = StatusCodes.Status201Created;
		return Task.FromResult(reservation);
	}

	[HttpPut]
	public Task<Reservation> UpdateReservation([FromBody] ReservationDTO dto)
	{
		var reservation = _reservationCreator.Create(dto);
		_reservationService.UpdateReservation(reservation);
		return Task.FromResult(reservation);
	}

	[HttpDelete]
	public Task DeleteReservation([FromQuery] Guid id)
	{
		_reservationService.RemoveReservation(id);
		Response.StatusCode = StatusCodes.Status204NoContent;
		return Task.CompletedTask;
	}
}