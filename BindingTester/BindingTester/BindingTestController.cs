using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Xamarin.Forms.Xaml;

[assembly:XamlCompilation(XamlCompilationOptions.Compile)]

namespace BindingTester
{
    public class BindingTestController : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _blahReceiver;
        
        public BindingTestController()
        {
            //default constructor for XAML binding
        }

        public string BlahReceiver
        {
            get { return _blahReceiver; }
            set
            {
                if (value == _blahReceiver) return;
                _blahReceiver = value;
                OnPropertyChanged(nameof(BlahReceiver));
            }
        }
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
