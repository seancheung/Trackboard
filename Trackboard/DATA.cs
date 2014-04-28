using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Configuration;

namespace Trackboard
{
    class DATA
    {

        private static string ConnStr = ConfigurationManager.ConnectionStrings["Trackboard.Properties.Settings.TrackboardConnectionString"].ConnectionString;

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
    }
}
