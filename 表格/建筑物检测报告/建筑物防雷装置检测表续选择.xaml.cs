using Config;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    public partial class 建筑物防雷装置检测表续选择 : UserControl
    {
        public 报告总表要素 _zbys = new 报告总表要素();
        public 建筑物防雷装置要素 _fbys = new 建筑物防雷装置要素();
        public string _people = "";
        public 建筑物防雷装置检测表续选择()
        {
            InitializeComponent();
            try
            {
                XmlConfig xmlConfig = new XmlConfig(Environment.CurrentDirectory + @"\config\设置.xml");
                string _con = xmlConfig.Read("DBConfig", "DB");
                string yqStr = "";
                using (SqlConnection mycon = new SqlConnection(_con))
                {
                    mycon.Open();//打开

                    string sql = string.Format("select  * from 建筑物防雷装置检测表续 order  BY 编号");  //SQL查询语句 (Name,StationID,Date)。按照数据库中的表的字段顺序保存
                    SqlCommand sqlman = new SqlCommand(sql, mycon);
                    SqlDataReader sqlreader = sqlman.ExecuteReader();
                    while (sqlreader.Read())
                    {
                        yqStr += sqlreader.GetString(sqlreader.GetOrdinal("编号")).Trim()+',';
                    }
                }
                if(yqStr.Length>0)
                {
                    yqStr = yqStr.Substring(0, yqStr.Length - 1);
                    foreach (string ss in yqStr.Split(','))
                    {
                        xcb1.Items.Add(ss);
                    }
                }
                
            }
            catch
            {
            }
        }
        public 建筑物防雷装置检测表续选择(报告总表要素 zbys, 建筑物防雷装置要素 fbys)
        {
            InitializeComponent();
            try
            {
                XmlConfig xmlConfig = new XmlConfig(Environment.CurrentDirectory + @"\config\设置.xml");
                string _con = xmlConfig.Read("DBConfig", "DB");
                string yqStr = "";
                using (SqlConnection mycon = new SqlConnection(_con))
                {
                    mycon.Open();//打开

                    string sql = string.Format("select  * from 建筑物防雷装置检测表续 order  BY 编号");  //SQL查询语句 (Name,StationID,Date)。按照数据库中的表的字段顺序保存
                    SqlCommand sqlman = new SqlCommand(sql, mycon);
                    SqlDataReader sqlreader = sqlman.ExecuteReader();
                    while (sqlreader.Read())
                    {
                        yqStr += sqlreader.GetString(sqlreader.GetOrdinal("编号")).Trim() + ',';
                    }
                }
                if (yqStr.Length > 0)
                {
                    yqStr = yqStr.Substring(0, yqStr.Length - 1);
                    foreach (string ss in yqStr.Split(','))
                    {
                        xcb1.Items.Add(ss);
                    }
                }

            }
            catch
            {
            }
            _zbys = zbys;
            _fbys = fbys;
        }

        private void OKBtu_Click(object sender, RoutedEventArgs e)
        {
            _people = xcb1.Text;
            RadWindow rw = GetParentObject<RadWindow>(this, "");
            rw.Close();
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
            _people = "";
            RadWindow rw = GetParentObject<RadWindow>(this, "");
            rw.Close();
        }

        private void AddBtu_Click(object sender, RoutedEventArgs e)
        {
            表格编号生成 bhsc = new 表格编号生成();
            RadWindow settingsDialog = new RadWindow();
            建筑物防雷装置表续属性表 ry = new 建筑物防雷装置表续属性表(bhsc.获取总表最新编号(),_fbys, _zbys);
            settingsDialog.Owner = this;
            settingsDialog.Content = ry;
            settingsDialog.MinWidth = 300;
            settingsDialog.MaxWidth = 800;
            settingsDialog.MinHeight = 180;
            settingsDialog.ResizeMode = ResizeMode.CanResize;
            settingsDialog.Header = "新增建筑物防雷装置表续";
            settingsDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            //settingsDialog.Closed += 新增总表属性表关闭;
            settingsDialog.ShowDialog();
        }
    }
}
