using System.ComponentModel.DataAnnotations;
using TripBooking_Api.Enums;

namespace TripBooking_Api.Models
{
	public class TripWithoutDescription 
	{

		public string Name { get; set; }
		public DateTime? StartDate { get; set; }
		public int? NumberOfSeats { get; set; }
		public CountryEnum Country { get; set; }
	}
}
