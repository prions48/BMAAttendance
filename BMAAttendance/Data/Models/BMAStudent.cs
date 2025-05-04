using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMAAttendance.Data.Models
{
    public class BMAStudent
    {
        [Key] public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid SchoolID { get; set; }
        public string StudentName { get; set; } = "";
        public string EmailAddress { get; set; } = "";
        public string? PhoneNumber { get; set; }
        public Guid? RankID { get; set; }
        public DateTime? DateAwarded { get; set; }
        //[ForeignKey(nameof(BMAStudent.ID))]//let's revisit this later
        [NotMapped] public List<BMAStudentAttend> Attends { get; set; } = [];
        [NotMapped] public List<BMAStudentRank> StudentRanks { get; set; } = [];
        public BMAStudent()
        {
            ID = Guid.NewGuid();
        }
    }
}