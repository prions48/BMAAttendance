using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMAAttendance.Data.Models
{
    public class BMAStudent
    {
        [Key] public Guid ID { get; set; }
        /*private Guid _userID;
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
        }*/
        public Guid SchoolID { get; set; }
        public string StudentName { get { return LastName + ", " + FirstName; } }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string EmailAddress { get; set; } = "";
        public string? PhoneNumber { get; set; }
        public Guid? RankID { get; set; }
        [NotMapped] public BMARank? CurerntRank { get; set; }//set in dialog
        public DateTime? DateAwarded { get; set; }
        public DateTime LastAttended
        {
            get
            {
                if (Attends == null || Attends.Count == 0)
                    return DateTime.MinValue;
                return Attends.MaxBy(e => e.AttendDate)!.AttendDate;
            }
        }
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