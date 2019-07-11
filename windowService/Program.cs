using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;


namespace windowService
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("需要先注册服务:");
                Console.WriteLine("-i   注册服务");
                Console.WriteLine("-u   卸载服务");
                Console.WriteLine("-d   调试服务");
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] { new Service() };
                ServiceBase.Run(ServicesToRun);
            }
            else
            {
                if ("-i".Equals(args[0]))
                {
                    Exec("\"" + typeof(Program).Assembly.Location + "\"");       
                }
                else if ("-u".Equals(args[0]))
                {
                    Exec("-u \"" + typeof(Program).Assembly.Location + "\"");
                }
                else if ("-d".Equals(args[0]))
                {
                    new contrl().pingThread();
                }
            }
        }
             public static bool Exec(string args)
        {
          Console.WriteLine("---------------------------");
            string s = System.Environment.GetEnvironmentVariable("windir");
            string url = s + "\\Microsoft.NET\\Framework\\v2.0.50727\\InstallUtil.exe";
            Console.WriteLine("{0} {1}", url, args);
            //Sbw.DbClient.Log.Info();
            Process p = new Process();
            p.StartInfo.FileName = url;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            //   not   display   window
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Arguments = args;
            p.Start();
            string strRst = p.StandardOutput.ReadToEnd();
            Console.WriteLine("+++++++++++++" + strRst);
          //  p.Close();
            return true;
        }

        }
    }

