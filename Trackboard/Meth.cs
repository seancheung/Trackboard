using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Windows;


namespace Trackboard
{
    class Meth
    {
        //当前已登录用户
        public static User CurrentUser { get; private set; }

        /// <summary>
        /// 学生表
        /// </summary>
        public List<Student> Students
        {
            get { return DATA.GetStudents(); }
        }

        public List<Class> Classes
        {
            get { return DATA.GetClasses(); }
        }

        public List<Course> Courses
        {
            get { return DATA.GetCourses(); }
        }

        public List<User> Users
        {
            get { return DATA.GetUsers(); }
        }

        public List<Grade> Grades
        {
            get { return DATA.GetGrades(); }
        }

        public List<Teacher> Teachers
        {
            get { return DATA.GetTeachers(); }
        }

        public List<Job> Jobs
        {
            get { return DATA.GetJobs(); }
        }

        /// <summary>
        /// 用户检查
        /// </summary>
        /// <param name="UID"></param>
        /// <param name="UPwd"></param>
        /// <returns></returns>
        public Boolean CheckLogin(string UID, string UPwd)
        {
            CurrentUser = Users.Find(u => u.UID == UID && u.UPwd == UPwd);
            return CurrentUser != null;
        }

        /// <summary>
        /// 返回用于显示的分数表
        /// </summary>
        /// <param name="sid">指定学号</param>
        /// <returns>包含课程名，分数和任课教师的分数表</returns>
        public object GetGradesByStudent(string sid)
        {
            var gl = Grades;
            var cl = Courses;
            var tl = Teachers;

            return
                from g in gl
                from c in cl
                from t in tl
                where g.SID == sid && g.CoID == c.CoID && c.TID == t.TID
                select new
                {
                    课程名 = c.CoName,
                    分数 = g.GMark,
                    任课教师 = t.TName
                };
        }

        public string GetClassName(string cid)
        {
            return Classes.First(c => c.CID == cid).CName;
        }

        public List<Grade> GetGradesByCourse(string coid)
        {
            return Grades.Where(g => g.CoID == coid).ToList();
        }

        public List<Job> GetJobBySID(string sid)
        {
            return Jobs.Where(j => j.SID == sid).ToList();
        }

        public List<Job> GetJobsByCID(string cid)
        {
            List<string> sids = Students.Where(s => s.CID == cid).Select(s => s.SID).ToList();
            return Jobs.Where(j => sids.Contains(j.SID)).ToList();
        }

        public IEnumerable<int> GetTotalGrade(string cid)
        {
            var gl = Grades;
            var sl = Students;

            return
                from g in gl
                from s in sl
                where s.CID == cid && g.SID == s.SID
                group g by g.SID into r
                select r.Sum(g => g.GMark);
        }

    }
}
