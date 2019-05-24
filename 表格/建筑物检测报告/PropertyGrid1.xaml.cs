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
using static fangleinew.建筑物防雷装置要素;

namespace fangleinew
{
    /// <summary>
    /// PropertyGrid1.xaml 的交互逻辑
    /// </summary>
    public partial class PropertyGrid1 : UserControl
    {
        public 报告总表要素 _zbys=new 报告总表要素()
        {
            仪器列表="测试仪器"
        };
        public PropertyGrid1()
        {
            InitializeComponent();
            rpg.AutoGeneratingPropertyDefinition += new EventHandler<Telerik.Windows.Controls.Data.PropertyGrid.AutoGeneratingPropertyDefinitionEventArgs>(RpgAutoGeneratingPropertyDefinition);
            rpg.Item = new 建筑物防雷装置要素()
            {
                项目名称="测试",
                防雷类别= (fangleiLBEnum)Enum.Parse(typeof(fangleiLBEnum), "二类"),
                地址="火星",
                联系人="光头强",
                电话="110",
                编号="11",

            };
        }
        public PropertyGrid1(报告总表要素 zbys)
        {
            InitializeComponent();
            rpg.AutoGeneratingPropertyDefinition += new EventHandler<Telerik.Windows.Controls.Data.PropertyGrid.AutoGeneratingPropertyDefinitionEventArgs>(RpgAutoGeneratingPropertyDefinition);
            _zbys = zbys;
            rpg.Item = new 建筑物防雷装置要素()
            {
                

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
                if (e.EditedPropertyDefinition.DisplayName == "接闪杆锈蚀情况" || e.EditedPropertyDefinition.DisplayName == "接闪杆保护范围" || e.EditedPropertyDefinition.DisplayName == "接闪杆接地电阻")
                {
                    建筑物防雷装置要素 item = (建筑物防雷装置要素)rpg.Item;
                    if (item.XsLB1 != null && item.BhLB1 != null)
                        item.Dxpj1 = getDXPJ(item.XsLB1, item.BhLB1, item.Jdzz1);
                    else
                        item.Dxpj1 = "/";
                }
                else if (e.EditedPropertyDefinition.DisplayName == "接闪带锈蚀情况" || e.EditedPropertyDefinition.DisplayName == "接闪带保护范围" || e.EditedPropertyDefinition.DisplayName == "接闪带接地电阻")
                {
                    建筑物防雷装置要素 item = (建筑物防雷装置要素)rpg.Item;
                    if (item.Jsdxs != null && item.Jsdbhfw != null)
                        item.Jsddxpj = getDXPJ(item.Jsdxs, item.Jsdbhfw, item.Jsdjddz);
                    else
                        item.Jsddxpj = "/";
                }
                else if (e.EditedPropertyDefinition.DisplayName == "接闪网络锈蚀情况" || e.EditedPropertyDefinition.DisplayName == "接闪网络保护范围" || e.EditedPropertyDefinition.DisplayName == "接闪网络接地电阻")
                {
                    建筑物防雷装置要素 item = (建筑物防雷装置要素)rpg.Item;
                    if (item.Jswlxs != null && item.Jswlbhfw != null)
                        item.Jswldxpj = getDXPJ(item.Jswlxs, item.Jswlbhfw, item.Jswljddz);
                    else
                        item.Jswldxpj = "/";
                  
                }
                else if (e.EditedPropertyDefinition.DisplayName == "金属结构与接闪带连接" || e.EditedPropertyDefinition.DisplayName == "连接用材料" || e.EditedPropertyDefinition.DisplayName == "金属结构间等电位连接")
                {
                    建筑物防雷装置要素 item = (建筑物防雷装置要素)rpg.Item;
                    if (item.Ljcl != null )
                        item.Jsdxpj = getJSDXPJ(item.jsjgDDW, item.jsjgJSD, item.Ljcl);
                    else
                        item.Jsdxpj = "/";
                    
                }
                else if(e.EditedPropertyDefinition.DisplayName == "敷设方式"|| e.EditedPropertyDefinition.DisplayName == "屏蔽保护措施" || e.EditedPropertyDefinition.DisplayName == "屏蔽保护层接地")
                {
                    建筑物防雷装置要素 item = (建筑物防雷装置要素)rpg.Item;
                    if(item.Dyfsfs=="/")
                    {
                        item.Dyxldxpj = "/";
                        item.Pbbhcs = "/";
                        item.Pbbhcjd = "/";
                    }
                    else if(item.Pbbhcs== "未采取措施" || item.Pbbhcjd == "未接地")
                        item.Dyxldxpj = "不符合";
                    else
                        item.Dyxldxpj = "符合";
                }
                else if(e.EditedPropertyDefinition.DisplayName == "屋面附属设备名称1" || e.EditedPropertyDefinition.DisplayName == "防直击雷1" || e.EditedPropertyDefinition.DisplayName == "防闪电感应1")
                {
                    建筑物防雷装置要素 item = (建筑物防雷装置要素)rpg.Item;
                    if (item.WmfsName1 == "")
                    {
                        item.WmfsName1 = "/";
                    }
                        if (item.WmfsName1 == "/")
                    {
                        item.Fzjl1 = "/";
                        item.Fsdgy1 = "/";
                        item.Wmfsdxpj1 = "/";
                    }
                    else if (item.Fsdgy1 =="符合"&&item.Fzjl1 == "符合")
                    {
                        item.Wmfsdxpj1 = "符合";
                    }
                    else
                    {
                        item.Wmfsdxpj1 = "不符合";
                    }
                }
                else if (e.EditedPropertyDefinition.DisplayName == "屋面附属设备名称2" || e.EditedPropertyDefinition.DisplayName == "防直击雷2" || e.EditedPropertyDefinition.DisplayName == "防闪电感应2")
                {
                    建筑物防雷装置要素 item = (建筑物防雷装置要素)rpg.Item;
                    if (item.WmfsName2 == "")
                    {
                        item.WmfsName2 = "/";
                    }
                    if (item.WmfsName2 == "/")
                    {
                        item.Fzjl2 = "/";
                        item.Fsdgy2 = "/";
                        item.Wmfsdxpj2 = "/";
                    }
                    else if (item.Fsdgy2 == "符合" && item.Fzjl2 == "符合")
                    {
                        item.Wmfsdxpj2 = "符合";
                    }
                    else
                    {
                        item.Wmfsdxpj2 = "不符合";
                    }
                }
                else if (e.EditedPropertyDefinition.DisplayName == "屋面附属设备名称3" || e.EditedPropertyDefinition.DisplayName == "防直击雷3" || e.EditedPropertyDefinition.DisplayName == "防闪电感应3")
                {
                    建筑物防雷装置要素 item = (建筑物防雷装置要素)rpg.Item;
                    if (item.WmfsName3 == "")
                    {
                        item.WmfsName3 = "/";
                    }
                    if (item.WmfsName3 == "/")
                    {
                        item.Fzjl3 = "/";
                        item.Fsdgy3= "/";
                        item.Wmfsdxpj3 = "/";
                    }
                    else if (item.Fsdgy3 == "符合" && item.Fzjl3 == "符合")
                    {
                        item.Wmfsdxpj3 = "符合";
                    }
                    else
                    {
                        item.Wmfsdxpj3 = "不符合";
                    }
                }
                else if(e.EditedPropertyDefinition.DisplayName == "防雷类别"|| e.EditedPropertyDefinition.DisplayName == "引下线敷设")
                {
                    建筑物防雷装置要素 item = (建筑物防雷装置要素)rpg.Item;
                    if(item.YxxFs=="明敷")
                    {
                        if(item.防雷类别.ToString()=="一类")
                        {
                            item.YxxJJ = "≤12";
                            item.YxxNum = 1;
                        }
                        else if (item.防雷类别.ToString() == "二类")
                        {
                            item.YxxJJ = "≤18";
                            item.YxxNum = 2;
                        }
                        else
                        {
                            item.YxxJJ = "≤25";
                            item.YxxNum = 2;
                        }
                    }
                    if (item.YxxFs == "暗敷")
                    {
                        item.YxxJJ = "/";
                        item.YxxNum = -1;
                        item.YxxCL = "/";
                        item.Yxxdxpj = "符合";
                        item.YxxHJJG = "/";
                        item.YxxJDK = "/";
                        item.YxxWZ = "/";
                    }
                    if (item.YxxFs == "/")
                    {
                        item.YxxJJ = "/";
                        item.YxxNum = -1;
                        item.YxxCL = "/";
                        item.Yxxdxpj = "/";
                        item.YxxHJJG = "/";
                        item.YxxJDK = "/";
                        item.YxxWZ = "/";
                    }
                }
                else if (e.EditedPropertyDefinition.DisplayName == "续表编号" || e.EditedPropertyDefinition.DisplayName == "SPD编号")
                {
                    建筑物防雷装置要素 item = (建筑物防雷装置要素)rpg.Item;
                    int countPage = 1;
                    if(item.Jzwxb.Trim().Length>0&& item.Jzwxb.Trim()!="/")
                    {
                        countPage++;
                    }
                    if (item.Jzwspd.Trim().Length > 0 && item.Jzwspd.Trim() != "/")
                    {
                        countPage++;
                    }
                    item.PageNum =   countPage;
                }
            }
            catch { }
        }
        /// <summary>
        /// 进行单项评价
        /// </summary>
        /// <param name="xs">锈蚀情况</param>
        /// <param name="baohufw">保护范围</param>
        /// <param name="dz">电阻</param>
        /// <returns></returns>
        public string getDXPJ(string xs,string baohufw,double dz)
        {

            if (xs == "无锈蚀" && baohufw == "够" && dz < 10)
            {
                return "符合";
            }
            else if (xs == "/" && baohufw == "/")
                return "/";
            else
                return "不符合";
            
        }

