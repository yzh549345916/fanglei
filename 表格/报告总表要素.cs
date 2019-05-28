using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace fangleinew
{
    public class 报告总表要素 : IDataErrorInfo, INotifyPropertyChanged
    {
        private string bh="";
        [Display(Description = "编号", GroupName = "01.基本信息",Order =1)]
        public string 编号
        {
            get { return bh; }
            set
            {
                if (value != bh)
                {
                    bh = value;
                    OnPropertyChanged("编号");
                }
                
            }
        }
        private string name = "";
        [Display(Description = "受检单位名称", GroupName = "01.基本信息", Order = 2)]
        public string 受检单位名称
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged("受检单位名称");
                }

            }
        }
        private string address = "";
        [Display(Description = "地址", GroupName = "01.基本信息", Order = 3)]
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
        private string lxbm = "";
        [Display(Description = "联系部门", GroupName = "01.基本信息", Order = 4)]
        public string 联系部门
        {
            get { return lxbm; }
            set
            {
                if (value != lxbm)
                {
                    lxbm = value;
                    this.OnPropertyChanged("联系部门");
                }

            }
        }
        private string fzPeople = "";
        [Display(Description = "负责人", GroupName = "01.基本信息", Order = 5)]
        public string 负责人
        {
            get { return fzPeople; }
            set
            {
                if (value != fzPeople)
                {
                    fzPeople = value;
                    this.OnPropertyChanged("负责人");
                }
                
            }
        }
        private string phoneNum = "";
        [Display(Description = "电话", GroupName = "01.基本信息", Order = 6)]
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
        private string youbian = "";
        [Display(Description = "邮编", GroupName = "01.基本信息", Order = 7)]
        public string 邮编
        {
            get { return youbian; }
            set
            {
                if (value != youbian)
                {
                    youbian = value;
                    this.OnPropertyChanged("邮编");
                }

            }
        }
        private DateTime startDateTime=DateTime.Now;
        [Display(Description = "检测开始日期", GroupName = "01.基本信息", Order = 8)]
        public DateTime 检测开始日期
        {
            get { return startDateTime; }
            set
            {
                if (value != startDateTime)
                {
                    startDateTime = value;
                    this.OnPropertyChanged("检测开始日期");
                }

            }
        }
        private DateTime endDateTime = DateTime.Now;
        [Display(Description = "检测结束日期", GroupName = "01.基本信息", Order = 9)]
        public DateTime 检测结束日期
        {
            get { return endDateTime; }
            set
            {
                if (value != endDateTime)
                {
                    endDateTime = value;
                    this.OnPropertyChanged("检测结束日期");
                }

            }
        }
        private DateTime nextDateTime = DateTime.Now.AddYears(1).AddDays(-1);
        [Display(Description = "下次检测日期", GroupName = "01.基本信息", Order = 10)]
        public DateTime 下次检测日期
        {
            get { return nextDateTime; }
            set
            {
                if (value != nextDateTime)
                {
                    nextDateTime = value;
                    this.OnPropertyChanged("下次检测日期");
                }

            }
        }
        private string yqList="";
        [Display(Description = "仪器列表", GroupName = "01.基本信息", Order = 11)]
        public string 仪器列表
        {
            get { return yqList; }
            set
            {
                if (value != yqList)
                {
                    yqList = value;
                    this.OnPropertyChanged("仪器列表");
                }

            }
        }

        private string fbList = "";
        [Display(Description = "分表编号", GroupName = "02.其他", Order = 12)]
        public string 分表编号
        {
            get { return fbList; }
            set
            {
                if (value != fbList)
                {
                    fbList = value;
                    this.OnPropertyChanged("分表编号");
                }
                
            }
        }
        private int pagetNum =1;
        [Display(Description = "报告页数，一般自动生成，不修改", GroupName = "02.其他", Order = 13)]
        public int 报告页数
        {
            get { return pagetNum; }
            set
            {
                if (value != pagetNum)
                {
                    pagetNum = value;
                    this.OnPropertyChanged("报告页数");
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
                    case "地址":
                        return this.地址 != null ? string.Empty : columnName + "不能为空";
                    case "负责人":
                        return this.负责人 != null ? string.Empty : columnName + "不能为空";
                    case "受检单位名称":
                        return this.受检单位名称 != null ? string.Empty : columnName + "不能为空";
                    case "编号":
                        return this.编号 != null ? string.Empty : columnName + "不能为空";
                    case "检测结束日期":
                        return this.检测开始日期 <= this.检测结束日期 ? string.Empty : "检测开始日期不能晚于结束日期";
                    case "下次检测日期":
                        return this.下次检测日期 > this.检测结束日期 ? string.Empty : "下次检测日期不能晚于结束日期";
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
