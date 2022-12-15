using System;
using TripBooking_Api.DbModels;
using TripBooking_Api.Interfaces;
using TripBooking_Api.Models;

namespace TripBooking_Api.Services
{
	public class PersonService : IPersonService
	{
		private TripDbContext _context;

		public PersonService(TripDbContext context)
		{
			_context = context;
		}
		public void RegisterToTrip(PersonRegister person)
		{
			try 
			{
				if (_context.Trips.Any(p => p.Name == person.Key_TripName) && !_context.Persons.Any(p=>p.Mail==person.Mail && p.Key_TripName==person.Key_TripName))
				{

					if (!_context.Trips.FirstOrDefault(p => p.Name == person.Key_TripName).NumberOfSeats.HasValue || _context.Persons.Where(p => p.Key_TripName == person.Key_TripName).Count() < _context.Trips.FirstOrDefault(p => p.Name == person.Key_TripName).NumberOfSeats)
					{
						_context.Persons.Add(new Person()
						{
							IsRegistered = true,
							Mail = person.Mail,
							Key_TripName = person.Key_TripName

						});
						_context.SaveChanges();
					}
					else
					{
						throw new Exception("niestety brakło miejsc");
					}
				}
				else
				{
					if(_context.Persons.Any(p => p.Mail == person.Mail && p.Key_TripName == person.Key_TripName && p.IsRegistered==false))
					{
						_context.Persons.Update(new Person
						{
							IsRegistered = true,
							Mail = person.Mail,
							Key_TripName = person.Key_TripName,

						});
					}
					throw new Exception($"Nie istnieje wycieczka o nazwie {person.Key_TripName}");

				}
			}
			catch (ArgumentException e)
			{

				throw new Exception($"Już istnieje klucz z Mailem: {person.Mail}");
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public void UnregisterFrom(PersonRegister person)
		{
			if (_context.Persons.Any(p => p.Mail == person.Mail && p.Key_TripName==person.Key_TripName && p.IsRegistered==false))
			{				
				_context.Persons.Update(new Person
				{
					IsRegistered=false,
					Mail=person.Mail,
					Key_TripName=person.Key_TripName,		

				});
				_context.SaveChanges();
			}
			else
			{
				throw new Exception($"Nie istnieje klucz z Mailem: {person.Mail}");

			}
		}

	}
}
