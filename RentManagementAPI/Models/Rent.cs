using System.Collections.Generic;
using System;

namespace RentManagementAPI.Models
{
    public class Rent
    {

        public int Id { get; set; }
        public DateTime RentMonth { get; set; }
        public double TotalAmount { get; set; }
        public bool IsPaid { get; set; }
        public int FlatId { get; set; }
        public Flat Flat { get; set; }
        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }
        public List<Deposite> Deposites { get; set; }
    }
}
