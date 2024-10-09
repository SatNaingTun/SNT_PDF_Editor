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
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {

                if (args.Length == 0)
                {
                    //Application.Run(new Images2PDF());
                    Application.Run(new PDF_Change_Form());
                    //MessageBox.Show(new SNT_PDF_Editor.Function.FileAssociate().getMyName());
                }
                else if (args[0] == "-split")
                {
                    IPDFFunction spliter = new PDFspliter();

                    doWork(ref spliter, args);

                }
                else if (args[0] == "-split-form")
                {

                    Application.Run(new PDF_Split_Form());
                }
                else if (args[0] == "-combine")
                {
                    IPDFFunction combiner = new PDFcombiner();

                    doWork(ref combiner, args);
                    //combiner.save("SNT_PDF_CombineOutput.pdf");

                }


                else if (args[0] == "-combine-form")
                {
                    Application.Run(new PDF_Change_Form(getFiles(args)));
                }
                else if (args[0] == "-convert")
                {
                    IPDFFunction converter = new PDFConverter();
                    doWork(ref converter, args);
                }
                else if(args[0] =="-images-form")
                {
                    Application.Run(new Images2PDF());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }
        private static void doWork(ref IPDFFunction myPDF,string[] args)
        {
            string output = null;
            for (int i = 1; i < args.Length; i++)
            {
                if (args[i] == "-output")
                {
                    output = args[i + 1];
                    break;
                }
                else
                {
                    myPDF.openDocument(args[i]);
                }

            }

            if (output == null)
            {
                myPDF.save(Path.GetDirectoryName(args[1]) + "\\" + "SNT_PDF_Output.pdf");
            }
            else if (Directory.Exists(output))
            {
                myPDF.save(output);
            }
            else
            {
                myPDF.save(Path.GetDirectoryName(args[1]) + "\\" + output);
            }
        }
        private static string[] getFiles(string[] args)
        {
            string[] myArr = new string[args.Length-1];
            for (int i = 1; i < args.Length; i++)
            {
                myArr[i-1] = args[i];
            }
            return myArr;
        }
        
    }
}
