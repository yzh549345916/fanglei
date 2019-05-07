using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows;
using System.Windows;
using System;
using System.Windows.Media;
using Telerik.Windows.Controls.RadialMenu;

namespace fangleinew
{
    /// <summary>
    /// 设置菜单.xaml 的交互逻辑
    /// </summary>
    public partial class 设置菜单 : UserControl
    {
        public 设置菜单()
        {
            InitializeComponent();
        }
        private void OnRadRadialMenuNavigated(object sender, RadRoutedEventArgs e)
        {
            this.CloseAllRadWindows();
           
        }

        private void OnRadRadialMenuItemClick(object sender, RadRoutedEventArgs e)
        {
            
            this.CloseAllRadWindows();
        }

        private void OnRadialMenuClosed(object sender, RadRoutedEventArgs e)
        {
            this.CloseAllRadWindows();
        }

        private void CloseAllRadWindows()
        {
            // Skip MainWindow and close all other open RadWindows.
            RadWindowManager.Current.GetWindows().Skip(1).ToList().ForEach(w => w.Close());
        }

        private void Fluent_Dark_Click(object sender, RadRoutedEventArgs e)
        {
            Settheme settheme1 = new Settheme();
            RadWindow rw = GetParentObject<RadWindow>(this, "");
            MainWindow mw = rw.Owner.Content as MainWindow;
            settheme1.setTheme(settheme1.setLightOrDark("Fluent_Dark"));
            StyleManager.SetTheme(mw, new Office2016Theme());
            
        }
        private void Fluent_Light_Click(object sender, RadRoutedEventArgs e)
        {
            Settheme settheme1 = new Settheme();
            RadWindow rw = GetParentObject<RadWindow>(this, "");
            MainWindow mw = rw.Owner.Content as MainWindow;
            StyleManager.SetTheme(mw, new FluentTheme());
            settheme1.setTheme(settheme1.setLightOrDark(" Fluent_Light"));


        }
        private void Crystal_Light_Click(object sender, RadRoutedEventArgs e)
        {
            Settheme settheme1 = new Settheme();
            RadWindow rw = GetParentObject<RadWindow>(this, "");
            MainWindow mw = rw.Owner.Content as MainWindow;
            settheme1.setTheme(settheme1.setLightOrDark(" Crystal_Light"));
            StyleManager.SetTheme(mw, new CrystalTheme());
           
        }
        private void Crystal_Dark_Click(object sender, RadRoutedEventArgs e)
        {
            Settheme settheme1 = new Settheme();
            RadWindow rw = GetParentObject<RadWindow>(this, "");
            MainWindow mw = rw.Owner.Content as MainWindow;
            settheme1.setTheme(settheme1.setLightOrDark(" Crystal_Dark"));
            StyleManager.SetTheme(mw, new CrystalTheme());

        }
        /// <summary>
        /// 查找父控件
        /// </summary>
        /// <typeparam name="T">父控件的类型</typeparam>
        /// <param name="obj">要找的是obj的父控件</param>
        /// <param name="name">想找的父控件的Name属性</param>
        /// <returns>目标父控件</returns>
        public static T GetParentObject<T>(DependencyObject obj, string name) where T : FrameworkElement
        {
            DependencyObject parent = VisualTreeHelper.GetParent(obj);
            while (parent != null)
            {
                if (parent is T )
                {
                    return (T)parent;
                }

                // 在上一级父控件中没有找到指定名字的控件，就再往上一级找
                parent = VisualTreeHelper.GetParent(parent);
            }

            return null;
        }

        private void RadRadialMenuItem_Click(object sender, RadRoutedEventArgs e)
        {
            RadRadialMenuItem rad = sender as RadRadialMenuItem;
            NavigateContext context = new NavigateContext(rad);
            rrm.CommandService.ExecuteCommand(Telerik.Windows.Controls.RadialMenu.Commands.CommandId.NavigateToView, context);

        }
    }
}
