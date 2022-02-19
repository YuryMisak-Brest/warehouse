using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseApi.Model;
using WarehouseApi.Service.Interface;

namespace WarehouseApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class VehiclesController : ControllerBase
	{

		private readonly ILogger<VehiclesController> _logger;
		private readonly IVehiclesService _vehiclesService;

		public VehiclesController(ILogger<VehiclesController> logger, IVehiclesService vehiclesService)
		{
			_logger = logger;
			_vehiclesService = vehiclesService;

		}

		[HttpGet]
		public IEnumerable<Vehicle> Get()
		{
			return _vehiclesService.GetVehicles();
		}
	}
}
