using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using Telerik.Windows.Controls;


namespace fangleinew
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public string StrTheme = "Crystal_Dark";
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
            //ApplicationThemeManager.GetInstance().ThemeChanged += Example_ThemeChanged;
            Settheme settheme1 = new Settheme();
            settheme1.setTheme(this, settheme1.setLightOrDark("Crystal_Dark"));
            this.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/fangleinew;component/Resources.xaml", UriKind.RelativeOrAbsolute) });
            BT bt = new BT();
            bt.mycolor = Color.FromRgb(0, 112, 250).ToString();
            BTL.DataContext = bt;  // 调整标题栏颜色，如果后续有需要
        }
        private void Example_ThemeChanged(object sender, System.EventArgs e)
        {
            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/fangleinew;component/Resources.xaml", UriKind.RelativeOrAbsolute) });
        }
        // 拖动  
        private void CustomWindow_MouseLeftButtonDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        //双击
        private int times = 0;
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            times += 1;

            DispatcherTimer timer = new DispatcherTimer();

            timer.Interval = new TimeSpan(0, 0, 0, 0, 300);

            timer.Tick += (s, e1) => { timer.IsEnabled = false; times = 0; };

            timer.IsEnabled = true;

            if (times % 2 == 0)
            {

                timer.IsEnabled = false;

                times = 0;

                this.WindowState = this.WindowState == WindowState.Maximized ?

                              WindowState.Normal : WindowState.Maximized;

            }
        }

        public class BT
        {
            public string mycolor { get; set; }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           


        }

        private void Mini_Click_1(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MaxBtu_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else
                WindowState = WindowState.Maximized;
        }

        private void CloseBtu_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
