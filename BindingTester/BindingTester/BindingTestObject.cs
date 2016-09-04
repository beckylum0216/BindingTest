using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace BindingTester
{

    class BindingTestObject : Entry
    {
        public BindingTestObject()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand;
            
        }

        

        public static BindableProperty blahStringProperty =
            BindableProperty.Create(
                nameof(blahSource),
                typeof(String),
                typeof(BindingTestObject),
                null,
                BindingMode.OneWay,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    ((BindingTestObject)bindable).blahSourceChanged();
                }
        );

        public String blahSource
        {
            get
            {
                return (string)GetValue(blahStringProperty);
            }
            set
            {
                SetValue(blahStringProperty, value);
            }
        }

        public void blahSourceChanged()
        {
            blahSource = this.Text;
        }

    }
}
