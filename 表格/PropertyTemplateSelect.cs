using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Data.PropertyGrid;

namespace fangleinew
{
    public class FileUploadTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var pd = item as PropertyDefinition;

            if (pd.SourceProperty.Name == "StringProp")
            {
                return OpenFileDialogTemplate;
            }
            else if (pd.SourceProperty.Name == "人员")
            {
                return PeopleSelectTemplate;
            }
            else if (pd.SourceProperty.Name == "依据标准")
            {
                return BZSelectTemplate;
            }
            else if(pd.SourceProperty.PropertyType == typeof(double))
            {
                return NumericPropertyTemplate;
            }
            else if (pd.SourceProperty.PropertyType == typeof(int))
            {
                return NumIntPropertyTemplate;
            }
            return null;
        }
        public DataTemplate OpenFileDialogTemplate { get; set; }

        public DataTemplate NumericPropertyTemplate { get; set; }
        public DataTemplate PeopleSelectTemplate { get; set; }
        public DataTemplate BZSelectTemplate { get; set; }
        public DataTemplate NumIntPropertyTemplate { get; set; }
    }
}
