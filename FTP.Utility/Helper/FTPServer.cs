using FluentFTP;
using FTP.Utility.Constant;

namespace FTP.Utility.Helper
{
    public static class FTPServer
    {
      
        public static void ConnectFTPS()
        {
            using (var conn = new FtpClient(FTPConfigs.HostName, FTPConfigs.User, FTPConfigs.Password, FTPConfigs.Port)) {
                conn.Config.EncryptionMode = FtpEncryptionMode.Implicit;
                conn.Config.ValidateAnyCertificate = true;
                conn.Connect();
            }
        }

        public static async Task ConnectFTPSAsync()
        {
            try {
                var token = new CancellationToken();
                using (var conn = new AsyncFtpClient(FTPConfigs.HostName, FTPConfigs.User, FTPConfigs.Password, FTPConfigs.Port)) {

                    //conn.Config.EncryptionMode = FtpEncryptionMode.Implicit;
                    //conn.Config.ValidateAnyCertificate = true;
                    await conn.Connect(token);
                }
            }catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
           
        }

        public static void CreateDirectory()
        {
            using (var conn = new FtpClient(FTPConfigs.HostName, FTPConfigs.User, FTPConfigs.Password)) {
                conn.Connect();
                conn.CreateDirectory("/make/this/happend",true); 
            }
        }

        public static async Task<bool> CreateDirectoryAsync()
        {
            try {

                var token = new CancellationToken();
                using (var conn = new AsyncFtpClient(FTPConfigs.HostName, FTPConfigs.User, FTPConfigs.Password)) {

                    if (!conn.IsConnected) {
                        conn.Config.EncryptionMode = FtpEncryptionMode.Implicit;
                        conn.Config.ValidateAnyCertificate = true;
                        await conn.Connect(token);
                    }
                    
                    bool success = await conn.CreateDirectory("/make/this/happend/", true, token);
                    return success;
                }
            } catch (Exception ex) {
                throw;
                Console.WriteLine(ex.Message);
            }
        }
    }


}
