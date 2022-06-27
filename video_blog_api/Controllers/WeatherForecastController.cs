using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using video_blog_api.Models;
using Newtonsoft.Json.Linq;

namespace video_blog_api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
				"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<WeatherForecastController> _logger;
		private readonly IConfiguration _configuration;

		public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
		}

		[HttpGet(Name = "GetWeatherForecast")]
		public JsonResult Get()
		{
			string query = @"select * from Users";
			DataTable table = new DataTable();
			string sqlDataSource = _configuration.GetConnectionString("videoBlogCon");
			NpgsqlDataReader myReader;
			using(NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
			{
				myCon.Open();
				using (NpgsqlCommand command = new NpgsqlCommand(query, myCon))
				{
					myReader = command.ExecuteReader();
					table.Load(myReader);
					myReader.Close();
					myCon.Close();
				}
			}

			return new JsonResult(table);

		}
	}
}
