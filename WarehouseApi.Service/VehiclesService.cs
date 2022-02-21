using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using WarehouseApi.Model;
using WarehouseApi.Service.Interface;

namespace WarehouseApi.Service
{
	public class VehiclesService : IVehiclesService
	{
		private T Read<T>(string filePath)
		{
			string text = File.ReadAllText(filePath);
			return JsonSerializer.Deserialize<T>(text, new JsonSerializerOptions {PropertyNameCaseInsensitive = true} );
		}

		private string GetVehicleImage(Vehicle vehicle)
		{
			try
			{
				var searchUrl =
					$"https://www.googleapis.com/customsearch/v1?key=AIzaSyCmWH3xXxKoTjcYdI52hpamm8_cc9vQ_2o&cx=4419d3df22894e90a&q={vehicle.Make}%20{vehicle.Model}%20{vehicle.YearModel}&searchType=image&fileType=jpg&imgSize=large&alt=json";
				string json;
				using (WebClient wc = new WebClient())
				{
					json = wc.DownloadString(searchUrl);
				}
				var result = JsonSerializer.Deserialize<SearchResult>(json,
					new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
				return result?.Items.FirstOrDefault()?.Link;
			}
			catch (Exception)
			{
				return
					"https://d2uzer0pyv83wf.cloudfront.net/Pictures/480x270/8/2/8/275828_automobilipininfarinapuravisiondesignconceptmodel_la2019_223286_crop.jpeg";
			}
		}

		public IList<Vehicle> GetVehicles()
		{
			var warehouses = Read<List<Warehouse>>("warehouses.json");
			var vehicles = warehouses.SelectMany(x => x.Cars.Vehicles).OrderBy(x => x.DateAdded).ToList();
			
			foreach (var vehicle in vehicles)
			{
				vehicle.Pic = GetVehicleImage(vehicle);
			}
			return vehicles;
		}
	}
}
