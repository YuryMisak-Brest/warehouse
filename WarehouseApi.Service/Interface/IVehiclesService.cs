using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseApi.Model;

namespace WarehouseApi.Service.Interface
{
	public interface IVehiclesService
	{
		IList<Vehicle> GetVehicles();
	}
}
