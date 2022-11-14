using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities
{
    public  interface IFileService
    {
        string FileSaveToServer(IFormFile file,string path);
        string FileSaveToFtp(IFormFile file);
        byte [] FileSaveToDataBase(IFormFile file);


    }
}
