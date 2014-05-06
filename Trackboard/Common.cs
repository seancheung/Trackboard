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
using System.Data.Linq.Mapping;

namespace Trackboard
{
	//身份
	public enum Auth
	{
		Student, //学生
		Teacher, //教师
		Admin //管理员
	}

	//学生
	[Table(Name = "Student")]
	public class Student
	{
		[Column(IsPrimaryKey = true,IsDbGenerated=true)]
		public int ID { get; set; }
		[Column]
		public string SID { get; set; } //学号(10)<P>
		[Column]
		public string SName { get; set; } //姓名(8)
		[Column]
		public Boolean SGender { get; set; } //性别
		[Column]
		public DateTime SBirth { get; set; } //出生日期<*>
		[Column]
		public string CID { get; set; } //班级号(10)
		[Column]
		public string SPhone { get; set; } //手机号(11)<*>
	}

	//课程
	[Table(Name = "Course")]
	public class Course
	{
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public int ID { get; set; }
		[Column]
		public string CoID { get; set; } //课程号(10)<P>
		[Column]
		public string CoName { get; set; } //课程名(12)
		[Column]
		public string TID { get; set; } //教师号(10)
	}

	//分数
	[Table(Name = "Grade")]
	public class Grade
	{
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public int ID { get; set; }
		[Column]
		public string SID { get; set; } //学号(10)<P>
		[Column]
		public string CoID { get; set; } //课程号(10)<P>
		[Column]
		public int GMark { get; set; } //分数<*>
	}

	//班级
	[Table(Name = "Class")]
	public class Class
	{
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public int ID { get; set; }
		[Column]
		public string CID { get; set; } //班级号(10)<P>
		[Column]
		public string CName { get; set; } //班级名(10)
		[Column]
		public string TID { get; set; } //教师号(10)
	}

	//教师
	[Table(Name = "Teacher")]
	public class Teacher
	{
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public int ID { get; set; }
		[Column]
		public string TID { get; set; } //教师号(10)<P>
		[Column]
		public string TName { get; set; } //教师名(8)
		[Column]
		public string TPhone { get; set; } //手机号(11)<*>
	}

	//用户
	[Table(Name = "User")]
	public class User
	{
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public int ID { get; set; }
		[Column]
		public string UID { get; set; } //用户名(10)<P>
		[Column]
		public string UPwd { get; set; } //密码(20)
		[Column]
		public int UAuth { get; set; } //身份(11)<*>
	}

	//工作
	[Table(Name = "Job")]
	public class Job
	{
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public int ID { get; set; }
		[Column]
		public string SID { get; set; } //学号(10)<P>
		[Column]
		public string Company { get; set; } //公司名(50)<*>
		[Column]
		public int Salary { get; set; } //工资<*>
		[Column]
		public string City { get; set; } //城市(10)<*>
	}
}
