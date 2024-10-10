using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.DevTeam.DAL.Models
{
    public class Warehouse : BaseEntity
    {
        public string Name { get; set; } 
        public string City { get; set; } 
        public string Manager { get; set; } 
    }

}