        /// <summary>
        /// 进行大型金属单项评价
        /// </summary>
        /// <param name="dz1">金属构件间等电位电阻</param>
        /// <param name="dz2">金属构件与接闪带连接电阻</param>
        /// <param name="ljcl">连接用材料</param>
        /// <returns></returns>

        public string getJSDXPJ(double dz1, double dz2,string ljcl)
        {

            if (ljcl == "/")
                return "/";
            else if (dz1 > 0.2 || dz2 > 0.2)
                return "不符合";
            else
                return "符合";

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
            人员选择 ry = new 人员选择("检测员");

            settingsDialog.Content = ry;
            settingsDialog.MinWidth = 300;
            settingsDialog.MinHeight = 180;
            settingsDialog.ResizeMode = ResizeMode.CanResize;
            settingsDialog.Header = "检测员选择";
            settingsDialog.Owner = this;
            settingsDialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            settingsDialog.HideMinimizeButton = true;
            settingsDialog.HideMaximizeButton = true;
            settingsDialog.CanClose = false;
            settingsDialog.Closed += OnClosed;
            // Settheme settheme1 = new Settheme();
            //MainWindow mw = settingsDialog.Owner as MainWindow;
            ////settheme1.setTheme(this, settheme1.setLightOrDark("Crystal"));

            settingsDialog.ShowDialog();
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
            settingsDialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            settingsDialog.HideMinimizeButton = true;
            settingsDialog.HideMaximizeButton = true;
            settingsDialog.CanClose = false;
            settingsDialog.Closed += jhClosed;
            // Settheme settheme1 = new Settheme();
            //MainWindow mw = settingsDialog.Owner as MainWindow;
            ////settheme1.setTheme(this, settheme1.setLightOrDark("Crystal"));

            settingsDialog.ShowDialog();
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
            settingsDialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            settingsDialog.HideMinimizeButton = true;
            settingsDialog.HideMaximizeButton = true;
            settingsDialog.CanClose = false;
            settingsDialog.Closed += jsClosed;
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
            settingsDialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            settingsDialog.HideMinimizeButton = true;
            settingsDialog.HideMaximizeButton = true;
            settingsDialog.CanClose = false;
            settingsDialog.Closed += bzClosed;
            // Settheme settheme1 = new Settheme();
            //MainWindow mw = settingsDialog.Owner as MainWindow;
            ////settheme1.setTheme(this, settheme1.setLightOrDark("Crystal"));

            settingsDialog.ShowDialog();
        }
        private void xbAdd_Click(object sender, RoutedEventArgs e)
        {
            RadWindow settingsDialog = new RadWindow();
            建筑物防雷装置检测表续选择 ry = new 建筑物防雷装置检测表续选择(_zbys, rpg.Item as 建筑物防雷装置要素);


            settingsDialog.Content = ry;
            settingsDialog.MinWidth = 300;
            settingsDialog.MinHeight = 250;
            settingsDialog.ResizeMode = ResizeMode.CanResize;
            settingsDialog.Header = "建筑物防雷装置检测表续选择";
            settingsDialog.Owner = this;
            settingsDialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            settingsDialog.HideMinimizeButton = true;
            settingsDialog.HideMaximizeButton = true;
            settingsDialog.CanClose = false;
            settingsDialog.Closed += XBClosed;
            // Settheme settheme1 = new Settheme();
            //MainWindow mw = settingsDialog.Owner as MainWindow;
            ////settheme1.setTheme(this, settheme1.setLightOrDark("Crystal"));

            settingsDialog.ShowDialog();
        }

