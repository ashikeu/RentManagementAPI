﻿namespace RentManagementAPI.Models.DTOs.User
{
    public class UserDTO
    {
        public string? Name { get; set; } = string.Empty;
        public int PropertyInfoId { get; set; }

        public string? Password { get; set; } = string.Empty;

        public bool IsActive { get; set; }
        public string? Email { get; set; } = string.Empty;
        public string? MobileNo { get; set; } = string.Empty;
        public bool IsLoggedIn { get; set; }
        public bool IsAdmin { get; set; }
    }
}
