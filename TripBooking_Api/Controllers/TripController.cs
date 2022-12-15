using Microsoft.AspNetCore.Mvc;
using System;
using TripBooking_Api.Enums;
using TripBooking_Api.Models;
using TripBooking_Api.Services;
using TripBooking_Api.DbModels;
using TripBooking_Api.Interfaces;

namespace TripBooking_Api.Controllers
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class TripController : ControllerBase  
	{
		private ITripService _service;
		public TripController(ITripService service)
		{
			_service = service;
		}

		[HttpPost(Name = "AddTrip")]
		public async Task AddTrip([FromQuery]  TripFull tripItem)
		{
			 _service.AddTrip(tripItem);
		}


		[HttpGet(Name = "GetListOfTrips")]
		public List<TripWithoutDescription> GetListOfTrips()
		{
			return _service.GetList();
		}


		[HttpPost(Name = "EditTrip")]
		public async Task EditTrip([FromQuery] TripFull tripItem)
		{
			_service.EditTrip(tripItem);
		}


		[HttpPost(Name = "GetListOfTripsByCountry")]
		public List<TripWithoutDescription> GetListOfTripsByCountry([FromQuery] CountryEnum country)
		{
			return _service.GetListByCountry(country);
		}

	}
}
