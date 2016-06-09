using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace TestLec4
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            var picker = new UIPickerView();

            var model = new PickerDataModel();
            model.Items.Add("+");
            model.Items.Add("-");
            model.Items.Add("*");
            model.Items.Add("/");
            model.ValueChanged += (sender, args) =>
            {
                Sign.Text = model.SelectedItem.ToString();
            };
            picker.Model = model;

            Sign.InputView = picker;

            Sign.Text = model.SelectedItem.ToString();

            var newButton = new UIBarButtonItem(UIBarButtonSystemItem.Action, (sender, args) =>
            {
                double result, first, second;
                bool failed = false;
                if (!Double.TryParse(FirstArgument.Text, out result))
                {
                    failed = true;
                    FirstArgument.Layer.BorderColor = UIColor.Red.CGColor;
                    FirstArgument.Layer.BorderWidth = 1.0f;
                }
                first = result;

                if (!Double.TryParse(SecondArgument.Text, out result))
                {
                    failed = true;
                    SecondArgument.Layer.BorderColor = UIColor.Red.CGColor;
                    SecondArgument.Layer.BorderWidth = 1.0f;
                }


                second = result;

                if (failed)
                    return;
                FirstArgument.Layer.BorderWidth = 0.0f;
                SecondArgument.Layer.BorderWidth = 0.0f;

                switch (Sign.Text)
                {
                    case "+":
                        ResultValue.Text = (first + second).ToString();
                        break;
                    case "-":
                        ResultValue.Text = (first - second).ToString();
                        break;
                    case "*":
                        ResultValue.Text = (first * second).ToString();
                        break;
                    case "/":
                        if (second.Equals(0.0d))
                        {
                            SecondArgument.Layer.BorderColor = UIColor.Red.CGColor;
                            return;
                        }

                        ResultValue.Text = (first / second).ToString();
                        break;
                }
                
                PerformSegue("SecondVC", this);
            });

            this.NavigationItem.SetRightBarButtonItem(newButton, true);

       
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            var vc = segue.DestinationViewController as SecondViewController;
            if (vc != null)
                vc.ValueForLabel = ResultValue.Text;

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }

    public class PickerDataModel : UIPickerViewModel
    {
        public event EventHandler<EventArgs> ValueChanged;

        /// <summary>
        /// The items to show up in the picker
        /// </summary>
        public List<string> Items { get; private set; }

        /// <summary>
        /// The current selected item
        /// </summary>
        public string SelectedItem
        {
            get { return Items[selectedIndex]; }
        }

        int selectedIndex = 0;

        public PickerDataModel()
        {
            Items = new List<string>();
        }

        /// <summary>
        /// Called by the picker to determine how many rows are in a given spinner item
        /// </summary>
        public override nint GetRowsInComponent(UIPickerView picker, nint component)
        {
            return Items.Count;
        }

        /// <summary>
        /// called by the picker to get the text for a particular row in a particular
        /// spinner item
        /// </summary>
        public override string GetTitle(UIPickerView picker, nint row, nint component)
        {
            return Items[(int)row];
        }

        /// <summary>
        /// called by the picker to get the number of spinner items
        /// </summary>
        public override nint GetComponentCount(UIPickerView picker)
        {
            return 1;
        }

        /// <summary>
        /// called when a row is selected in the spinner
        /// </summary>
        public override void Selected(UIPickerView picker, nint row, nint component)
        {
            selectedIndex = (int)row;
            if (ValueChanged != null)
            {
                ValueChanged(this, new EventArgs());
            }
        }
    }

}