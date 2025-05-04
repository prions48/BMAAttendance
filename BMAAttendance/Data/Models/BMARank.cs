using System.ComponentModel.DataAnnotations;

namespace BMAAttendance.Data.Models
{
    public class BMARank
    {
        [Key] public Guid ID { get; set; }
        public string RankName { get; set; } = "";
        public string? RankDescription { get; set; }
        public string? Color1 { get; set; }
        public string? Color2 { get; set; }
        public BMARank()
        {
            ID = Guid.NewGuid();
        }
    }
}