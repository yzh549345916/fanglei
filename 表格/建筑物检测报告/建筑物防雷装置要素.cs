using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace fangleinew
{
    public class 建筑物防雷装置要素 : IDataErrorInfo, INotifyPropertyChanged
    {
        private string xmName="";
        [Display(Description = "项目名称", GroupName = "01.基本信息",Order =1)]
        public string 项目名称
        {
            get { return xmName; }
            set
            {
                if (value != xmName)
                {
                    xmName = value;
                    OnPropertyChanged("项目名称");
                }
                
            }
        }
        private string address = "";
        [Display(Description = "地址", GroupName = "01.基本信息", Order = 2)]
        public string 地址
        {
            get { return address; }
            set
            {
                if(value!= address)
                {
                    address = value;
                    this.OnPropertyChanged("地址");
                }
                
            }
        }
        private string lxPeople = "";
        [Display(Description = "联系人", GroupName = "01.基本信息", Order = 3)]
        public string 联系人
        {
            get { return lxPeople; }
            set
            {
                if (value != lxPeople)
                {
                    lxPeople = value;
                    this.OnPropertyChanged("联系人");
                }
                
            }
        }
        private string phoneNum = "";
        [Display(Description = "电话", GroupName = "01.基本信息", Order = 4)]
        public string 电话
        {
            get { return phoneNum; }
            set
            {
                if (value != phoneNum)
                {
                    phoneNum = value;
                    this.OnPropertyChanged("电话");
                }
                
            }
        }

        public enum weatherEnu
        {
            晴,
            阴,
            多云,
            雷阵雨,
            小雨,
            中雨,
            大雨,
            暴雨,
            小雪,
            中雪,
            大雪,
            暴雪,
            扬沙,
            沙尘暴

        }

        private weatherEnu myWeather=weatherEnu.晴;
        [Display(Description = "天气", GroupName = "01.基本信息", Order = 5)]
        public weatherEnu 天气
        {
            get { return myWeather; }
            set
            {
                if (value != myWeather)
                {
                    myWeather = value;
                    this.OnPropertyChanged("天气");
                }
                
            }
        }

        
        private string yjbz = "";
        [Display(Description = "依据标准", GroupName = "01.基本信息", Order = 6)]
        public string 依据标准
        {
            get { return yjbz; }
            set
            {
                if (value != yjbz)
                {
                    yjbz = value;
                    this.OnPropertyChanged("依据标准");
                }
                
            }
        }
        private string jcPeople = "";
        [Display(Description = "检测员", GroupName = "01.基本信息", Order = 7)]
        public string 检测员
        {
            get { return jcPeople; }
            set
            {
                if (value != jcPeople)
                {
                    jcPeople = value;
                    this.OnPropertyChanged("检测员");
                }

            }
        }
        private string jhPeople = "";
        [Display(Description = "校核人", GroupName = "01.基本信息", Order = 8)]
        public string 校核人
        {
            get { return jhPeople; }
            set
            {
                if (value != jhPeople)
                {
                    jhPeople = value;
                    this.OnPropertyChanged("校核人");
                }

            }
        }
        private string jsPeople = "";
        [Display(Description = "技术负责人", GroupName = "01.基本信息", Order = 9)]
        public string 技术负责人
        {
            get { return jsPeople; }
            set
            {
                if (value != jsPeople)
                {
                    jsPeople = value;
                    this.OnPropertyChanged("技术负责人");
                }

            }
        }
        private double high;
        [Display(Description = "高度，填写负数则生成报告时为/", GroupName = "02.建筑物",Order =9)]
        public double 高度
        {
            get { return high; }
            set
            {
                high = value;
                this.OnPropertyChanged("高度");

            }
        }
        private double mianji1;
        [Display(Description = "面积1，填写负数则生成报告时为/", GroupName = "02.建筑物", Order = 10)]
        public double 面积1
        {
            get { return mianji1; }
            set
            {
                mianji1 = value;
                this.OnPropertyChanged("面积1");

            }
        }
        private double mianji2;
        [Display(Description = "面积2，填写负数则生成报告时为/", GroupName = "02.建筑物", Order = 11)]
        public double 面积2
        {
            get { return mianji2; }
            set
            {
                mianji2 = value;
                this.OnPropertyChanged("面积2");
            }
        }
        private int cengshu1;
        [Display(Description = "地上层数，填写负数则生成报告时为/", GroupName = "02.建筑物", Order = 12)]
        public int 地上层数
        {
            get { return cengshu1; }
            set
            {
                if (value != cengshu1)
                {
                    cengshu1 = value;
                    this.OnPropertyChanged("地上层数");
                }
               
            }
        }
        private int cengshu2;
        [Display(Description = "地下层数，填写负数则生成报告时为/", GroupName = "02.建筑物", Order = 13)]
        public int 地下层数
        {
            get { return cengshu2; }
            set
            {
                if (value != cengshu2)
                {
                    cengshu2 = value;
                    this.OnPropertyChanged("地下层数");
                }
                
            }
        }
        public enum yongtuEnum
        {
            住宅,
            商务,
            办公,
            教学,
            生产,
            其他

        }

        private yongtuEnum yongtu;
        [Display(Description = "主要用途", GroupName = "02.建筑物", Order = 14)]
        public yongtuEnum 主要用途
        {
            get { return yongtu; }
            set
            {
                if (value != yongtu)
                {
                    yongtu = value;
                    this.OnPropertyChanged("主要用途");
                }
               
            }
        }
        public enum fangleiLBEnum
        {
            一类,
            二类,
            三类

        }



        private fangleiLBEnum fangleiLB;
        [Display(Description = "请选择防雷类别", GroupName = "02.建筑物", Order = 15)]
        public fangleiLBEnum 防雷类别
        {
            get { return fangleiLB; }
            set
            {
                if (value != fangleiLB)
                {
                    fangleiLB = value;
                    this.OnPropertyChanged("防雷类别");
                }
              
            }
        }
        public class xsTypeConverter : TypeConverter
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
                return new StandardValuesCollection(new string[] { "无锈蚀", "锈蚀", "严重锈蚀", "/" });
            }
        }
        public class BHTypeConverter : TypeConverter
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
                return new StandardValuesCollection(new string[] { "够", "不够", "/" });
            }
        }

        private string clgg1 = "/";
        [Display(Description = "接闪杆材料规格", GroupName = "03.接闪装置", Order = 16,ShortName = "接闪杆材料规格")]
        public string Clgg1
        {
            get { return clgg1; }
            set
            {
                if (value != clgg1)
                {
                    clgg1 = value;
                    this.OnPropertyChanged("Clgg1");
                }
               
            }
        }
        
        private string xsLB1 = "/";
        [TypeConverter(typeof(xsTypeConverter))]
        [Display(Description = "接闪杆锈蚀情况", GroupName = "03.接闪装置", Order = 17, ShortName = "接闪杆锈蚀情况")]
        public string XsLB1
        {
            get { return xsLB1; }
            set
            {
                if (value != xsLB1)
                {
                    xsLB1 = value;
                    this.OnPropertyChanged("XsLB1");
                }
            }
        }
        private string bhLB1 = "/";
        [TypeConverter(typeof(BHTypeConverter))]
        [Display(Description = "接闪杆保护范围", GroupName = "03.接闪装置", Order = 18, ShortName = "接闪杆保护范围")]
        public string BhLB1
        {
            get { return bhLB1; }
            set
            {
                if (value != bhLB1)
                {
                    bhLB1 = value;
                    this.OnPropertyChanged("BhLB1");
                }
               
            }
        }
        private double jdzz1=-0.1;
        [Display(Description = "接闪杆接地电阻，填写负数则生成报告时为/", GroupName = "03.接闪装置", Order = 19, ShortName = "接闪杆接地电阻")]
        public double Jdzz1
        {
            get { return jdzz1; }
            set
            {
                jdzz1 = value;
                this.OnPropertyChanged("Jdzz1");

            }
        }
        private string dxpj1 = "/";
        [Display(Description = "接闪杆单项评价", GroupName = "03.接闪装置", Order = 20, ShortName = "接闪杆单项评价")]
        public string Dxpj1
        {
            get { return dxpj1; }
            set
            {
                if (value != dxpj1)
                {
                    dxpj1 = value;
                    this.OnPropertyChanged("Dxpj1");
                }
                
            }
        }
        private string jsdclgg = "/";
        [Display(Description = "接闪带材料规格", GroupName = "03.接闪装置", Order = 21, ShortName = "接闪带材料规格")]
        public string Jsdclgg
        {
            get { return jsdclgg; }
            set
            {
                if (value != jsdclgg)
                {
                    jsdclgg = value;
                    this.OnPropertyChanged("Jsdclgg");
                }
                
            }
        }

        private string jsdxs = "/";
        [TypeConverter(typeof(xsTypeConverter))]
        [Display(Description = "接闪带锈蚀情况", GroupName = "03.接闪装置", Order = 22, ShortName = "接闪带锈蚀情况")]
        public string Jsdxs
        {
            get { return jsdxs; }
            set
            {
                if (value != jsdxs)
                {
                    jsdxs = value;
                    this.OnPropertyChanged("Jsdxs");
                }
               
            }
        }
        private string jsdbhfw = "/";
        [TypeConverter(typeof(BHTypeConverter))]
        [Display(Description = "接闪带保护范围", GroupName = "03.接闪装置", Order = 23, ShortName = "接闪带保护范围")]
        public string Jsdbhfw
        {
            get { return jsdbhfw; }
            set
            {
                if (value != jsdbhfw)
                {
                    jsdbhfw = value;
                    this.OnPropertyChanged("Jsdbhfw");
                }
                
            }
        }
        private double jsdjddz=-0.1;
        [Display(Description = "接闪带接地电阻，填写负数则生成报告时为/", GroupName = "03.接闪装置", Order = 24, ShortName = "接闪带接地电阻")]
        public double Jsdjddz
        {
            get { return jsdjddz; }
            set
            {
                jsdjddz = value;
                this.OnPropertyChanged("Jsdjddz");
            }
        }
        private string jsddxpj = "/";
        [Display(Description = "接闪带单项评价", GroupName = "03.接闪装置", Order = 25, ShortName = "接闪带单项评价")]
        public string Jsddxpj
        {
            get { return jsddxpj; }
            set
            {
                if (value != jsddxpj)
                {
                    jsddxpj = value;
                    this.OnPropertyChanged("Jsddxpj");
                }
                
            }
        }
        private string jswlclgg = "/";
        [Display(Description = "接闪网络材料规格", GroupName = "03.接闪装置", Order = 26, ShortName = "接闪网络材料规格")]
        public string Jswlclgg
        {
            get { return jswlclgg; }
            set
            {
                if (value != jswlclgg)
                {
                    jswlclgg = value;
                    this.OnPropertyChanged("Jswlclgg");
                }
               
            }
        }

        private string jswlxs = "/";
        [TypeConverter(typeof(xsTypeConverter))]
        [Display(Description = "接闪网络锈蚀情况", GroupName = "03.接闪装置", Order = 27, ShortName = "接闪网络锈蚀情况")]
        public string Jswlxs
        {
            get { return jswlxs; }
            set
            {
                if (value != jswlxs)
                {
                    jswlxs = value;
                    this.OnPropertyChanged("Jswlxs");
                }
                
            }
        }
        private string jswlbhfw = "/";
        [TypeConverter(typeof(BHTypeConverter))]
        [Display(Description = "接闪网络保护范围", GroupName = "03.接闪装置", Order = 28, ShortName = "接闪网络保护范围")]
        public string Jswlbhfw
        {
            get { return jswlbhfw; }
            set
            {
                if (value != jswlbhfw)
                {
                    jswlbhfw = value;
                    this.OnPropertyChanged("Jswlbhfw");
                }
               
            }
        }
        private double jswljddz=-0.1;
        [Display(Description = "接闪网络接地电阻，填写负数则生成报告时为/", GroupName = "03.接闪装置", Order = 29, ShortName = "接闪网络接地电阻")]
        public double Jswljddz
        {
            get { return jswljddz; }
            set
            {

                jswljddz = value;
                this.OnPropertyChanged("Jswljddz");
            }
        }
        private string jswldxpj = "/";
        [Display(Description = "接闪网络单项评价", GroupName = "03.接闪装置", Order = 30, ShortName = "接闪网络单项评价")]
        public string Jswldxpj
        {
            get { return jswldxpj; }
            set
            {
                if (value != jswldxpj)
                {
                    jswldxpj = value;
                    this.OnPropertyChanged("Jswldxpj");
                }
                
            }
        }

        private double jsjg1=-0.1;
        [Display(Description = "金属结构间等电位连接，填写负数则生成报告时为/", GroupName = "04.大型金属构件", Order = 31, ShortName = "金属结构间等电位连接")]
        public double jsjgDDW
        {
            get { return jsjg1; }
            set
            {
                jsjg1 = value;
                this.OnPropertyChanged("jsjgDDW");
            }
        }
        private double jsjg2=-0.1;
        [Display(Description = "金属结构与接闪带连接，填写负数则生成报告时为/", GroupName = "04.大型金属构件", Order = 32, ShortName = "金属结构与接闪带连接")]
        public double jsjgJSD
        {
            get { return jsjg2; }
            set
            {
                jsjg2 = value;
                this.OnPropertyChanged("jsjgjsdDDW");
            }
        }
        public class LJCLTypeConverter : TypeConverter
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
                return new StandardValuesCollection(new string[] { "4*40mm扁钢", "Φ10mm圆钢", "/" });
            }
        }
        private string ljcl = "/";
        [Display(Description = "连接用材料", GroupName = "04.大型金属构件", Order = 33, ShortName = "连接用材料")]
        [TypeConverter(typeof(LJCLTypeConverter))]
        public string Ljcl
        {
            get { return ljcl; }
            set
            {
                if (value != ljcl)
                {
                    ljcl = value;
                    OnPropertyChanged("Ljcl");
                }
            }
        }
        private string jsdxpj = "/";
        [Display(Description = "大型金属构件单项评价", GroupName = "04.大型金属构件", Order = 34, ShortName = "大型金属构件单项评价")]
      
        public string Jsdxpj
        {
            get { return jsdxpj; }
            set
            {
                if (value != jsdxpj)
                {
                    jsdxpj = value;
                    this.OnPropertyChanged("Jsdxpj");
                }
            }
        }
        public class FSFSTypeConverter : TypeConverter
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
                return new StandardValuesCollection(new string[] { "架空敷设", "沿屋面敷设","沿女儿墙敷设", "/" });
            }
        }
        private string dyfsfs = "/";
        [Display(Description = "敷设方式", GroupName = "05.电源、信号线路", Order = 35, ShortName = "敷设方式")]
        [TypeConverter(typeof(FSFSTypeConverter))]
        public string Dyfsfs
        {
            get { return dyfsfs; }
            set
            {
                if (value != dyfsfs)
                {
                    dyfsfs = value;
                    OnPropertyChanged("Dyfsfs");
                }
            }
        }
        public class PBBHCSTypeConverter : TypeConverter
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
                return new StandardValuesCollection(new string[] { "穿金属管", "金属线槽", "未采取措施", "/" });
            }
        }
        private string pbbhcs = "/";
        [Display(Description = "屏蔽保护措施", GroupName = "05.电源、信号线路", Order = 36, ShortName = "屏蔽保护措施")]
        [TypeConverter(typeof(PBBHCSTypeConverter))]
        public string Pbbhcs
        {
            get { return pbbhcs; }
            set
            {
                if (value != pbbhcs)
                {
                    pbbhcs = value;
                    OnPropertyChanged("Pbbhcs");
                }
            }
        }
        public class JDTypeConverter : TypeConverter
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
                return new StandardValuesCollection(new string[] { "接地", "未接地", "/" });
            }
        }
        private string pbbhcjd = "/";
        [Display(Description = "屏蔽保护层接地", GroupName = "05.电源、信号线路", Order = 37, ShortName = "屏蔽保护层接地")]
        [TypeConverter(typeof(JDTypeConverter))]
        public string Pbbhcjd
        {
            get { return pbbhcjd; }
            set
            {
                if (value != pbbhcjd)
                {
                    pbbhcjd = value;
                    OnPropertyChanged("Pbbhcjd");
                }
            }
        }
        private string dyxldxpj = "/";
        [Display(Description = "电源、信号线路单项评价", GroupName = "05.电源、信号线路", Order = 38, ShortName = "电源、信号线路单项评价")]

        public string Dyxldxpj
        {
            get { return dyxldxpj; }
            set
            {
                if (value != dyxldxpj)
                {
                    dyxldxpj = value;
                    this.OnPropertyChanged("Dyxldxpj");
                }
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
        private string wmfsName1="/";
        [Display(Description = "屋面附属设备名称1", GroupName = "06.屋面附属设备", Order = 39, ShortName = "屋面附属设备名称1")]

        public string WmfsName1
        {
            get { return wmfsName1; }
            set
            {
                if (value != wmfsName1)
                {
                    wmfsName1 = value;
                    this.OnPropertyChanged("WmfsName1");
                }
            }
        }
        private string fzjl1="/";
        [Display(Description = "防直击雷1", GroupName = "06.屋面附属设备", Order = 40, ShortName = "防直击雷1")]
        [TypeConverter(typeof(FHTypeConverter))]
        public string Fzjl1
        {
            get { return fzjl1; }
            set
            {
                if (value != fzjl1)
                {
                    fzjl1 = value;
                    OnPropertyChanged("Fzjl1");
                }
            }
        }
        private string fsdgy1 = "/";
        [Display(Description = "防闪电感应1", GroupName = "06.屋面附属设备", Order = 41, ShortName = "防闪电感应1")]
        [TypeConverter(typeof(FHTypeConverter))]
        public string Fsdgy1
        {
            get { return fsdgy1; }
            set
            {
                if (value != fsdgy1)
                {
                    fsdgy1 = value;
                    OnPropertyChanged("Fsdgy1");
                }
            }
        }
        private string wmfsdxpj1 = "/";
        [Display(Description = "屋面附属设备单项评价1", GroupName = "06.屋面附属设备", Order =42
            , ShortName = "屋面附属设备单项评价1")]

        public string Wmfsdxpj1
        {
            get { return wmfsdxpj1; }
            set
            {
                if (value != wmfsdxpj1)
                {
                    wmfsdxpj1 = value;
                    this.OnPropertyChanged("Wmfsdxpj1");
                }
            }
        }
        private string wmfsName2 = "/";
        [Display(Description = "屋面附属设备名称2", GroupName = "06.屋面附属设备", Order = 43, ShortName = "屋面附属设备名称2")]

        public string WmfsName2
        {
            get { return wmfsName2; }
            set
            {
                if (value != wmfsName2)
                {
                    wmfsName2 = value;
                    this.OnPropertyChanged("WmfsName2");
                }
            }
        }
        private string fzjl2 = "/";
        [Display(Description = "防直击雷2", GroupName = "06.屋面附属设备", Order = 44, ShortName = "防直击雷2")]
        [TypeConverter(typeof(FHTypeConverter))]
        public string Fzjl2
        {
            get { return fzjl2; }
            set
            {
                if (value != fzjl2)
                {
                    fzjl2 = value;
                    OnPropertyChanged("Fzjl2");
                }
            }
        }
        private string fsdgy2 = "/";
        [Display(Description = "防闪电感应2", GroupName = "06.屋面附属设备", Order = 45, ShortName = "防闪电感应2")]
        [TypeConverter(typeof(FHTypeConverter))]
        public string Fsdgy2
        {
            get { return fsdgy2; }
            set
            {
                if (value != fsdgy2)
                {
                    fsdgy2 = value;
                    OnPropertyChanged("Fsdgy2");
                }
            }
        }
        private string wmfsdxpj2 = "/";
        [Display(Description = "屋面附属设备单项评价2", GroupName = "06.屋面附属设备", Order = 46
            , ShortName = "屋面附属设备单项评价2")]

        public string Wmfsdxpj2
        {
            get { return wmfsdxpj2; }
            set
            {
                if (value != wmfsdxpj2)
                {
                    wmfsdxpj2 = value;
                    this.OnPropertyChanged("Wmfsdxpj2");
                }
            }
        }
        private string wmfsName3 = "/";
        [Display(Description = "屋面附属设备名称3", GroupName = "06.屋面附属设备", Order = 47, ShortName = "屋面附属设备名称3")]

        public string WmfsName3
        {
            get { return wmfsName3; }
            set
            {
                if (value != wmfsName3)
                {
                    wmfsName3 = value;
                    this.OnPropertyChanged("WmfsName3");
                }
            }
        }
        private string fzjl3 = "/";
        [Display(Description = "防直击雷3", GroupName = "06.屋面附属设备", Order = 48, ShortName = "防直击雷3")]
        [TypeConverter(typeof(FHTypeConverter))]
        public string Fzjl3
        {
            get { return fzjl3; }
            set
            {
                if (value != fzjl3)
                {
                    fzjl3= value;
                    OnPropertyChanged("Fzjl3");
                }
            }
        }
        private string fsdgy3 = "/";
        [Display(Description = "防闪电感应3", GroupName = "06.屋面附属设备", Order = 49, ShortName = "防闪电感应3")]
        [TypeConverter(typeof(FHTypeConverter))]
        public string Fsdgy3
        {
            get { return fsdgy3; }
            set
            {
                if (value != fsdgy3)
                {
                    fsdgy3 = value;
                    OnPropertyChanged("Fsdgy3");
                }
            }
        }
        private string wmfsdxpj3 = "/";
        [Display(Description = "屋面附属设备单项评价3", GroupName = "06.屋面附属设备", Order = 50
            , ShortName = "屋面附属设备单项评价3")]

        public string Wmfsdxpj3
        {
            get { return wmfsdxpj3; }
            set
            {
                if (value != wmfsdxpj3)
                {
                    wmfsdxpj3 = value;
                    this.OnPropertyChanged("Wmfsdxpj3");
                }
            }
        }
        public class YXXFSTypeConverter : TypeConverter
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
                return new StandardValuesCollection(new string[] { "暗敷", "明敷", "/" });
            }
        }
        private string yxxFs = "/";
        [Display(Description = "引下线敷设", GroupName = "07.引下线", Order = 51, ShortName = "引下线敷设")]
        [TypeConverter(typeof(YXXFSTypeConverter))]
        public string YxxFs
        {
            get { return yxxFs; }
            set
            {
                if (value != yxxFs)
                {
                    yxxFs = value;
                    OnPropertyChanged("YxxFs");
                }
            }
        }
        private int yxxNum = -1;
        [Display(Description = "引下线数目", GroupName = "07.引下线", Order = 52, ShortName = "引下线数目")]
        public int YxxNum
        {
            get { return yxxNum; }
            set
            {
                if (value != yxxNum)
                {
                    yxxNum = value;
                    OnPropertyChanged("YxxNum");
                }
            }
        }
        public class WZTypeConverter : TypeConverter
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
                return new StandardValuesCollection(new string[] { "均匀", "不均匀", "/" });
            }
        }
        private string yxxWZ = "/";
        [Display(Description = "引下线位置", GroupName = "07.引下线", Order = 53, ShortName = "引下线位置")]
        [TypeConverter(typeof(WZTypeConverter))]
        public string YxxWZ
        {
            get { return yxxWZ; }
            set
            {
                if (value != yxxWZ)
                {
                    yxxWZ = value;
                    OnPropertyChanged("YxxWZ");
                }
            }
        }
        private string yxxJJ = "/";
        [Display(Description = "引下线间距", GroupName = "07.引下线", Order = 54, ShortName = "引下线间距")]
        public string YxxJJ
        {
            get { return yxxJJ; }
            set
            {
                if (value != yxxJJ)
                {
                    yxxJJ = value;
                    OnPropertyChanged("YxxJJ");
                }
            }
        }
        public class CLTypeConverter : TypeConverter
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
                return new StandardValuesCollection(new string[] { "4*40mm扁钢", "Φ8mm圆钢", "Φ10mm圆钢", "Φ12mm圆钢", "/" });
            }
        }
        private string yxxCL = "/";
        [Display(Description = "引下线材料规格", GroupName = "07.引下线", Order = 55, ShortName = "引下线材料规格")]
        [TypeConverter(typeof(CLTypeConverter))]
        public string YxxCL
        {
            get { return yxxCL; }
            set
            {
                if (value != yxxCL)
                {
                    yxxCL = value;
                    OnPropertyChanged("YxxCL");
                }
            }
        }
        public class JGTypeConverter : TypeConverter
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
                return new StandardValuesCollection(new string[] { "牢固", "松垮", "/" });
            }
        }
        private string yxxHJJG = "/";
        [Display(Description = "引下线焊接紧固", GroupName = "07.引下线", Order = 56, ShortName = "引下线焊接紧固")]
        [TypeConverter(typeof(JGTypeConverter))]
        public string YxxHJJG
        {
            get { return yxxHJJG; }
            set
            {
                if (value != yxxHJJG)
                {
                    yxxHJJG = value;
                    OnPropertyChanged("YxxHJJG");
                }
            }
        }
        public class AZTypeConverter : TypeConverter
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
                return new StandardValuesCollection(new string[] { "安装", "未安装", "/" });
            }
        }
        private string yxxJDK = "/";
        [Display(Description = "引下线断间卡", GroupName = "07.引下线", Order = 57, ShortName = "引下线断间卡")]
        [TypeConverter(typeof(AZTypeConverter))]
        public string YxxJDK
        {
            get { return yxxJDK; }
            set
            {
                if (value != yxxJDK)
                {
                    yxxJDK = value;
                    OnPropertyChanged("YxxJDK");
                }
            }
        }
        private string yxxdxpj = "/";
        [Display(Description = "引下线单项评价", GroupName = "07.引下线", Order = 58, ShortName = "引下线单项评价")]
        [TypeConverter(typeof(FHTypeConverter))]
        public string Yxxdxpj
        {
            get { return yxxdxpj; }
            set
            {
                if (value != yxxdxpj)
                {
                    yxxdxpj = value;
                    OnPropertyChanged("Yxxdxpj");
                }
            }
        }
       
        private string jzwxb="";
        [Display(Description = "建筑物检测报告续表编号，如果为空或者/，则说明没有续表", GroupName = "08.其他信息", Order = 90, ShortName = "续表编号")]
        public string Jzwxb
        {
            get { return jzwxb; }
            set
            {
                if (value != jzwxb)
                {
                    jzwxb = value;
                    this.OnPropertyChanged("Jzwxb");
                }

            }
        }
        private string jzwspd="";
        [Display(Description = "建筑物检测报告SPD编号，如果为空或者/，则说明没有SPD表", GroupName = "08.其他信息", Order = 91, ShortName = "SPD编号")]
        public string Jzwspd
        {
            get { return jzwspd; }
            set
            {
                if (value != jzwspd)
                {
                    jzwspd = value;
                    this.OnPropertyChanged("Jzwspd");
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
        private int pagetNum=1;
        [Display(Description = "检测表页数，一般自动生成，不修改", GroupName = "09.其他信息", Order = 101,ShortName = "检测表页数")]
        public int PageNum
        {
            get { return pagetNum; }
            set
            {
                if (value != pagetNum)
                {
                    pagetNum = value;
                    this.OnPropertyChanged("PageNum");
                }

            }
        }
       
        private string bgbh;
        [Display(Description = "所属检测报告的编号，一般自动生成，不修改", GroupName = "09.其他信息", Order = 103)]
        public string 报告编号
        {
            get { return bgbh; }
            set
            {
                if (value != bgbh)
                {
                    bgbh = value;
                    this.OnPropertyChanged("报告编号");
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
                    case "项目名称":
                        return this.项目名称 != null ? string.Empty : columnName+"不能为空";
                    case "地址":
                        return this.地址 != null ? string.Empty : columnName + "不能为空";
                    case "联系人":
                        return this.联系人 != null ? string.Empty : columnName + "不能为空";
                    case "电话":
                        return this.电话 != null ? string.Empty : columnName + "不能为空";
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
