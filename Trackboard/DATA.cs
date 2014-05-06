using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Configuration;
using System.Reflection;

namespace Trackboard
{
	class DATA
	{

		private static string ConnStr = ConfigurationManager.ConnectionStrings["Trackboard.Properties.Settings.TrackboardConnectionString"].ConnectionString;

		#region 获取数据表
		/// <summary>
		/// 返回用户列表
		/// </summary>
		/// <returns></returns>
		public static List<User> GetUsers()
		{
			using (var datacontex = new DataContext(ConnStr))
			{
				return datacontex.GetTable<User>().ToList<User>();
			}

		}

		/// <summary>
		/// 返回学生表
		/// </summary>
		/// <returns></returns>
		public static List<Student> GetStudents()
		{
			using (var datacontex = new DataContext(ConnStr))
			{
				return datacontex.GetTable<Student>().ToList<Student>();
			}

		}

		/// <summary>
		/// 返回成绩表
		/// </summary>
		/// <returns></returns>
		public static List<Grade> GetGrades()
		{
			using (var datacontex = new DataContext(ConnStr))
			{
				return datacontex.GetTable<Grade>().ToList<Grade>();
			}

		}

		/// <summary>
		/// 返回老师表
		/// </summary>
		/// <returns></returns>
		public static List<Teacher> GetTeachers()
		{
			using (var datacontex = new DataContext(ConnStr))
			{
				return datacontex.GetTable<Teacher>().ToList<Teacher>();
			}

		}

		/// <summary>
		/// 返回班级表
		/// </summary>
		/// <returns></returns>
		public static List<Class> GetClasses()
		{
			using (var datacontex = new DataContext(ConnStr))
			{
				return datacontex.GetTable<Class>().ToList<Class>();
			}

		}

		/// <summary>
		/// 返回课程表
		/// </summary>
		/// <returns></returns>
		public static List<Course> GetCourses()
		{
			using (var datacontex = new DataContext(ConnStr))
			{
				return datacontex.GetTable<Course>().ToList<Course>();
			}

		}

		/// <summary>
		/// 返回就业表
		/// </summary>
		/// <returns></returns>
		public static List<Job> GetJobs()
		{
			using (var datacontex = new DataContext(ConnStr))
			{
				return datacontex.GetTable<Job>().ToList<Job>();
			}

		}
		#endregion

		#region 用户操作
		/// <summary>
		/// 添加用户
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public static void AddUser(User user)
		{
			using (var datacontex = new DataContext(ConnStr))
			{
				try
				{
					var tab = datacontex.GetTable<User>();
					tab.InsertOnSubmit(user);
					datacontex.SubmitChanges();
					
				}
				catch
				{
					throw;
				}
			}
		}

		/// <summary>
		/// 删除用户
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public static void DeleteUser(User user)
		{
			using (var datacontex = new DataContext(ConnStr))
			{
				try
				{
					var tab = datacontex.GetTable<User>();
					var tuser = tab.FirstOrDefault(u => u.ID == user.ID);
					tab.DeleteOnSubmit(tuser);
					datacontex.SubmitChanges();
					
				}
				catch
				{
					throw;
				}
			}
		}

		/// <summary>
		/// 修改用户
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public static void UpdateUser(User user)
		{
			using (var datacontex = new DataContext(ConnStr))
			{
				try
				{
					var tab = datacontex.GetTable<User>();
					var tuser = tab.FirstOrDefault(u => u.ID == user.ID);
					foreach (var p in typeof(User).GetProperties())
					{
						//确保属性可写
						if (p.CanWrite)
							p.SetValue(tuser, typeof(User).GetProperty(p.Name).GetValue(user, null), null);
					}
					datacontex.SubmitChanges();
					
				}
				catch
				{
					throw;
				}
			}
		}
		#endregion

		#region 课程操作
		/// <summary>
		/// 添加课程
		/// </summary>
		/// <param name="course"></param>
		/// <returns></returns>
		public static void AddCourse(Course course)
		{
			using (var datacontex = new DataContext(ConnStr))
			{
				try
				{
					var tab = datacontex.GetTable<Course>();
					tab.InsertOnSubmit(course);
					datacontex.SubmitChanges();
					
				}
				catch
				{
					throw;
				}
			}
		}

