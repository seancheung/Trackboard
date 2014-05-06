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
using System.Windows;
using System.Windows.Input;

namespace Trackboard
{
	/// <summary>
	/// Message.xaml 的交互逻辑
	/// </summary>
	public partial class Message : Window
	{
		private static MessageBoxResult result;
		private string title
		{
			get
			{
				return txtTitle.Text;
			}
			set
			{
				txtTitle.Text = value;
			}
		}
		private string message
		{
			get
			{
				return txtMsg.Text;
			}
			set
			{
				txtMsg.Text = value;
			}
		}

		private Message()
		{
			InitializeComponent();
		}

		public static MessageBoxResult Show(string msg)
		{
			new Message()
			{
				title = string.Empty,
				message = msg,
				btnNo = { Visibility = Visibility.Collapsed },
				btnYes = { Visibility = Visibility.Collapsed },
				btnCancel = { Visibility = Visibility.Collapsed },
				btnOK = { Visibility = Visibility.Visible }
			}.ShowDialog();

			return result;
		}

		public static MessageBoxResult Show(string title, string msg, MessageBoxButton btn)
		{
			bool yesNo = btn.ToString().Contains("Yes");
			bool cancel = btn.ToString().Contains("Cancel");
			bool ok = btn.ToString().Contains("OK");

			new Message()
			{
				title = title,
				message = msg,
				btnNo = { Visibility = yesNo ? Visibility.Visible : Visibility.Collapsed },
				btnYes = { Visibility = yesNo ? Visibility.Visible : Visibility.Collapsed },
				btnCancel = { Visibility = cancel && yesNo ? Visibility.Visible : Visibility.Collapsed },
				btnOK = { Visibility = ok ? Visibility.Visible : Visibility.Collapsed }

			}.ShowDialog();

			return result;
		}

		private void Window_DragMove(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void Close_Click(object sender, RoutedEventArgs e)
		{
			result = MessageBoxResult.None;
			Close();
		}

		private void btnYes_Click(object sender, RoutedEventArgs e)
		{
			result = MessageBoxResult.Yes;
			Close();
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			result = MessageBoxResult.Cancel;
			Close();
		}

		private void btnOK_Click(object sender, RoutedEventArgs e)
		{
			result = MessageBoxResult.OK;
			Close();
		}

		private void btnNo_Click(object sender, RoutedEventArgs e)
		{
			result = MessageBoxResult.No;
			Close();
		}
	}
}
