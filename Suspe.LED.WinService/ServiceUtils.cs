﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SuspeSys.WinService
{
   public class ServiceUtils
    {
        /// <summary>
        /// 获取服务安装路径
        /// </summary>
        /// <param name="ServiceName"></param>
        /// <returns></returns>
        public static string GetWindowsServiceInstallPath(string ServiceName)
        {
            string key = @"SYSTEM\CurrentControlSet\Services\" + ServiceName;
            string path = Registry.LocalMachine.OpenSubKey(key).GetValue("ImagePath").ToString();
            //替换掉双引号   
            path = path.Replace("\"", string.Empty);

            FileInfo fi = new FileInfo(path);
            return fi.Directory.ToString();
        }
    }
}
