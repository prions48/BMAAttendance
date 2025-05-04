using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMAAttendance.Data.Models
{
    public class BMAStudentAttend
    {
        [Key] public Guid ID { get; set; }
        public Guid StudentID { get; set; }
        public DateTime AttendDate { get; set; }
        public DateTime LoggedDate { get; set; }
        public Guid LoggedBy { get; set; }
        public BMAStudentAttend()
        {
            ID = Guid.NewGuid();
        }
    }
}