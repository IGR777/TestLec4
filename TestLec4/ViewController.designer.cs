// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace TestLec4
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField FirstArgument { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ResultValue { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField SecondArgument { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField Sign { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (FirstArgument != null) {
                FirstArgument.Dispose ();
                FirstArgument = null;
            }

            if (ResultValue != null) {
                ResultValue.Dispose ();
                ResultValue = null;
            }

            if (SecondArgument != null) {
                SecondArgument.Dispose ();
                SecondArgument = null;
            }

            if (Sign != null) {
                Sign.Dispose ();
                Sign = null;
            }
        }
    }
}