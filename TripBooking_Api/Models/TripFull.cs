using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using TripBooking_Api.Enums;

namespace TripBooking_Api.Models
{
	public class TripFull 
	{

		[Key]
		public string Name { get; set; }
		public DateTime? StartDate { get; set; }
		public int? NumberOfSeats { get; set; }
		public string? Description { get; set; }
		public CountryEnum Country { get; set; }
	}
}
