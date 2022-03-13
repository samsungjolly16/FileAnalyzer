using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System.Data;
using System.Threading;

namespace FileAnalyzer
{
    class Program
    {
        public static List<FileDiscovery> GlobalData = new List<FileDiscovery>();
        static string globalpath = @"C:\Users\tommaso\Desktop\Utile";
        static int count = 0;
        static void Main(string[] args)
        {
           
            for (int i = 0; i<5; i++)
            {
                File.Create($"file{count}.txt");
                count++;
            }
            int count2 = 0;
            Thread.Sleep(1000);
           for (int i = 0; i <= count; i++)
           {
                File.Move($@"C:\Users\tommaso\Downloads\FileAnalyzer\FileAnalyzer\bin\Debug\netcoreapp3.1\file{count2}.txt", @"C:\Users\tommaso\Desktop\Utile");
                count2++;
           }
           
                
            
            //leggiamo il path di lavoro+
            LeggiCartella();
            EseguiTrhead(5);
            //memorizzo il nome e il numero dei file su una lista
            //cicliamo tra i file che posso eleborare
            //ElaboraFile();
            //facciamo un metodo che blocca il file, lo elabora
            //e quando ho finito metto il flag a 1                

        }
        private static void ElaboraFile()
        {
            foreach (FileDiscovery fd in GlobalData)
            {
                if ( fd.l_Lock==false)
                    {
                    fd.l_Lock = true;
                   // string pathfile = string.Concat(globalpath, "", fd._Nomefile);
                    FileInfo fi = new FileInfo(fd._Nomefile);
                    
                    if (fi.Exists)
                    {
                        
                        fi.MoveTo(string.Concat(fi.FullName,".usr"));
                        //Console.WriteLine("File Renamed.");
                    }
                    fd.l_Lock = false;
                    //File fl = new File();

                    // file.

                }
            }
            //Thread.Sleep(20000);
            //CheckThread();
        }
        
       

        private static void CreaThread()
        {
            Thread thread = new Thread(new ThreadStart(ElaboraFile));
            thread.Start();
        }

        private static void EseguiTrhead(int numth)
        {
            for (int i=1;i<=numth; i++)
            {
                CreaThread();
            }
        }

        private static void LeggiCartella()
        {
            try
            {
                FileInfo fi;
                if (Directory.Exists(globalpath))
                    {
                    String[] files = Directory.GetFiles(globalpath);
                    foreach (string _file in files)
                    {
                        fi = new FileInfo(_file);
                       
                        if (fi.Extension==".txt")
                        {
                            FileDiscovery fd = new FileDiscovery();
                            fd._Nomefile = _file.ToString();
                            fd.l_Lock = false;
                            GlobalData.Add(fd);
                            //Console.WriteLine(_file.ToString());
                        }
                        

                    }

                }
                
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
   
}
