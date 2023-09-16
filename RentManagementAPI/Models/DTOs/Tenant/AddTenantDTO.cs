namespace RentManagementAPI.Models.DTOs.Tenant
{
    public class AddTenantDTO
    {
        public string Name { get; set; } = string.Empty;
        public string NID { get; set; } = string.Empty;
        public string PassportNo { get; set; } = string.Empty;
        public string BirthCertificateNo { get; set; } = string.Empty;
        public string MobileNo { get; set; } = string.Empty;
        public int NoofFamilyMember { get; set; }
        public DateTime ArrivalDate { get; set; }
        public double RentAmount { get; set; }
        public double ElectricityBill { get; set; }
        public double GasBill { get; set; }
        public double WaterBill { get; set; }
        public double TotalAmount { get; set; }
        public int FloorId { get; set; }
        public int FlatId { get; set; }

    }
}