		/// <summary>
		/// 删除课程
		/// </summary>
		/// <param name="course"></param>
		/// <returns></returns>
		public static void DeleteCourse(Course course)
		{
			using (var datacontex = new DataContext(ConnStr))
			{
				try
				{
					var tab = datacontex.GetTable<Course>();
					var tcourse = tab.FirstOrDefault(c => c.ID == course.ID);
					tab.DeleteOnSubmit(tcourse);
					datacontex.SubmitChanges();
					
				}
				catch
				{
					throw;
				}
			}
		}

		/// <summary>
		/// 修改课程
		/// </summary>
		/// <param name="course"></param>
		/// <returns></returns>
		public static void UpdateCourse(Course course)
		{
			using (var datacontex = new DataContext(ConnStr))
			{
				try
				{
					var tab = datacontex.GetTable<Course>();
					var tcourse = tab.FirstOrDefault(c => c.ID == course.ID);
					foreach (var p in typeof(Course).GetProperties())
					{
						//确保属性可写
						if (p.CanWrite)
							p.SetValue(tcourse, typeof(Course).GetProperty(p.Name).GetValue(course, null), null);
					}
					datacontex.SubmitChanges();
					
				}
				catch
				{
					throw;
				}
			}
		}
		#endregion

		#region 分数操作
		/// <summary>
		/// 添加分数
		/// </summary>
		/// <param name="grade"></param>
		/// <returns></returns>
		public static void AddGrade(Grade grade)
		{
			using (var datacontex = new DataContext(ConnStr))
			{
				try
				{
					var tab = datacontex.GetTable<Grade>();
					tab.InsertOnSubmit(grade);
					datacontex.SubmitChanges();
					
				}
				catch
				{
					throw;
				}
			}
		}

		/// <summary>
		/// 删除分数
		/// </summary>
		/// <param name="grade"></param>
		/// <returns></returns>
		public static void DeleteGrade(Grade grade)
		{
			using (var datacontex = new DataContext(ConnStr))
			{
				try
				{
					var tab = datacontex.GetTable<Grade>();
					var tgrade = tab.FirstOrDefault(g => g.ID == grade.ID);
					tab.DeleteOnSubmit(tgrade);
					datacontex.SubmitChanges();
					
				}
				catch
				{
					throw;
				}
			}
		}

		/// <summary>
		/// 修改分数
		/// </summary>
		/// <param name="grade"></param>
		/// <returns></returns>
		public static void UpdateGrade(Grade grade)
		{
			using (var datacontex = new DataContext(ConnStr))
			{
				try
				{
					var tab = datacontex.GetTable<Grade>();
					var tcourse = tab.FirstOrDefault(g => g.ID == grade.ID);
					foreach (var p in typeof(Grade).GetProperties())
					{
						//确保属性可写
						if (p.CanWrite)
							p.SetValue(tcourse, typeof(Grade).GetProperty(p.Name).GetValue(grade, null), null);
					}
					datacontex.SubmitChanges();
					
				}
				catch
				{
					throw;
				}
			}
		}
		#endregion

		#region 学生操作
		/// <summary>
		/// 增加学生
		/// </summary>
		/// <param name="student"></param>
		public static void AddStudent(Student student)
		{
			using (var datacontex = new DataContext(ConnStr))
			{
				try
				{
					var tab = datacontex.GetTable<Student>();
					tab.InsertOnSubmit(student);
					datacontex.SubmitChanges();
				}
				catch
				{
					throw;
				}
			}
		}

		/// <summary>
		/// 删除学生
		/// </summary>
		/// <param name="student"></param>
		public static void DeleteStudent(Student student)
		{
			using (var datacontex = new DataContext(ConnStr))
			{
				try
				{
					var tab = datacontex.GetTable<Student>();
					var tstudent = tab.FirstOrDefault(s => s.ID == student.ID);
					tab.DeleteOnSubmit(tstudent);
					datacontex.SubmitChanges();
					
				}
				catch
				{
					throw;
				}
			}
		}

