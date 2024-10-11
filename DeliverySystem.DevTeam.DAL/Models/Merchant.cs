using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.DevTeam.DAL.Models
{
	public class Merchant : BaseEntity
	{ 
			public string Name { get; set; }
            public bool IsDeleted { get; set; }
			public string Email { get; set; }
			public string PhoneNumber { get; set; }
			public string Address { get; set; } 
            public DateTime CreatedOn { get; set; } = DateTime.Now;
            public DateTime? LastUpdatedOn { get; set; }

    }
}
