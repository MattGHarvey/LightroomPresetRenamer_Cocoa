using System;
using System.IO;
using System.Collections;
using XmpCore;
using System.Globalization;
namespace LightroomPresetRenamer_Cocoa
{
    public class Processor
    {
        public static void goProcess(string sPath)
        {
            DirectoryInfo startDir = new DirectoryInfo(sPath);
            TraverseDirectory(startDir);
        }
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
      
                if (file.Extension == ".xmp")
                {

                   HandleFile(file);

                }
            }
        }
        public static void TraverseDirectoryOrganize(DirectoryInfo directoryInfo)
        {
            var subdirectories = directoryInfo.EnumerateDirectories();

            foreach (var subdirectory in subdirectories)
            {
                TraverseDirectoryOrganize(subdirectory);
            }

            var files = directoryInfo.EnumerateFiles();

            foreach (var file in files)
            {

                if (file.Extension == ".xmp")
                {

                    HandleFileOrg(file);

                }
            }
        }
        public static void goOrg(string sPath)
        {
            DirectoryInfo startDir = new DirectoryInfo(sPath);
            TraverseDirectoryOrganize(startDir);
        }
        private static void HandleFile(FileInfo file)
        {


            IXmpMeta xmp;
            String curFile = file.FullName.ToString();

            using (var stream = File.OpenRead(curFile))
                xmp = XmpMetaFactory.Parse(stream);
            Boolean success = false;
            foreach (var property in xmp.Properties)
            {
                success = false;
                Console.WriteLine(property.Path);
                Console.WriteLine(property.Value);
                if (property.Path == "crs:Preset/crs:Name"||property.Path== "crs:Name[1]")
                {
                    string newfilename = property.Value.Trim().Replace('/', '-') + ".xmp";
                    if (string.Compare(newfilename, file.Name.ToString(), CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)

                    { break; }
                    else
                    {
                        string buPath = Path.Combine(file.DirectoryName, file.Name + "_old");
                        //file.CopyTo(file.DirectoryName + "/" + file.Name + "_old", true);
                        file.CopyTo(buPath, true);
                        string newPath = Path.Combine(file.DirectoryName, newfilename);
                        //file.CopyTo(file.DirectoryName + "/" + newfilename, true);
                        file.CopyTo(newPath, true);
                        Console.WriteLine(property.Value);
                        success = true;

                        break;
                    }
                }
            }
            if (success == true)
            {
                file.Delete();

            }
        }
        private static void HandleFileOrg(FileInfo file)
        {


            IXmpMeta xmp;
            String curFile = file.FullName.ToString();

            using (var stream = File.OpenRead(curFile))
                xmp = XmpMetaFactory.Parse(stream);
            Boolean success = false;
            foreach (var property in xmp.Properties)
                Console.WriteLine($"Path={property.Path} Namespace={property.Namespace} Value={property.Value}");
        }
    }
}
