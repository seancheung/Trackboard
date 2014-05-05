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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Windows.Media.Animation;

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
					mainList.SetResourceReference(Control.TemplateProperty, "AdminPanelTemplate");
					break;
				case 1:
					adminPanel.Visibility = Visibility.Collapsed;
					btnAdd.Visibility = Visibility.Visible;
					btnDel.Visibility = Visibility.Visible;
					btnMod.Visibility = Visibility.Visible;
					break;
				default:
					adminPanel.Visibility = Visibility.Collapsed;
					btnAdd.Visibility = Visibility.Collapsed;
					btnDel.Visibility = Visibility.Collapsed;
					btnMod.Visibility = Visibility.Collapsed;
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
				mainList.ItemsSource = new Meth().Classes;
				detailpanel.SetResourceReference(Control.TemplateProperty, "ClassPanelTemplate");
			}
			else if (e.AddedItems[0].ToString() == "课程视图")
			{
				comboSub.ItemsSource = null;
				comboSub.Visibility = Visibility.Collapsed;
				mainList.SetResourceReference(ListBox.ItemTemplateProperty, "CourseListTemplate");
				mainList.ItemsSource = new Meth().Courses;
				detailpanel.SetResourceReference(Control.TemplateProperty, "CoursePanelTemplate");

			}
			else
			{
				comboSub.DisplayMemberPath = "CName";
				comboSub.ItemsSource = new Meth().Classes;
				comboSub.Visibility = Visibility.Visible;
				mainList.SetResourceReference(ListBox.ItemTemplateProperty, "StudentListTemplate");
				mainList.ItemsSource = new Meth().Students;
				detailpanel.SetResourceReference(Control.TemplateProperty, "StudentPanelTemplate");
			}
		}

		private void comboSub_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
		{
			if (comboSub.ItemsSource != null)
				mainList.ItemsSource = new Meth().Students.Where(s => s.CID == (e.AddedItems[0] as Class).CID);
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

		}

		private void btnQue_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btnMod_Click(object sender, RoutedEventArgs e)
		{
			
		}

		private void btnDel_Click(object sender, RoutedEventArgs e)
		{
			
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			
		}


	}
}
