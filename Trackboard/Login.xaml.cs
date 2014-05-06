using System.Windows;
using System.Windows.Input;

namespace Trackboard
{
	/// <summary>
	/// Interaction logic for Login.xaml
	/// </summary>
	public partial class Login : Window
	{

		public Login()
		{
			InitializeComponent();

			var user = Meth.ReadUData();
			if (!string.IsNullOrWhiteSpace(user.UID) && !string.IsNullOrWhiteSpace(user.UPwd))
			{
				textbox_uid.Text = user.UID;
				passwordbox_pwd.Password = user.UPwd;
				chkRem.IsChecked = true;
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
			Meth.InitLogin();
			Close();
		}

		private void Button_Click_3(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(textbox_uid.Text) || string.IsNullOrWhiteSpace(passwordbox_pwd.Password))
				textbox_info.Text = "请检查输入";
			else if (!Meth.CheckLogin(textbox_uid.Text, passwordbox_pwd.Password))
				textbox_info.Text = "用户名或密码错误";
			else
			{
				textbox_info.Text = Meth.CurrentUser.UID + "登陆成功";
				if (chkRem.IsChecked == true)
					Meth.SaveUData(new User() { UID = textbox_uid.Text, UPwd = passwordbox_pwd.Password });
				else
					Meth.ClearUData();

				Close();
			}
		}

		private void Window_PreviewKeyDown_1(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				Button_Click_3(null, null);
			}
		}

	}
}
