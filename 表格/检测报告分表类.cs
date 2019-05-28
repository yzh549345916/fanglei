using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace 表格分层
{
    public class 检测报告分表类 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string name;
        private string fbid;
        private string zbid;
        private string jcPeople;
        private string jhPeople;
        private string pzPeople;
        private DateTime mydate;
        private string fenLei;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value != this.name)
                {
                    this.name = value;
                    this.OnPropertyChanged("Name");
                }
            }
        }


        public string Fbid
        {
            get { return this.fbid; }
            set
            {
                if (value != this.fbid)
                {
                    this.fbid = value;
                    this.OnPropertyChanged("Fbid");
                }
            }
        }
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
        public string JcPeople
        {
            get { return this.jcPeople; }
            set
            {
                if (value != this.jcPeople)
                {
                    this.jcPeople = value;
                    this.OnPropertyChanged("JcPeople");
                }
            }
        }
        public string JhPeople
        {
            get { return this.jhPeople; }
            set
            {
                if (value != this.jhPeople)
                {
                    this.jhPeople = value;
                    this.OnPropertyChanged("JhPeople");
                }
            }
        }
        public string PzPeople
        {
            get { return this.pzPeople; }
            set
            {
                if (value != this.pzPeople)
                {
                    this.pzPeople = value;
                    this.OnPropertyChanged("PzPeople");
                }
            }
        }
        public string FenLei
        {
            get { return this.fenLei; }
            set
            {
                if (value != this.fenLei)
                {
                    this.fenLei = value;
                    this.OnPropertyChanged("FenLei");
                }
            }
        }
        public DateTime Mydate
        {
            get { return this.mydate; }
            set
            {
                if (value != this.mydate)
                {
                    this.mydate = value;
                    this.OnPropertyChanged("Mydate");
                }
            }
        }
        public 检测报告分表类()
        {

        }

        public 检测报告分表类(string name, string fbid, string zbid,DateTime mydate,string fenLei)
        {
            this.name = name;
            this.fbid = fbid;
            this.zbid = zbid;
            this.mydate = mydate;
            this.fenLei = fenLei;
        }
        public 检测报告分表类(string name, string fbid, string zbid, DateTime mydate, string fenLei, string jcPeople, string jhPeople, string pzPeople) : this(name, fbid,  zbid,  mydate,  fenLei)
        {
            this.jcPeople = jcPeople;
            this.jhPeople = jhPeople;
            this.pzPeople = pzPeople;
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
            return this.Name;
        }

        public static ObservableCollection<检测报告分表类> GetFbs()
        {
            return new ObservableCollection<检测报告分表类>(检测报告总表类.GetZbs().SelectMany(c => c.JcbgFbs));
        }
    }
}
