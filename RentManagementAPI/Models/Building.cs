namespace RentManagementAPI.Models
{
    public class Building
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public int UserId { get; set; }
        public bool? IsActive { get; set; } 
        
        public virtual PropertyInfo? PropertyInfo { get; set; }
      

    }
}
