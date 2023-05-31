using System.ComponentModel.DataAnnotations;

namespace BigBang_Assessment.Models
{
    public class Hotel
    {
        [Key]
        public int Hotel_Id { get; set; }
        public string Hotel_Name { get; set; } = string.Empty;
        public string Hotel_Location { get; set; } = string.Empty;
        public string Hotel_Type { get; set; } = string.Empty;
        public string Feedback { get; set; } = string.Empty;
        public ICollection<Rooms>? Rooms { get; set; }
    }
}
