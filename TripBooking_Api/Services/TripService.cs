using TripBooking_Api.Interfaces;
using TripBooking_Api.Models;
using TripBooking_Api.DbModels;
using System.Xml.Linq;
using TripBooking_Api.Enums;

namespace TripBooking_Api.Services
{
	public class TripService : ITripService
	{

		private TripDbContext _context;

		public TripService(TripDbContext context)
		{
			_context = context;
		}

		public void AddTrip(TripFull tripItem)
		{
			try
			{
				_context.Trips.Add(new Trip()
				{
					Name = tripItem.Name,
					Country = tripItem.Country,
					Description = tripItem.Description,
					StartDate = tripItem.StartDate,
					NumberOfSeats = tripItem.NumberOfSeats
				});
				_context.SaveChanges();
			}
			catch (ArgumentException e)
			{

				throw  new Exception ($"Już istnieje klucz o nazwie {tripItem.Name}");
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public void DeleteTrip(string name)
		{
			try
			{
				if (_context.Trips.Any(p => p.Name == name))
				{

					_context.Trips.Remove(_context.Trips.FirstOrDefault(p => p.Name == name));
					_context.SaveChanges();
				}

				else
				{
					throw new Exception($"Nie istnieje klucz o nazwie {name}");
				}
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public void EditTrip(TripFull tripItem)
		{
			try
			{
				if (_context.Trips.Any(p => p.Name == tripItem.Name))
				{
				_context.Trips.Update(new Trip()
					{
						Name = tripItem.Name,
						Country = tripItem.Country,
						Description = tripItem.Description,
						StartDate = tripItem.StartDate,
						NumberOfSeats = tripItem.NumberOfSeats
					});
					_context.SaveChanges();
				}

				else
				{
					throw new Exception($"Nie istnieje klucz o nazwie {tripItem.Name}");
				}
			}
			catch (Exception e)
			{
				throw e;
			}
		}


		public TripFull GetTrip(string name)
		{
			Trip trip = _context.Trips.FirstOrDefault(p => p.Name == name);
			if (trip == null)
			{
				throw new Exception($"Nie istnieje klucz o nazwie {name}");

			}

			else
			{
				return new TripFull()
				{
					Description = trip.Description,
					StartDate = trip.StartDate,
					NumberOfSeats = trip.NumberOfSeats,
					Country = trip.Country,
					Name = trip.Name

				};
			}
		}

		public List<TripWithoutDescription> GetList()
		{
			return _context.Trips.Select(p => new TripWithoutDescription()
			{
				Name = p.Name,
				StartDate = p.StartDate,
				Country = p.Country,
				NumberOfSeats = p.NumberOfSeats
			}).ToList();
		}


		public List<TripWithoutDescription> GetListByCountry(CountryEnum country)
		{
			return _context.Trips.Select(p => new TripWithoutDescription()
			{
				Name = p.Name,
				StartDate = p.StartDate,
				Country = p.Country,
				NumberOfSeats = p.NumberOfSeats
			}).Where(p=>p.Country==country).ToList();
		}
	}
}
