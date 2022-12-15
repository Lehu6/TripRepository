using TripBooking_Api.Enums;
using TripBooking_Api.Models;
namespace TripBooking_Api.Interfaces
{
	public interface ITripService
	{
		public void AddTrip(TripFull tripItem);
		public List<TripWithoutDescription> GetList();
		public void EditTrip(TripFull tripItem);
		public void DeleteTrip(string name);
		public List<TripWithoutDescription> GetListByCountry(CountryEnum country);
		public TripFull GetTrip(string name);

	}
}
