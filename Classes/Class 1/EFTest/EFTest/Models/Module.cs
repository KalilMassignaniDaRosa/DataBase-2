using System.ComponentModel.DataAnnotations;

namespace EFTest.Models
{
    public class Module
    {
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
        public int Semester { get; set; }
        public string? Situation { get; set; }
        public float? Frequency { get; set; }
    }
}
