using System;
using System.Text.Json.Serialization;

namespace WarehouseApi.Model
{
	public class Vehicle
	{

		[JsonPropertyName("_id")]
		public int Id { get; set; }
		public string Make { get; set; }
		public string Model { get; set; }
		[JsonPropertyName("year_model")]
		public int YearModel { get; set; }
		public decimal Price { get; set; }
		public bool Licensed { get; set; }
		[JsonPropertyName("date_added")]
		public DateTime DateAdded { get; set; }
		public string Pic { get; set; }
	}
}
