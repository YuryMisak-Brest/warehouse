﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseApi.Model
{
	public class Storage
	{
		public string Location { get; set; }
		public List<Vehicle> Vehicles { get; set; }
	}
}
