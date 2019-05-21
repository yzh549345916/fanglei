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
        private readonly RadGridView gridView = null;
        private readonly FrameworkElement contextMenu = null;

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

                    switch (header)
                    {
                        case "新增检测报告":
                            新增检测报告(rw1);
                            break;
                        case "编辑":
                            gridView.BeginEdit();
                            break;
                        case "测试总表1":
                            MessageBox.Show(header);
                            break;
                        case "测试分表3":
                            MessageBox.Show(header);
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
            settingsDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
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
                    menu.Items.Add("新增检测报告");
                    menu.Items.Add("测试总表3");
                    menu.Items.Add("测试总表2");
                }
                else if ((selectItem as 检测报告分表类) != null)
                {
                    menu.Items.Clear();
                    menu.Items.Add("测试分表1");
                    menu.Items.Add("测试分表2");
                    menu.Items.Add("测试分表3");
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
                    myGridData.JcbgZbs.Add(new 检测报告总表类()
                    {
                        CompanyAddress=ys.地址,
                        StartDate=ys.检测开始日期,
                        EndDate=ys.检测结束日期,
                        NextDate=ys.下次检测日期,
                        TelephoneNumber=ys.电话,
                        CompanyName=ys.受检单位名称,
                        ContactDepartment=ys.联系部门,
                        Zbid=ys.编号,
                        ZrPeople=ys.负责人,
                        
                    });
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
