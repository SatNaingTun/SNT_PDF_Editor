using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using SNT_PDF_Editor.Function;
using System.IO;

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
                else if(args[0]=="-split")
                {
                    PDFspliter spliter = new PDFspliter();
                    spliter.openDocument(args[1]);
                    spliter.save(args[1]);
                }
                else if (args[0] == "-combine")
                {
                    PDFcombiner combiner = new PDFcombiner();
                    string output=null;
                    for (int i = 1; i < args.Length; i++)
                    {
                        if (args[i] == "-output")
                        {
                            output = args[i + 1];
                            break;
                        }
                        else
                        
                        combiner.addDocument(args[i]);
                        
                    }

                    if (output == null)
                    {
                        combiner.save(Path.GetDirectoryName(args[1]) + "\\" + "SNT_PDF_CombineOutput.pdf");
                    }
                    else if (Directory.Exists(output))
                    {
                        combiner.save(output);
                    }
                    else
                    {
                        combiner.save(Path.GetDirectoryName(args[1]) + "\\" + output);
                    }
                    //combiner.save("SNT_PDF_CombineOutput.pdf");
                    
                }
               
                else if (args[0] == "-split-form")
                {

                    Application.Run(new PDF_Split_Form(args[1]));
                }
                else if(args[0]=="-combine-form")
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
