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
    public partial class SPD检测表属性表 : UserControl
    {

        public bool boolBS = false;
        public SPD检测表属性表()
        {
            InitializeComponent();
            rpg.AutoGeneratingPropertyDefinition += new EventHandler<Telerik.Windows.Controls.Data.PropertyGrid.AutoGeneratingPropertyDefinitionEventArgs>(RpgAutoGeneratingPropertyDefinition);
            rpg.Item = new SPD要素()
            {
               
            };
        }
        public SPD检测表属性表(string bh,string jcy,string jhr,string jsfzr)
        {
            InitializeComponent();

            rpg.AutoGeneratingPropertyDefinition += new EventHandler<Telerik.Windows.Controls.Data.PropertyGrid.AutoGeneratingPropertyDefinitionEventArgs>(RpgAutoGeneratingPropertyDefinition);
            rpg.Item = new SPD要素()
            {
               
                编号= bh,
                检测员= jcy,
                校核人= jhr,
                技术负责人= jsfzr,
            };
        }

        public SPD检测表属性表(SPD要素 xbys1)
        {
            InitializeComponent();
            rpg.AutoGeneratingPropertyDefinition += new EventHandler<Telerik.Windows.Controls.Data.PropertyGrid.AutoGeneratingPropertyDefinitionEventArgs>(RpgAutoGeneratingPropertyDefinition);
            rpg.Item = xbys1;
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
                if (e.EditedPropertyDefinition.DisplayName.Contains("Iie测试值")|| e.EditedPropertyDefinition.DisplayName.Contains("状态指示器") || e.EditedPropertyDefinition.DisplayName.Contains("过流保护"))
                {
                    SPD要素 item = (SPD要素)rpg.Item;
                    if(item.第一级Iie测试值L1>20|| item.第一级Iie测试值L2 > 20 || item.第一级Iie测试值L3 > 20 || item.第一级Iie测试值N > 20 || item.第二级Iie测试值L1 > 20 || item.第二级Iie测试值L2 > 20 || item.第二级Iie测试值L3 > 20 || item.第二级Iie测试值N > 20 || item.第三级Iie测试值L1 > 20 || item.第三级Iie测试值L2 > 20 || item.第三级Iie测试值L3 > 20 || item.第三级Iie测试值N > 20)
                    {
                        item.SPD检测综评 = "不符合《建筑物防雷装置检测技术规范》GB/T21431-2015第5.8条要求。";
                    }
                    else if(item.第一级状态指示器.Contains("劣化")|| item.第二级状态指示器.Contains("劣化")|| item.第三级状态指示器.Contains("劣化"))
                    {
                        item.SPD检测综评 = "不符合《建筑物防雷装置检测技术规范》GB/T21431-2015第5.8条要求。";
                    }
                    else if (item.第一级过流保护 == "无" || item.第二级过流保护 == "无" || item.第三级过流保护 == "无")
                    {
                        item.SPD检测综评 = "不符合《建筑物防雷装置检测技术规范》GB/T21431-2015第5.8条要求。";
                    }
                    else
                    {
                        item.SPD检测综评 = "符合《建筑物防雷装置检测技术规范》GB/T21431-2015第5.8条要求。";
                    }
                }
                
             

            }
            catch { }
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

        private void jsClosed(object sender, WindowClosedEventArgs e)
        {
            var item = this.rpg.Item as SPD要素;
            string peop = ((sender as RadWindow).Content as 人员选择)._people;
            if (peop.Trim().Length > 0)
                item.技术负责人 = peop;

        }
        private void jhClosed(object sender, WindowClosedEventArgs e)
        {
            var item = this.rpg.Item as SPD要素;
            string peop = ((sender as RadWindow).Content as 人员选择)._people;
            if (peop.Trim().Length > 0)
                item.校核人 = peop;

        }
        private void jhpeopleAdd_Click(object sender, RoutedEventArgs e)
        {
            RadWindow settingsDialog = new RadWindow();
            人员选择 ry = new 人员选择("校核人");

            settingsDialog.Content = ry;
            settingsDialog.MinWidth = 300;
            settingsDialog.MinHeight = 180;
            settingsDialog.ResizeMode = ResizeMode.CanResize;
            settingsDialog.Header = "校核人选择";
            settingsDialog.Owner = this;
            settingsDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            settingsDialog.HideMinimizeButton = true;
            settingsDialog.HideMaximizeButton = true;
            settingsDialog.CanClose = false;
            settingsDialog.Closed += jhClosed;
            // Settheme settheme1 = new Settheme();
            //MainWindow mw = settingsDialog.Owner as MainWindow;
            ////settheme1.setTheme(this, settheme1.setLightOrDark("Crystal"));

            settingsDialog.ShowDialog();
        }

        private void AZSL1Add_Click(object sender, RoutedEventArgs e)
        {
            RadWindow settingsDialog = new RadWindow();
            安装数量选择 ry = new 安装数量选择();

            settingsDialog.Content = ry;
            settingsDialog.MinWidth = 300;
            settingsDialog.MinHeight = 180;
            settingsDialog.ResizeMode = ResizeMode.CanResize;
            settingsDialog.Header = "安装数量选择";
            settingsDialog.Owner = this;
            settingsDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            settingsDialog.HideMinimizeButton = true;
            settingsDialog.HideMaximizeButton = true;
            settingsDialog.CanClose = false;
            settingsDialog.Closed += az1Closed;

            settingsDialog.ShowDialog();
        }
        private void az1Closed(object sender, WindowClosedEventArgs e)
        {
            var item = this.rpg.Item as SPD要素;
            string peop = ((sender as RadWindow).Content as 安装数量选择)._people;
            if (peop.Trim().Length > 0)
                item.第一级安装数量 = peop;

        }
        private void AZSL2Add_Click(object sender, RoutedEventArgs e)
        {
            RadWindow settingsDialog = new RadWindow();
            安装数量选择 ry = new 安装数量选择();

            settingsDialog.Content = ry;
            settingsDialog.MinWidth = 300;
            settingsDialog.MinHeight = 180;
            settingsDialog.ResizeMode = ResizeMode.CanResize;
            settingsDialog.Header = "安装数量选择";
            settingsDialog.Owner = this;
            settingsDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            settingsDialog.HideMinimizeButton = true;
            settingsDialog.HideMaximizeButton = true;
            settingsDialog.CanClose = false;
            settingsDialog.Closed += az2Closed;

            settingsDialog.ShowDialog();
        }
        private void az2Closed(object sender, WindowClosedEventArgs e)
        {
            var item = this.rpg.Item as SPD要素;
            string peop = ((sender as RadWindow).Content as 安装数量选择)._people;
            if (peop.Trim().Length > 0)
                item.第二级安装数量 = peop;

        }
        private void AZSL3Add_Click(object sender, RoutedEventArgs e)
        {
            RadWindow settingsDialog = new RadWindow();
            安装数量选择 ry = new 安装数量选择();

            settingsDialog.Content = ry;
            settingsDialog.MinWidth = 300;
            settingsDialog.MinHeight = 180;
            settingsDialog.ResizeMode = ResizeMode.CanResize;
            settingsDialog.Header = "安装数量选择";
            settingsDialog.Owner = this;
            settingsDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            settingsDialog.HideMinimizeButton = true;
            settingsDialog.HideMaximizeButton = true;
            settingsDialog.CanClose = false;
            settingsDialog.Closed += az3Closed;

            settingsDialog.ShowDialog();
        }
        private void az3Closed(object sender, WindowClosedEventArgs e)
        {
            var item = this.rpg.Item as SPD要素;
            string peop = ((sender as RadWindow).Content as 安装数量选择)._people;
            if (peop.Trim().Length > 0)
                item.第三级安装数量 = peop;

        }
        private void jspeopleAdd_Click(object sender, RoutedEventArgs e)
        {
            RadWindow settingsDialog = new RadWindow();
            人员选择 ry = new 人员选择("技术负责人");

            settingsDialog.Content = ry;
            settingsDialog.MinWidth = 300;
            settingsDialog.MinHeight = 180;
            settingsDialog.ResizeMode = ResizeMode.CanResize;
            settingsDialog.Header = "技术负责人选择";
            settingsDialog.Owner = this;
            settingsDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            settingsDialog.HideMinimizeButton = true;
            settingsDialog.HideMaximizeButton = true;
            settingsDialog.CanClose = false;
            settingsDialog.Closed += jsClosed;
            // Settheme settheme1 = new Settheme();
            //MainWindow mw = settingsDialog.Owner as MainWindow;
            ////settheme1.setTheme(this, settheme1.setLightOrDark("Crystal"));

            settingsDialog.ShowDialog();
        }
        //新增人员窗口关闭事件处理
        private void OnClosed(object sender, WindowClosedEventArgs e)
        {
            var item = this.rpg.Item as SPD要素;
            string peop = ((sender as RadWindow).Content as 人员选择)._people;
            if(peop.Trim().Length>2)
             item.检测员 = peop;
            
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
                var item = this.rpg.Item as SPD要素;
                数据库处理类 cjkcl = new 数据库处理类();
                if (!cjkcl.ExistsSPD(item.编号))
                {
                    
                    if(cjkcl.AddSPD(item))
                    {
                        RadWindow rw = GetParentObject<RadWindow>(this, "");
                        boolBS = true;
                        rw.Close();
                        
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
                    RadWindow.Confirm(new DialogParameters
                    {
                        Content = "SPD编号已存在，继续保存将覆盖已有数据，是否继续？",
                        Closed = new EventHandler<WindowClosedEventArgs>(UpdateClosed),
                        Header = "注意",
                        CancelButtonContent = "否",
                        OkButtonContent = "是"

                    });
                }
                
            }
        }
        private void UpdateClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                var item = this.rpg.Item as SPD要素;
                数据库处理类 cjkcl = new 数据库处理类();
                if (cjkcl.UpdateSPD(item))
                {
                    RadWindow rw = GetParentObject<RadWindow>(this, "");
                    boolBS = true;
                    rw.Close();

                }
                else
                {
                    RadWindow.Alert(new DialogParameters
                    {
                        Content = "数据库更新失败，请重试",

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
