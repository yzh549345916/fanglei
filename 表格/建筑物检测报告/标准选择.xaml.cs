using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace fangleinew
{
    /// <summary>
    /// 人员选择.xaml 的交互逻辑
    /// </summary>
    public partial class 标准选择 : UserControl
    {
        public string _bz = "";
        public 标准选择()
        {
            InitializeComponent();
            string bz = "《建筑物防雷设计规范》GB50057-2010,《建筑物防雷装置检测技术规范》GB/T21431-2015";
            foreach(string ss in bz.Split(','))
            {
                xcb1.Items.Add(ss);
            }
        }

        private void OKBtu_Click(object sender, RoutedEventArgs e)
        {
           
            if (xcb1.SelectedIndex >= 0)
            {
                _bz = xcb1.Text;
                RadWindow rw = GetParentObject<RadWindow>(this, "");
                rw.Close();
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

        private void CancelBtu_Click(object sender, RoutedEventArgs e)
        {
            _bz = "";
            RadWindow rw = GetParentObject<RadWindow>(this, "");
            rw.Close();
        }
    }
}
