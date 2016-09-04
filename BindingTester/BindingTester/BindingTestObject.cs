using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace BindingTester
{

    class BindingTestObject : StackLayout
    {
        public BindingTestObject()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand;
            Children.Add(blahTextbox());
            
        }

        public Entry blahTextbox()
        {
            var blah = new Entry()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            };


            return blah;
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
            blahSource = blahTextbox().Text;
        }

    }
}
