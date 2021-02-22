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
            mainLabel.StringValue = "Clicked";
            var dlg = NSOpenPanel.OpenPanel;
            dlg.CanChooseFiles = false;
            dlg.CanChooseDirectories = true;
            //   dlg.AllowedFileTypes = new string[] { "txt", "html", "md", "css" };
            // dlg.RunModal();
            //    List<Result> fileSearchResults = new List<Result>();
            if (dlg.RunModal() == 1)
            {
                // Nab the first file
                var url = dlg.Urls[0];
                if (url != null)
                {
                    var path = url.Path;
               //     SearchFileNames(path);
                }
            }
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
