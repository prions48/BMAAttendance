using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMAAttendance.Data.Models
{
    public class BMAUser
    {
        [Key] public Guid UserID { get; set; }
        public Guid? SchoolID { get; set; }
        public string UserName { get; set; } = "";
        public string EmailAddress { get; set; } = "";
        public bool DashboardAccess { get; set; }
        public DateTime? AccessExpire { get; set; }
        [NotMapped] public List<BMAStudentUser> Students { get; set; } = [];
        //specifically for adding students
        [NotMapped] public BMAStudent? SelectedStudent { get; set; } = null;
        [NotMapped] public bool EditInfo { get; set; }
        public BMAUser()
        {

        }
    }
}