using Converter.Interfaces;
using Converter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Converter.Controllers
{
	[ApiController]
	[Produces("application/json")]
	[Route("[controller]")]
	public class UnitConversionController : ControllerBase
	{
		private readonly ILogger<UnitConversionController> _logger;
		private readonly ITemperatureConversionService _service;

		public UnitConversionController(ILogger<UnitConversionController> logger, ITemperatureConversionService service)
		{
			_logger = logger;
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok("API running...");
		}

		[HttpPost]
		[Route("")]
		public async Task<IActionResult> ConvertTemperature([FromBody] TemperatureConversion temperatureToConvert)
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
