using System.Collections.ObjectModel;
using Telerik.Windows.Controls;

namespace fangleinew
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<NavigationItemModel> Items { get; set; }

        public MainViewModel()
        {
            this.Items = new ObservableCollection<NavigationItemModel>();

            this.Items.Add(CreateItem("检测报告", "&#xe303;", string.Empty, "Images/1.JPG"));
            this.Items.Add(CreateItem("泽", "&#xe13d;", string.Empty, "Images/4.JPG", "Images/5.JPG", "Images/6.JPG"));
            this.Items.Add(CreateItem("华", "&#xe500;", string.Empty, "Images/7.JPG", "Images/8.JPG", "Images/9.JPG"));
            this.Items.Add(CreateItem("是", "&#xe303;", string.Empty, @"D:\cx\防雷\防雷\检测报告\设置菜单.xaml"));
            this.Items.Add(CreateItem("是2", "&#xe303;", string.Empty, @"/设置菜单.xaml"));
            this.Items.Add(CreateItem("是3", "&#xe303;", string.Empty, @"设置菜单.xaml"));
            this.Items.Add(CreateItem(
                "超级大帅哥",
                "&#xe401;",

                "Discover our beautiful collection. Download up to 750 Images/Month! Speedy Search & Discovery. 4k Images added per hour. No daily\n download limit. Footage & music libraries. Types: Images, Photos, Vectors, Illustrations, Editorial, Icons. \n\n" +
                "Discover our beautiful collection. Download up to 750 Images/Month! Speedy Search & Discovery. 4k Images added per hour. No daily\n download limit. Footage & music libraries. Types: Images, Photos, Vectors, Illustrations, Editorial, Icons. \n\n" +
                "Discover our beautiful collection. Download up to 750 Images/Month! Speedy Search & Discovery. 4k Images added per hour. No daily\n download limit. Footage & music libraries. Types: Images, Photos, Vectors, Illustrations, Editorial, Icons. \n\n",

                "Images/6.JPG",
                "Images/2.JPG",
                "Images/8.JPG",
                "Images/9.JPG",
                "Images/5.JPG"));
        }

        private static NavigationItemModel CreateItem(string title, string iconGlyph, string text, params string[] imagePaths)
        {
            NavigationItemModel item = new NavigationItemModel();
            item.Title = title;
            item.Text = text;
            item.IconGlyph = iconGlyph;
            item.ImagePaths = imagePaths;

            return item;
        }
    }
}
