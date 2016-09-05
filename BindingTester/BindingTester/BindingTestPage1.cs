using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;

namespace BindingTester
{
    class BindingTestPage1 : ContentPage
    {
        BindingTestController viewModel;

        public BindingTestPage1()
        {
            viewModel = new BindingTestController();

            BindingContext = viewModel;

            var TestStack = StackBlah();

            Content = TestStack;
            
        }
        
        public StackLayout StackBlah()
        {
            StackLayout blahStack = new StackLayout
            {
                
            };

            blahStack.Children.Add(BindingEntry());
            blahStack.Children.Add(GetTestBind());

            return blahStack;
        }

        public BindingTestObject BindingEntry()
        {
            BindingTestObject TestEntry = new BindingTestObject();
            TestEntry.BindingContext = viewModel;
            TestEntry.SetBinding(BindingTestObject.BlahStringProperty, "BlahReceiver", BindingMode.TwoWay);

            return TestEntry;
        }

        public Label GetTestBind()
        {
            Label TestLabel = new Label()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Accent
            };
            //Looking for some method like that below
            //TestLabel.GetBinding(Label.TextProperty, "blahReceiver");
            TestLabel.BindingContext = viewModel;
            TestLabel.SetBinding(Label.TextProperty, "BlahReceiver");
            Debug.WriteLine("Everything0");
            return TestLabel;

        }


    }
}
