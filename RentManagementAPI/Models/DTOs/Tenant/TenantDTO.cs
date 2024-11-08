﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RentManagementAPI.Models.DTOs.Tenant
{
    public class TenantDTO
    {
      
        public int UserId { get; set; }
        public int BuildingId { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? NID { get; set; } = string.Empty;
        public string? PassportNo { get; set; } = string.Empty;
        public string? BirthCertificateNo { get; set; } = string.Empty;
        public string? MobileNo { get; set; } = string.Empty;
        public string? EmgMobileNo { get; set; } = string.Empty;
        public int? NoofFamilyMember { get; set; }
        public DateTime? ArrivalDate { get; set; }

        public double? AdvanceAmount { get; set; }
        public bool? IsActive { get; set; }
        public byte[]? TenantImage { get; set; }
        public byte[]? TenantNidImage { get; set; }
        public DateTime? RentAmountChangeDate { get; set; }
    }
}
