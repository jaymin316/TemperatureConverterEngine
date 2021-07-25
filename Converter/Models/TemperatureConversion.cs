using System.ComponentModel.DataAnnotations;

namespace Converter.Models
{
	public class TemperatureConversion
	{
		[Required]
		public double TemperatureInput { get; set; }
		[Required]
		public int ConvertFromID { get; set; }
		[Required]
		public int ConvertToID { get; set; }
	}
}
