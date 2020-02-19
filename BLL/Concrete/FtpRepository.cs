using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows;

namespace BLL.Concrete
{
     public class FtpRepository
    {
        public string Host { get; } = Properties.Settings.Default.FtpServerAddress;
        public string Username { get; } = Properties.Settings.Default.FtpServerUsername;
        public string Password { get; } = Properties.Settings.Default.FtpServerPassword;
        public FtpWebResponse FtpResponse { get; private set; }
        public FtpWebRequest FtpRequest { get; private set; }
        public bool UseSsl { get; } = Properties.Settings.Default.FtpUseSsl;

        //Скачивание файла с FTP сервера
        public void DownloadFile(string path, string localPath, string fileName)
        {
            try
            {
                FtpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + Host + "/" + path + "/" + fileName + ".zip");

                FtpRequest.Credentials = new NetworkCredential(Username, Password);

                //Команда фтп RETR
                FtpRequest.Method = WebRequestMethods.Ftp.DownloadFile;

                FtpRequest.EnableSsl = UseSsl;

                //Файлы будут копироваться в кталог программы
                FileStream downloadedFile = new FileStream(localPath, FileMode.Create, FileAccess.ReadWrite);

                FtpResponse = (FtpWebResponse)FtpRequest.GetResponse();

                //Получаем входящий поток
                Stream responseStream = FtpResponse.GetResponseStream();

                //Буфер для считываемых данных
                byte[] buffer = new byte[1024];

                if (responseStream != null)
                {
                    int size;

                    while ((size = responseStream.Read(buffer, 0, 1024)) > 0)
                    {
                        downloadedFile.Write(buffer, 0, size);
                    }

                    FtpResponse.Close();
                    downloadedFile.Close();
                    responseStream.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        //Загрузка файла на сервер
        public void UploadFile(string path, string fileName, string fileNameGuid)
        {
            try
            {
                FileStream uploadedFile = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                FtpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + Host + "/" + path + "/" + fileNameGuid + ".zip");
                FtpRequest.Credentials = new NetworkCredential(Username, Password);
                FtpRequest.EnableSsl = UseSsl;
                FtpRequest.Method = WebRequestMethods.Ftp.UploadFile;

                //Буфер для загружаемых данных
                byte[] fileToBytes = new byte[uploadedFile.Length];

                //Считываем данные в буфер
                uploadedFile.Read(fileToBytes, 0, fileToBytes.Length);

                uploadedFile.Close();

                //Поток для загрузки файла 
                Stream writer = FtpRequest.GetRequestStream();

                writer.Write(fileToBytes, 0, fileToBytes.Length);
                writer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }


        //Метод протокола FTP DELE для удаления файла с FTP-сервера 
        public void DeleteFile(string path, string fileName)
        {
            try
            {
                FtpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + Host + "/" + path + "/" + fileName + ".zip");
                FtpRequest.Credentials = new NetworkCredential(Username, Password);
                FtpRequest.EnableSsl = UseSsl;
                FtpRequest.Method = WebRequestMethods.Ftp.DeleteFile;

                FtpWebResponse ftpResponse = (FtpWebResponse)FtpRequest.GetResponse();
                ftpResponse.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        //Метод протокола FTP MKD для создания каталога на FTP-сервере 
        public void CreateDirectory(string path)
        {
            try
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + Host + "/" + path);

                ftpRequest.Credentials = new NetworkCredential(Username, Password);
                ftpRequest.EnableSsl = UseSsl;
                ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;

                FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                ftpResponse.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        //Метод протокола FTP RMD для удаления каталога с FTP-сервера 
        public void RemoveDirectory(string path)
        {
            try
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + Host + "/" + path);
                ftpRequest.Credentials = new NetworkCredential(Username, Password);
                ftpRequest.EnableSsl = UseSsl;
                ftpRequest.Method = WebRequestMethods.Ftp.RemoveDirectory;

                FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                ftpResponse.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        //Проверка на существование директории
        public bool ExistDirectory(string directory)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + Host);

                request.Method = WebRequestMethods.Ftp.ListDirectory;

                request.Credentials = new NetworkCredential(Username, Password);

                request.EnableSsl = UseSsl;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();

                if (responseStream != null)
                {
                    StreamReader reader = new StreamReader(responseStream);

                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (directory == line)
                        {
                            return true;
                        }
                    }

                    reader.Close();
                    
                }
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        //Просмотр файлов в директории
        public List<string> DirectoryListing(string path)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + Host + "/" + path);
                request.Credentials = new NetworkCredential(Username, Password);

                request.Method = WebRequestMethods.Ftp.ListDirectory;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();

                List<string> result = new List<string>();
                if (responseStream != null)

                {
                    StreamReader reader = new StreamReader(responseStream);

                    while (!reader.EndOfStream)
                    {
                        result.Add(reader.ReadLine());
                    }
                    reader.Close();
                }

                response.Close();

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        //Удаление директории с файлами
        public void DeleteFtpDirectory(string path)
        {
            try
            {
                FtpWebRequest clsRequest = (FtpWebRequest)WebRequest.Create("ftp://" + Host + "/" + path);

                clsRequest.Credentials = new NetworkCredential(Username, Password);

                List<string> filesList = DirectoryListing(path);

                foreach (string file in filesList)
                {
                    DeleteFile(path, file.Substring(0, file.LastIndexOf('.')));
                }

                clsRequest.Method = WebRequestMethods.Ftp.RemoveDirectory;

                FtpWebResponse response = (FtpWebResponse)clsRequest.GetResponse();

                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

    }
}
