using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseApi.Storage.Models
{
	public class Vehicle
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int DbId { get; set; }
		public int Id { get; set; }
		public string Make { get; set; }
		public string Model { get; set; }
		public int YearModel { get; set; }
		public decimal Price { get; set; }
		public bool Licensed { get; set; }
		public DateTime DateAdded { get; set; }
		public string Pic { get; set; }
	}
}
