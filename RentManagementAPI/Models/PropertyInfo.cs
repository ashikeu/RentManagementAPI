﻿namespace RentManagementAPI.Models
{
    public class PropertyInfo
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? WebAddress { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string? OwnerName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? MobileNo { get; set; } = string.Empty;
      
    } 
}
