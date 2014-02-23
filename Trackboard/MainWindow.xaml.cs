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

            //Login dlg = new Login();
            //dlg.ShowDialog();

            tabcontrol.DataContext = new ObservableCollection<Student>(new Meth().Students);

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
                this.WindowState = System.Windows.WindowState.Normal;
                tabcontrol.Margin = new Thickness(10, 5, 10, 10);
                pathheader.Data = Geometry.Parse("M 0,0 L 0,45 10,50 10,45 1014,45 1014,50 1024,45 1024,0 Z");
                m_edgeBorder.Margin = new Thickness(10);
            }
            else
            {
                this.WindowState = System.Windows.WindowState.Maximized;
                tabcontrol.Margin = new Thickness(0, 5, 0, 0);
                pathheader.Data = Geometry.Parse("M 0,0 L 0,50 1024,50 1024,0 Z");
                m_edgeBorder.Margin = new Thickness(0);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        void Item_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            data.Visibility = System.Windows.Visibility.Visible;
        }

        void Item_Selected(object sender, RoutedEventArgs e)
        {
            
        }

    }
}
