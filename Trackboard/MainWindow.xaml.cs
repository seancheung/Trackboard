using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Trackboard
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			Login dlg = new Login();
			dlg.ShowDialog();
			if (Meth.CurrentUser != null) SetAuth(Meth.CurrentUser);
			else
				Close();
		}

		/// <summary>
		/// 设置用户操作权限
		/// </summary>
		/// <param name="user"></param>
		private void SetAuth(User user)
		{
			switch (user.UAuth)
			{
				case 2:
					adminPanel.Visibility = Visibility.Visible;
					btnAdd.Visibility = Visibility.Visible;
					btnDel.Visibility = Visibility.Visible;
					btnMod.Visibility = Visibility.Visible;
					btnQue.Visibility = Visibility.Collapsed;
					detailpanel.SetResourceReference(Control.TemplateProperty, "AdminPanelTemplate");
					break;
				case 1:
					adminPanel.Visibility = Visibility.Collapsed;
					btnAdd.Visibility = Visibility.Collapsed;
					btnDel.Visibility = Visibility.Collapsed;
					btnMod.Visibility = Visibility.Collapsed;
					btnQue.Visibility = Visibility.Visible;
					break;
				default:
					adminPanel.Visibility = Visibility.Collapsed;
					btnAdd.Visibility = Visibility.Collapsed;
					btnDel.Visibility = Visibility.Collapsed;
					btnMod.Visibility = Visibility.Collapsed;
					btnQue.Visibility = Visibility.Collapsed;
					break;
			}
		}

		private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
		{
			this.DragMove();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			this.WindowState = System.Windows.WindowState.Minimized;
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			if (this.WindowState == System.Windows.WindowState.Maximized)
			{
				WindowState = System.Windows.WindowState.Normal;
				pathheader.Data = Geometry.Parse("M 0,0 L 0,45 10,50 10,45 1014,45 1014,50 1024,45 1024,0 Z");
				m_edgeBorder.Margin = new Thickness(10);
			}
			else
			{
				WindowState = System.Windows.WindowState.Maximized;
				pathheader.Data = Geometry.Parse("M 0,0 L 0,50 1024,50 1024,0 Z");
				m_edgeBorder.Margin = new Thickness(0);
			}
		}

		private void Button_Click_3(object sender, RoutedEventArgs e)
		{
			App.Current.Shutdown();
		}

		private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
		{
			if (e.AddedItems[0].ToString() == "班级视图")
			{
				comboSub.ItemsSource = null;
				comboSub.Visibility = Visibility.Collapsed;
				mainList.SetResourceReference(ListBox.ItemTemplateProperty, "ClassListTemplate");
				mainList.ItemsSource = Meth.Classes;
				detailpanel.SetResourceReference(Control.TemplateProperty, "ClassPanelTemplate");
			}
			else if (e.AddedItems[0].ToString() == "课程视图")
			{
				comboSub.ItemsSource = null;
				comboSub.Visibility = Visibility.Collapsed;
				mainList.SetResourceReference(ListBox.ItemTemplateProperty, "CourseListTemplate");
				mainList.ItemsSource = Meth.Courses;
				detailpanel.SetResourceReference(Control.TemplateProperty, "CoursePanelTemplate");

			}
			else
			{
				comboSub.DisplayMemberPath = "CName";
				comboSub.ItemsSource = Meth.Classes;
				comboSub.Visibility = Visibility.Visible;
				mainList.SetResourceReference(ListBox.ItemTemplateProperty, "StudentListTemplate");
				mainList.ItemsSource = Meth.Students;
				detailpanel.SetResourceReference(Control.TemplateProperty, "StudentPanelTemplate");
			}
		}

		private void comboSub_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
		{
			if (comboSub.ItemsSource != null)
				mainList.ItemsSource = Meth.Students.Where(s => s.CID == (e.AddedItems[0] as Class).CID);
		}

		private void btnOff_Click(object sender, RoutedEventArgs e)
		{
			Login dlg = new Login();
			Hide();
			dlg.ShowDialog();
			if (Meth.CurrentUser != null)
			{
				SetAuth(Meth.CurrentUser);
				Show();
			}
			else
				Close();

		}

		private void btnPrf_Click(object sender, RoutedEventArgs e)
		{
			new Profile().ShowDialog();
		}

		private void btnQue_Click(object sender, RoutedEventArgs e)
		{
			new Query().ShowDialog();
		}

		private void btnMod_Click(object sender, RoutedEventArgs e)
		{
			if (Meth.CurrentUser.UAuth == 2)
			{
				#region 管理员操作
				var dg = detailpanel.Template.FindName("adminView", detailpanel) as DataGrid;
				var obj = dg.SelectedValue;
				if (obj == null) return;

				var res = Message.Show("修改警告", "确认修改?", MessageBoxButton.YesNoCancel);
				if (res != MessageBoxResult.Yes) return;

				try
				{
					if (obj is User)
					{
						Meth.UpdateUser(obj as User);
					}
					else if (obj is Teacher)
					{
						Meth.UpdateTeacher(obj as Teacher);
					}
					else if (obj is Student)
					{
						Meth.UpdateStudent(obj as Student);
					}
					else if (obj is Course)
					{
						Meth.UpdateCourse(obj as Course);
					}
					Message.Show("修改成功");
				}
				catch (Exception ex)
				{
					Message.Show(String.Format("修改失败:\n{0}", ex.Message));
				}
				#endregion
			}
			

		}

		private void btnDel_Click(object sender, RoutedEventArgs e)
		{
			if (Meth.CurrentUser.UAuth == 2)
			{
				#region 管理员操作
				var dg = detailpanel.Template.FindName("adminView", detailpanel) as DataGrid;
				var obj = dg.SelectedValue;
				if (obj == null) return;

				var res = Message.Show("删除警告", "确认删除?", MessageBoxButton.YesNoCancel);
				if (res != MessageBoxResult.Yes) return;

				try
				{
					if (obj is User)
					{
						Meth.DeleteUser(obj as User);
					}
					else if (obj is Teacher)
					{
						Meth.DeleteTeacher(obj as Teacher);
					}
					else if (obj is Student)
					{
						Meth.DeleteStudent(obj as Student);
					}
					else if (obj is Course)
					{
						Meth.DeleteCourse(obj as Course);
					}
					else if (obj is Grade)
					{
						Meth.DeleteGrade(obj as Grade);
					}

					Message.Show("删除成功");
				}
				catch (Exception ex)
				{
					Message.Show(String.Format("删除失败:\n{0}", ex.Message));
				}
				#endregion
			}
			
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			if (Meth.CurrentUser.UAuth == 2)
			{
				#region 管理员操作
				var dg = detailpanel.Template.FindName("adminView", detailpanel) as DataGrid;
				var obj = dg.SelectedValue;
				if (obj == null) return;

				try
				{
					if (obj is User)
					{
						Meth.AddUser(obj as User);
					}
					else if (obj is Teacher)
					{
						Meth.AddTeacher(obj as Teacher);
					}
					else if (obj is Student)
					{
						Meth.AddStudent(obj as Student);
					}
					else if (obj is Course)
					{
						Meth.AddCourse(obj as Course);
					}

					Message.Show("添加成功");

				}
				catch (Exception ex)
				{
					Message.Show(String.Format("添加失败:\n{0}", ex.Message));
				}
				#endregion
			}

		}

		private void btnUser_Click(object sender, RoutedEventArgs e)
		{
			detailpanel.DataContext = Meth.Users;

			var dg = detailpanel.Template.FindName("adminView", detailpanel) as DataGrid;
			dg.Columns[0].Visibility = Visibility.Collapsed;
			dg.Columns[1].Header = "用户名";
			dg.Columns[2].Header = "密码";
			dg.Columns[3].Header = "身份";
		}

		private void btnStu_Click(object sender, RoutedEventArgs e)
		{
			detailpanel.DataContext = Meth.Students;

			var dg = detailpanel.Template.FindName("adminView", detailpanel) as DataGrid;
			dg.Columns[0].Visibility = Visibility.Collapsed;
			dg.Columns[1].Header = "学号";
			dg.Columns[2].Header = "姓名";
			dg.Columns[3].Header = "性别";
			dg.Columns[4].Header = "出生日期";
			dg.Columns[5].Header = "班级号";
			dg.Columns[6].Header = "手机号";
		}

		private void btnTch_Click(object sender, RoutedEventArgs e)
		{
			detailpanel.DataContext = Meth.Teachers;

			var dg = detailpanel.Template.FindName("adminView", detailpanel) as DataGrid;
			dg.Columns[0].Visibility = Visibility.Collapsed;
			dg.Columns[1].Header = "教师号";
			dg.Columns[2].Header = "姓名";
			dg.Columns[3].Header = "手机号";
		}

		private void btnCos_Click(object sender, RoutedEventArgs e)
		{
			detailpanel.DataContext = Meth.Courses;

			var dg = detailpanel.Template.FindName("adminView", detailpanel) as DataGrid;
			dg.Columns[0].Visibility = Visibility.Collapsed;
			dg.Columns[1].Header = "课程号";
			dg.Columns[2].Header = "课程名";
			dg.Columns[3].Header = "教师号";
		}


	}
}
