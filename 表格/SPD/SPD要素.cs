using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace fangleinew
{
    public class SPD要素 : IDataErrorInfo, INotifyPropertyChanged
    {
        public class YWTypeConverter : TypeConverter
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
                return new StandardValuesCollection(new string[] { "有", "无", "/" });
            }
        }
        public class ZLTypeConverter : TypeConverter
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
                return new StandardValuesCollection(new string[] { "正常", "劣化", "/" });
            }
        }
        public class YXCDTypeConverter : TypeConverter
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
                return new StandardValuesCollection(new string[] { "＞50", "<50", "/" });
            }
        }
        public class GFTypeConverter : TypeConverter
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
                return new StandardValuesCollection(new string[] { "规范", "不规范", "/" });
            }
        }
        public class JMTypeConverter : TypeConverter
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
                return new StandardValuesCollection(new string[] { "4", "6", "10", "16", "25", "/" });
            }
        }
        #region 第一级
        private string bh1 = "/";
        [Display(Description = "第一级编号", GroupName = "01.第一级", Order = 1)]
        public string 第一级编号
        {
            get { return bh1; }
            set
            {
                if (value != bh1)
                {
                    bh1 = value;
                    OnPropertyChanged("第一级编号");
                }
            }
        }
        private string azwz1 = "/";
        [Display(Description = "第一级安装位置", GroupName = "01.第一级", Order = 2)]
        public string 第一级安装位置
        {
            get { return azwz1; }
            set
            {
                if (value != azwz1)
                {
                    azwz1 = value;
                    OnPropertyChanged("第一级安装位置");
                }
            }
        }
        private string cpxh1 = "/";
        [Display(Description = "第一级产品型号", GroupName = "01.第一级", Order = 3)]
        public string 第一级产品型号
        {
            get { return cpxh1; }
            set
            {
                if (value != cpxh1)
                {
                    cpxh1 = value;
                    OnPropertyChanged("第一级产品型号");
                }
            }
        }
        private string azsl1 = "/";
        [Display(Description = "第一级安装数量", GroupName = "01.第一级", Order = 4)]
        public string 第一级安装数量
        {
            get { return azsl1; }
            set
            {
                if (value != azsl1)
                {
                    azsl1 = value;
                    OnPropertyChanged("第一级安装数量");
                }
            }
        }
        private double ucbcz1 = -1;
        [Display(Description = "第一级Uc标称值，填写负数则生成报告时为/", GroupName = "01.第一级", Order = 5)]
        public double 第一级Uc标称值
        {
            get { return ucbcz1; }
            set
            {
                ucbcz1 = value;
                this.OnPropertyChanged("第一级Uc标称值");

            }
        }
        private double jcdl1 = -1;
        [Display(Description = "第一级检查电流，填写负数则生成报告时为/", GroupName = "01.第一级", Order = 6)]
        public double 第一级检查电流
        {
            get { return jcdl1; }
            set
            {
                jcdl1 = value;
                this.OnPropertyChanged("第一级检查电流");

            }
        }
        private double upjcz1 = -1;
        [Display(Description = "第一级Up检查值，填写负数则生成报告时为/", GroupName = "01.第一级", Order = 7)]
        public double 第一级Up检查值
        {
            get { return jcdl1; }
            set
            {
                jcdl1 = value;
                this.OnPropertyChanged("第一级Up检查值");

            }
        }

        private string tlqjc1 = "/";
        [Display(Description = "第一级脱离器检查", GroupName = "01.第一级", Order = 8)]
        [TypeConverter(typeof(YWTypeConverter))]
        public string 第一级脱离器检查
        {
            get { return tlqjc1; }
            set
            {
                if (value != tlqjc1)
                {
                    tlqjc1 = value;
                    OnPropertyChanged("第一级脱离器检查");
                }
            }
        }
        private double iiel11 = -1;
        [Display(Description = "第一级Iie测试值L1，填写负数则生成报告时为/", GroupName = "01.第一级", Order = 9)]
        public double 第一级Iie测试值L1
        {
            get { return iiel11; }
            set
            {
                iiel11 = value;
                this.OnPropertyChanged("第一级Iie测试值L1");

            }
        }
        private double iiel21 = -1;
        [Display(Description = "第一级Iie测试值L2，填写负数则生成报告时为/", GroupName = "01.第一级", Order = 10)]
        public double 第一级Iie测试值L2
        {
            get { return iiel21; }
            set
            {
                iiel21 = value;
                this.OnPropertyChanged("第一级Iie测试值L2");

            }
        }
        private double iiel31 = -1;
        [Display(Description = "第一级Iie测试值L3，填写负数则生成报告时为/", GroupName = "01.第一级", Order = 11)]
        public double 第一级Iie测试值L3
        {
            get { return iiel31; }
            set
            {
                iiel31 = value;
                this.OnPropertyChanged("第一级Iie测试值L3");

            }
        }
        private double iieN1 = -1;
        [Display(Description = "第一级Iie测试值N，填写负数则生成报告时为/", GroupName = "01.第一级", Order = 12)]
        public double 第一级Iie测试值N
        {
            get { return iieN1; }
            set
            {
                iieN1 = value;
                this.OnPropertyChanged("第一级Iie测试值N");

            }
        }
        private double uimal11 = -1;
        [Display(Description = "第一级Uima测试值L1，填写负数则生成报告时为/", GroupName = "01.第一级", Order = 13)]
        public double 第一级Uima测试值L1
        {
            get { return uimal11; }
            set
            {
                uimal11 = value;
                this.OnPropertyChanged("第一级Uima测试值L1");

            }
        }
        private double uimal21 = -1;
        [Display(Description = "第一级Uima测试值L2，填写负数则生成报告时为/", GroupName = "01.第一级", Order = 14)]
        public double 第一级Uima测试值L2
        {
            get { return uimal21; }
            set
            {
                uimal21 = value;
                this.OnPropertyChanged("第一级Uima测试值L2");

            }
        }
        private double uimal31 = -1;
        [Display(Description = "第一级Uima测试值L3，填写负数则生成报告时为/", GroupName = "01.第一级", Order = 15)]
        public double 第一级Uima测试值L3
        {
            get { return uimal31; }
            set
            {
                uimal31 = value;
                this.OnPropertyChanged("第一级Uima测试值L3");

            }
        }
        private double uimaN1 = -1;
        [Display(Description = "第一级Uima测试值N，填写负数则生成报告时为/", GroupName = "01.第一级", Order = 16)]
        public double 第一级Uima测试值N
        {
            get { return uimaN1; }
            set
            {
                uimaN1 = value;
                this.OnPropertyChanged("第一级Uima测试值N");

            }
        }
        private string ztzsq1 = "/";
        [Display(Description = "第一级状态指示器", GroupName = "01.第一级", Order = 17)]
        [TypeConverter(typeof(ZLTypeConverter))]
        public string 第一级状态指示器
        {
            get { return ztzsq1; }
            set
            {
                if (value != ztzsq1)
                {
                    ztzsq1 = value;
                    OnPropertyChanged("第一级状态指示器");
                }
            }
        }
        private string yxcd1 = "/";
        [Display(Description = "第一级引线长度", GroupName = "01.第一级", Order = 18)]
        [TypeConverter(typeof(YXCDTypeConverter))]
        public string 第一级引线长度
        {
            get { return yxcd1; }
            set
            {
                if (value != yxcd1)
                {
                    yxcd1 = value;
                    OnPropertyChanged("第一级引线长度");
                }
            }
        }
        private string lxsb1 = "/";
        [Display(Description = "第一级连线色标", GroupName = "01.第一级", Order = 19)]
        [TypeConverter(typeof(GFTypeConverter))]
        public string 第一级连线色标
        {
            get { return lxsb1; }
            set
            {
                if (value != lxsb1)
                {
                    lxsb1 = value;
                    OnPropertyChanged("第一级连线色标");
                }
            }
        }
        private string lxjm1 = "/";
        [Display(Description = "第一级连线截面", GroupName = "01.第一级", Order = 20)]
        [TypeConverter(typeof(JMTypeConverter))]
        public string 第一级连线截面
        {
            get { return lxjm1; }
            set
            {
                if (value != lxjm1)
                {
                    lxjm1 = value;
                    OnPropertyChanged("第一级连线截面");
                }
            }
        }
        private double gddzN1 = -1;
        [Display(Description = "第一级过渡电阻，填写负数则生成报告时为/", GroupName = "01.第一级", Order = 21)]
        public double 第一级过渡电阻
        {
            get { return gddzN1; }
            set
            {
                gddzN1 = value;
                this.OnPropertyChanged("第一级过渡电阻");

            }
        }
        private string glbh1 = "/";
        [Display(Description = "第一级过流保护", GroupName = "01.第一级", Order = 22)]
        [TypeConverter(typeof(YWTypeConverter))]
        public string 第一级过流保护
        {
            get { return glbh1; }
            set
            {
                if (value != glbh1)
                {
                    glbh1 = value;
                    OnPropertyChanged("第一级过流保护");
                }
            }
        }
        #endregion

        #region 第二级
        private string bh2 = "/";
        [Display(Description = "第二级编号", GroupName = "02.第二级", Order = 23)]
        public string 第二级编号
        {
            get { return bh2; }
            set
            {
                if (value != bh2)
                {
                    bh2 = value;
                    OnPropertyChanged("第二级编号");
                }
            }
        }
        private string azwz2 = "/";
        [Display(Description = "第二级安装位置", GroupName = "02.第二级", Order = 24)]
        public string 第二级安装位置
        {
            get { return azwz2; }
            set
            {
                if (value != azwz2)
                {
                    azwz2 = value;
                    OnPropertyChanged("第二级安装位置");
                }
            }
        }
        private string cpxh2 = "/";
        [Display(Description = "第二级产品型号", GroupName = "02.第二级", Order = 25)]
        public string 第二级产品型号
        {
            get { return cpxh2; }
            set
            {
                if (value != cpxh2)
                {
                    cpxh2 = value;
                    OnPropertyChanged("第二级产品型号");
                }
            }
        }
        private string azsl2 = "/";
        [Display(Description = "第二级安装数量", GroupName = "02.第二级", Order = 26)]
        public string 第二级安装数量
        {
            get { return azsl2; }
            set
            {
                if (value != azsl2)
                {
                    azsl2 = value;
                    OnPropertyChanged("第二级安装数量");
                }
            }
        }
        private double ucbcz2 = -1;
        [Display(Description = "第二级Uc标称值，填写负数则生成报告时为/", GroupName = "02.第二级", Order = 27)]
        public double 第二级Uc标称值
        {
            get { return ucbcz2; }
            set
            {
                ucbcz2 = value;
                this.OnPropertyChanged("第二级Uc标称值");

            }
        }
        private double jcdl2 = -1;
        [Display(Description = "第二级检查电流，填写负数则生成报告时为/", GroupName = "02.第二级", Order = 28)]
        public double 第二级检查电流
        {
            get { return jcdl2; }
            set
            {
                jcdl2 = value;
                this.OnPropertyChanged("第二级检查电流");

            }
        }
        private double upjcz2 = -1;
        [Display(Description = "第二级Up检查值，填写负数则生成报告时为/", GroupName = "02.第二级", Order = 29)]
        public double 第二级Up检查值
        {
            get { return upjcz2; }
            set
            {
                upjcz2 = value;
                this.OnPropertyChanged("第二级Up检查值");

            }
        }

        private string tlqjc2 = "/";
        [Display(Description = "第二级脱离器检查", GroupName = "02.第二级", Order = 30)]
        [TypeConverter(typeof(YWTypeConverter))]
        public string 第二级脱离器检查
        {
            get { return tlqjc2; }
            set
            {
                if (value != tlqjc2)
                {
                    tlqjc2 = value;
                    OnPropertyChanged("第二级脱离器检查");
                }
            }
        }
        private double iiel12 = -1;
        [Display(Description = "第二级Iie测试值L1，填写负数则生成报告时为/", GroupName = "02.第二级", Order = 31)]
        public double 第二级Iie测试值L1
        {
            get { return iiel12; }
            set
            {
                iiel12 = value;
                this.OnPropertyChanged("第二级Iie测试值L1");

            }
        }
        private double iiel22 = -1;
        [Display(Description = "第二级Iie测试值L2，填写负数则生成报告时为/", GroupName = "02.第二级", Order = 32)]
        public double 第二级Iie测试值L2
        {
            get { return iiel22; }
            set
            {
                iiel22 = value;
                this.OnPropertyChanged("第二级Iie测试值L2");

            }
        }
        private double iiel32 = -1;
        [Display(Description = "第二级Iie测试值L3，填写负数则生成报告时为/", GroupName = "02.第二级", Order = 33)]
        public double 第二级Iie测试值L3
        {
            get { return iiel32; }
            set
            {
                iiel32 = value;
                this.OnPropertyChanged("第二级Iie测试值L3");

            }
        }
        private double iieN2 = -1;
        [Display(Description = "第二级Iie测试值N，填写负数则生成报告时为/", GroupName = "02.第二级", Order = 34)]
        public double 第二级Iie测试值N
        {
            get { return iieN2; }
            set
            {
                iieN2 = value;
                this.OnPropertyChanged("第二级Iie测试值N");

            }
        }
        private double uimal12 = -1;
        [Display(Description = "第二级Uima测试值L1，填写负数则生成报告时为/", GroupName = "02.第二级", Order = 35)]
        public double 第二级Uima测试值L1
        {
            get { return uimal12; }
            set
            {
                uimal12 = value;
                this.OnPropertyChanged("第二级Uima测试值L1");

            }
        }
        private double uimal22 = -1;
        [Display(Description = "第二级Uima测试值L2，填写负数则生成报告时为/", GroupName = "02.第二级", Order = 36)]
        public double 第二级Uima测试值L2
        {
            get { return uimal22; }
            set
            {
                uimal22 = value;
                this.OnPropertyChanged("第二级Uima测试值L2");

            }
        }
        private double uimal32 = -1;
        [Display(Description = "第二级Uima测试值L3，填写负数则生成报告时为/", GroupName = "02.第二级", Order = 37)]
        public double 第二级Uima测试值L3
        {
            get { return uimal32; }
            set
            {
                uimal32 = value;
                this.OnPropertyChanged("第二级Uima测试值L3");

            }
        }
        private double uimaN2 = -1;
        [Display(Description = "第二级Uima测试值N，填写负数则生成报告时为/", GroupName = "02.第二级", Order = 38)]
        public double 第二级Uima测试值N
        {
            get { return uimaN2; }
            set
            {
                uimaN2 = value;
                this.OnPropertyChanged("第二级Uima测试值N");

            }
        }
        private string ztzsq2 = "/";
        [Display(Description = "第二级状态指示器", GroupName = "02.第二级", Order = 39)]
        [TypeConverter(typeof(ZLTypeConverter))]
        public string 第二级状态指示器
        {
            get { return ztzsq2; }
            set
            {
                if (value != ztzsq2)
                {
                    ztzsq2 = value;
                    OnPropertyChanged("第二级状态指示器");
                }
            }
        }
        private string yxcd2 = "/";
        [Display(Description = "第二级引线长度", GroupName = "02.第二级", Order = 40)]
        [TypeConverter(typeof(YXCDTypeConverter))]
        public string 第二级引线长度
        {
            get { return yxcd2; }
            set
            {
                if (value != yxcd2)
                {
                    yxcd2 = value;
                    OnPropertyChanged("第二级引线长度");
                }
            }
        }
        private string lxsb2 = "/";
        [Display(Description = "第二级连线色标", GroupName = "02.第二级", Order = 41)]
        [TypeConverter(typeof(GFTypeConverter))]
        public string 第二级连线色标
        {
            get { return lxsb2; }
            set
            {
                if (value != lxsb2)
                {
                    lxsb2 = value;
                    OnPropertyChanged("第二级连线色标");
                }
            }
        }
        private string lxjm2 = "/";
        [Display(Description = "第二级连线截面", GroupName = "02.第二级", Order = 42)]
        [TypeConverter(typeof(JMTypeConverter))]
        public string 第二级连线截面
        {
            get { return lxjm2; }
            set
            {
                if (value != lxjm2)
                {
                    lxjm2 = value;
                    OnPropertyChanged("第二级连线截面");
                }
            }
        }
        private double gddzN2 = -1;
        [Display(Description = "第二级过渡电阻，填写负数则生成报告时为/", GroupName = "02.第二级", Order = 43)]
        public double 第二级过渡电阻
        {
            get { return gddzN2; }
            set
            {
                gddzN2 = value;
                this.OnPropertyChanged("第二级过渡电阻");

            }
        }
        private string glbh2 = "/";
        [Display(Description = "第二级过流保护", GroupName = "02.第二级", Order = 44)]
        [TypeConverter(typeof(YWTypeConverter))]
        public string 第二级过流保护
        {
            get { return glbh2; }
            set
            {
                if (value != glbh2)
                {
                    glbh2 = value;
                    OnPropertyChanged("第二级过流保护");
                }
            }
        }
        #endregion

        #region 第三级
        private string bh3 = "/";
        [Display(Description = "第三级编号", GroupName = "03.第三级", Order = 45)]
        public string 第三级编号
        {
            get { return bh3; }
            set
            {
                if (value != bh3)
                {
                    bh3 = value;
                    OnPropertyChanged("第三级编号");
                }
            }
        }
        private string azwz3 = "/";
        [Display(Description = "第三级安装位置", GroupName = "03.第三级", Order = 46)]
        public string 第三级安装位置
        {
            get { return azwz3; }
            set
            {
                if (value != azwz3)
                {
                    azwz3 = value;
                    OnPropertyChanged("第三级安装位置");
                }
            }
        }
        private string cpxh3 = "/";
        [Display(Description = "第三级产品型号", GroupName = "03.第三级", Order = 47)]
        public string 第三级产品型号
        {
            get { return cpxh3; }
            set
            {
                if (value != cpxh3)
                {
                    cpxh3 = value;
                    OnPropertyChanged("第三级产品型号");
                }
            }
        }
        private string azsl3 = "/";
        [Display(Description = "第三级安装数量", GroupName = "03.第三级", Order = 48)]
        public string 第三级安装数量
        {
            get { return azsl3; }
            set
            {
                if (value != azsl3)
                {
                    azsl3 = value;
                    OnPropertyChanged("第三级安装数量");
                }
            }
        }
        private double ucbcz3 = -1;
        [Display(Description = "第三级Uc标称值，填写负数则生成报告时为/", GroupName = "03.第三级", Order = 49)]
        public double 第三级Uc标称值
        {
            get { return ucbcz3; }
            set
            {
                ucbcz3 = value;
                this.OnPropertyChanged("第三级Uc标称值");

            }
        }
        private double jcdl3 = -1;
        [Display(Description = "第三级检查电流，填写负数则生成报告时为/", GroupName = "03.第三级", Order = 50)]
        public double 第三级检查电流
        {
            get { return jcdl3; }
            set
            {
                jcdl3 = value;
                this.OnPropertyChanged("第三级检查电流");

            }
        }
        private double upjcz3 = -1;
        [Display(Description = "第三级Up检查值，填写负数则生成报告时为/", GroupName = "03.第三级", Order = 51)]
        public double 第三级Up检查值
        {
            get { return upjcz3; }
            set
            {
                upjcz3 = value;
                this.OnPropertyChanged("第三级Up检查值");

            }
        }

        private string tlqjc3 = "/";
        [Display(Description = "第三级脱离器检查", GroupName = "03.第三级", Order = 52)]
        [TypeConverter(typeof(YWTypeConverter))]
        public string 第三级脱离器检查
        {
            get { return tlqjc3; }
            set
            {
                if (value != tlqjc3)
                {
                    tlqjc3 = value;
                    OnPropertyChanged("第三级脱离器检查");
                }
            }
        }
        private double iiel13 = -1;
        [Display(Description = "第三级Iie测试值L1，填写负数则生成报告时为/", GroupName = "03.第三级", Order = 53)]
        public double 第三级Iie测试值L1
        {
            get { return iiel13; }
            set
            {
                iiel13 = value;
                this.OnPropertyChanged("第三级Iie测试值L1");

            }
        }
        private double iiel23 = -1;
        [Display(Description = "第三级Iie测试值L2，填写负数则生成报告时为/", GroupName = "03.第三级", Order =54)]
        public double 第三级Iie测试值L2
        {
            get { return iiel23; }
            set
            {
                iiel23 = value;
                this.OnPropertyChanged("第三级Iie测试值L2");

            }
        }
        private double iiel33 = -1;
        [Display(Description = "第三级Iie测试值L3，填写负数则生成报告时为/", GroupName = "03.第三级", Order = 55)]
        public double 第三级Iie测试值L3
        {
            get { return iiel33; }
            set
            {
                iiel33 = value;
                this.OnPropertyChanged("第三级Iie测试值L3");

            }
        }
        private double iieN3 = -1;
        [Display(Description = "第三级Iie测试值N，填写负数则生成报告时为/", GroupName = "03.第三级", Order = 56)]
        public double 第三级Iie测试值N
        {
            get { return iieN3; }
            set
            {
                iieN3 = value;
                this.OnPropertyChanged("第三级Iie测试值N");

            }
        }
        private double uimal13 = -1;
        [Display(Description = "第三级Uima测试值L1，填写负数则生成报告时为/", GroupName = "03.第三级", Order = 57)]
        public double 第三级Uima测试值L1
        {
            get { return uimal13; }
            set
            {
                uimal13 = value;
                this.OnPropertyChanged("第三级Uima测试值L1");

            }
        }
        private double uimal23 = -1;
        [Display(Description = "第三级Uima测试值L2，填写负数则生成报告时为/", GroupName = "03.第三级", Order = 58)]
        public double 第三级Uima测试值L2
        {
            get { return uimal23; }
            set
            {
                uimal23 = value;
                this.OnPropertyChanged("第三级Uima测试值L2");

            }
        }
        private double uimal33 = -1;
        [Display(Description = "第三级Uima测试值L3，填写负数则生成报告时为/", GroupName = "03.第三级", Order = 59)]
        public double 第三级Uima测试值L3
        {
            get { return uimal33; }
            set
            {
                uimal33 = value;
                this.OnPropertyChanged("第三级Uima测试值L3");

            }
        }
        private double uimaN3 = -1;
        [Display(Description = "第三级Uima测试值N，填写负数则生成报告时为/", GroupName = "03.第三级", Order = 60)]
        public double 第三级Uima测试值N
        {
            get { return uimaN3; }
            set
            {
                uimaN3 = value;
                this.OnPropertyChanged("第三级Uima测试值N");

            }
        }
        private string ztzsq3 = "/";
        [Display(Description = "第三级状态指示器", GroupName = "03.第三级", Order = 61)]
        [TypeConverter(typeof(ZLTypeConverter))]
        public string 第三级状态指示器
        {
            get { return ztzsq3; }
            set
            {
                if (value != ztzsq3)
                {
                    ztzsq3 = value;
                    OnPropertyChanged("第三级状态指示器");
                }
            }
        }
        private string yxcd3 = "/";
        [Display(Description = "第三级引线长度", GroupName = "03.第三级", Order = 62)]
        [TypeConverter(typeof(YXCDTypeConverter))]
        public string 第三级引线长度
        {
            get { return yxcd3; }
            set
            {
                if (value != yxcd3)
                {
                    yxcd3 = value;
                    OnPropertyChanged("第三级引线长度");
                }
            }
        }
        private string lxsb3 = "/";
        [Display(Description = "第三级连线色标", GroupName = "03.第三级", Order = 63)]
        [TypeConverter(typeof(GFTypeConverter))]
        public string 第三级连线色标
        {
            get { return lxsb3; }
            set
            {
                if (value != lxsb3)
                {
                    lxsb3 = value;
                    OnPropertyChanged("第三级连线色标");
                }
            }
        }
        private string lxjm3 = "/";
        [Display(Description = "第三级连线截面", GroupName = "03.第三级", Order = 64)]
        [TypeConverter(typeof(JMTypeConverter))]
        public string 第三级连线截面
        {
            get { return lxjm3; }
            set
            {
                if (value != lxjm3)
                {
                    lxjm3 = value;
                    OnPropertyChanged("第三级连线截面");
                }
            }
        }
        private double gddzN3 = -1;
        [Display(Description = "第三级过渡电阻，填写负数则生成报告时为/", GroupName = "03.第三级", Order = 65)]
        public double 第三级过渡电阻
        {
            get { return gddzN3; }
            set
            {
                gddzN3 = value;
                this.OnPropertyChanged("第三级过渡电阻");

            }
        }
        private string glbh3 = "/";
        [Display(Description = "第三级过流保护", GroupName = "03.第三级", Order = 66)]
        [TypeConverter(typeof(YWTypeConverter))]
        public string 第三级过流保护
        {
            get { return glbh3; }
            set
            {
                if (value != glbh3)
                {
                    glbh3 = value;
                    OnPropertyChanged("第三级过流保护");
                }
            }
        }
        #endregion
        private string jspd = "/";
        [Display(Description = "SPD检测综评", GroupName = "04.综合信息", Order = 67)]
        public string SPD检测综评
        {
            get { return jspd; }
            set
            {
                if (value != jspd)
                {
                    jspd = value;
                    OnPropertyChanged("SPD检测综评");
                }
            }
        }

        private string jcPeople = "/";
        [Display(Description = "检测员", GroupName = "04.综合信息", Order = 68)]
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
        [Display(Description = "校核人", GroupName = "04.综合信息", Order = 69)]
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
        [Display(Description = "技术负责人", GroupName = "04.综合信息", Order = 70)]
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
        private DateTime date = DateTime.Now;
        [Display(Description = "日期", GroupName = "04.综合信息", Order = 71)]
        public DateTime 日期
        {
            get { return date; }
            set
            {
                if (value != date)
                {
                    date = value;
                    OnPropertyChanged("日期");
                }
            }
        }
        private string bh;
        [Display(Description = "编号，一般自动生成，不修改", GroupName = "04.综合信息", Order = 100)]
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
