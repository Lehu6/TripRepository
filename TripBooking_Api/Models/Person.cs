using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripBooking_Api.Models
{
	public class Person
	{
		//public Person()
		//{
		//	this.Trips = new HashSet<Trip>();
		//}

		[Key]
		[EmailAddress]
		[Index("MailAndTrip", 1, IsUnique = true)]

		public string Mail { get; set; }
		public bool IsRegistered { get; set; }
		[Index("MailAndTrip", 2, IsUnique = true)]

		public string Key_TripName{ get; set; }
		//public  ICollection<Trip> Trips { get; set; }

	}
}
