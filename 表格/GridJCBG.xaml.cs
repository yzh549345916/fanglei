using Config;
using fangleinew;
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
using Telerik.Windows.Controls.GridView;

namespace 表格分层
{
    /// <summary>
    /// GridJCBG.xaml 的交互逻辑
    /// </summary>
    public partial class GridJCBG : UserControl
    {
        bool changingSelection = false;
        public GridJCBG()
        {
            
            InitializeComponent();
            CSH();

        }
        public Theme GetMyTheme(string name)
        {
            string myName = name.ToLower();
            if (myName.Contains("crystal"))
            {
                return new CrystalTheme();
            }
            else if (myName.Contains("fluent"))
            {
                return new FluentTheme();
            }
            else if (myName.Contains("material"))
            {
                return new MaterialTheme();
            }
            else if (myName.Contains("office2016touch"))
            {
                return new Office2016TouchTheme();
            }
            else if (myName.Contains("office2016"))
            {
                return new Office2016Theme();
            }
            else if (myName.Contains("green"))
            {
                return new GreenTheme();
            }
            else if (myName.Contains("office2013"))
            {
                return new Office2013Theme();
            }
            else if (myName.Contains("visualstudio2013"))
            {
                return new VisualStudio2013Theme();
            }
            else if (myName.Contains("windows8touch"))
            {
                return new Windows8TouchTheme();
            }
            else if (myName.Contains("windows8"))
            {
                return new Windows8Theme();
            }
            else if (myName.Contains("office_black"))
            {
                return new Office_BlackTheme();
            }
            else if (myName.Contains("office_blue"))
            {
                return new Office_BlueTheme();
            }
            else if (myName.Contains("office_silver"))
            {
                return new Office_SilverTheme();
            }
            else if (myName.Contains("summer"))
            {
                return new SummerTheme();
            }
            else if (myName.Contains("vista"))
            {
                return new VistaTheme();
            }
            else if (myName.Contains("transparent"))
            {
                return new TransparentTheme();
            }
            else if (myName.Contains("windows7"))
            {
                return new Windows7Theme();
            }
            else if (myName.Contains("expression_dark"))
            {
                return new Expression_DarkTheme();
            }
            return new CrystalTheme();
        }
        private void CSH()
        {
           
        }
        private void clubsGrid_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            if (changingSelection)
                return;
            changingSelection = true;
            var dataControl = e.OriginalSource as GridViewDataControl;
            var selectedItem = dataControl.SelectedItem;

            this.UnSelect();
            dataControl.SelectedItems.Add(selectedItem);
            var p=selectedItem as 检测报告分表类;
            
            changingSelection = false;
        }
        private void S1_MouseWheel(object sender, MouseButtonEventArgs e)
        {
            RadialMenuCommands.Show.Execute(null, clubsGrid);
        }

        private void NavigationView_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RadialMenuCommands.Hide.Execute(null, clubsGrid);
        }

        private void UnSelect()
        {
            this.clubsGrid.UnselectAll();

            foreach (GridViewRow row in this.clubsGrid.ChildrenOfType<GridViewRow>())
            {
                if (row != null && row.IsExpanded == true)
                {
                    RadGridView childGrid = row.ChildrenOfType<RadGridView>().FirstOrDefault();
                    childGrid.UnselectAll();
                }
            }
        }
    }


}
