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
    public partial class 建筑物防雷装置表续属性表 : UserControl
    {
        建筑物防雷装置要素 _fbys = new 建筑物防雷装置要素();
        public bool boolBS = false;
        public 建筑物防雷装置表续属性表()
        {
            InitializeComponent();
            rpg.AutoGeneratingPropertyDefinition += new EventHandler<Telerik.Windows.Controls.Data.PropertyGrid.AutoGeneratingPropertyDefinitionEventArgs>(RpgAutoGeneratingPropertyDefinition);
            rpg.Item = new 建筑物防雷装置表续要素()
            {
               
            };
        }
        public 建筑物防雷装置表续属性表(string bh,建筑物防雷装置要素 fbys,报告总表要素 zbys)
        {
            InitializeComponent();
            _fbys = fbys;
            rpg.AutoGeneratingPropertyDefinition += new EventHandler<Telerik.Windows.Controls.Data.PropertyGrid.AutoGeneratingPropertyDefinitionEventArgs>(RpgAutoGeneratingPropertyDefinition);
            string jspd = "";
            try
            {
                if (fbys.Dxpj1.Trim() == "不符合" || fbys.Jsddxpj.Trim() == "不符合" || fbys.Jswldxpj.Trim() == "不符合")
                    jspd += "防雷装置不符合《建筑物防雷装置检测技术规范》GB/T21431-2015第5.2.1条要求及《建筑物防雷设计规范》GB50057-2010第4.2.4、4.3.1、4.4.1、5.2的规定。";
            }
            catch
            {
            }

           try
           {
                if (fbys.Jsdxpj.Trim() == "不符合" || fbys.Dyxldxpj.Trim() == "不符合" || fbys.Wmfsdxpj1.Trim() == "不符合" || fbys.Wmfsdxpj2.Trim() == "不符合" || fbys.Wmfsdxpj3.Trim() == "不符合")
                    jspd += "防雷装置不符合《建筑物防雷装置检测技术规范》GB/T21431-2015第5.2.2条要求及《建筑物防雷设计规范》GB50057-2010第5.2的规定。";
            }
           catch
           {
           }

           try
           {
                if (fbys.Yxxdxpj.Trim() == "不符合")
                    jspd += "防雷装置不符合《建筑物防雷装置检测技术规范》GB/T21431-2015第5.3.1条要求及《建筑物防雷设计规范》GB50057-2010第5.3的规定。";
            }
           catch
           {
           }

           rpg.Item = new 建筑物防雷装置表续要素()
            {
               
                编号= bh,
                主要检测仪器= zbys.仪器列表,
                检测员=fbys.检测员,
                校核人=fbys.校核人,
                技术负责人=fbys.技术负责人,
                技术评定=jspd
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
                if (e.EditedPropertyDefinition.DisplayName == "金属门窗过渡电阻")
                {
                    建筑物防雷装置表续要素 item = (建筑物防雷装置表续要素)rpg.Item;
                    if (item.金属门窗过渡电阻 < 0.03 && item.金属门窗过渡电阻 > 0)
                        item.金属门窗单项评价 = "符合";
                    else if(item.金属门窗过渡电阻>= 0.03)
                    {
                        item.金属门窗单项评价 = "不符合";
                        
                    }
                        
                    else
                        item.金属门窗单项评价 = "/";
                }
                if (e.EditedPropertyDefinition.DisplayName == "外墙大型金属物过渡电阻")
                {
                    建筑物防雷装置表续要素 item = (建筑物防雷装置表续要素)rpg.Item;
                    if (item.外墙大型金属物过渡电阻 < 0.03 && item.外墙大型金属物过渡电阻 > 0)
                        item.外墙大型金属物单项评价 = "符合";
                    else if (item.外墙大型金属物过渡电阻 >= 0.03)
                    {
                        item.外墙大型金属物单项评价 = "不符合";
                       
                    }
                       
                    else
                        item.外墙大型金属物单项评价 = "/";
                }
                if (e.EditedPropertyDefinition.DisplayName == "金属框架过渡电阻")
                {
                    建筑物防雷装置表续要素 item = (建筑物防雷装置表续要素)rpg.Item;
                    if (item.金属框架过渡电阻 < 0.03 && item.金属框架过渡电阻 > 0)
                        item.金属框架单项评价 = "符合";
                    else if (item.金属框架过渡电阻 >= 0.03)
                    {
                        item.金属框架单项评价 = "不符合";
                       
                    }
                        
                    else
                        item.金属框架单项评价 = "/";
                }
                if(e.EditedPropertyDefinition.DisplayName == "金属框架过渡电阻"|| e.EditedPropertyDefinition.DisplayName == "外墙大型金属物过渡电阻"|| e.EditedPropertyDefinition.DisplayName == "金属门窗过渡电阻")
                {
                    建筑物防雷装置表续要素 item = (建筑物防雷装置表续要素)rpg.Item;
                    string jspd = "";
                    if (_fbys.Dxpj1.Trim() == "不符合" || _fbys.Jsddxpj.Trim() == "不符合" || _fbys.Jswldxpj.Trim() == "不符合")
                        jspd += "防雷装置不符合《建筑物防雷装置检测技术规范》GB/T21431-2015第5.2.1条要求及《建筑物防雷设计规范》GB50057-2010第4.2.4、4.3.1、4.4.1、5.2的规定。";
                    if (_fbys.Jsdxpj.Trim() == "不符合" || _fbys.Dyxldxpj.Trim() == "不符合" || _fbys.Wmfsdxpj1.Trim() == "不符合" || _fbys.Wmfsdxpj2.Trim() == "不符合" || _fbys.Wmfsdxpj3.Trim() == "不符合")
                        jspd += "防雷装置不符合《建筑物防雷装置检测技术规范》GB/T21431-2015第5.2.2条要求及《建筑物防雷设计规范》GB50057-2010第5.2的规定。";
                    if (_fbys.Yxxdxpj.Trim() == "不符合")
                        jspd += "防雷装置不符合《建筑物防雷装置检测技术规范》GB/T21431-2015第5.3.1条要求及《建筑物防雷设计规范》GB50057-2010第5.3的规定。";
                    if (item.金属门窗单项评价.Trim() == "不符合"|| item.外墙大型金属物单项评价.Trim() == "不符合"|| item.金属框架单项评价.Trim() == "不符合")
                    {
                      
                        jspd += "防雷装置不符合《建筑物防雷设计规范》GB50057-2010第4.2.4、4.3.9、4.4.8的规定。";
                        
                    }
                    if(item.接地装置单项评价.Trim() == "不符合")
                    {

                        jspd += "防雷装置不符合《建筑物防雷装置检测技术规范》GB/T21431-2015第5.4.1条要求及《建筑物防雷设计规范》GB50057-2010第5.4的规定。";

                    }
                    item.技术评定 = jspd;

                }
                if (e.EditedPropertyDefinition.DisplayName == "接地方式"|| e.EditedPropertyDefinition.DisplayName == "接地装置接地电阻")
                {
                    建筑物防雷装置表续要素 item = (建筑物防雷装置表续要素)rpg.Item;
                    if (item.接地装置接地电阻 < 4 && item.接地装置接地电阻 > 0&& item.接地方式=="共用")
                        item.接地装置单项评价 = "符合";
                    else if (item.接地装置接地电阻 < 30&& item.接地装置接地电阻 > 0 && item.接地方式 == "独立")
                        item.接地装置单项评价 = "符合";
                    else
                        item.接地装置单项评价 = "不符合";

                    string jspd = "";
                    if (_fbys.Dxpj1.Trim() == "不符合" || _fbys.Jsddxpj.Trim() == "不符合" || _fbys.Jswldxpj.Trim() == "不符合")
                        jspd += "防雷装置不符合《建筑物防雷装置检测技术规范》GB/T21431-2015第5.2.1条要求及《建筑物防雷设计规范》GB50057-2010第4.2.4、4.3.1、4.4.1、5.2的规定。";
                    if (_fbys.Jsdxpj.Trim() == "不符合" || _fbys.Dyxldxpj.Trim() == "不符合" || _fbys.Wmfsdxpj1.Trim() == "不符合" || _fbys.Wmfsdxpj2.Trim() == "不符合" || _fbys.Wmfsdxpj3.Trim() == "不符合")
                        jspd += "防雷装置不符合《建筑物防雷装置检测技术规范》GB/T21431-2015第5.2.2条要求及《建筑物防雷设计规范》GB50057-2010第5.2的规定。";
                    if (_fbys.Yxxdxpj.Trim() == "不符合")
                        jspd += "防雷装置不符合《建筑物防雷装置检测技术规范》GB/T21431-2015第5.3.1条要求及《建筑物防雷设计规范》GB50057-2010第5.3的规定。";
                    if (item.金属门窗单项评价.Trim() == "不符合" || item.外墙大型金属物单项评价.Trim() == "不符合" || item.金属框架单项评价.Trim() == "不符合")
                    {

                        jspd += "防雷装置不符合《建筑物防雷设计规范》GB50057-2010第4.2.4、4.3.9、4.4.8的规定。";

                    }
                    if (item.接地装置单项评价.Trim() == "不符合")
                    {

                        jspd += "防雷装置不符合《建筑物防雷装置检测技术规范》GB/T21431-2015第5.4.1条要求及《建筑物防雷设计规范》GB50057-2010第5.4的规定。";

                    }
                    item.技术评定 = jspd;
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
