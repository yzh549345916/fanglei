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
    public partial class MainWindow : RadWindow
    {
        public string StrTheme = "Fluent_Dark";
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
            //RadWindow radWindow = this as RadWindow;
            //ApplicationThemeManager.GetInstance().ThemeChanged += Example_ThemeChanged;
            StyleManager.SetTheme(this, new Office2016Theme());
            Settheme settheme1 = new Settheme();
            settheme1.setTheme( settheme1.setLightOrDark("Fluent_Dark"));
            
          
            this.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/fangleinew;component/Resources.xaml", UriKind.RelativeOrAbsolute) });
            // var ss = (Content as DependencyObject);
            //StyleManager.SetTheme(Content as DependencyObject, new CrystalTheme());
        }
        private void Example_ThemeChanged(object sender, System.EventArgs e)
        {
            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/fangleinew;component/Resources.xaml", UriKind.RelativeOrAbsolute) });
        }
        
    }
}
