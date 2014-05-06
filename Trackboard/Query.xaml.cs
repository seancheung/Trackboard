using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Trackboard
{
	/// <summary>
	/// Query.xaml 的交互逻辑
	/// </summary>
	public partial class Query : Window
	{
		public Query()
		{
			InitializeComponent();

			combStu.ItemsSource = Meth.Students;
			combClass.ItemsSource = Meth.Classes;
			combCourse.ItemsSource = Meth.Courses;
		}

		private void Window_DragMove(object sender, MouseButtonEventArgs e)
		{
			this.DragMove();
		}

		private void btnFlt_Click(object sender, RoutedEventArgs e)
		{
			if(combStu.SelectedValue != null)
			{
				var s = combStu.SelectedValue as Student;
				if (combCourse.SelectedValue != null)
				{
					var co = combCourse.SelectedValue as Course;
					dgGrade.ItemsSource = Meth.Grades.Where(g => g.SID == s.SID && g.CoID == co.CoID);
				}
				else
					dgGrade.ItemsSource = Meth.Grades.Where(g => g.SID == s.SID);
			}
			else if (combCourse.SelectedValue != null)
			{
				var co = combCourse.SelectedValue as Course;
				dgGrade.ItemsSource = Meth.Grades.Where(g =>g.CoID == co.CoID);
			}
				
			if(dgGrade.ItemsSource != null)
			{
				dgGrade.Columns[0].Visibility = Visibility.Collapsed;
				dgGrade.Columns[1].Header = "学号";
				dgGrade.Columns[2].Header = "课程号";
				dgGrade.Columns[3].Header = "分数";
			}
		}

		private void radStu_Checked(object sender, RoutedEventArgs e)
		{
			if (combStu != null) combStu.DisplayMemberPath = radStu.IsChecked == true ? "SID" : "SName";
		}

		private void Close_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void combClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (combClass.SelectedValue != null)
			{
				var c = combClass.SelectedValue as Class;
				combStu.ItemsSource = Meth.Students.Where(s => s.CID == c.CID);
			}
			
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			var obj = dgGrade.SelectedValue;
			if (obj == null) return;

			try
			{
				Meth.AddGrade(obj as Grade);
				Message.Show("添加成功");
			}
			catch (Exception ex)
			{
				Message.Show(String.Format("添加失败:\n{0}", ex.Message));
			}
		}

		private void btnDel_Click(object sender, RoutedEventArgs e)
		{
			var obj = dgGrade.SelectedValue;
			if (obj == null) return;

			var res = Message.Show("删除警告", "确认删除?", MessageBoxButton.YesNoCancel);
			if (res != MessageBoxResult.Yes) return;

			try
			{
				Meth.DeleteGrade(obj as Grade);
				Message.Show("删除成功");
			}
			catch (Exception ex)
			{
				Message.Show(String.Format("删除失败:\n{0}", ex.Message));
			}
		}

		private void btnMod_Click(object sender, RoutedEventArgs e)
		{
			var obj = dgGrade.SelectedValue;
			if (obj == null) return;

			var res = Message.Show("修改警告", "确认修改?", MessageBoxButton.YesNoCancel);
			if (res != MessageBoxResult.Yes) return;

			try
			{
				Meth.UpdateGrade(obj as Grade);
				Message.Show("修改成功");
			}
			catch (Exception ex)
			{
				Message.Show(String.Format("修改失败:\n{0}", ex.Message));
			}
		}
	}
}
