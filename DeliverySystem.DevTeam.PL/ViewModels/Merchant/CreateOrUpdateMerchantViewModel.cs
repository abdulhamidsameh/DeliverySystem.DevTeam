﻿namespace DeliverySystem.DevTeam.PL.ViewModels.Merchant
{
    public class CreateOrUpdateMerchantViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }  
        public string Email { get; set; }  
		public string PhoneNumber { get; set; }
		public string Address { get; set; } 
	}
}