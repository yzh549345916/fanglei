using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using fangleinew;

namespace 表格分层
{
    public class 检测报告总表类 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string zbid;//总表ID
        private DateTime startDate;//检测开始时间
        private DateTime endDate;//检测结束时间
        private DateTime nextDate;//下次检测时间
        private string companyName;//单位名称
        private string companyAddress;//单位地址
        private string contactDepartment;//联系部门
        private string zrPeople;//负责人
        private string telephoneNumber;//联系电话
        private string bgPath;//报告路径
        private ObservableCollection<检测报告分表类> jcbgFbs;

        public string Zbid
        {
            get { return this.zbid; }
            set
            {
                if (value != this.zbid)
                {
                    this.zbid = value;
                    this.OnPropertyChanged("Zbid");
                }
            }
        }

        public DateTime StartDate
        {
            get { return this.startDate; }
            set
            {
                if (value != this.startDate)
                {
                    this.startDate = value;
                    this.OnPropertyChanged("StartDate");
                }
            }
        }
        public DateTime EndDate
        {
            get { return this.endDate; }
            set
            {
                if (value != this.endDate)
                {
                    this.endDate = value;
                    this.OnPropertyChanged("EndDate");
                }
            }
        }
        public DateTime NextDate
        {
            get { return this.nextDate; }
            set
            {
                if (value != this.nextDate)
                {
                    this.nextDate = value;
                    this.OnPropertyChanged("NextDate");
                }
            }
        }
        public string CompanyName
        {
            get { return this.companyName; }
            set
            {
                if (value != this.companyName)
                {
                    this.companyName = value;
                    this.OnPropertyChanged("CompanyName");
                }
            }
        }
        public string CompanyAddress
        {
            get { return this.companyAddress; }
            set
            {
                if (value != this.companyAddress)
                {
                    this.companyAddress = value;
                    this.OnPropertyChanged("CompanyAddress");
                }
            }
        }
        public string ContactDepartment
        {
            get { return this.contactDepartment; }
            set
            {
                if (value != this.contactDepartment)
                {
                    this.contactDepartment = value;
                    this.OnPropertyChanged("ContactDepartment");
                }
            }
        }
        public string ZrPeople
        {
            get { return this.zrPeople; }
            set
            {
                if (value != this.zrPeople)
                {
                    this.zrPeople = value;
                    this.OnPropertyChanged("ZrPeople");
                }
            }
        }
        public string TelephoneNumber
        {
            get { return this.telephoneNumber; }
            set
            {
                if (value != this.telephoneNumber)
                {
                    this.telephoneNumber = value;
                    this.OnPropertyChanged("TelephoneNumber");
                }
            }
        }
        public string BgPath
        {
            get { return this.bgPath; }
            set
            {
                if (value != this.bgPath)
                {
                    this.bgPath = value;
                    this.OnPropertyChanged("BgPath");
                }
            }
        }


        public ObservableCollection<检测报告分表类> JcbgFbs
        {
            get
            {
                if (null == this.jcbgFbs)
                {
                    this.jcbgFbs = new ObservableCollection<检测报告分表类>();
                }

                return this.jcbgFbs;
            }
        }

        public 检测报告总表类()
        {

        }

        public 检测报告总表类(string zbid, DateTime startDate, DateTime endDate, DateTime nextDate, string companyName)
        {
            this.zbid = zbid;
            this.startDate = startDate;
            this.endDate = endDate;
            this.nextDate = nextDate;
            this.companyName = companyName;
        }

        public 检测报告总表类(string zbid, DateTime startDate, DateTime endDate, DateTime nextDate, string companyName, ObservableCollection<检测报告分表类> jcbgFbs)
            : this(zbid, startDate, endDate, nextDate, companyName)
        {
            this.jcbgFbs = jcbgFbs;
        }
        public 检测报告总表类(string zbid, DateTime startDate, DateTime endDate, DateTime nextDate, string companyName, ObservableCollection<检测报告分表类> jcbgFbs, string companyAddress, string contactDepartment, string zrPeople, string telephoneNumber, string bgPath)
            : this(zbid, startDate, endDate, nextDate, companyName, jcbgFbs)
        {
            this.companyAddress = companyAddress;
            this.contactDepartment = contactDepartment;
            this.zrPeople = zrPeople;
            this.telephoneNumber = telephoneNumber;
            this.bgPath = bgPath;
        }
        public 检测报告总表类(string zbid, DateTime startDate, DateTime endDate, DateTime nextDate, string companyName,  string companyAddress, string contactDepartment, string zrPeople, string telephoneNumber, string bgPath)
            : this(zbid, startDate, endDate, nextDate, companyName)
        {
            this.companyAddress = companyAddress;
            this.contactDepartment = contactDepartment;
            this.zrPeople = zrPeople;
            this.telephoneNumber = telephoneNumber;
            this.bgPath = bgPath;
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return this.Zbid;
        }

        public static ObservableCollection<检测报告总表类> GetZbs()
        {
            ObservableCollection<检测报告总表类> zbs = new ObservableCollection<检测报告总表类>();
            数据库处理类 sjkcl = new 数据库处理类();
            foreach (检测报告总表类 zb in sjkcl.getZB())
            {
                List<检测报告分表类> fbLists = sjkcl.GetALLFBListbyZB(zb.Zbid);
                foreach(var fbl in fbLists)
                {
                    zb.JcbgFbs.Add(fbl);
                }
                zbs.Add(zb);
            }

            

            return zbs;
        }

        public static ObservableCollection<检测报告总表类> updateZbs(ObservableCollection<检测报告总表类> zbs,string bh)
        {
            int count = zbs.IndexOf((zbs.Where(y => y.Zbid == bh).First()));
            zbs[count].JcbgFbs.Clear();
            数据库处理类 sjkcl = new 数据库处理类();
            List<检测报告分表类> fbLists = sjkcl.GetALLFBListbyZB(bh);
            foreach (var fbl in fbLists)
            {
                zbs[count].JcbgFbs.Add(fbl);
            }
            return zbs;
        }

        public static ObservableCollection<检测报告总表类> GetZbs2()
        {
            ObservableCollection<检测报告总表类> zbs = new ObservableCollection<检测报告总表类>();
            //检测报告总表类 zb;

            //// Liverpool
            //zb = new 检测报告总表类("000002", DateTime.Now.AddDays(-3), DateTime.Now.AddDays(-1), DateTime.Now.AddYears(1), "火星", "宇宙", "办公室213", "孙子", "110", "空空如也");
            //zb.JcbgFbs.Add(new 检测报告分表类("分表3", "10000001", "10210", DateTime.Now, "建筑物", "帅哥", "傻子", "愣子"));
            //zb.JcbgFbs.Add(new 检测报告分表类("分表4", "10000002", "10210", DateTime.Now, "建筑物", "帅哥", "傻子", "愣子"));
            //zb.JcbgFbs.Add(new 检测报告分表类("分表5", "10000003", "10210", DateTime.Now.AddDays(1), "导弹", "帅哥2", "傻子2", "愣子2"));
            //zbs.Add(zb);

            

            return zbs;
        }
    }
}
