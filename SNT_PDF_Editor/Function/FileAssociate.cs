using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;

namespace SNT_PDF_Editor.Function
{
   public   class FileAssociate
    {
        [DllImport("Shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);

      public  bool isAssociated(string fileExt)
        {
          return (Registry.CurrentUser.OpenSubKey("Software\\Classes\\."+fileExt,false)==null);
        }

      public  string getMyName()
      {
          return AssemblyName.GetAssemblyName(Assembly.GetExecutingAssembly().Location).Name;
      }

      public  void associate(string fileExt)
      {
          RegistryKey fileReg = Registry.CurrentUser.CreateSubKey("Software\\Classes\\."+fileExt);
          RegistryKey appReg = Registry.CurrentUser.CreateSubKey("Software\\Classes\\Applications\\" + getMyName()+".exe");
          RegistryKey appAssoc = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\."+fileExt);
          fileReg.CreateSubKey("DefaultIcon").SetValue("", Application.ExecutablePath + "pdf.ico");
          fileReg.CreateSubKey("PerceivedType").SetValue("", "Text");
          appReg.CreateSubKey("shell\\open\\command").SetValue("", "\"" + Application.ExecutablePath + "\" %1");
         // appReg.CreateSubKey("DefaultIcon").SetValue("", "C:\\Users\\MyName\\Pictures\\3ncryp3d fil3.ico");
          appReg.CreateSubKey("DefaultIcon").SetValue("", Application.ExecutablePath +"pdf.ico");

          appAssoc.CreateSubKey("UserChoice").SetValue("Progid", "Applications\\"+getMyName()+".exe");


          SHChangeNotify(0x000000, 0x0000, IntPtr.Zero, IntPtr.Zero);

      }
    }
}
