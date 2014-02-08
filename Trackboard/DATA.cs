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
        //private static string ConnStr = @"Data Source=(localdb)\v11.0;Initial Catalog=Trackboard;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        //private static string ConnStr = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\Users\Sean\Documents\GitHub\Trackboard\Trackboard\DATABASE\Trackboard.mdf;Integrated Security=True";
        private static string ConnStr = ConfigurationManager.ConnectionStrings["Trackboard.Properties.Settings.TrackboardConnectionString"].ConnectionString;

        /// <summary>
        /// 返回用户列表
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
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
        public List<Student> GetStudents()
        {
            using (var datacontex = new DataContext(ConnStr))
            {
                return datacontex.GetTable<Student>().ToList<Student>();
            }

        }
    }
}