		/// <summary>
		/// 修改学生
		/// </summary>
		/// <param name="student"></param>
		public static void UpdateStudent(Student student)
		{
			using (var datacontex = new DataContext(ConnStr))
			{
				try
				{
					var tab = datacontex.GetTable<Student>();
					var tstudent = tab.FirstOrDefault(s => s.ID == student.ID);
					foreach (var p in typeof(Student).GetProperties())
					{
						//确保属性可写
						if (p.CanWrite)
							p.SetValue(tstudent, typeof(Student).GetProperty(p.Name).GetValue(student, null), null);
					}
					datacontex.SubmitChanges();
			
				}
				catch
				{
					throw;
				}
			}
		}
		#endregion

		#region 教师操作
		/// <summary>
		/// 增加教师
		/// </summary>
		/// <param name="teacher"></param>
		public static void AddTeacher(Teacher teacher)
		{
			using (var datacontex = new DataContext(ConnStr))
			{
				try
				{
					var tab = datacontex.GetTable<Teacher>();
					tab.InsertOnSubmit(teacher);
					datacontex.SubmitChanges();
					
				}
				catch
				{
					throw;
				}
			}
		}

		/// <summary>
		/// 删除教师
		/// </summary>
		/// <param name="teacher"></param>
		public static void DeleteTeacher(Teacher teacher)
		{
			using (var datacontex = new DataContext(ConnStr))
			{
				try
				{
					var tab = datacontex.GetTable<Teacher>();
					var tteacher = tab.FirstOrDefault(t => t.ID == teacher.ID);
					tab.DeleteOnSubmit(tteacher);
					datacontex.SubmitChanges();
					
				}
				catch
				{
					throw;
				}
			}
		}

		/// <summary>
		/// 修改教师
		/// </summary>
		/// <param name="teacher"></param>
		public static void UpdateTeacher(Teacher teacher)
		{
			using (var datacontex = new DataContext(ConnStr))
			{
				try
				{
					var tab = datacontex.GetTable<Teacher>();
					var tteacher = tab.FirstOrDefault(t => t.ID == teacher.ID);
					foreach (var p in typeof(Teacher).GetProperties())
					{
						//确保属性可写
						if (p.CanWrite)
							p.SetValue(tteacher, typeof(Teacher).GetProperty(p.Name).GetValue(teacher, null), null);
					}
					datacontex.SubmitChanges();
					
				}
				catch
				{
					throw;
				}
			}
		}
		#endregion

		#region 工作操作
		/// <summary>
		/// 增加工作
		/// </summary>
		/// <param name="job"></param>
		public static void AddJob(Job job)
		{
			using (var datacontex = new DataContext(ConnStr))
			{
				try
				{
					var tab = datacontex.GetTable<Job>();
					tab.InsertOnSubmit(job);
					datacontex.SubmitChanges();
					
				}
				catch
				{
					throw;
				}
			}
		}

		/// <summary>
		/// 删除工作
		/// </summary>
		/// <param name="job"></param>
		public static void DeleteJob(Job job)
		{
			using (var datacontex = new DataContext(ConnStr))
			{
				try
				{
					var tab = datacontex.GetTable<Job>();
					var tjob = tab.FirstOrDefault(j => j.ID == job.ID);
					tab.DeleteOnSubmit(tjob);
					datacontex.SubmitChanges();
					
				}
				catch
				{
					throw;
				}
			}
		}

		/// <summary>
		/// 修改工作
		/// </summary>
		/// <param name="job"></param>
		public static void UpdateJob(Job job)
		{
			using (var datacontex = new DataContext(ConnStr))
			{
				try
				{
					var tab = datacontex.GetTable<Job>();
					var tjob = tab.FirstOrDefault(j => j.ID == job.ID);
					foreach (var p in typeof(Job).GetProperties())
					{
						//确保属性可写
						if (p.CanWrite)
							p.SetValue(tjob, typeof(Job).GetProperty(p.Name).GetValue(job, null), null);
					}
					datacontex.SubmitChanges();
				}
				catch
				{
					throw;
				}
			}
		}
		#endregion
	}
}
