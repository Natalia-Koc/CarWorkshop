namespace CarWorkshop.MVCv2.Models
{
    public class About
    {
        public int ID { get; set; } 
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<string>? Tags { get; set; } = new List<string>();
    }
}

