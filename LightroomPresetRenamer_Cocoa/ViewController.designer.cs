// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace LightroomPresetRenamer_Cocoa
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTextField mainLabel { get; set; }

		[Action ("cmdProcess:")]
		partial void cmdProcess (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (mainLabel != null) {
				mainLabel.Dispose ();
				mainLabel = null;
			}
		}
	}
}
