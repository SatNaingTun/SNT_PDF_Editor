using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace SNT_PDF_Editor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
       static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            if (Process.GetProcessesByName("SNT_PDF_Editor.exe").Length == 0)
            {
                if (args.Length == 0)
                {
                    Application.Run(new PDF_Combine_Form());
                    //MessageBox.Show(new SNT_PDF_Editor.Function.FileAssociate().getMyName());
                }
                else
                {
                    Application.Run(new PDF_Combine_Form(args));
                }
            }
           
           
            
        }
    }
}
