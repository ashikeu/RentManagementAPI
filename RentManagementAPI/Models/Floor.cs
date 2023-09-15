using System.Collections.Generic;

namespace RentManagementAPI.Models
{
    public class Floor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Flat> Flats { get; set; } = new List<Flat>();

    }
}
