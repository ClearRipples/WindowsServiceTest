using System;
using System.IO;
using System.Timers;
using System.ServiceProcess;

namespace Monitoring.WebSiteMonitoring
{
    partial class WebMonitorSrv : ServiceBase
    {
        /*************************
         * property.
         */

        Timer timer = new Timer();

        public WebMonitorSrv()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer.Elapsed += new ElapsedEventHandler(TimersElapsed);
            timer.Enabled = true;
        }

        protected override void OnStop()
        {
            timer.Enabled = false;
        }

        private void TimersElapsed(object sender, ElapsedEventArgs e)
        {
            string path = @"d:\\TestFile.txt";
            StreamWriter sw;

            if (!File.Exists(path))
            {
                sw = File.CreateText(path);
            }
            else
            {
                sw = File.AppendText(path);
                sw.WriteLine("+++++++++++++++++++");
                sw.Write("添加日期为：" + DateTime.Now.ToString() + "\r\n");
                sw.Write("日志内容为：" + "测试服务" + "\r\n");
                sw.WriteLine("===========================");
                sw.Flush();
                sw.Close();
            }
        }
    }
}
