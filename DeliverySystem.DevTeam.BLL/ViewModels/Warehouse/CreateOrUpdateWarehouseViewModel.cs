using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.DevTeam.BLL.ViewModels.Warehouse
{
	public class CreateOrUpdateWarehouseViewModel
	{
        public int Id { get; set; }
        public string Name { get; set; }
		public string City { get; set; }
		public string Manager { get; set; }
	}
}
