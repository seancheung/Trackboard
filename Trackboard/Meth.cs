/*The MIT License (MIT)

Copyright (c) 2014 Sean/Zhang Xuan

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. 
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


namespace Trackboard
{
	class Meth
	{
		//当前已登录用户
		public static User CurrentUser { get; private set; }

		private static readonly string PasswordHash = "1f02796a";
		private static readonly string SaltKey = "c2a9e9eb";
		private static readonly string VIKey = "9b05a3b5-ad2e-d5";

		#region 数据表
		public static List<Student> Students
		{
			get { return DATA.GetStudents(); }
		}

		public static List<Class> Classes
		{
			get { return DATA.GetClasses(); }
		}

		public static List<Course> Courses
		{
			get { return DATA.GetCourses(); }
		}

		public static List<User> Users
		{
			get { return DATA.GetUsers(); }
		}

		public static List<Grade> Grades
		{
			get { return DATA.GetGrades(); }
		}

		public static List<Teacher> Teachers
		{
			get { return DATA.GetTeachers(); }
		}

		public static List<Job> Jobs
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
		public static Boolean CheckLogin(string UID, string UPwd)
		{
			CurrentUser = Users.Find(u => u.UID == UID && u.UPwd == UPwd);
			return CurrentUser != null;
		}

		/// <summary>
		/// 初始化登录
		/// </summary>
		public static void InitLogin()
		{
			CurrentUser = null;
		}

		#region 连接操作
		/// <summary>
		/// 返回用于显示的分数表
		/// </summary>
		/// <param name="sid">指定学号</param>
		/// <returns>包含课程名，分数和任课教师的分数表</returns>
		public static object GetGradesByStudent(string sid)
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
		public static string GetClassName(string cid)
		{
			return Classes.First(c => c.CID == cid).CName;
		}

		/// <summary>
		/// 根据课程ID获取分数
		/// </summary>
		/// <param name="coid"></param>
		/// <returns></returns>
		public static IEnumerable<Grade> GetGradesByCourse(string coid)
		{
			return Grades.Where(g => g.CoID == coid).ToList();
		}

		/// <summary>
		/// 根据学号获取工作
		/// </summary>
		/// <param name="sid"></param>
		/// <returns></returns>
		public static IEnumerable<Job> GetJobBySID(string sid)
		{
			return Jobs.Where(j => j.SID == sid).ToList();
		}

		/// <summary>
		/// 根据班级ID获取工作
		/// </summary>
		/// <param name="cid"></param>
		/// <returns></returns>
		public static IEnumerable<Job> GetJobsByCID(string cid)
		{
			List<string> sids = Students.Where(s => s.CID == cid).Select(s => s.SID).ToList();
			return Jobs.Where(j => sids.Contains(j.SID)).ToList();
		}

		/// <summary>
		/// 根据班级ID获取总分
		/// </summary>
		/// <param name="cid"></param>
		/// <returns></returns>
		public static IEnumerable<int> GetTotalGrade(string cid)
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
		public static void AddUser(User user)
		{
			try
			{
				DATA.AddUser(user);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		/// <summary>
		/// 删除用户
		/// </summary>
		/// <param name="user"></param>
		public static void DeleteUser(User user)
		{
			try
			{
				DATA.DeleteUser(user);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		/// <summary>
		/// 修改用户
		/// </summary>
		/// <param name="user"></param>
		public static void UpdateUser(User user)
		{
			try
			{
				DATA.UpdateUser(user);
			}
			catch (Exception ex)
			{
				throw;
			}
		}
		#endregion

		#region 课程操作
		/// <summary>
		/// 增加课程
		/// </summary>
		/// <param name="course"></param>
		public static void AddCourse(Course course)
		{
			try
			{
				DATA.AddCourse(course);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		/// <summary>
		/// 删除课程
		/// </summary>
		/// <param name="course"></param>
		public static void DeleteCourse(Course course)
		{
			try
			{
				DATA.DeleteCourse(course);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		/// <summary>
		/// 修改课程
		/// </summary>
		/// <param name="course"></param>
		public static void UpdateCourse(Course course)
		{
			try
			{
				DATA.UpdateCourse(course);
			}
			catch (Exception ex)
			{
				throw;
			}
		}
		#endregion

		#region 分数操作
		/// <summary>
		/// 增加分数
		/// </summary>
		/// <param name="grade"></param>
		public static void AddGrade(Grade grade)
		{
			try
			{
				DATA.AddGrade(grade);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		/// <summary>
		/// 删除分数
		/// </summary>
		/// <param name="grade"></param>
		public static void DeleteGrade(Grade grade)
		{
			try
			{
				DATA.DeleteGrade(grade);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		/// <summary>
		/// 修改分数
		/// </summary>
		/// <param name="grade"></param>
		public static void UpdateGrade(Grade grade)
		{
			try
			{
				DATA.UpdateGrade(grade);
			}
			catch (Exception ex)
			{
				throw;
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
			try
			{
				DATA.AddStudent(student);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		/// <summary>
		/// 删除学生
		/// </summary>
		/// <param name="student"></param>
		public static void DeleteStudent(Student student)
		{
			try
			{
				DATA.DeleteStudent(student);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		/// <summary>
		/// 修改学生
		/// </summary>
		/// <param name="student"></param>
		public static void UpdateStudent(Student student)
		{
			try
			{
				DATA.UpdateStudent(student);
			}
			catch (Exception ex)
			{
				throw;
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
			try
			{
				DATA.AddTeacher(teacher);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		/// <summary>
		/// 删除教师
		/// </summary>
		/// <param name="teacher"></param>
		public static void DeleteTeacher(Teacher teacher)
		{
			try
			{
				DATA.DeleteTeacher(teacher);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		/// <summary>
		/// 修改教师
		/// </summary>
		/// <param name="teacher"></param>
		public static void UpdateTeacher(Teacher teacher)
		{
			try
			{
				DATA.UpdateTeacher(teacher);
			}
			catch (Exception ex)
			{
				throw;
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
			try
			{
				DATA.AddJob(job);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		/// <summary>
		/// 删除工作
		/// </summary>
		/// <param name="job"></param>
		public static void DeleteJob(Job job)
		{
			try
			{
				DATA.DeleteJob(job);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		/// <summary>
		/// 修改工作
		/// </summary>
		/// <param name="job"></param>
		public static void UpdateJob(Job job)
		{
			try
			{
				DATA.UpdateJob(job);
			}
			catch (Exception ex)
			{
				throw;
			}
		}
		#endregion

		#region 登录操作
		/// <summary>
		/// 保存登录记录
		/// </summary>
		/// <param name="user"></param>
		public static void SaveUData(User user)
		{
			try
			{
				using (var fs = File.Create("tbudat"))
				{
					using (var bw = new BinaryWriter(fs))
					{
						bw.Write(Encrypt(user.UID));
						bw.Write(Encrypt(user.UPwd));
					}
				}
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// 读取登录记录
		/// </summary>
		/// <returns></returns>
		public static User ReadUData()
		{
			User user = new User();

			if (!File.Exists("tbudat"))
				return user;

			try
			{
				using (var br = new BinaryReader(File.OpenRead("tbudat")))
				{
					user.UID = Decrypt(br.ReadString());
					user.UPwd = Decrypt(br.ReadString());
				}

				return user;
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// 清除登录记录
		/// </summary>
		public static void ClearUData()
		{
			File.Delete("tbudat");
		}

		/// <summary>
		/// 加密
		/// </summary>
		/// <param name="plainText"></param>
		/// <returns></returns>
		private static string Encrypt(string plainText)
		{
			byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

			byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
			var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
			var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

			byte[] cipherTextBytes;

			using (var memoryStream = new MemoryStream())
			{
				using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
				{
					cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
					cryptoStream.FlushFinalBlock();
					cipherTextBytes = memoryStream.ToArray();
					cryptoStream.Close();
				}
				memoryStream.Close();
			}
			return Convert.ToBase64String(cipherTextBytes);
		}

		/// <summary>
		/// 解密
		/// </summary>
		/// <param name="encryptedText"></param>
		/// <returns></returns>
		private static string Decrypt(string encryptedText)
		{
			byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
			byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
			var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

			var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
			var memoryStream = new MemoryStream(cipherTextBytes);
			var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
			byte[] plainTextBytes = new byte[cipherTextBytes.Length];

			int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
			memoryStream.Close();
			cryptoStream.Close();
			return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
		}
		#endregion
	}
}
