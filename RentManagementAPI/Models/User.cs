namespace RentManagementAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }    = string.Empty;
        public int PropertyInfoId { get; set; }

        public string Password { get; set; } = string.Empty;

        public bool IsActive { get; set; } 
        public string Email { get; set; } = string.Empty;
        public string MobileNo { get; set; } = string.Empty;
        public bool IsLoggedIn { get; set; }
        public bool IsRegularUser { get; set; }
        public bool IsAdmin { get; set; }

        


    }
}
