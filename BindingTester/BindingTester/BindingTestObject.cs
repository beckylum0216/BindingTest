using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;


namespace BindingTester
{

    public class BindingTestObject : Entry
    {
        public static BindableProperty BlahStringProperty = BindableProperty.Create(
            propertyName: nameof(BlahString),
            returnType: typeof(string),
            declaringType: typeof(BindingTestObject),
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: OnBlahStringChanged);

        

        public BindingTestObject()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand;

            TextChanged += OnTextChanged;

        }

        private void OnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            BlahString = Text;
        }

        public string BlahString
        {
            get
            {
                Debug.WriteLine("Anything1");
                return (string)GetValue(BlahStringProperty);
            }
            set
            {
                SetValue(BlahStringProperty, value);
            }
        }

        private static void OnBlahStringChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Debug.WriteLine("Anything0");

            var customObject = bindable as BindingTestObject;

            if (customObject != null)
            {
                customObject.BlahString = newValue as string;
            }
        }
    }
}
