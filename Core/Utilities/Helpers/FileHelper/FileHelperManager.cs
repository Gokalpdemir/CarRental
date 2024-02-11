using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filePath)
        {
            if(File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {
           if(File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return this.Upload(file, root);
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(file.FileName); //dosyanın uzantısı
                string guid = Guid.NewGuid().ToString();// string tutulmuş bir guid 
                string filePath = guid + extension; //yeni dosya adı ve uzantısı

                using (FileStream fileStream = File.Create(root + filePath)) //Dosya okuma yazma işlemleri için kullanılan bir sınıftır
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return filePath;
                }
            }
            return null;


        }
    }
}
