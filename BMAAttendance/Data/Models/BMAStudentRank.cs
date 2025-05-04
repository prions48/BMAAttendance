using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace BMAAttendance.Data.Models
{
    public class BMAStudentRank
    {
        [Key] public Guid ID { get; set; }
        public Guid StudentID { get; set; }
        public Guid RankID { get; set; }
        public DateTime DateAwarded { get; set; }
        [NotMapped] public BMARank Rank { get; set; }
        public BMAStudentRank()
        {
            ID = Guid.NewGuid();
        }
    }
}