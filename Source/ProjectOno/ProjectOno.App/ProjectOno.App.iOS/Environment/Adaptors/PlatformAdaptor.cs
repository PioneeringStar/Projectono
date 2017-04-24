using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace ProjectOno.Environment.Adaptors
{
    public class PlatformAdaptor : IPlatformAdaptor
    {
        public bool FullScreenEnabled {
            get { return UIApplication.SharedApplication.StatusBarHidden; }
            set { UIApplication.SharedApplication.StatusBarHidden = value; }
        }
    }
}