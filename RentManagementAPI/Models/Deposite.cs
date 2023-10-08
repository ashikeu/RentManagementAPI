using System;

namespace RentManagementAPI.Models
{
    public class Deposite
    { 
        public int Id { get; set; }
        public int UserId { get; set; }
        public double TotalAmount { get; set; }
        public double DepositeAmount { get; set; }
        public double DueAmount { get; set; }
        public DateTime TranDate { get; set; }
        public int RentId { get; set; }
        
    }
}
