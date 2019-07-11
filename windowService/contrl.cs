using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace windowService
{
   public  class contrl
    {
      // public static String logPath = "pingLog.txt";
       public String pathparameter="172.16.0.1 -n 5";
        private StreamReader sr;
     //   private FileStream fs = new FileStream(@"c:\" + logPath, FileMode.Append);
      //  private FileStream fs ;
        public bool stopPing=false;
       // private StreamWriter sw = null;
        Process p;
        public void pingThread()
        {
           
            while (!stopPing)
            {
             run();
         //    sw.Flush();
         }
           // fs.Close();
         //   sw.Close();
        }

      
       

        public void run()
        {    //   Console.WriteLine("运行中");
             p = new Process();
            p.StartInfo.FileName = "ping";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            //   not   display   window
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.Arguments = pathparameter;
            p.Start();
            sr = p.StandardOutput;
           
            String line;
            string date = DateTime.Now.ToString();
        

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                //  Console.WriteLine(line);
                Log.Debug(line);
            }
            p.WaitForExit();
            p.Close();
          
            System.Threading.Thread.Sleep(5000);
        }
    }
}
