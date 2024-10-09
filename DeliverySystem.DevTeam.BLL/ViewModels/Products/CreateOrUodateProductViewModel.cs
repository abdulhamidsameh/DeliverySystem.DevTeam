
using System.ComponentModel.DataAnnotations;

namespace DeliverySystem.DevTeam.BLL.ViewModels.Products
{
    public class CreateOrUodateProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityAvailable { get; set; }

    }
}
