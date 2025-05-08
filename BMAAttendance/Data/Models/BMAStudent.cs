using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMAAttendance.Data.Models
{
    public class BMAStudent
    {
        [Key] public Guid ID { get; set; }
        private Guid _userID;
        public Guid UserID
        {
            get
            {
                return _userID;
            }
            set
            {
                if (_userID != value)
                    _isDirty = true;
                _userID = value;
            }
        }
        public Guid SchoolID { get; set; }
        public string StudentName { get; set; } = "";
        public string EmailAddress { get; set; } = "";
        public string? PhoneNumber { get; set; }
        public Guid? RankID { get; set; }
        public DateTime? DateAwarded { get; set; }
        //[ForeignKey(nameof(BMAStudent.ID))]//let's revisit this later
        [NotMapped] public List<BMAStudentAttend> Attends { get; set; } = [];
        [NotMapped] public List<BMAStudentRank> StudentRanks { get; set; } = [];
        private bool _isDirty = false;
        public void Clean() => _isDirty = false;
        public bool IsDirty
        {
            get
            {
                return _isDirty;
            }
        }
        public BMAStudent()
        {
            ID = Guid.NewGuid();
        }
    }
}