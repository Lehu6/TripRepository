using TripBooking_Api.Models;

namespace TripBooking_Api.Interfaces
{
	public interface IPersonService
	{
		public void RegisterToTrip(PersonRegister person);
		public void UnregisterFrom(PersonRegister person);

		
	}
}
