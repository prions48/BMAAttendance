using Microsoft.EntityFrameworkCore;

namespace BMAAttendance.Data.Models
{
    public class BMAService
    {
        private readonly BMAContext _context;
        public BMAService(BMAContext context)
        {
            _context = context;
        }
        #region Users
        public BMAUser GetOrCreateUserByID(Guid userid)
        {
            BMAUser? user = _context.BMAUsers.FirstOrDefault(e => e.UserID == userid);
            if (user == null)
            {
                user = new BMAUser()
                {
                    UserID = userid,
                    DashboardAccess = false
                };
                _context.BMAUsers.Add(user);
                _context.SaveChanges();
            }
            return user;
        }
        public void UpdateUser(BMAUser user)
        {
            _context.BMAUsers.Update(user);
            _context.SaveChanges();
        }
        #endregion

        #region Students
        public List<BMASchool> GetSchools()
        {
            return _context.BMASchools.ToList();
        }
        public List<BMAStudent> GetStudentsBySchool(Guid schoolid)
        {
            List<BMAStudent> students = _context.BMAStudents.Where(e => e.SchoolID == schoolid).ToList();
            List<BMAStudentAttend> attends = _context.BMAStudentAttends.ToList();
            foreach (BMAStudent student in students)
            {
                student.Attends = attends.Where(e => e.StudentID == student.ID).ToList();
            }
            return students;
        }
        public BMAStudent? GetStudentByID(Guid studentid)
        {
            BMAStudent? student = _context.BMAStudents.FirstOrDefault(e => e.ID == studentid);
            if (student != null)
            {
                student.Attends = _context.BMAStudentAttends.Where(e => e.StudentID == student.ID).ToList();
            }
            return student;
        }
        public void CreateStudent(BMAStudent student)
        {
            _context.BMAStudents.Add(student);
            _context.SaveChanges();
        }
        public void UpdateStudent(BMAStudent student)
        {
            _context.BMAStudents.Update(student);
            _context.SaveChanges();
        }
        #endregion
        #region attendance records
        public void CreateAttend(BMAStudentAttend attend)
        {
            _context.BMAStudentAttends.Add(attend);
            _context.SaveChanges();
        }
        public void DeleteAttend(BMAStudentAttend attend)
        {
            _context.BMAStudentAttends.Remove(attend);
            _context.SaveChanges();
        }
        #endregion

        #region Ranks
        public List<BMARank> GetRanks()
        {
            return _context.BMARanks.ToList();
        }
        public BMARank? GetRankByID(Guid rankid)
        {
            return _context.BMARanks.FirstOrDefault(e => e.ID == rankid);
        }
        public void CreateRank(BMARank rank)
        {
            _context.BMARanks.Add(rank);
            _context.SaveChanges();
        }
        public void DeleteRank(BMARank rank)
        {
            _context.BMARanks.Remove(rank);
            _context.SaveChanges();
        }
        public List<BMAStudentRank> GetStudentRanksByStudent(Guid studentid)
        {
            return _context.BMAStudentRanks.Where(e => e.StudentID == studentid).OrderBy(e => e.DateAwarded).ToList();
        }
        public void CreateStudentRank(BMAStudentRank studentrank)
        {
            _context.BMAStudentRanks.Add(studentrank);
            _context.SaveChanges();
        }
        public void DeleteStudentRank(BMAStudentRank studentrank)
        {
            _context.BMAStudentRanks.Remove(studentrank);
            _context.SaveChanges();
        }
        #endregion
    }
}