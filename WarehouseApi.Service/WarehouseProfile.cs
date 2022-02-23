using AutoMapper;
using WarehouseApi.Model;

namespace WarehouseApi.Service
{
	public class WarehouseProfile : Profile
	{
		public WarehouseProfile() 
		{
			CreateMap<Vehicle, Storage.Models.Vehicle>().ReverseMap();
		}
		
	}

}
