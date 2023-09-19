using System;

using AppKit;
using Foundation;

namespace LightroomPresetRenamer_Cocoa
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.
        }
        partial void cmdProcess(NSObject sender)
        {
            //throw new NotImplementedException();
            
            var dlg = NSOpenPanel.OpenPanel;
            dlg.CanChooseFiles = false;
            dlg.CanChooseDirectories = true;

            if (dlg.RunModal() == 1)
            {

                var url = dlg.Urls[0];
                if (url != null)
                {
                    var path = url.Path;

                    Processor.goProcess(path);
                }
            }
            mainLabel.StringValue = "Processing Complete";
        }

        partial void cmdOrganize(NSObject sender)
        {
            //throw new NotImplementedException();

            var dlg = NSOpenPanel.OpenPanel;
            dlg.CanChooseFiles = false;
            dlg.CanChooseDirectories = true;

            if (dlg.RunModal() == 1)
            {

                var url = dlg.Urls[0];
                if (url != null)
                {
                    var path = url.Path;

                    Processor.goOrg(path);
                }
            }
            mainLabel.StringValue = "Processing Complete";
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}
