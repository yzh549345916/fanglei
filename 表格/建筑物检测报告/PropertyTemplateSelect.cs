using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Data.PropertyGrid;
using System;

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
            else if (pd.SourceProperty.Name == "检测员")
            {
                return PeopleSelectTemplate;
            }
            else if (pd.SourceProperty.Name == "校核人")
            {
                return jhPeopleSelectTemplate;
            }
            else if (pd.SourceProperty.Name == "技术负责人")
            {
                return jsPeopleSelectTemplate;
            }
            else if (pd.SourceProperty.Name == "仪器列表")
            {
                return YQSelectTemplate;
            }
            else if (pd.SourceProperty.Name == "依据标准")
            {
                return BZSelectTemplate;
            }
            else if (pd.SourceProperty.Name == "技术评定")
            {
                return zhPJTemplate;
            }
            else if (pd.SourceProperty.Name == "Jzwxb")
            {
                return XBSelectTemplate;
            }
            else if (pd.SourceProperty.Name == "Jzwspd")
            {
                return SPDSelectTemplate;
            }
            else if (pd.SourceProperty.Name=="第一级安装数量")
            {
                return AZSLTemplate1;
            }
            else if (pd.SourceProperty.Name == "第二级安装数量")
            {
                return AZSLTemplate2;
            }
            else if (pd.SourceProperty.Name == "第三级安装数量")
            {
                return AZSLTemplate3;
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
        public DataTemplate YQSelectTemplate { get; set; }
        public DataTemplate XBSelectTemplate { get; set; }
        public DataTemplate SPDSelectTemplate { get; set; }
        public DataTemplate jhPeopleSelectTemplate { get; set; }
        public DataTemplate jsPeopleSelectTemplate { get; set; }
        public DataTemplate zhPJTemplate { get; set; }
        public DataTemplate AZSLTemplate1 { get; set; }
        public DataTemplate AZSLTemplate2 { get; set; }
        public DataTemplate AZSLTemplate3 { get; set; }
    }
}
