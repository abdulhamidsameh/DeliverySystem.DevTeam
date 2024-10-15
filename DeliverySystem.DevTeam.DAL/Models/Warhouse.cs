using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.DevTeam.DAL.Models
{
     public class Warhouse : BaseEntity
    {
		public string Name { get; set; }
		public bool IsDeleted { get; set; }
		public string City { get; set; }
		public DateTime CreatedOn { get; set; } = DateTime.Now;
		public DateTime? LastUpdatedOn { get; set; }
		public ICollection<Product> Products { get; set; }
	}
}
