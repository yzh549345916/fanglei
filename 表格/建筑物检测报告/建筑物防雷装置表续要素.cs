using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace fangleinew
{
    public class 建筑物防雷装置表续要素 : IDataErrorInfo, INotifyPropertyChanged
    {

        private int jsmcjcds;
        [Display(Description = "金属门窗检测点数，填写负数则生成报告时为/", GroupName = "01.防侧击雷", Order = 1)]
        public int 金属门窗检测点数
        {
            get { return jsmcjcds; }
            set
            {
                if(value!= jsmcjcds)
                {
                    jsmcjcds = value;
                    this.OnPropertyChanged("金属门窗检测点数");
                }
                
            }
        }
        private double jsmcgddz;
        [Display(Description = "金属门窗过渡电阻，填写负数则生成报告时为/", GroupName = "01.防侧击雷", Order = 2)]
        public double 金属门窗过渡电阻
        {
            get { return jsmcgddz; }
            set
            {
                jsmcgddz = value;
                this.OnPropertyChanged("金属门窗过渡电阻");

            }
        }
        public class FHTypeConverter : TypeConverter
        {
            public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
            {
                return true;
            }

            public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
            {
                return true;
            }

            public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                return new StandardValuesCollection(new string[] { "符合", "不符合", "/" });
            }
        }
        private string jsmcdxpj = "/";
        [Display(Description = "金属门窗单项评价", GroupName = "01.防侧击雷", Order = 3)]
        [TypeConverter(typeof(FHTypeConverter))]
        public string 金属门窗单项评价
        {
            get { return jsmcdxpj; }
            set
            {
                if (value != jsmcdxpj)
                {
                    jsmcdxpj = value;
                    OnPropertyChanged("金属门窗单项评价");
                }
            }
        }
        private int wqdxjswjcds;
        [Display(Description = "外墙大型金属物检测点数，填写负数则生成报告时为/",GroupName = "01.防侧击雷", Order = 4)]
        public int 外墙大型金属物检测点数
        {
            get { return wqdxjswjcds; }
            set
            {
                if (value != wqdxjswjcds)
                {
                    wqdxjswjcds = value;
                    this.OnPropertyChanged("外墙大型金属物检测点数");
                }

            }
        }
        private double wqdxjswgddz;
        [Display(Description = "外墙大型金属物过渡电阻，填写负数则生成报告时为/", GroupName = "01.防侧击雷", Order = 5)]
        public double 外墙大型金属物过渡电阻
        {
            get { return wqdxjswgddz; }
            set
            {
                wqdxjswgddz = value;
                this.OnPropertyChanged("外墙大型金属物过渡电阻");

            }
        }
        private string wqdxjswdxpj = "/";
        [Display(Description = "外墙大型金属物单项评价", GroupName = "01.防侧击雷", Order = 6)]
        [TypeConverter(typeof(FHTypeConverter))]
        public string 外墙大型金属物单项评价
        {
            get { return wqdxjswdxpj; }
            set
            {
                if (value != wqdxjswdxpj)
                {
                    wqdxjswdxpj = value;
                    OnPropertyChanged("外墙大型金属物单项评价");
                }
            }
        }
        private int jskjjcds;
        [Display(Description = "金属框架检测点数，填写负数则生成报告时为/", GroupName = "01.防侧击雷", Order = 7)]
        public int 金属框架检测点数
        {
            get { return jskjjcds; }
            set
            {
                if (value != jskjjcds)
                {
                    jskjjcds = value;
                    this.OnPropertyChanged("金属框架检测点数");
                }

            }
        }
        private double jskjgddz;
        [Display(Description = "金属框架过渡电阻，填写负数则生成报告时为/", GroupName = "01.防侧击雷", Order = 8)]
        public double 金属框架过渡电阻
        {
            get { return jskjgddz; }
            set
            {
                jskjgddz = value;
                this.OnPropertyChanged("金属框架过渡电阻");

            }
        }
        private string jskjdxpj = "/";
        [Display(Description = "金属框架单项评价", GroupName = "01.防侧击雷", Order = 9)]
        [TypeConverter(typeof(FHTypeConverter))]
        public string 金属框架单项评价
        {
            get { return jskjdxpj; }
            set
            {
                if (value != jskjdxpj)
                {
                    jskjdxpj = value;
                    OnPropertyChanged("金属框架单项评价");
                }
            }
        }
        public class JDZZTypeConverter : TypeConverter
        {
            public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
            {
                return true;
            }

            public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
            {
                return true;
            }

            public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                return new StandardValuesCollection(new string[] { "自然", "人工", "混合", "/" });
            }
        }
        private string jdzzxs = "/";
        [Display(Description = "接地装置形式", GroupName = "02.接地装置", Order = 10)]
        [TypeConverter(typeof(JDZZTypeConverter))]
        public string 接地装置形式
        {
            get { return jdzzxs; }
            set
            {
                if (value != jdzzxs)
                {
                    jdzzxs = value;
                    OnPropertyChanged("接地装置形式");
                }
            }
        }
        public class JDFSTypeConverter : TypeConverter
        {
            public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
            {
                return true;
            }

            public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
            {
                return true;
            }

            public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                return new StandardValuesCollection(new string[] { "共用", "独立", "/" });
            }
        }
        private string jdfs = "/";
        [Display(Description = "接地方式", GroupName = "02.接地装置", Order = 11)]
        [TypeConverter(typeof(JDZZTypeConverter))]
        public string 接地方式
        {
            get { return jdfs; }
            set
            {
                if (value != jdfs)
                {
                    jdfs = value;
                    OnPropertyChanged("接地方式");
                }
            }
        }
        private int jdzzjcds;
        [Display(Description = "接地装置检测点数，填写负数则生成报告时为/", GroupName = "02.接地装置", Order = 12)]
        public int 接地装置检测点数
        {
            get { return jdzzjcds; }
            set
            {
                if (value != jdzzjcds)
                {
                    jdzzjcds = value;
                    this.OnPropertyChanged("接地装置检测点数");
                }

            }
        }
        private double jdzzgddz;
        [Display(Description = "接地装置接地电阻，填写负数则生成报告时为/", GroupName = "02.接地装置", Order = 13)]
        public double 接地装置接地电阻
        {
            get { return jdzzgddz; }
            set
            {
                jdzzgddz = value;
                this.OnPropertyChanged("接地装置接地电阻");

            }
        }
        private string jdzzdxpj = "/";
        [Display(Description = "接地装置单项评价", GroupName = "02.接地装置", Order = 14)]
        [TypeConverter(typeof(FHTypeConverter))]
        public string 接地装置单项评价
        {
            get { return jdzzdxpj; }
            set
            {
                if (value != jdzzdxpj)
                {
                    jdzzdxpj = value;
                    OnPropertyChanged("接地装置单项评价");
                }
            }
        }
        #region 室内大型设备
        private string dxsbName1="/";
        [Display(Description = "室内大型设备名称1", GroupName = "03.室内大型设备等电位连接", Order = 15)]
        public string 室内大型设备名称1
        {
            get { return dxsbName1; }
            set
            {
                if (value != dxsbName1)
                {
                    dxsbName1 = value;
                    this.OnPropertyChanged("室内大型设备名称1");
                }

            }
        }
        private double dxsbDZ1 = -1;
        [Display(Description = "室内大型设备电阻1，填写负数则生成报告时为/", GroupName = "03.室内大型设备等电位连接", Order = 16)]
        public double 室内大型设备电阻1
        {
            get { return dxsbDZ1; }
            set
            {
                if (value != dxsbDZ1)
                {
                    dxsbDZ1 = value;
                    this.OnPropertyChanged("室内大型设备电阻1");
                }

            }
        }
        private string dxsbName2 = "/";
        [Display(Description = "室内大型设备名称2", GroupName = "03.室内大型设备等电位连接", Order = 17)]
        public string 室内大型设备名称2
        {
            get { return dxsbName2; }
            set
            {
                if (value != dxsbName2)
                {
                    dxsbName2 = value;
                    this.OnPropertyChanged("室内大型设备名称1");
                }

            }
        }
        private double dxsbDZ2 = -1;
        [Display(Description = "室内大型设备电阻2，填写负数则生成报告时为/", GroupName = "03.室内大型设备等电位连接", Order = 18)]
        public double 室内大型设备电阻2
        {
            get { return dxsbDZ2; }
            set
            {
                if (value != dxsbDZ2)
                {
                    dxsbDZ2 = value;
                    this.OnPropertyChanged("室内大型设备电阻2");
                }

            }
        }
        private string dxsbName3 = "/";
        [Display(Description = "室内大型设备名称3", GroupName = "03.室内大型设备等电位连接", Order = 19)]
        public string 室内大型设备名称3
        {
            get { return dxsbName3; }
            set
            {
                if (value != dxsbName3)
                {
                    dxsbName3 = value;
                    this.OnPropertyChanged("室内大型设备名称3");
                }

            }
        }
        private double dxsbDZ3 = -1;
        [Display(Description = "室内大型设备电阻3，填写负数则生成报告时为/", GroupName = "03.室内大型设备等电位连接", Order = 20)]
        public double 室内大型设备电阻3
        {
            get { return dxsbDZ3; }
            set
            {
                if (value != dxsbDZ3)
                {
                    dxsbDZ3 = value;
                    this.OnPropertyChanged("室内大型设备电阻3");
                }

            }
        }
        private string dxsbName4 = "/";
        [Display(Description = "室内大型设备名称4", GroupName = "03.室内大型设备等电位连接", Order = 21)]
        public string 室内大型设备名称4
        {
            get { return dxsbName4; }
            set
            {
                if (value != dxsbName4)
                {
                    dxsbName4 = value;
                    this.OnPropertyChanged("室内大型设备名称4");
                }

            }
        }
        private double dxsbDZ4 = -1;
        [Display(Description = "室内大型设备电阻4，填写负数则生成报告时为/", GroupName = "03.室内大型设备等电位连接", Order = 22)]
        public double 室内大型设备电阻4
        {
            get { return dxsbDZ4; }
            set
            {
                if (value != dxsbDZ4)
                {
                    dxsbDZ4 = value;
                    this.OnPropertyChanged("室内大型设备电阻4");
                }

            }
        }
        private string dxsbName5 = "/";
        [Display(Description = "室内大型设备名称5", GroupName = "03.室内大型设备等电位连接", Order = 23)]
        public string 室内大型设备名称5
        {
            get { return dxsbName5; }
            set
            {
                if (value != dxsbName5)
                {
                    dxsbName5 = value;
                    this.OnPropertyChanged("室内大型设备名称5");
                }

            }
        }
        private double dxsbDZ5 = -1;
        [Display(Description = "室内大型设备电阻5，填写负数则生成报告时为/", GroupName = "03.室内大型设备等电位连接", Order = 24)]
        public double 室内大型设备电阻5
        {
            get { return dxsbDZ5; }
            set
            {
                if (value != dxsbDZ5)
                {
                    dxsbDZ5 = value;
                    this.OnPropertyChanged("室内大型设备电阻5");
                }

            }
        }
        private string dxsbName6 = "/";
        [Display(Description = "室内大型设备名称6", GroupName = "03.室内大型设备等电位连接", Order = 25)]
        public string 室内大型设备名称6
        {
            get { return dxsbName6; }
            set
            {
                if (value != dxsbName6)
                {
                    dxsbName6 = value;
                    this.OnPropertyChanged("室内大型设备名称6");
                }

            }
        }
        private double dxsbDZ6 = -1;
        [Display(Description = "室内大型设备电阻6，填写负数则生成报告时为/", GroupName = "03.室内大型设备等电位连接", Order = 26)]
        public double 室内大型设备电阻6
        {
            get { return dxsbDZ6; }
            set
            {
                if (value != dxsbDZ6)
                {
                    dxsbDZ6 = value;
                    this.OnPropertyChanged("室内大型设备电阻6");
                }

            }
        }
        private string dxsbName7 = "/";
        [Display(Description = "室内大型设备名称7", GroupName = "03.室内大型设备等电位连接", Order = 27)]
        public string 室内大型设备名称7
        {
            get { return dxsbName7; }
            set
            {
                if (value != dxsbName7)
                {
                    dxsbName7 = value;
                    this.OnPropertyChanged("室内大型设备名称7");
                }

            }
        }
        private double dxsbDZ7 = -1;
        [Display(Description = "室内大型设备电阻7，填写负数则生成报告时为/", GroupName = "03.室内大型设备等电位连接", Order = 28)]
        public double 室内大型设备电阻7
        {
            get { return dxsbDZ7; }
            set
            {
                if (value != dxsbDZ7)
                {
                    dxsbDZ7 = value;
                    this.OnPropertyChanged("室内大型设备电阻7");
                }

            }
        }
        private string dxsbName8 = "/";
        [Display(Description = "室内大型设备名称8", GroupName = "03.室内大型设备等电位连接", Order = 29)]
        public string 室内大型设备名称8
        {
            get { return dxsbName8; }
            set
            {
                if (value != dxsbName8)
                {
                    dxsbName8 = value;
                    this.OnPropertyChanged("室内大型设备名称8");
                }

            }
        }
        private double dxsbDZ8=-1;
        [Display(Description = "室内大型设备电阻8，填写负数则生成报告时为/", GroupName = "03.室内大型设备等电位连接", Order = 30)]
        public double 室内大型设备电阻8
        {
            get { return dxsbDZ8; }
            set
            {
                if (value != dxsbDZ8)
                {
                    dxsbDZ8 = value;
                    this.OnPropertyChanged("室内大型设备电阻8");
                }

            }
        }
        private string dxsbName9 = "/";
        [Display(Description = "室内大型设备名称9", GroupName = "03.室内大型设备等电位连接", Order = 31)]
        public string 室内大型设备名称9
        {
            get { return dxsbName9; }
            set
            {
                if (value != dxsbName9)
                {
                    dxsbName9 = value;
                    this.OnPropertyChanged("室内大型设备名称9");
                }

            }
        }
        private double dxsbDZ9 = -1;
        [Display(Description = "室内大型设备电阻9，填写负数则生成报告时为/", GroupName = "03.室内大型设备等电位连接", Order = 32)]
        public double 室内大型设备电阻9
        {
            get { return dxsbDZ9; }
            set
            {
                if (value != dxsbDZ9)
                {
                    dxsbDZ9 = value;
                    this.OnPropertyChanged("室内大型设备电阻9");
                }

            }
        }
        private string dxsbName10 = "/";
        [Display(Description = "室内大型设备名称10", GroupName = "03.室内大型设备等电位连接", Order = 33)]
        public string 室内大型设备名称10
        {
            get { return dxsbName10; }
            set
            {
                if (value != dxsbName10)
                {
                    dxsbName10 = value;
                    this.OnPropertyChanged("室内大型设备名称10");
                }

            }
        }
        private double dxsbDZ10 = -1;
        [Display(Description = "室内大型设备电阻10，填写负数则生成报告时为/", GroupName = "03.室内大型设备等电位连接", Order = 34)]
        public double 室内大型设备电阻10
        {
            get { return dxsbDZ10; }
            set
            {
                if (value != dxsbDZ10)
                {
                    dxsbDZ10 = value;
                    this.OnPropertyChanged("室内大型设备电阻10");
                }

            }
        }
        private string dxsbName11 = "/";
        [Display(Description = "室内大型设备名称11", GroupName = "03.室内大型设备等电位连接", Order = 35)]
        public string 室内大型设备名称11
        {
            get { return dxsbName11; }
            set
            {
                if (value != dxsbName11)
                {
                    dxsbName11 = value;
                    this.OnPropertyChanged("室内大型设备名称11");
                }

            }
        }
        private double dxsbDZ11 = -1;
        [Display(Description = "室内大型设备电阻11，填写负数则生成报告时为/", GroupName = "03.室内大型设备等电位连接", Order = 36)]
        public double 室内大型设备电阻11
        {
            get { return dxsbDZ11; }
            set
            {
                if (value != dxsbDZ11)
                {
                    dxsbDZ11 = value;
                    this.OnPropertyChanged("室内大型设备电阻11");
                }

            }
        }
        #endregion
        #region 入户管线
        private string rhgxName1 = "/";
        [Display(Description = "入户管线名称1", GroupName = "04.入户管线等电位连接", Order = 37)]
        public string 入户管线名称1
        {
            get { return rhgxName1; }
            set
            {
                if (value != rhgxName1)
                {
                    rhgxName1 = value;
                    this.OnPropertyChanged("入户管线名称1");
                }

            }
        }
        private double rhgxDZ1 = -1;
        [Display(Description = "入户管线电阻1，填写负数则生成报告时为/", GroupName = "04.入户管线等电位连接", Order = 38)]
        public double 入户管线电阻1
        {
            get { return rhgxDZ1; }
            set
            {
                if (value != rhgxDZ1)
                {
                    rhgxDZ1 = value;
                    this.OnPropertyChanged("入户管线电阻1");
                }

            }
        }
        private string rhgxName2 = "/";
        [Display(Description = "入户管线名称2", GroupName = "04.入户管线等电位连接", Order = 39)]
        public string 入户管线名称2
        {
            get { return rhgxName2; }
            set
            {
                if (value != rhgxName2)
                {
                    rhgxName2 = value;
                    this.OnPropertyChanged("入户管线名称1");
                }

            }
        }
        private double rhgxDZ2 = -1;
        [Display(Description = "入户管线电阻2，填写负数则生成报告时为/", GroupName = "04.入户管线等电位连接", Order = 40)]
        public double 入户管线电阻2
        {
            get { return rhgxDZ2; }
            set
            {
                if (value != rhgxDZ2)
                {
                    rhgxDZ2 = value;
                    this.OnPropertyChanged("入户管线电阻2");
                }

            }
        }
        private string rhgxName3 = "/";
        [Display(Description = "入户管线名称3", GroupName = "04.入户管线等电位连接", Order = 41)]
        public string 入户管线名称3
        {
            get { return rhgxName3; }
            set
            {
                if (value != rhgxName3)
                {
                    rhgxName3 = value;
                    this.OnPropertyChanged("入户管线名称3");
                }

            }
        }
        private double rhgxDZ3 = -1;
        [Display(Description = "入户管线电阻3，填写负数则生成报告时为/", GroupName = "04.入户管线等电位连接", Order =42)]
        public double 入户管线电阻3
        {
            get { return rhgxDZ3; }
            set
            {
                if (value != rhgxDZ3)
                {
                    rhgxDZ3 = value;
                    this.OnPropertyChanged("入户管线电阻3");
                }

            }
        }
        private string rhgxName4 = "/";
        [Display(Description = "入户管线名称4", GroupName = "04.入户管线等电位连接", Order = 43)]
        public string 入户管线名称4
        {
            get { return rhgxName4; }
            set
            {
                if (value != rhgxName4)
                {
                    rhgxName4 = value;
                    this.OnPropertyChanged("入户管线名称4");
                }

            }
        }
        private double rhgxDZ4 = -1;
        [Display(Description = "入户管线电阻4，填写负数则生成报告时为/", GroupName = "04.入户管线等电位连接", Order =44)]
        public double 入户管线电阻4
        {
            get { return rhgxDZ4; }
            set
            {
                if (value != rhgxDZ4)
                {
                    rhgxDZ4 = value;
                    this.OnPropertyChanged("入户管线电阻4");
                }

            }
        }
        private string rhgxName5 = "/";
        [Display(Description = "入户管线名称5", GroupName = "04.入户管线等电位连接", Order = 45)]
        public string 入户管线名称5
        {
            get { return rhgxName5; }
            set
            {
                if (value != rhgxName5)
                {
                    rhgxName5 = value;
                    this.OnPropertyChanged("入户管线名称5");
                }

            }
        }
        private double rhgxDZ5 = -1;
        [Display(Description = "入户管线电阻5，填写负数则生成报告时为/", GroupName = "04.入户管线等电位连接", Order = 46)]
        public double 入户管线电阻5
        {
            get { return rhgxDZ5; }
            set
            {
                if (value != rhgxDZ5)
                {
                    rhgxDZ5 = value;
                    this.OnPropertyChanged("入户管线电阻5");
                }

            }
        }
        private string rhgxName6 = "/";
        [Display(Description = "入户管线名称6", GroupName = "04.入户管线等电位连接", Order = 47)]
        public string 入户管线名称6
        {
            get { return rhgxName6; }
            set
            {
                if (value != rhgxName6)
                {
                    rhgxName6 = value;
                    this.OnPropertyChanged("入户管线名称6");
                }

            }
        }
        private double rhgxDZ6 = -1;
        [Display(Description = "入户管线电阻6，填写负数则生成报告时为/", GroupName = "04.入户管线等电位连接", Order = 48)]
        public double 入户管线电阻6
        {
            get { return rhgxDZ6; }
            set
            {
                if (value != rhgxDZ6)
                {
                    rhgxDZ6 = value;
                    this.OnPropertyChanged("入户管线电阻6");
                }

            }
        }
        private string rhgxName7 = "/";
        [Display(Description = "入户管线名称7", GroupName = "04.入户管线等电位连接", Order = 49)]
        public string 入户管线名称7
        {
            get { return rhgxName7; }
            set
            {
                if (value != rhgxName7)
                {
                    rhgxName7 = value;
                    this.OnPropertyChanged("入户管线名称7");
                }

            }
        }
        private double rhgxDZ7 = -1;
        [Display(Description = "入户管线电阻7，填写负数则生成报告时为/", GroupName = "04.入户管线等电位连接", Order = 50)]
        public double 入户管线电阻7
        {
            get { return rhgxDZ7; }
            set
            {
                if (value != rhgxDZ7)
                {
                    rhgxDZ7 = value;
                    this.OnPropertyChanged("入户管线电阻7");
                }

            }
        }
        private string rhgxName8 = "/";
        [Display(Description = "入户管线名称8", GroupName = "04.入户管线等电位连接", Order = 51)]
        public string 入户管线名称8
        {
            get { return rhgxName8; }
            set
            {
                if (value != rhgxName8)
                {
                    rhgxName8 = value;
                    this.OnPropertyChanged("入户管线名称8");
                }

            }
        }
        private double rhgxDZ8 = -1;
        [Display(Description = "入户管线电阻8，填写负数则生成报告时为/", GroupName = "04.入户管线等电位连接", Order = 52)]
        public double 入户管线电阻8
        {
            get { return rhgxDZ8; }
            set
            {
                if (value != rhgxDZ8)
                {
                    rhgxDZ8 = value;
                    this.OnPropertyChanged("入户管线电阻8");
                }

            }
        }
        private string rhgxName9 = "/";
        [Display(Description = "入户管线名称9", GroupName = "04.入户管线等电位连接", Order = 53)]
        public string 入户管线名称9
        {
            get { return rhgxName9; }
            set
            {
                if (value != rhgxName9)
                {
                    rhgxName9 = value;
                    this.OnPropertyChanged("入户管线名称9");
                }

            }
        }
        private double rhgxDZ9 = -1;
        [Display(Description = "入户管线电阻9，填写负数则生成报告时为/", GroupName = "04.入户管线等电位连接", Order = 54)]
        public double 入户管线电阻9
        {
            get { return rhgxDZ9; }
            set
            {
                if (value != rhgxDZ9)
                {
                    rhgxDZ9 = value;
                    this.OnPropertyChanged("入户管线电阻9");
                }

            }
        }
        private string rhgxName10 = "/";
        [Display(Description = "入户管线名称10", GroupName = "04.入户管线等电位连接", Order = 55)]
        public string 入户管线名称10
        {
            get { return rhgxName10; }
            set
            {
                if (value != rhgxName10)
                {
                    rhgxName10 = value;
                    this.OnPropertyChanged("入户管线名称10");
                }

            }
        }
        private double rhgxDZ10 = -1;
        [Display(Description = "入户管线电阻10，填写负数则生成报告时为/", GroupName = "04.入户管线等电位连接", Order =56)]
        public double 入户管线电阻10
        {
            get { return rhgxDZ10; }
            set
            {
                if (value != rhgxDZ10)
                {
                    rhgxDZ10 = value;
                    this.OnPropertyChanged("入户管线电阻10");
                }

            }
        }
        private string rhgxName11 = "/";
        [Display(Description = "入户管线名称11", GroupName = "04.入户管线等电位连接", Order = 57)]
        public string 入户管线名称11
        {
            get { return rhgxName11; }
            set
            {
                if (value != rhgxName11)
                {
                    rhgxName11 = value;
                    this.OnPropertyChanged("入户管线名称11");
                }

            }
        }
        private double rhgxDZ11 = -1;
        [Display(Description = "入户管线电阻11，填写负数则生成报告时为/", GroupName = "04.入户管线等电位连接", Order = 58)]
        public double 入户管线电阻11
        {
            get { return rhgxDZ11; }
            set
            {
                if (value != rhgxDZ11)
                {
                    rhgxDZ11 = value;
                    this.OnPropertyChanged("入户管线电阻11");
                }

            }
        }
        #endregion
        #region 竖向管井内管线
        private string sxgngxName1 = "/";
        [Display(Description = "竖向管井内管线名称1", GroupName = "05.竖向管井内管线等电位连接", Order = 59)]
        public string 竖向管井内管线名称1
        {
            get { return sxgngxName1; }
            set
            {
                if (value != sxgngxName1)
                {
                    sxgngxName1 = value;
                    this.OnPropertyChanged("竖向管井内管线名称1");
                }

            }
        }
        private double sxgngxDZ1 = -1;
        [Display(Description = "竖向管井内管线电阻1，填写负数则生成报告时为/", GroupName = "05.竖向管井内管线等电位连接", Order = 60)]
        public double 竖向管井内管线电阻1
        {
            get { return sxgngxDZ1; }
            set
            {
                if (value != sxgngxDZ1)
                {
                    sxgngxDZ1 = value;
                    this.OnPropertyChanged("竖向管井内管线电阻1");
                }

            }
        }
        private string sxgngxName2 = "/";
        [Display(Description = "竖向管井内管线名称2", GroupName = "05.竖向管井内管线等电位连接", Order = 61)]
        public string 竖向管井内管线名称2
        {
            get { return sxgngxName2; }
            set
            {
                if (value != sxgngxName2)
                {
                    sxgngxName2 = value;
                    this.OnPropertyChanged("竖向管井内管线名称1");
                }

            }
        }
        private double sxgngxDZ2 = -1;
        [Display(Description = "竖向管井内管线电阻2，填写负数则生成报告时为/", GroupName = "05.竖向管井内管线等电位连接", Order = 62)]
        public double 竖向管井内管线电阻2
        {
            get { return sxgngxDZ2; }
            set
            {
                if (value != sxgngxDZ2)
                {
                    sxgngxDZ2 = value;
                    this.OnPropertyChanged("竖向管井内管线电阻2");
                }

            }
        }
        private string sxgngxName3 = "/";
        [Display(Description = "竖向管井内管线名称3", GroupName = "05.竖向管井内管线等电位连接", Order = 63)]
        public string 竖向管井内管线名称3
        {
            get { return sxgngxName3; }
            set
            {
                if (value != sxgngxName3)
                {
                    sxgngxName3 = value;
                    this.OnPropertyChanged("竖向管井内管线名称3");
                }

            }
        }
        private double sxgngxDZ3 = -1;
        [Display(Description = "竖向管井内管线电阻3，填写负数则生成报告时为/", GroupName = "05.竖向管井内管线等电位连接", Order = 64)]
        public double 竖向管井内管线电阻3
        {
            get { return sxgngxDZ3; }
            set
            {
                if (value != sxgngxDZ3)
                {
                    sxgngxDZ3 = value;
                    this.OnPropertyChanged("竖向管井内管线电阻3");
                }

            }
        }
        private string sxgngxName4 = "/";
        [Display(Description = "竖向管井内管线名称4", GroupName = "05.竖向管井内管线等电位连接", Order = 65)]
        public string 竖向管井内管线名称4
        {
            get { return sxgngxName4; }
            set
            {
                if (value != sxgngxName4)
                {
                    sxgngxName4 = value;
                    this.OnPropertyChanged("竖向管井内管线名称4");
                }

            }
        }
        private double sxgngxDZ4 = -1;
        [Display(Description = "竖向管井内管线电阻4，填写负数则生成报告时为/", GroupName = "05.竖向管井内管线等电位连接", Order = 66)]
        public double 竖向管井内管线电阻4
        {
            get { return sxgngxDZ4; }
            set
            {
                if (value != sxgngxDZ4)
                {
                    sxgngxDZ4 = value;
                    this.OnPropertyChanged("竖向管井内管线电阻4");
                }

            }
        }
        private string sxgngxName5 = "/";
        [Display(Description = "竖向管井内管线名称5", GroupName = "05.竖向管井内管线等电位连接", Order = 67)]
        public string 竖向管井内管线名称5
        {
            get { return sxgngxName5; }
            set
            {
                if (value != sxgngxName5)
                {
                    sxgngxName5 = value;
                    this.OnPropertyChanged("竖向管井内管线名称5");
                }

            }
        }
        private double sxgngxDZ5 = -1;
        [Display(Description = "竖向管井内管线电阻5，填写负数则生成报告时为/", GroupName = "05.竖向管井内管线等电位连接", Order = 68)]
        public double 竖向管井内管线电阻5
        {
            get { return sxgngxDZ5; }
            set
            {
                if (value != sxgngxDZ5)
                {
                    sxgngxDZ5 = value;
                    this.OnPropertyChanged("竖向管井内管线电阻5");
                }

            }
        }
        private string sxgngxName6 = "/";
        [Display(Description = "竖向管井内管线名称6", GroupName = "05.竖向管井内管线等电位连接", Order = 69)]
        public string 竖向管井内管线名称6
        {
            get { return sxgngxName6; }
            set
            {
                if (value != sxgngxName6)
                {
                    sxgngxName6 = value;
                    this.OnPropertyChanged("竖向管井内管线名称6");
                }

            }
        }
        private double sxgngxDZ6 = -1;
        [Display(Description = "竖向管井内管线电阻6，填写负数则生成报告时为/", GroupName = "05.竖向管井内管线等电位连接", Order = 70)]
        public double 竖向管井内管线电阻6
        {
            get { return sxgngxDZ6; }
            set
            {
                if (value != sxgngxDZ6)
                {
                    sxgngxDZ6 = value;
                    this.OnPropertyChanged("竖向管井内管线电阻6");
                }

            }
        }
        private string sxgngxName7 = "/";
        [Display(Description = "竖向管井内管线名称7", GroupName = "05.竖向管井内管线等电位连接", Order = 71)]
        public string 竖向管井内管线名称7
        {
            get { return sxgngxName7; }
            set
            {
                if (value != sxgngxName7)
                {
                    sxgngxName7 = value;
                    this.OnPropertyChanged("竖向管井内管线名称7");
                }

            }
        }
        private double sxgngxDZ7 = -1;
        [Display(Description = "竖向管井内管线电阻7，填写负数则生成报告时为/", GroupName = "05.竖向管井内管线等电位连接", Order = 72)]
        public double 竖向管井内管线电阻7
        {
            get { return sxgngxDZ7; }
            set
            {
                if (value != sxgngxDZ7)
                {
                    sxgngxDZ7 = value;
                    this.OnPropertyChanged("竖向管井内管线电阻7");
                }

            }
        }
        private string sxgngxName8 = "/";
        [Display(Description = "竖向管井内管线名称8", GroupName = "05.竖向管井内管线等电位连接", Order = 73)]
        public string 竖向管井内管线名称8
        {
            get { return sxgngxName8; }
            set
            {
                if (value != sxgngxName8)
                {
                    sxgngxName8 = value;
                    this.OnPropertyChanged("竖向管井内管线名称8");
                }

            }
        }
        private double sxgngxDZ8 = -1;
        [Display(Description = "竖向管井内管线电阻8，填写负数则生成报告时为/", GroupName = "05.竖向管井内管线等电位连接", Order = 74)]
        public double 竖向管井内管线电阻8
        {
            get { return sxgngxDZ8; }
            set
            {
                if (value != sxgngxDZ8)
                {
                    sxgngxDZ8 = value;
                    this.OnPropertyChanged("竖向管井内管线电阻8");
                }

            }
        }
        private string sxgngxName9 = "/";
        [Display(Description = "竖向管井内管线名称9", GroupName = "05.竖向管井内管线等电位连接", Order = 75)]
        public string 竖向管井内管线名称9
        {
            get { return sxgngxName9; }
            set
            {
                if (value != sxgngxName9)
                {
                    sxgngxName9 = value;
                    this.OnPropertyChanged("竖向管井内管线名称9");
                }

            }
        }
        private double sxgngxDZ9 = -1;
        [Display(Description = "竖向管井内管线电阻9，填写负数则生成报告时为/", GroupName = "05.竖向管井内管线等电位连接", Order = 76)]
        public double 竖向管井内管线电阻9
        {
            get { return sxgngxDZ9; }
            set
            {
                if (value != sxgngxDZ9)
                {
                    sxgngxDZ9 = value;
                    this.OnPropertyChanged("竖向管井内管线电阻9");
                }

            }
        }
        private string sxgngxName10 = "/";
        [Display(Description = "竖向管井内管线名称10", GroupName = "05.竖向管井内管线等电位连接", Order = 77)]
        public string 竖向管井内管线名称10
        {
            get { return sxgngxName10; }
            set
            {
                if (value != sxgngxName10)
                {
                    sxgngxName10 = value;
                    this.OnPropertyChanged("竖向管井内管线名称10");
                }

            }
        }
        private double sxgngxDZ10 = -1;
        [Display(Description = "竖向管井内管线电阻10，填写负数则生成报告时为/", GroupName = "05.竖向管井内管线等电位连接", Order = 78)]
        public double 竖向管井内管线电阻10
        {
            get { return sxgngxDZ10; }
            set
            {
                if (value != sxgngxDZ10)
                {
                    sxgngxDZ10 = value;
                    this.OnPropertyChanged("竖向管井内管线电阻10");
                }

            }
        }
        private string sxgngxName11 = "/";
        [Display(Description = "竖向管井内管线名称11", GroupName = "05.竖向管井内管线等电位连接", Order = 79)]
        public string 竖向管井内管线名称11
        {
            get { return sxgngxName11; }
            set
            {
                if (value != sxgngxName11)
                {
                    sxgngxName11 = value;
                    this.OnPropertyChanged("竖向管井内管线名称11");
                }

            }
        }
        private double sxgngxDZ11=-1;
        [Display(Description = "竖向管井内管线电阻11，填写负数则生成报告时为/", GroupName = "05.竖向管井内管线等电位连接", Order = 80)]
        public double 竖向管井内管线电阻11
        {
            get { return sxgngxDZ11; }
            set
            {
                if (value != sxgngxDZ11)
                {
                    sxgngxDZ11 = value;
                    this.OnPropertyChanged("竖向管井内管线电阻11");
                }

            }
        }
        #endregion
        private string jcyq = "/";
        [Display(Description = "主要检测仪器", GroupName = "06.综合信息", Order = 81)]
        public string 主要检测仪器
        {
            get { return jcyq; }
            set
            {
                if (value != jcyq)
                {
                    jcyq = value;
                    OnPropertyChanged("主要检测仪器");
                }
            }
        }
        private string jspd = "/";
        [Display(Description = "技术评定", GroupName = "06.综合信息", Order = 82)]
        public string 技术评定
        {
            get { return jspd; }
            set
            {
                if (value != jspd)
                {
                    jspd = value;
                    OnPropertyChanged("技术评定");
                }
            }
        }

        private string jcPeople = "/";
        [Display(Description = "检测员", GroupName = "06.综合信息", Order = 83)]
        public string 检测员
        {
            get { return jcPeople; }
            set
            {
                if (value != jcPeople)
                {
                    jcPeople = value;
                    OnPropertyChanged("检测员");
                }
            }
        }
        private string jhPeople = "/";
        [Display(Description = "校核人", GroupName = "06.综合信息", Order = 84)]
        public string 校核人
        {
            get { return jhPeople; }
            set
            {
                if (value != jhPeople)
                {
                    jhPeople = value;
                    OnPropertyChanged("校核人");
                }
            }
        }
        private string jsfzPeople = "/";
        [Display(Description = "技术负责人", GroupName = "06.综合信息", Order = 85)]
        public string 技术负责人
        {
            get { return jsfzPeople; }
            set
            {
                if (value != jsfzPeople)
                {
                    jsfzPeople = value;
                    OnPropertyChanged("技术负责人");
                }
            }
        }
        private string bh;
        [Display(Description = "编号，一般自动生成，不修改", GroupName = "09.其他信息", Order = 100)]
        public string 编号
        {
            get { return bh; }
            set
            {
                if (value != bh)
                {
                    bh = value;
                    this.OnPropertyChanged("编号");
                }

            }
        }
        
        [Browsable(false)]
        public string Error
        {
            get { return string.Empty; }
        }

        public string this[string columnName]
        {
            get
            {
                switch(columnName)
                {
                    
                    case "编号":
                        return this.编号 != null ? string.Empty : columnName + "不能为空";
                    case "StringProp":
                        //return this.StringProp != null && Regex.IsMatch(this.StringProp, @"^[0-9]+[\p{L}]*") ? string.Empty : @"Value should math the regex: ^[0-9]+[\p{L}]*";
                        break;
                    default:
                        return string.Empty;

                }
                return string.Empty;
            }
        }

        protected void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ValidateProperty(string propName, object value)
        {
            var result = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            Validator.TryValidateProperty(value, new ValidationContext(this, null, null) { MemberName = propName }, result);

            if (result.Count > 0)
            {
                throw new ValidationException(result[0].ErrorMessage);
            }
        }
    }
    
}
