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
        /// 用户检查
        /// </summary>
        /// <param name="UID"></param>
        /// <param name="UPwd"></param>
        /// <returns></returns>
        public Boolean CheckLogin(string UID, string UPwd)
        {
            List<User> users = DATA.GetUsers();
            CurrentUser = DATA.GetUsers().Find(u => u.UID == UID && u.UPwd == UPwd);
            return CurrentUser != null;
        }

        /// <summary>
        /// 返回学生表
        /// </summary>
        public List<Student> Students
        {
            get { return DATA.GetStudents(); }
        }

        /// <summary>
        /// 返回用于显示的分数表
        /// </summary>
        /// <param name="sid">指定学号</param>
        /// <returns>包含课程名，分数和任课教师的分数表</returns>
        public object GetGrades(object sid)
        {
            return
                from g in DATA.GetGrades()
                from c in DATA.GetCourses()
                from t in DATA.GetTeachers()
                where g.SID == sid.ToString() && g.CoID == c.CoID && c.TID == t.TID
                select new
                {
                    课程名 = c.CoName,
                    分数 = g.GMark,
                    任课教师 = t.TName
                };
        }

        public object GetClass(object cid)
        {
            return DATA.GetClasses().First(c => c.CID == cid.ToString()).CName;
        }


    }
}
