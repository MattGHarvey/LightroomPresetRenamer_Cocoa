using System;
using System.IO;
using System.Collections;
using XmpCore;
using System.Globalization;
namespace LightroomPresetRenamer_Cocoa
{
    public class Processor
    {
        public static void TraverseDirectory(DirectoryInfo directoryInfo)
        {
            var subdirectories = directoryInfo.EnumerateDirectories();

            foreach (var subdirectory in subdirectories)
            {
                TraverseDirectory(subdirectory);
            }

            var files = directoryInfo.EnumerateFiles();

            foreach (var file in files)
            {
                // 
                if (file.Extension == ".xmp")
                {
                    //   Console.WriteLine(file);
                    // if (file.Name.Contains("Velvia"))
                    //    {
             //       HandleFile(file);
                    //   }
                }
            }
        }
    }
}
