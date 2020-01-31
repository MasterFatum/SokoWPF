using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace BLL.Concrete
{
     public class FtpRepository
    {
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public FtpWebResponse FtpResponse { get; set; }
        public FtpWebRequest FtpRequest { get; set; }
        public bool UseSsl { get; set; }

        public void DownloadFile(string path, string fileName)
        {

            FtpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + Host + path + "/" + fileName);

            FtpRequest.Credentials = new NetworkCredential(Username, Password);

            //Команда фтп RETR
            FtpRequest.Method = WebRequestMethods.Ftp.DownloadFile;

            FtpRequest.EnableSsl = UseSsl;

            //Файлы будут копироваться в кталог программы
            FileStream downloadedFile = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);

            FtpResponse = (FtpWebResponse)FtpRequest.GetResponse();

            //Получаем входящий поток
            Stream responseStream = FtpResponse.GetResponseStream();

            //Буфер для считываемых данных
            byte[] buffer = new byte[1024];
            int size = 0;

            while ((size = responseStream.Read(buffer, 0, 1024)) > 0)
            {
                downloadedFile.Write(buffer, 0, size);

            }
            FtpResponse.Close();
            downloadedFile.Close();
            responseStream.Close();
        }


        public void UploadFile(string path, string fileName)
        {
            //Для имени файла
            string shortName = fileName.Remove(0, fileName.LastIndexOf(@"\", StringComparison.Ordinal) + 1);


            FileStream uploadedFile = new FileStream(fileName, FileMode.Open, FileAccess.Read);

            FtpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + Host + path + shortName);
            FtpRequest.Credentials = new NetworkCredential(Username, Password);
            FtpRequest.EnableSsl = UseSsl;
            FtpRequest.Method = WebRequestMethods.Ftp.UploadFile;

            //Буфер для загружаемых данных
            byte[] file_to_bytes = new byte[uploadedFile.Length];

            //Считываем данные в буфер
            uploadedFile.Read(file_to_bytes, 0, file_to_bytes.Length);

            uploadedFile.Close();

            //Поток для загрузки файла 
            Stream writer = FtpRequest.GetRequestStream();

            writer.Write(file_to_bytes, 0, file_to_bytes.Length);
            writer.Close();
        }

        //Метод протокола FTP DELE для удаления файла с FTP-сервера 
        public void DeleteFile(string path)
        {
            FtpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + Host + path);
            FtpRequest.Credentials = new NetworkCredential(Username, Password);
            FtpRequest.EnableSsl = UseSsl;
            FtpRequest.Method = WebRequestMethods.Ftp.DeleteFile;

            FtpWebResponse ftpResponse = (FtpWebResponse)FtpRequest.GetResponse();
            ftpResponse.Close();
        }

        //Метод протокола FTP MKD для создания каталога на FTP-сервере 
        public void CreateDirectory(string path, string folderName)
        {
            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + Host + path + folderName);

            ftpRequest.Credentials = new NetworkCredential(Username, Password);
            ftpRequest.EnableSsl = UseSsl;
            ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;

            FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            ftpResponse.Close();
        }

        //Метод протокола FTP RMD для удаления каталога с FTP-сервера 
        public void RemoveDirectory(string path)
        {
            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + Host + path);
            ftpRequest.Credentials = new NetworkCredential(Username, Password);
            ftpRequest.EnableSsl = UseSsl;
            ftpRequest.Method = WebRequestMethods.Ftp.RemoveDirectory;

            FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            ftpResponse.Close();
        }
    }
}
