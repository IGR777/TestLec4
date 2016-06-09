using Foundation;
using System;
using UIKit;

namespace TestLec4
{
    public partial class SecondViewController : UIViewController
    {
        public string ValueForLabel{
            get;set;
        }


        public SecondViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ResultLabel.Text = ValueForLabel;
        }
    }
}