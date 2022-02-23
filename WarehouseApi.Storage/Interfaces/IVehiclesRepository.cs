using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseApi.Storage.Interfaces
{
	public interface IVehiclesRepository
	{
		void AddUpdateVehicle(Models.Vehicle vehicle);
		IQueryable<Models.Vehicle> GeVehicles();
	}
}
