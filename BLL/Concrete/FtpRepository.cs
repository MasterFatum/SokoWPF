using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows;

namespace BLL.Concrete
{
     public class FtpRepository
    {
        private string host = "172.20.2.221";
        private string username = "anonymous";
        private string password = "sko@fckrasnodar.ru";
        private FtpWebResponse ftpResponse;
        private FtpWebRequest ftpRequest;
        private bool useSsl = false;

        public void UploadFile(string path, string fileName, string fileNameGuid)
        {
            //Для имени файла
            //string shortName = fileName.Remove(0, fileName.LastIndexOf(@"\", StringComparison.Ordinal) + 1);
            //string shortName = Guid.NewGuid().ToString();


            FileStream uploadedFile = new FileStream(fileName, FileMode.Open, FileAccess.Read);

            ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + host + "/" + path + "/" + fileNameGuid + ".zip");
            ftpRequest.Credentials = new NetworkCredential(username, password);
            ftpRequest.EnableSsl = useSsl;
            ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;

            //Буфер для загружаемых данных
            byte[] file_to_bytes = new byte[uploadedFile.Length];

            //Считываем данные в буфер
            uploadedFile.Read(file_to_bytes, 0, file_to_bytes.Length);

            uploadedFile.Close();

            //Поток для загрузки файла 
            Stream writer = ftpRequest.GetRequestStream();

            writer.Write(file_to_bytes, 0, file_to_bytes.Length);
            writer.Close();

        }

        public void DownloadFile(string path, string filePath, string fileName)
        {

            ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + host + "/" + path + "/" + fileName + ".zip");
            ftpRequest.Credentials = new NetworkCredential(username, password);
            //Команда фтп RETR
            ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
            ftpRequest.EnableSsl = useSsl;
            //Файлы будут копироваться в кталог программы
            FileStream downloadedFile = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
            ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            //Получаем входящий поток
            Stream responseStream = ftpResponse.GetResponseStream();
            //Буфер для считываемых данных
            byte[] buffer = new byte[1024];
            int size = 0;
            while ((size = responseStream.Read(buffer, 0, 1024)) > 0)
            {
                downloadedFile.Write(buffer, 0, size);

            }
            ftpResponse.Close();
            downloadedFile.Close();
            responseStream.Close();
        }
        
        //Метод протокола FTP DELE для удаления файла с FTP-сервера 
        public void DeleteFile(string path, string fileName)
        {
            ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + host + "/" + path + "/" + fileName + ".zip");
            ftpRequest.Credentials = new NetworkCredential(username, password);
            ftpRequest.EnableSsl = useSsl;
            ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;

            FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            ftpResponse.Close();
        }

        //Метод протокола FTP MKD для создания каталога на FTP-сервере 
        public void CreateDirectory(string path)
        {
            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + host + path);

            ftpRequest.Credentials = new NetworkCredential(username, password);
            ftpRequest.EnableSsl = useSsl;
            ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;

            FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            ftpResponse.Close();
        }

        //Метод протокола FTP RMD для удаления каталога с FTP-сервера 
        public void RemoveDirectory(string path)
        {
            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + host + "/" + path);
            ftpRequest.Credentials = new NetworkCredential(username, password);
            ftpRequest.EnableSsl = useSsl;
            ftpRequest.Method = WebRequestMethods.Ftp.RemoveDirectory;

            FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            ftpResponse.Close();
        }
    }
}
