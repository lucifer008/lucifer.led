using System;
using System.ServiceProcess;

namespace SuspeSys.Server
{

    public class WinServiceUtils
    {
        public static bool ServiceIsExisted(string svcName)
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController s in services)
            {
                if (s.ServiceName == svcName)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>  
        /// 判断是否安装了某个服务  
        /// </summary>  
        /// <param name="serviceName"></param>  
        /// <returns></returns>  

        public static bool ISWindowsServiceInstalled(string serviceName)
        {
            try
            {
                ServiceController[] services = ServiceController.GetServices();
                foreach (ServiceController service in services)
                {
                    if (service.ServiceName == serviceName)
                    {
                        return true;
                    }
                }
                return false;
            }

            catch

            { return false; }
        }

        /// <summary>  
        /// 启动某个服务  
        /// </summary>  
        /// <param name="serviceName"></param>  

        public static bool StartService(string serviceName, ref Exception exx)
        {
            try
            {
                ServiceController[] services = ServiceController.GetServices();
                foreach (ServiceController service in services)
                {
                    if (service.ServiceName == serviceName)
                    {
                        if (service.Status == ServiceControllerStatus.Running)
                        {
                            //MessageBox.Show("服务正在运行中...");
                            return false;
                        }
                        service.Start();
                        service.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 30));
                    }
                }

            }
            catch (Exception ex)
            {
                exx=ex;
                
                return false;
                //MessageBox.Show(ex.Message);
            }
            return true;
        }
        /// <summary>  
        /// 停止某个服务  
        /// </summary>  
        /// <param name="serviceName"></param>  
        public static bool StopService(string serviceName, ref Exception exx)
        {
            try
            {

                ServiceController[] services = ServiceController.GetServices();
                foreach (ServiceController service in services)
                {
                    if (service.ServiceName == serviceName)
                    {
                        service.Stop();
                        service.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 30));
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                exx = ex;
                // MessageBox.Show(ex.Message);
            }
            return false;
        }

        public static bool ISStart(string serviceName)
        {
            bool result = true;
            try
            {
                ServiceController[] services = ServiceController.GetServices();
                foreach (ServiceController service in services)
                {
                    if (service.ServiceName == serviceName)
                    {
                        if ((service.Status == ServiceControllerStatus.Stopped)
                            || (service.Status == ServiceControllerStatus.StopPending))
                        {
                            result = false;
                        }
                    }
                }
            }
            catch { }
            return result;
        }

    }
}
