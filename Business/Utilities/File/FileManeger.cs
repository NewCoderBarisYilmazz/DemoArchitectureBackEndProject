using Microsoft.AspNetCore.Http;
using System.Net;

namespace Business.Utilities
{
    public class FileManeger : IFileService
    {
        public string FileSaveToServer(IFormFile file, string path)
        {
          string guid= Guid.NewGuid().ToString();   
            var fileName=file.FileName.Substring(file.FileName.LastIndexOf('.')).ToLower();
            string combineFile=guid+fileName;
            var copyFile=path+combineFile;
            using (var stream=File.Create(copyFile))
            {
                file.CopyTo(stream);
            }
            return combineFile;


        }

        public string FileSaveToFtp(IFormFile file)
        {
            var fileName = file.FileName.Substring(file.FileName.LastIndexOf('.')).ToLower() ;
            var combineFile=Guid.NewGuid().ToString()+fileName;
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp adresş/dosyamız"+ combineFile);
            request.Credentials = new NetworkCredential("Kullanıcı adı", "Şifre");
            request.Method = WebRequestMethods.Ftp.UploadFile;
            using (Stream ftpstream=request.GetRequestStream())
            {
                file.CopyTo(ftpstream);
            }
            return fileName;
        }

        public byte[] FileSaveToDataBase(IFormFile file)
        {
            using (var memorystream=new  MemoryStream())
            {
                file.CopyTo(memorystream);
                var fileBytes = memorystream.ToArray();
                string fileData = Convert.ToBase64String(fileBytes);
                return fileBytes;

            }
        }
    }
}