        private void spdAdd_Click(object sender, RoutedEventArgs e)
        {
            RadWindow settingsDialog = new RadWindow();
            var item = rpg.Item as 建筑物防雷装置要素;
            SPD检测表选择 ry = new SPD检测表选择(item.检测员,item.校核人,item.技术负责人);


            settingsDialog.Content = ry;
            settingsDialog.MinWidth = 300;
            settingsDialog.MinHeight = 250;
            settingsDialog.ResizeMode = ResizeMode.CanResize;
            settingsDialog.Header = "SPD检测表续选择";
            settingsDialog.Owner = this;
            settingsDialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            settingsDialog.HideMinimizeButton = true;
            settingsDialog.HideMaximizeButton = true;
            settingsDialog.CanClose = false;
            settingsDialog.Closed += SPDClosed;
            // Settheme settheme1 = new Settheme();
            //MainWindow mw = settingsDialog.Owner as MainWindow;
            ////settheme1.setTheme(this, settheme1.setLightOrDark("Crystal"));

            settingsDialog.ShowDialog();
        }
        private void SPDClosed(object sender, WindowClosedEventArgs e)
        {
            var item = this.rpg.Item as 建筑物防雷装置要素;
            string peop = ((sender as RadWindow).Content as SPD检测表选择)._people;
            if (peop.Trim().Length > 0)
                item.Jzwspd = peop;
            int count = 1;
            if (item.Jzwxb.Length > 1)
                count++;
            if (item.Jzwspd.Length > 1)
                count++;
            item.PageNum = count;

        }
        private void XBClosed(object sender, WindowClosedEventArgs e)
        {
            var item = this.rpg.Item as 建筑物防雷装置要素;
            string peop = ((sender as RadWindow).Content as 建筑物防雷装置检测表续选择)._people;
            if (peop.Trim().Length > 0)
                item.Jzwxb = peop;
            int count = 1;
            if (item.Jzwxb.Length > 1)
                count++;
            if (item.Jzwspd.Length > 1)
                count++;
            item.PageNum = count;

        }
        //新增人员窗口关闭事件处理
        private void OnClosed(object sender, WindowClosedEventArgs e)
        {
            var item = this.rpg.Item as 建筑物防雷装置要素;
            string peop = ((sender as RadWindow).Content as 人员选择)._people;
            if(peop.Trim().Length>0)
             item.检测员 = peop;
            
        }
        private void jsClosed(object sender, WindowClosedEventArgs e)
        {
            var item = this.rpg.Item as 建筑物防雷装置要素;
            string peop = ((sender as RadWindow).Content as 人员选择)._people;
            if (peop.Trim().Length > 0)
                item.技术负责人 = peop;

        }
        private void jhClosed(object sender, WindowClosedEventArgs e)
        {
            var item = this.rpg.Item as 建筑物防雷装置要素;
            string peop = ((sender as RadWindow).Content as 人员选择)._people;
            if (peop.Trim().Length > 0)
                item.校核人 = peop;

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
                Header = "注意",
                CancelButtonContent = "否",
                OkButtonContent = "是"

            });
        }
        private void OnConfirmClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                var item = this.rpg.Item as 建筑物防雷装置要素;
                数据库处理类 cjkcl = new 数据库处理类();
                if (!cjkcl.ExistsJZWBX(item.编号))
                {

                    if (cjkcl.AddJZWBX(item))
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
                        Content = "建筑物表续编号已存在，继续保存将覆盖已有数据，是否继续？",
                        Closed = new EventHandler<WindowClosedEventArgs>(UpdateClosed),
                        Header = "注意",
                        CancelButtonContent = "否",
                        OkButtonContent = "是"

                    });
                }

            }
        }

        private void CancelBtu_Click(object sender, RoutedEventArgs e)
        {

        }
    }



}
