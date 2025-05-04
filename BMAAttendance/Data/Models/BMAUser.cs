using System.ComponentModel.DataAnnotations;

namespace BMAAttendance.Data.Models
{
    public class BMAUser
    {
        [Key] public Guid UserID { get; set; }
        public Guid? SchoolID { get; set; }
        public string UserName { get; set; } = "";
        public string EmailAddress { get; set; } = "";
        public bool DashboardAccess { get; set; }
        public BMAUser()
        {
            
        }
    }
}