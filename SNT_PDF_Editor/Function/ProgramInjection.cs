using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace SNT_PDF_Editor.Function
{
    class ProgramInjection
    {
        void work(string[] args)
        {
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
                                var initiatedObject = (PDF_Change_Form)Activator.CreateInstance(t);
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
        }
        private static object[] toObjectArray(string[] arr)
        {
            List<object> objList = new List<object>();

            objList.AddRange(arr);

            return objList.ToArray();
        }
           
    }
}
