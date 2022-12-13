using Microsoft.EntityFrameworkCore;
using RoomReservationSystem.DatabaseAccess;
using RoomReservationSystem.Services;

namespace RoomReservationSystem;

public class Program
{
	private static readonly string _dbPath = Path.Join(Environment.CurrentDirectory, "database.db");

	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.

		builder.Services.AddControllers();
		builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlite($"Data Source={_dbPath}"));

		builder.Services.AddScoped<IReservationService, ReservationService>();
		builder.Services.AddScoped<IReservationCreator, ReservationCreator>();

		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();


		app.MapControllers();

		app.Run();
	}
}