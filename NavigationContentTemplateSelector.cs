using System.Windows;
using System.Windows.Controls;

namespace fangleinew
{
    public class NavigationContentTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Template { get; set; }
        public DataTemplate TemplateAlternative { get; set; }
        public DataTemplate ConfigContentTemplate { get; set; }
        public DataTemplate JCBGContentTemplate { get; set; }
        public DataTemplate MapContentTemplate { get; set; }
        public DataTemplate Property1ContentTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item != null)
            {
                NavigationItemModel model = (NavigationItemModel)item;
                if(model.Title=="检测报告")
                {
                    return this.JCBGContentTemplate;
                }
                else if (model.Title == "华")
                {
                    return this.MapContentTemplate;
                }
                else if(model.Title != "检测报告")
                {
                    return this.Property1ContentTemplate;
                }
                else if (!string.IsNullOrEmpty(model.Text))
                {
                    return this.TemplateAlternative;
                }
            }

            return this.Template;
        }
    }
}
