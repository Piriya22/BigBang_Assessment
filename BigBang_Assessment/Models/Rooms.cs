using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigBang_Assessment.Models
{
    public class Rooms
    {
        [Key]
        public int Room_No { get; set; }

        [ForeignKey("Hotel")]
        public int Hotel_Id { get; set; }
        public string Room_Type { get; set; } = string.Empty;
        public int Cost { get; set;}
        public string Room_Status { get; set; } = string.Empty;
        public string Aminities { get; set; } = string.Empty;
        public Hotel? Hotel { get; set; }

    }
}
