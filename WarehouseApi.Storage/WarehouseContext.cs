using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using WarehouseApi.Storage.Models;

namespace WarehouseApi.Storage
{
	public class WarehouseContext : DbContext
	{
		public DbSet<Models.Vehicle> Vehicle { get; set; }

		public WarehouseContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
		{
		}

	}
}
