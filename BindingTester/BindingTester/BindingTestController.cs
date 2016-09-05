using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;

namespace BindingTester
{
    class BindingTestController : INotifyPropertyChanged
    {
        string BlahStringTest;

        public String BlahReceiver
        {
            get
            {
                Debug.WriteLine("Otherthings2");
                return BlahStringTest;
                
            }
            set
            {
                BlahStringTest = value;
                OnPropertyChanged("BlahReceiver");
                Debug.WriteLine("Otherthings0");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
