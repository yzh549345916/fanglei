using System;
using System.Windows;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace fangleinew
{
    public static class NavigationViewSettingsCommands
    {
        public static DelegateCommand OpenSettingsDialogCommand { get; private set; }

        static NavigationViewSettingsCommands()
        {
            OpenSettingsDialogCommand = new DelegateCommand(OpenSettingsDialogCommandExecute);
        }

        private static void OpenSettingsDialogCommandExecute(object obj)
        {
            var navigationView = obj as RadNavigationView;
            if (navigationView != null)
            {
                RadWindow settingsDialog = new RadWindow();
                settingsDialog.Content = new SettingsWindowContent();
                settingsDialog.ResizeMode = ResizeMode.CanResizeWithGrip;
                settingsDialog.Header = "设置";
                settingsDialog.Owner = App.Current.MainWindow;
                settingsDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                settingsDialog.HideMinimizeButton = false;
                settingsDialog.HideMaximizeButton = false;
                settingsDialog.CanClose = true;
                Settheme settheme1 = new Settheme();
                MainWindow mw = settingsDialog.Owner as MainWindow;
                ////settheme1.setTheme(this, settheme1.setLightOrDark("Crystal"));
                settheme1.setTheme(settingsDialog, settheme1.setLightOrDark(mw.StrTheme));
                settingsDialog.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/fangleinew;component/Resources.xaml", UriKind.RelativeOrAbsolute) });
                settingsDialog.ShowDialog();
            }

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
                if (parent is T)
                {
                    return (T)parent;
                }

                // 在上一级父控件中没有找到指定名字的控件，就再往上一级找
                parent = VisualTreeHelper.GetParent(parent);
            }

            return null;
        }
    }
}
