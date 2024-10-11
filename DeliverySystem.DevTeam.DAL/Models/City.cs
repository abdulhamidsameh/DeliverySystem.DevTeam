using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.DevTeam.DAL.Models
{
    public class City : BaseEntity
    {


        public string Name { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? LastUpdatedOn { get; set; }

    }
}
