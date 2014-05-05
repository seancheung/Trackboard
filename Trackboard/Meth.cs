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

		#region 数据表
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
		#endregion

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
		/// 初始化登录
		/// </summary>
		public void InitLogin()
		{
			CurrentUser = null;
		}

		#region 连接操作
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

		/// <summary>
		/// 根据班级ID获取班级名
		/// </summary>
		/// <param name="cid"></param>
		/// <returns></returns>
		public string GetClassName(string cid)
		{
			return Classes.First(c => c.CID == cid).CName;
		}

		/// <summary>
		/// 根据课程ID获取分数
		/// </summary>
		/// <param name="coid"></param>
		/// <returns></returns>
		public IEnumerable<Grade> GetGradesByCourse(string coid)
		{
			return Grades.Where(g => g.CoID == coid).ToList();
		}

		/// <summary>
		/// 根据学号获取工作
		/// </summary>
		/// <param name="sid"></param>
		/// <returns></returns>
		public IEnumerable<Job> GetJobBySID(string sid)
		{
			return Jobs.Where(j => j.SID == sid).ToList();
		}

		/// <summary>
		/// 根据班级ID获取工作
		/// </summary>
		/// <param name="cid"></param>
		/// <returns></returns>
		public IEnumerable<Job> GetJobsByCID(string cid)
		{
			List<string> sids = Students.Where(s => s.CID == cid).Select(s => s.SID).ToList();
			return Jobs.Where(j => sids.Contains(j.SID)).ToList();
		}

		/// <summary>
		/// 根据班级ID获取总分
		/// </summary>
		/// <param name="cid"></param>
		/// <returns></returns>
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
		#endregion

		#region 用户操作
		/// <summary>
		/// 增加用户
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public bool AddUser(User user)
		{
			return DATA.AddUser(user);
		}

		/// <summary>
		/// 删除用户
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public bool DeleteUser(User user)
		{
			return DATA.DeleteUser(user);
		}

		/// <summary>
		/// 修改用户
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public bool UpdateUser(User user)
		{
			return DATA.UpdateUser(user);
		}
		#endregion

		#region 课程操作
		/// <summary>
		/// 增加课程
		/// </summary>
		/// <param name="course"></param>
		/// <returns></returns>
		public bool AddCourse(Course course)
		{
			return DATA.AddCourse(course);
		}

		/// <summary>
		/// 删除课程
		/// </summary>
		/// <param name="course"></param>
		/// <returns></returns>
		public bool DeleteCourse(Course course)
		{
			return DATA.DeleteCourse(course);
		}

		/// <summary>
		/// 修改课程
		/// </summary>
		/// <param name="course"></param>
		/// <returns></returns>
		public bool UpdateCourse(Course course)
		{
			return DATA.UpdateCourse(course);
		}
		#endregion

		#region 分数操作
		/// <summary>
		/// 增加分数
		/// </summary>
		/// <param name="grade"></param>
		/// <returns></returns>
		public bool AddGrade(Grade grade)
		{
			return DATA.AddGrade(grade);
		}

		/// <summary>
		/// 删除分数
		/// </summary>
		/// <param name="grade"></param>
		/// <returns></returns>
		public bool DeleteGrade(Grade grade)
		{
			return DATA.DeleteGrade(grade);
		}

		/// <summary>
		/// 修改分数
		/// </summary>
		/// <param name="grade"></param>
		/// <returns></returns>
		public bool UpdateGrade(Grade grade)
		{
			return DATA.UpdateGrade(grade);
		}
		#endregion

		#region 学生操作
		/// <summary>
		/// 增加学生
		/// </summary>
		/// <param name="student"></param>
		/// <returns></returns>
		public bool AddStudent(Student student)
		{
			return DATA.AddStudent(student);
		}

		/// <summary>
		/// 删除学生
		/// </summary>
		/// <param name="student"></param>
		/// <returns></returns>
		public bool DeleteStudent(Student student)
		{
			return DATA.DeleteStudent(student);
		}

		/// <summary>
		/// 修改学生
		/// </summary>
		/// <param name="student"></param>
		/// <returns></returns>
		public bool UpdateStudent(Student student)
		{
			return DATA.UpdateStudent(student);
		}
		#endregion

		#region 教师操作
		/// <summary>
		/// 增加教师
		/// </summary>
		/// <param name="teacher"></param>
		/// <returns></returns>
		public bool AddTeacher(Teacher teacher)
		{
			return DATA.AddTeacher(teacher);
		}

		/// <summary>
		/// 删除教师
		/// </summary>
		/// <param name="teacher"></param>
		/// <returns></returns>
		public bool DeleteTeacher(Teacher teacher)
		{
			return DATA.DeleteTeacher(teacher);
		}

		/// <summary>
		/// 修改教师
		/// </summary>
		/// <param name="teacher"></param>
		/// <returns></returns>
		public bool UpdateTeacher(Teacher teacher)
		{
			return DATA.UpdateTeacher(teacher);
		}
		#endregion

		#region 工作操作
		/// <summary>
		/// 增加工作
		/// </summary>
		/// <param name="job"></param>
		/// <returns></returns>
		public bool AddJob(Job job)
		{
			return DATA.AddJob(job);
		}

		/// <summary>
		/// 删除工作
		/// </summary>
		/// <param name="job"></param>
		/// <returns></returns>
		public bool DeleteJob(Job job)
		{
			return DATA.DeleteJob(job);
		}

		/// <summary>
		/// 修改工作
		/// </summary>
		/// <param name="job"></param>
		/// <returns></returns>
		public bool UpdateJob(Job job)
		{
			return DATA.UpdateJob(job);
		}
		#endregion
    }
}
