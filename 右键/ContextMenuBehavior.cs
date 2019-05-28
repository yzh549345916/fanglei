using fangleinew;
using System;
using System.Windows;
using System.Windows.Media;
using Telerik.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace 表格分层
{
    public class GridContextMenuBehavior
    {
        object _rowit = null;
        private readonly RadGridView gridView = null;
        private readonly FrameworkElement contextMenu = null;
        string _closeID = "";
        public static readonly DependencyProperty ContextmenuPropery =
        DependencyProperty.RegisterAttached("ContextMenu", typeof(FrameworkElement), typeof(GridContextMenuBehavior),
            new PropertyMetadata(new PropertyChangedCallback(OnIsEnabledPropertyChanged)));

        public static void SetContextMenu(DependencyObject dependencyObject, FrameworkElement contextmenu)
        {
            dependencyObject.SetValue(ContextmenuPropery, contextmenu);
        }

        public static FrameworkElement GetContextMenu(DependencyObject dependencyObject)
        {
            return (FrameworkElement)dependencyObject.GetValue(ContextmenuPropery);
        }

        public static void OnIsEnabledPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            RadGridView grid = dependencyObject as RadGridView;
            FrameworkElement contextMenu = e.NewValue as FrameworkElement;

            if (grid != null && contextMenu != null)
            {
                GridContextMenuBehavior behavior = new GridContextMenuBehavior(grid, contextMenu);
            }
        }

        public GridContextMenuBehavior(RadGridView grid, FrameworkElement contextMenu)
        {
            this.gridView = grid;
            this.contextMenu = contextMenu;

            (contextMenu as RadContextMenu).Opened += RadContextMenu_Opened;
            (contextMenu as RadContextMenu).ItemClick += RadContextMenu_ItemClick;
        }

        private void RadContextMenu_ItemClick(object sender, RadRoutedEventArgs e)
        {
           try
           {
                RadContextMenu menu = (RadContextMenu)sender;
                RadMenuItem clickedItem = e.OriginalSource as RadMenuItem;
                GridViewRow row = menu.GetClickedElement<GridViewRow>();
                
                GridJCBG rw1 = GetParentObject<GridJCBG>(row.GridViewDataControl, "");
                // var ls = menu.DataContext as 表格分层.MyGridData;//刷新表格数据
                //ls.JcbgZbs = 检测报告总表类.GetZbs2();
                if (clickedItem != null && row != null)
                {
                    string header = Convert.ToString(clickedItem.Header);
                    string typeStr=row.Item.GetType().ToString();
                    检测报告分表类 fbitem;
                    MyGridData myGridData;
                    switch (header)
                    {
                        case "新增检测报告":
                            新增检测报告(rw1);
                            break;
                        case "查看检测报告":
                            
                            查看检测报告(rw1, (row.Item as 检测报告总表类)?.Zbid);
                            break;
                        case "新增建（构）筑物防雷装置检测表":
                            _rowit = row.Item;
                            if (typeStr== "表格分层.检测报告总表类")
                            {
                                新增建筑物防雷装置检测表(rw1, row.Item as 检测报告总表类);

                            }
                            else
                            {
                                myGridData = rw1.clubsGrid.DataContext as MyGridData;
                                fbitem = row.Item as 检测报告分表类;
                                _rowit = myGridData.getZBbyID(fbitem.Zbid);
                                
                                新增建筑物防雷装置检测表(rw1, _rowit as 检测报告总表类);
                            }
                            break;
                        case "查看":
                            myGridData = rw1.clubsGrid.DataContext as MyGridData;
                            fbitem = row.Item as 检测报告分表类;
                            _rowit = myGridData.getZBbyID(fbitem.Zbid);
                            查看检测报告分表(rw1, fbitem);
                            break;
                        case "删除":
                            _rowit = row.Item;
                            if (typeStr == "表格分层.检测报告总表类")
                            {
                                _closeID = (row.Item as 检测报告总表类).Zbid;
                                RadWindow.Confirm(new DialogParameters
                                {
                                    Content = "删除检测报告将同时删除其包含的检测报告分表，是否继续删除？",
                                    Closed = DeleteZBConfirmClosed,
                                    Header = "注意",
                                    CancelButtonContent = "否",
                                    OkButtonContent = "是",
                                    Owner=rw1
                                });

                            }
                            else
                            {
                                myGridData = rw1.clubsGrid.DataContext as MyGridData;
                                fbitem = row.Item as 检测报告分表类;
                                _rowit = myGridData.getZBbyID(fbitem.Zbid);

                                _closeID = fbitem.Fbid;
                                RadWindow.Confirm(new DialogParameters
                                {
                                    Content = "即将删除检测报告分表，是否继续删除？",
                                    Closed = DeleteFBConfirmClosed,
                                    Header = "注意",
                                    CancelButtonContent = "否",
                                    OkButtonContent = "是",
                                    Owner = rw1
                                });
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
           catch
           {
           }
        }
        private void DeleteZBConfirmClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                数据库处理类 sjkcl = new 数据库处理类();
               
                sjkcl.DeleteZB(_closeID);
                MyGridData myGridData = ((sender as RadWindow).Owner as GridJCBG).clubsGrid.DataContext as MyGridData;
                myGridData.JcbgZbs = 检测报告总表类.GetZbs();
            }
        }
        private void DeleteFBConfirmClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                数据库处理类 sjkcl = new 数据库处理类();

                sjkcl.deleFBList((_rowit as 检测报告总表类).Zbid,_closeID);
                
                sjkcl.DeleteFB(_closeID);
                var zbys = sjkcl.GetZBbyBh((_rowit as 检测报告总表类).Zbid);
                zbys.报告页数 = sjkcl.GetPagebyZB(zbys.编号);
                sjkcl.UpdateZB(zbys);
                MyGridData myGridData = ((sender as RadWindow).Owner as GridJCBG).clubsGrid.DataContext as MyGridData;
                myGridData.JcbgZbs = 检测报告总表类.updateZbs(myGridData.JcbgZbs, (_rowit as 检测报告总表类).Zbid);
            }
        }
        private void 查看检测报告分表(GridJCBG gridJCBG,检测报告分表类 fb )
        {
            数据库处理类 sjkcl = new 数据库处理类();
            RadWindow settingsDialog = new RadWindow();
            switch (fb.FenLei)
            {
                case "建筑物防雷装置检测表":
                    
                    建筑物防雷装置要素 fljz =sjkcl.GetJZWFBbyBh(fb.Fbid);
                    var zbys = sjkcl.GetZBbyBh(fljz.报告编号);
                    PropertyGrid1 ry = new PropertyGrid1(zbys,fljz);
                    settingsDialog.Content = ry;
                    settingsDialog.Closed += 新增建筑物防雷装置检测表关闭;
                    break;
                case "建筑物电子信息系统防雷装置检测表":
                   
                    break;
                case "爆炸和火灾危险场所防雷装置检测表":
                    
                    break;
                case "风力发电机组防雷装置检测表":
                    
                    break;
                case "太阳能光伏系统防雷装置检测表":
                    
                    break;
                default:
                    break;
            }
            settingsDialog.Owner = gridJCBG;
            settingsDialog.MinWidth = 300;
            settingsDialog.MinHeight = 180;
            settingsDialog.ResizeMode = ResizeMode.CanResize;
            settingsDialog.Header = "查看" + fb.FenLei;
            settingsDialog.WindowStartupLocation = WindowStartupLocation.Manual;
            
            settingsDialog.ShowDialog();

        }
        private void 新增检测报告(GridJCBG gridJCBG)
        {
            表格编号生成 bhsc = new 表格编号生成();
            RadWindow settingsDialog = new RadWindow();
            总表属性表 ry = new 总表属性表(bhsc.获取总表最新编号());
            settingsDialog.Owner = gridJCBG;
            settingsDialog.Content = ry;
            settingsDialog.MinWidth = 300;
            settingsDialog.MinHeight = 180;
            settingsDialog.ResizeMode = ResizeMode.CanResize;
            settingsDialog.Header = "新增检测报告";
            settingsDialog.WindowStartupLocation = WindowStartupLocation.Manual;
            settingsDialog.Closed += 新增总表属性表关闭;
            settingsDialog.ShowDialog();
        }
        private void 新增建筑物防雷装置检测表(GridJCBG gridJCBG,检测报告总表类 zbl)
        {
            数据库处理类 sjkcl = new 数据库处理类();
            报告总表要素 zbys = sjkcl.GetZBbyBh(zbl.Zbid);
            表格编号生成 bhsc = new 表格编号生成();
            RadWindow settingsDialog = new RadWindow();
            PropertyGrid1 ry = new PropertyGrid1(zbys, bhsc.获取建筑物防雷装置检测表最新编号());
            settingsDialog.Owner = gridJCBG;
            settingsDialog.Content = ry;
            settingsDialog.MinWidth = 300;
            settingsDialog.MinHeight = 180;
            settingsDialog.ResizeMode = ResizeMode.CanResize;
            settingsDialog.Header = "新增建（构）筑物防雷装置检测表";
            settingsDialog.WindowStartupLocation = WindowStartupLocation.Manual;
            settingsDialog.Closed += 新增建筑物防雷装置检测表关闭;
            settingsDialog.ShowDialog();
        }
        private void 新增建筑物防雷装置检测表关闭(object sender, WindowClosedEventArgs e)
        {
            try
            {
                数据库处理类 sjkcl = new 数据库处理类();
                
                PropertyGrid1 zsxb = (sender as RadWindow).Content as PropertyGrid1;
                sjkcl.UpdateZB(zsxb._zbys);
                if (zsxb.boolBS)
                {
                    MyGridData myGridData = ((sender as RadWindow).Owner as GridJCBG).clubsGrid.DataContext as MyGridData;
                    myGridData.JcbgZbs = 检测报告总表类.updateZbs(myGridData.JcbgZbs, (_rowit as 检测报告总表类).Zbid);

                }
            }
            catch(Exception ex)
            {
            }
        }
        private void 查看检测报告(GridJCBG gridJCBG,string bh)
        {

            表格编号生成 bhsc = new 表格编号生成();
            RadWindow settingsDialog = new RadWindow();
            数据库处理类 sjkcl = new 数据库处理类();
            总表属性表 ry = new 总表属性表(sjkcl.GetZBbyBh(bh));
            settingsDialog.Owner = gridJCBG;
            settingsDialog.Content = ry;
            settingsDialog.MinWidth = 300;
            settingsDialog.MinHeight = 180;
            settingsDialog.ResizeMode = ResizeMode.CanResize;
            settingsDialog.Header = "查看检测报告";
            settingsDialog.WindowStartupLocation = WindowStartupLocation.Manual;
            settingsDialog.Closed += 新增总表属性表关闭;
            settingsDialog.ShowDialog();
        }
        private void RadContextMenu_Opened(object sender, RoutedEventArgs e)
        {
            RadContextMenu menu = (RadContextMenu)sender;

            GridViewRow row = menu.GetClickedElement<GridViewRow>();

            if (row != null)
            {
                
                row.IsSelected = row.IsCurrent = true;
                object selectItem =row.GridViewDataControl.SelectedItem;
                GridViewCell cell = menu.GetClickedElement<GridViewCell>();
                if (cell != null)
                {
                    cell.IsCurrent = true;
                }
                if((selectItem as 检测报告总表类)!=null)
                {
                    menu.Items.Clear();
                    menu.Items.Add("查看检测报告");
                    menu.Items.Add("新增检测报告");
                    menu.Items.Add("新增建（构）筑物防雷装置检测表");
                    menu.Items.Add("新增建筑物电子信息系统防雷装置检测表");
                    menu.Items.Add("新增爆炸和火灾危险场所防雷装置检测表");
                    menu.Items.Add("新增风力发电机组防雷装置检测表");
                    menu.Items.Add("新增太阳能光伏系统防雷装置检测表");
                    menu.Items.Add("删除");
                }
                else if ((selectItem as 检测报告分表类) != null)
                {
                    menu.Items.Clear();
                    menu.Items.Add("查看");
                    menu.Items.Add("新增建（构）筑物防雷装置检测表");
                    menu.Items.Add("新增建筑物电子信息系统防雷装置检测表");
                    menu.Items.Add("新增爆炸和火灾危险场所防雷装置检测表");
                    menu.Items.Add("新增风力发电机组防雷装置检测表");
                    menu.Items.Add("新增太阳能光伏系统防雷装置检测表");
                    menu.Items.Add("上移");
                    menu.Items.Add("下移");
                    menu.Items.Add("删除");
                }
                else
                {
                    menu.IsOpen = false;
                }

            }
            else
            {
                menu.IsOpen = false;
            }
        }

        private void 新增总表属性表关闭(object sender, WindowClosedEventArgs e)
        {
            try
            {
                总表属性表 zsxb = (sender as RadWindow).Content as 总表属性表;
                if (zsxb.boolBS)
                {
                    报告总表要素 ys = zsxb.rpg.Item as 报告总表要素;
                    MyGridData myGridData =((sender as RadWindow).Owner as GridJCBG).clubsGrid.DataContext as MyGridData;
                    myGridData.JcbgZbs=检测报告总表类.GetZbs();
                  
                }
            }
            catch
            {
            }
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
