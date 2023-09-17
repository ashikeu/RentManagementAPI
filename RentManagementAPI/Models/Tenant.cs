using System;

namespace RentManagementAPI.Models
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string NID { get; set; } = string.Empty;
        public string PassportNo { get; set; } = string.Empty;
        public string BirthCertificateNo { get; set; } = string.Empty;
        public string MobileNo { get; set; } = string.Empty;
        public int NoofFamilyMember { get; set; }
        public DateTime ArrivalDate { get; set; }
        public double RentAmount { get; set; }
        public double UtilityBill { get; set; }
        public double GasBill { get; set; }
        public double WaterBill { get; set; }
        public double TotalAmount { get; set; }
        public int FlatId { get; set; }
        
       
        
        public List<Rent> Rents { get; set; } = new List<Rent>();

    }
}
