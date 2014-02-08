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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
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
            App.Current.Shutdown();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textbox_uid.Text) || string.IsNullOrWhiteSpace(passwordbox_pwd.Password))
                textbox_info.Text = "请检查输入";
            else if (!new Meth().CheckLogin(textbox_uid.Text, passwordbox_pwd.Password))
                textbox_info.Text = "用户名或密码错误";
            else
            {
                textbox_info.Text = Meth.CurrentUser.UID + "登陆成功";
                this.Close();
            }
        }
    }
}
