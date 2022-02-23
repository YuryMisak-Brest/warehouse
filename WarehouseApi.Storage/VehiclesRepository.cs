using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseApi.Storage.Interfaces;
using WarehouseApi.Storage.Models;

namespace WarehouseApi.Storage
{
	public class VehiclesRepository : IVehiclesRepository
	{
		private readonly WarehouseContext _wContext;

		public VehiclesRepository(WarehouseContext wContext)
		{
			_wContext = wContext;
		}

		public void AddUpdateVehicle(Vehicle vehicle)
		{
			_wContext.Vehicle.Add(vehicle);
			_wContext.SaveChanges();
		}

		public IQueryable<Vehicle> GeVehicles()
		{
			return _wContext.Vehicle;
		}
	}
}
