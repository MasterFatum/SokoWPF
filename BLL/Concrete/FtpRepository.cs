using System.IO;
using System.Net;

namespace BLL.Concrete
{
     public class FtpRepository
    {
        public string Host { get; } = "172.20.2.221";
        public string Username { get; } = "anonymous";
        public string Password { get; } = "sko@fckrasnodar.ru";
        private FtpWebResponse ftpResponse;
        private FtpWebRequest ftpRequest;
        public bool UseSsl { get; } = false;

        public void DownloadFile(string path, string fileName)
        {

            ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + Host + path + "/" + fileName);

            ftpRequest.Credentials = new NetworkCredential(Username, Password);

            //Команда фтп RETR
            ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;

            ftpRequest.EnableSsl = UseSsl;

            //Файлы будут копироваться в кталог программы
            FileStream downloadedFile = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);

            ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();

            //Получаем входящий поток
            Stream responseStream = ftpResponse.GetResponseStream();

            //Буфер для считываемых данных
            byte[] buffer = new byte[1024];
            int size;

            while ((size = responseStream.Read(buffer, 0, 1024)) > 0)
            {
                downloadedFile.Write(buffer, 0, size);

            }
            ftpResponse.Close();
            downloadedFile.Close();
            responseStream.Close();
        }


        public void UploadFile(string path, string fileName, string fileNameGuid)
        {
            //Для имени файла
            //string shortName = fileName.Remove(0, fileName.LastIndexOf(@"\", StringComparison.Ordinal) + 1);
            //string shortName = Guid.NewGuid().ToString();


            FileStream uploadedFile = new FileStream(fileName, FileMode.Open, FileAccess.Read);

            ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + Host + path + fileNameGuid + ".zip");
            ftpRequest.Credentials = new NetworkCredential(Username, Password);
            ftpRequest.EnableSsl = UseSsl;
            ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;

            //Буфер для загружаемых данных
            byte[] fileToBytes = new byte[uploadedFile.Length];

            //Считываем данные в буфер
            uploadedFile.Read(fileToBytes, 0, fileToBytes.Length);

            uploadedFile.Close();

            //Поток для загрузки файла 
            Stream writer = ftpRequest.GetRequestStream();

            writer.Write(fileToBytes, 0, fileToBytes.Length);
            writer.Close();
        }


        //Метод протокола FTP DELE для удаления файла с FTP-сервера 
        public void DeleteFile(string path, string fileName)
        {
            ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + Host + path + fileName + ".zip");
            ftpRequest.Credentials = new NetworkCredential(Username, Password);
            ftpRequest.EnableSsl = UseSsl;
            ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;

            FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            ftpResponse.Close();
        }

        //Метод протокола FTP MKD для создания каталога на FTP-сервере 
        public void CreateDirectory(string path)
        {
            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + Host + path);

            ftpRequest.Credentials = new NetworkCredential(Username, Password);
            ftpRequest.EnableSsl = UseSsl;
            ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;

            FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            ftpResponse.Close();
        }

        //Метод протокола FTP RMD для удаления каталога с FTP-сервера 
        public void RemoveDirectory(string path)
        {
            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + Host + "/" + path);
            ftpRequest.Credentials = new NetworkCredential(Username, Password);
            ftpRequest.EnableSsl = UseSsl;
            ftpRequest.Method = WebRequestMethods.Ftp.RemoveDirectory;

            FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            ftpResponse.Close();
        }
    }
}
