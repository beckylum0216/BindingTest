using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;


namespace BindingTester
{

    class BindingTestObject : Entry
    {
        public BindingTestObject()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand;
            
        }

        

        public static BindableProperty BlahStringProperty =
            BindableProperty.Create(
                nameof(BlahString),
                typeof(String),
                typeof(BindingTestObject),
                null,
                BindingMode.TwoWay,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    ((BindingTestObject)bindable).BlahSourceChanged();
                    Debug.WriteLine("Anything0");
                }
        );

        public String BlahString
        {
            get
            {
                Debug.WriteLine("Anything1");
                return (string)GetValue(BlahStringProperty);
                
            }
            set
            {
                SetValue(BlahStringProperty, value);
                Debug.WriteLine("Anything2");
            }
        }

        public void BlahSourceChanged()
        {
            BlahString = this.Text;
        }

    }
}
