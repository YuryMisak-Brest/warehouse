using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseApi.Model
{
	public class Warehouse
	{
		public string Name { get; set; }
		public Location Location { get; set; }
		public Storage Cars { get; set; }
	}
}
