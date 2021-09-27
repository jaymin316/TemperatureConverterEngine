using Microsoft.VisualStudio.TestTools.UnitTesting;
using Converter.Interfaces;
using Converter.Models;
using Converter.Enums;

namespace Converter.Services.Tests
{
	[TestClass()]
	public class TemperatureConversionServiceTests
	{
		[TestMethod()]
		public void ConvertCelsiusToFahrenheit_Valid()
		{
			// Arrange
			ITemperatureConversionService temperatureConversionService = new TemperatureConversionService();
			TemperatureConversion input = new TemperatureConversion()
			{
				TemperatureInput = 22,
				ConvertFromID = (int)TemperatureUnits.Celsius,
				ConvertToID = (int)TemperatureUnits.Fahrenheit
			};
			var expectedResult = 71.6;

			// Act
			var result = temperatureConversionService.Convert(input);

			// Assert
			Assert.AreEqual(result, expectedResult);
		}

		[TestMethod()]
		public void ConvertCelsiusToKelvin_Valid()
		{
			// Arrange
			ITemperatureConversionService temperatureConversionService = new TemperatureConversionService();
			TemperatureConversion input = new TemperatureConversion()
			{
				TemperatureInput = 22,
				ConvertFromID = (int)TemperatureUnits.Celsius,
				ConvertToID = (int)TemperatureUnits.Kelvin
			};
			var expectedResult = 295.15;

			// Act
			var result = temperatureConversionService.Convert(input);

			// Assert
			Assert.AreEqual(result, expectedResult);
		}

		[TestMethod()]
		public void ConvertCelsiusToKelvin_InValidFromAndTo()
		{
			// Arrange
			ITemperatureConversionService temperatureConversionService = new TemperatureConversionService();
			TemperatureConversion input = new TemperatureConversion()
			{
				TemperatureInput = 22,
				ConvertFromID = 4,
				ConvertToID = 5
			};
			var expectedResult = 295.15;

			// Act
			var result = temperatureConversionService.Convert(input);

			// Assert
			Assert.AreNotEqual(result, expectedResult);
		}

	}
}