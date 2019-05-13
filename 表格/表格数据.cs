using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace 表格分层
{
    public class MyGridData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<检测报告总表类> jcbgZbs;
        private ObservableCollection<检测报告分表类> jcbgFbs;

        public ObservableCollection<检测报告总表类> JcbgZbs
        {
            get
            {
                if (this.jcbgZbs == null)
                {
                    this.jcbgZbs = 检测报告总表类.GetZbs();
                }

                return this.jcbgZbs;
            }
        }

        public ObservableCollection<检测报告分表类> JcbgFbs
        {
            get
            {
                if (this.jcbgFbs == null)
                {
                    this.jcbgFbs = 检测报告分表类.GetFbs();
                }

                return this.jcbgFbs;
            }
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
    }
}
