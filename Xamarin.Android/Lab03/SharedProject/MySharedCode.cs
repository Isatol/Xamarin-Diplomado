using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace SharedProject
{
    class MySharedCode
    {
        public string GetFilePath(string fileName) {
#if WINDOWS_UWP
            var FilePath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, fileName);
#else
#if __ANDROID__
            string LibraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var FilePath = Path.Combine(LibraryPath, fileName);
#else

#endif

#endif
            var FilePath = Path.Combine(Environment.CurrentDirectory, fileName);
            return FilePath;
        }
    }
}
