using Converter.Models;

namespace Converter.Interfaces
{
	public interface ITemperatureConversionService
	{
		double Convert(TemperatureConversion temperature);
	}
}
