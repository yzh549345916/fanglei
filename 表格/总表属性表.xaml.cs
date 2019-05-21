using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// PropertyGrid1.xaml 的交互逻辑
    /// </summary>
    public partial class 总表属性表 : UserControl
    {
        public bool boolBS = false;
        public 总表属性表()
        {
            InitializeComponent();
            rpg.AutoGeneratingPropertyDefinition += new EventHandler<Telerik.Windows.Controls.Data.PropertyGrid.AutoGeneratingPropertyDefinitionEventArgs>(RpgAutoGeneratingPropertyDefinition);
            rpg.Item = new 报告总表要素()
            {
                检测开始日期=DateTime.Now,
                检测结束日期 = DateTime.Now,
                下次检测日期 = DateTime.Now,
            };
        }
        public 总表属性表(string bh)
        {
            InitializeComponent();
            rpg.AutoGeneratingPropertyDefinition += new EventHandler<Telerik.Windows.Controls.Data.PropertyGrid.AutoGeneratingPropertyDefinitionEventArgs>(RpgAutoGeneratingPropertyDefinition);
            rpg.Item = new 报告总表要素()
            {
                检测开始日期 = DateTime.Now,
                检测结束日期 = DateTime.Now,
                编号= bh,
                下次检测日期 = DateTime.Now.AddDays(-1).AddYears(1),
            };
        }
        void RpgAutoGeneratingPropertyDefinition(object sender, Telerik.Windows.Controls.Data.PropertyGrid.AutoGeneratingPropertyDefinitionEventArgs e)
        {
            //IDataErrorInfo
            (e.PropertyDefinition.Binding as Binding).ValidatesOnDataErrors = true;
            (e.PropertyDefinition.Binding as Binding).NotifyOnValidationError = true;

            // DataAnnotations
            (e.PropertyDefinition.Binding as Binding).ValidatesOnExceptions = true;
        }
      
        //关联值处理
        private void PropertyGrid1_EditEnded(object sender, Telerik.Windows.Controls.Data.PropertyGrid.PropertyGridEditEndedEventArgs e)
        {
             try
            {
                if (e.EditedPropertyDefinition.DisplayName == "检测结束日期" )
                {
                    报告总表要素 item = (报告总表要素)rpg.Item;
                    item.下次检测日期 = item.检测结束日期.AddDays(-1).AddYears(1);
                }
                if (e.EditedPropertyDefinition.DisplayName == "检测开始日期")
                {
                    报告总表要素 item = (报告总表要素)rpg.Item;
                    item.检测结束日期 = item.检测开始日期;
                    item.下次检测日期 = item.检测结束日期.AddDays(-1).AddYears(1);
                }

            }
            catch { }
        }
       
        
        private void SelectFileClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var item = this.rpg.Item as 建筑物防雷装置要素;
                //item.StringProp = openFileDialog.SafeFileName;
            }
        }

        private void peopleAdd_Click(object sender, RoutedEventArgs e)
        {
            RadWindow settingsDialog = new RadWindow();
            人员选择 ry = new 人员选择();

            settingsDialog.Content = ry;
            settingsDialog.MinWidth = 300;
            settingsDialog.MinHeight = 180;
            settingsDialog.ResizeMode = ResizeMode.CanResize;
            settingsDialog.Header = "人员选择";
            settingsDialog.Owner = this;
            settingsDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            settingsDialog.HideMinimizeButton = true;
            settingsDialog.HideMaximizeButton = true;
            settingsDialog.CanClose = false;
            settingsDialog.Closed += OnClosed;
            // Settheme settheme1 = new Settheme();
            //MainWindow mw = settingsDialog.Owner as MainWindow;
            ////settheme1.setTheme(this, settheme1.setLightOrDark("Crystal"));

            settingsDialog.ShowDialog();
        }
        private void YQAdd_Click(object sender, RoutedEventArgs e)
        {
            RadWindow settingsDialog = new RadWindow();
            仪器选择 ry = new 仪器选择();

            settingsDialog.Content = ry;
            settingsDialog.MinWidth = 300;
            settingsDialog.MinHeight = 180;
            settingsDialog.ResizeMode = ResizeMode.CanResize;
            settingsDialog.Header = "仪器选择";
            settingsDialog.Owner = this;
            settingsDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            settingsDialog.HideMinimizeButton = true;
            settingsDialog.HideMaximizeButton = true;
            settingsDialog.CanClose = false;
            settingsDialog.Closed += YQClosed;
            // Settheme settheme1 = new Settheme();
            //MainWindow mw = settingsDialog.Owner as MainWindow;
            ////settheme1.setTheme(this, settheme1.setLightOrDark("Crystal"));

            settingsDialog.ShowDialog();
        }
        private void bzAdd_Click(object sender, RoutedEventArgs e)
        {
            RadWindow settingsDialog = new RadWindow();
            标准选择 ry = new 标准选择();

            settingsDialog.Content = ry;
            settingsDialog.MinWidth = 300;
            settingsDialog.MinHeight = 180;
            settingsDialog.ResizeMode = ResizeMode.CanResize;
            settingsDialog.Header = "依据标准选择";
            settingsDialog.Owner = this;
            settingsDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            settingsDialog.HideMinimizeButton = true;
            settingsDialog.HideMaximizeButton = true;
            settingsDialog.CanClose = false;
            settingsDialog.Closed += bzClosed;
            // Settheme settheme1 = new Settheme();
            //MainWindow mw = settingsDialog.Owner as MainWindow;
            ////settheme1.setTheme(this, settheme1.setLightOrDark("Crystal"));

            settingsDialog.ShowDialog();
        }
        //新增人员窗口关闭事件处理
        private void OnClosed(object sender, WindowClosedEventArgs e)
        {
            var item = this.rpg.Item as 建筑物防雷装置要素;
            string peop = ((sender as RadWindow).Content as 人员选择)._people;
            //if(peop.Trim().Length>2)
             //item.人员 = peop;
            
        }
        private void YQClosed(object sender, WindowClosedEventArgs e)
        {
            var item = this.rpg.Item as 报告总表要素;
            string peop = ((sender as RadWindow).Content as 仪器选择)._people;
            if(peop.Trim().Length>2)
             item.仪器列表 = peop;

        }

        private void bzClosed(object sender, WindowClosedEventArgs e)
        {
            var item = this.rpg.Item as 建筑物防雷装置要素;
            string peop = ((sender as RadWindow).Content as 标准选择)._bz;
            if (peop.Trim().Length > 2)
                item.依据标准 = peop;

        }

        private void SaveBtu_Click(object sender, RoutedEventArgs e)
        {
            string confirmText = "是否确定保存数据?";
            RadWindow.Confirm(new DialogParameters
            {
                Content = confirmText,
                Closed = new EventHandler<WindowClosedEventArgs>(OnConfirmClosed),
                Header="注意",
                CancelButtonContent="否",
                OkButtonContent="是"

            });

            
        }
        private void OnConfirmClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                var item = this.rpg.Item as 报告总表要素;
                数据库处理类 cjkcl = new 数据库处理类();
                if (!cjkcl.ExistsZB(item.分表编号))
                {
                    
                    if(cjkcl.AddZB(item))
                    {
                        RadWindow rw = GetParentObject<RadWindow>(this, "");
                        rw.Close();
                        boolBS = true;
                    }
                    else
                    {
                        RadWindow.Alert(new DialogParameters
                        {
                            Content = "数据库新增失败，请重试",

                        });
                    }
                   
                }
                else
                {
                    RadWindow.Alert(new DialogParameters
                    {
                        Content = "报告编号已存在，请修改编号",

                    });
                }
                
            }
        }
        private void CancelConfirmClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                boolBS = false;
                RadWindow rw = GetParentObject<RadWindow>(this, "");
                rw.Close();
            }
        }
        private void CancelBtu_Click(object sender, RoutedEventArgs e)
        {
            string confirmText = "是否放弃已编辑的数据?";
            RadWindow.Confirm(new DialogParameters
            {
                Content = confirmText,
                Closed = new EventHandler<WindowClosedEventArgs>(CancelConfirmClosed),
                Header = "注意",
                CancelButtonContent = "否",
                OkButtonContent = "是"

            });
            

        }
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
