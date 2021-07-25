using Converter.Enums;
using Converter.Interfaces;
using Converter.Models;
using System;

namespace Converter.Services
{
	public class TemperatureConversionService : ITemperatureConversionService
	{
		public TemperatureConversionService() { }

		public double Convert(TemperatureConversion temperature)
		{
			double convertedTemperature;
			switch (temperature.ConvertFromID)
			{
				case (int)TemperatureUnits.Celsius:
					convertedTemperature = ConvertCelsius(temperature);
					break;
				case (int)TemperatureUnits.Fahrenheit:
					convertedTemperature = ConvertFahrenheit(temperature);
					break;
				case (int)TemperatureUnits.Kelvin:
					convertedTemperature = ConvertKelvin(temperature);
					break;
				default:
					convertedTemperature = temperature.TemperatureInput;
					break;
			}
			return Math.Round(convertedTemperature, 2);
		}

		private double ConvertCelsius(TemperatureConversion temperatureToConvert)
		{
			switch (temperatureToConvert.ConvertToID)
			{
				default:
				case (int)TemperatureUnits.Celsius:
					return temperatureToConvert.TemperatureInput;

				case (int)TemperatureUnits.Fahrenheit:
					return (temperatureToConvert.TemperatureInput * 9/5) + 32;

				case (int)TemperatureUnits.Kelvin:
					return temperatureToConvert.TemperatureInput + 273.15;
			}
		}

		private double ConvertFahrenheit(TemperatureConversion temperatureToConvert)
		{
			switch (temperatureToConvert.ConvertToID)
			{
				default:
				case (int)TemperatureUnits.Fahrenheit:
					return temperatureToConvert.TemperatureInput;

				case (int)TemperatureUnits.Celsius:
					return (temperatureToConvert.TemperatureInput - 32) * 5/9;

				case (int)TemperatureUnits.Kelvin:
					return (temperatureToConvert.TemperatureInput - 32) * 5/9 + 273.15;
			}
		}

		private double ConvertKelvin(TemperatureConversion temperatureToConvert)
		{
			switch (temperatureToConvert.ConvertToID)
			{
				default:
				case (int)TemperatureUnits.Kelvin:
					return temperatureToConvert.TemperatureInput;

				case (int)TemperatureUnits.Celsius:
					return temperatureToConvert.TemperatureInput - 273.15;

				case (int)TemperatureUnits.Fahrenheit:
					return (temperatureToConvert.TemperatureInput - 273.15) * 9/5 + 32;
			}

		}

	}
}
