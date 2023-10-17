using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTP.Utility.Constant
{
    internal static class FTPConfigs
    {
        public static string HostName { get; set; } = "127.0.0.1";
        public static int Port { get; set; } = 21;
        public static string User { get; set; } = "YOUR_USER_NAME";
        public static string Password { get; set; } = "PASSOWERD";


    }
}
