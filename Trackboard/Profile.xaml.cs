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
	/// Profile.xaml 的交互逻辑
	/// </summary>
	public partial class Profile : Window
	{
		public Profile()
		{
			InitializeComponent();

			if (Meth.CurrentUser != null)
				userName.Text = Meth.CurrentUser.UID;
		}

		private void Window_DragMove(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void btnDisc_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void btnSave_Click(object sender, RoutedEventArgs e)
		{
			if(string.IsNullOrWhiteSpace(pwdOld.Password))
			{
				Message.Show("请输入旧密码");
				return;
			}
			else if (pwdOld.Password != Meth.CurrentUser.UPwd)
			{
				Message.Show("旧密码错误");
				return;
			}
			else if (string.IsNullOrWhiteSpace(pwdNew.Password)||string.IsNullOrWhiteSpace(pwdCon.Password))
			{
				Message.Show("请输入/确认新密码");
				return;
			}
			else if (pwdNew.Password != pwdCon.Password)
			{
				Message.Show("两次输入不一致");
				return;
			}
			else
			{
				try
				{
					var user = new User();
					user = Meth.CurrentUser;
					user.UPwd = pwdCon.Password;
					Meth.UpdateUser(user);
					Message.Show("更新成功");
					Close();
				}
				catch (Exception ex)
				{
					Message.Show(String.Format("更新失败:\n{0}", ex.Message));
				}
			}		
		}

	}
}
