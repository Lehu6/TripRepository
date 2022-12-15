using TripBooking_Api.Enums;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace TripBooking_Api.Models
{

	public class Trip 
	{
		//public Trip()
		//{
		//	this.Persons = new HashSet<Person>();
		//}
		[Key]
		public string Name { get; set; }
		public DateTime? StartDate { get; set; }
		public int? NumberOfSeats { get; set; }
		public CountryEnum Country { get; set; }
		public string? Description { get; set; }

		//public  ICollection<Person> Persons { get; set; }

	}


}
