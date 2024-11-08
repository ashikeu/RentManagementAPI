using System.Collections.Generic;
using System;

namespace RentManagementAPI.Models
{
    public class Rent
    {

        public int Id { get; set; }
        public DateTime? RentMonth { get; set; }
        public double? RentAmount { get; set; }
        public double? GasBill { get; set; }
        public double? WaterBill { get; set; }
        public double? ServiceCharge { get; set; } 
        public double? TotalAmount { get; set; }
        public double? DueAmount  { get; set; }
        public bool? IsPaid { get; set; }
        public int FlatId { get; set; }
        public int BuildingId { get; set; }
        public int UserId { get; set; }
        public int TenantId { get; set; }
        public bool? IsPrinted { get; set; }
        public string ReciptNo { get; set; } = string.Empty;

        public virtual Flat? Flat { get; set; }
        public virtual User? User { get; set; }
        public virtual Tenant? Tenant { get; set; }
        public virtual Building? Building { get; set; }




    }
}
