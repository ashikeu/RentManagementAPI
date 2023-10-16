namespace RentManagementAPI.Models.DTOs.Tenant
{
    using RentManagementAPI.Models;
    public class GetTenantDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string NID { get; set; } = string.Empty;
        public string PassportNo { get; set; } = string.Empty;
        public string BirthCertificateNo { get; set; } = string.Empty;
        public string MobileNo { get; set; } = string.Empty;
        public string EmgMobileNo { get; set; } = string.Empty;
        public int NoofFamilyMember { get; set; }
        public DateTime ArrivalDate { get; set; }

        public double AdvanceAmount { get; set; }
        public bool IsActive { get; set; }
        public Byte[] TenantImage { get; set; }
        public Byte[] TenantNidImage { get; set; } 
        public DateTime RentAmountChangeDate { get; set; }

        

    }
}
