using System.ComponentModel.DataAnnotations;

namespace BMAAttendance.Data.Models
{
    public class BMASchool
    {
        [Key] public Guid ID { get; set; }
        public string SchoolName { get; set; } = "";
        public string SchoolAddress { get; set; } = "";
        public BMASchool()
        {
            ID = Guid.NewGuid();
        }
    }
}