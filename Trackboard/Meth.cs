using System;
using System.Collections.Generic;
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
            List<User> users = new DATA().GetUsers();
            CurrentUser = new DATA().GetUsers().Find(u => u.UID == UID && u.UPwd == UPwd);
            return CurrentUser != null;
        }

        /// <summary>
        /// 返回学生表
        /// </summary>
        public List<Student> Students
        {
            get { return new DATA().GetStudents(); }
        }
        
    }
}
