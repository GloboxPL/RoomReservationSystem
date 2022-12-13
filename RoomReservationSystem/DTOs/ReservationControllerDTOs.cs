namespace RoomReservationSystem.DTOs;

public record ReservationDTO(string Name, DateTime Start, DateTime End, Guid RoomId, string Description = "");
