using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace windowService
{
    class Log
    {

        static FileInfo file;
        public static void Debug(string msg)
        {
            StreamWriter sw;

            DirectoryInfo logDirectory = new DirectoryInfo("e:\\gftLog");
            if (!logDirectory.Exists)
            {
                logDirectory.Create();
            }

            if (file == null)
            {
                //  System.Windows.Forms.MessageBox.Show(string.Format("c:\\{0:yyyy-MM-dd-HH:mm:ss}.log", DateTime.Now), "sss");
                file = new FileInfo(string.Format("e:\\gftLog\\{0:yyyy-MM-dd-HH-mm-ss}.log", DateTime.Now));
                sw = file.CreateText();
                sw.Dispose();
            }
            file.Refresh();
            // System.Windows.Forms.MessageBox.Show(file.Length.ToString(), "ss");
            if (file.Length > 1024 * 10240)
            {
                //System.Windows.Forms.MessageBox.Show("sa", "ss");
                file = new FileInfo(string.Format("e:\\gftLog\\{0:yyyy-MM-dd-HH-mm-ss}.log", DateTime.Now));
                sw = file.CreateText();
                sw.WriteLine(msg);
            }
            else
                sw = file.AppendText();
            sw.WriteLine(msg);
            sw.Flush();
            sw.Close();
            sw.Dispose();
            //   System.Windows.Forms.MessageBox.Show("sa","ss");
        }
    }
}
