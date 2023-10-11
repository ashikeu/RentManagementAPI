using System.Collections.Generic;

namespace RentManagementAPI.Models
{
    public class Floor
    {
        public int Id { get; set; }
        public int UserId { get; set; } 
        public int BuildingId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } 

        public Building Building { get; set; }
        public List<Flat> Flats { get; set; } = new List<Flat>(); 

    }
}
