using Converter.Interfaces;
using Converter.Models;
using Microsoft.AspNetCore.Mvc;

namespace Converter.Controllers
{
	[ApiController]
	[Produces("application/json")]
	[Route("[controller]")]
	public class UnitConversionController : ControllerBase
	{
		private readonly ITemperatureConversionService _service;

		public UnitConversionController(ITemperatureConversionService service)
		{
			_service = service;
		}

		[HttpGet]
		public IActionResult Get()
		{
			return Ok("API running...");
		}

		[HttpPost]
		[Route("")]
		public IActionResult ConvertTemperature([FromBody] TemperatureConversion temperatureToConvert)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var convertedTemperature = _service.Convert(temperatureToConvert);

			return Ok(convertedTemperature);

		}
	}
}
