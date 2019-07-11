using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;


namespace windowService
{
    
    public partial class Service : ServiceBase
    {
        public Thread th;
        public contrl c;
        public Service()
        {
            InitializeComponent();
        
        }

        protected override void OnStart(string[] args)
        {
         
        
         
            System.Threading.Thread.Sleep(5000);
            c=new contrl();
            if (th == null)
            {
                th = new Thread(c.pingThread);
                th.IsBackground = true;
                th.Start();
            }
          
           // else c.log();
          
        }

        protected override void OnStop()
        {
            
            c.stopPing = true;
            System.Threading.Thread.Sleep(10000);
            if (th != null)
            {
                if (th.ThreadState == System.Threading.ThreadState.Running)
                {
                    th.Abort();
                }
            }
             
        }

        public static void run()
        {
           // Console.WriteLine("运行中。。。。");
           
        }
      
    }
}
