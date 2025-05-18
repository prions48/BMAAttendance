using System.ComponentModel.DataAnnotations;

namespace BMAAttendance.Data.Models
{
    public class BMAStudentUser
    {
        [Key] public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid StudentID { get; set; }
        public bool EditInfo { get; set; }
        public BMAStudentUser()
        {
            ID = Guid.NewGuid();
        }
    }
}