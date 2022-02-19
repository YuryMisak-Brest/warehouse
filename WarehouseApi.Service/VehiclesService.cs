using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WarehouseApi.Model;
using WarehouseApi.Service.Interface;

namespace WarehouseApi.Service
{
	public class VehiclesService : IVehiclesService
	{
		public static T Read<T>(string filePath)
		{
			string text = File.ReadAllText(filePath);
			return JsonSerializer.Deserialize<T>(text, new JsonSerializerOptions {PropertyNameCaseInsensitive = true} );
		}

		public IList<Vehicle> GetVehicles()
		{
			var warehouses = Read<List<Warehouse>>("warehouses.json");
			return warehouses.SelectMany(x => x.Cars.Vehicles).OrderBy(x => x.DateAdded).ToList();
		}
	}
}
