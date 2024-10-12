namespace DeliverySystem.DevTeam.PL.ViewModels.City
{
    public class CityViewModal
    {
        public int   Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? LastUpdatedOn { get; set; }

    }
}
