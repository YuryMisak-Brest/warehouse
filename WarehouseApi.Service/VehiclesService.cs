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
			var vehicles = warehouses.SelectMany(x => x.Cars.Vehicles).OrderBy(x => x.DateAdded).ToList();
			
			foreach (var vehicle in vehicles)
			{
				//gonna make it to find appropriate picture in google by model and year. don't know how to do yet, but.. :)
				vehicle.Pic = "https://images.unsplash.com/photo-1605559424843-9e4c228bf1c2?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8OXx8Y2Fyc3xlbnwwfHwwfHw%3D&w=1000&q=80";
			}
			return vehicles;
		}
	}
}
