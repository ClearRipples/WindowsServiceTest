%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exeMonitoring.Service.exe
Net Start WebMonitorSrv
sc config WebMonitorSrv start= auto
::pause