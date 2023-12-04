using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

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
            #region AlreadyOpened
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Process[] myProcesses = Process.GetProcessesByName("SNT_PDF_Editor");
            Process currentProcess = Process.GetCurrentProcess();
            if (myProcesses.Length > 1)
            {

                foreach (var process in myProcesses)
                {
                    //MessageBox.Show("Process ID is " + process.Id + "Current " + currentProcess.Id);
                    if (process.Id != currentProcess.Id)
                        if (!process.ProcessName.Contains("vshost"))
                        {
                            try
                            {
                                string assemblyName = process.ProcessName + ".exe";
                                Assembly a = Assembly.LoadFrom(assemblyName);
                                //Type[] types = a.GetTypes();
                                //foreach (Type t in types)
                                //{
                                //    Console.WriteLine("\nType : {0}", t.FullName);
                                //    Console.WriteLine("\tBase class: {0}", t.BaseType.FullName);
                                //}

                                Type t = a.GetType("SNT_PDF_Editor.PDF_Combine_Form");
                                MethodInfo myMethod = t.GetMethod("addFile2Grid");
                                var initiatedObject = (PDF_Combine_Form)Activator.CreateInstance(t);
                                //if(args!=null)
                                // myMethod.Invoke(initiatedObject,toObjectArray( args));

                                initiatedObject.addFiles2Grid(args);



                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }

                }

            } 
            #endregion
            else
            {
                if (args.Length == 0)
                {
                    Application.Run(new PDF_Combine_Form());
                    //MessageBox.Show(new SNT_PDF_Editor.Function.FileAssociate().getMyName());
                }
               
                else if (args[0] == "-split-form")
                {

                    Application.Run(new PDF_Split_Form(args[1]));
                }
                else
                {
                    Application.Run(new PDF_Combine_Form(args));
                }
            }
           
           
            
        }
        private static object[] toObjectArray(string[] arr)
        {
            List<object> objList = new List<object>();

            objList.AddRange(arr);

            return objList.ToArray();
        }
    }
}
