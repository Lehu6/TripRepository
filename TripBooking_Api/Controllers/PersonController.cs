using Microsoft.AspNetCore.Mvc;
using TripBooking_Api.Interfaces;
using TripBooking_Api.Models;

namespace TripBooking_Api.Controllers
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class PersonController
	{
		private IPersonService _service;
		public PersonController(IPersonService service)
		{
			_service = service;
		}
		[HttpPost(Name = "RegisterPerson")]
		public async Task RegisterPerson([FromQuery] PersonRegister personItem)
		{
			_service.RegisterToTrip(personItem);
		}


		[HttpPost(Name = "UnRegisterPerson")]
		public async Task UnRegisterPerson([FromQuery] PersonRegister personItem)
		{
			_service.UnregisterFrom(personItem);
		}

	}
}
