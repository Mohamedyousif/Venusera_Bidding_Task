using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BiddingWebAPI.Helpers
{
    public class UploadImageHelper : IUploadImageHelper
    {
        public string SaveImage(string base64Image,string folderName)
        {
            var bytes = Convert.FromBase64String(base64Image);
            
            // full path to file in current project location
            string filedir = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Files\RequestImages\" + folderName);

            if (!Directory.Exists(filedir))
            { //check if the folder exists;
                Directory.CreateDirectory(filedir);
            }
            Guid name = Guid.NewGuid();
            string file = Path.Combine(filedir, name.ToString() + ".jpg");

            if (bytes.Length > 0)
            {
                using (var stream = new FileStream(file, FileMode.Create))
                {
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Flush();
                }
            }
            return @$"~\Files\RequestImages\{folderName}\{name.ToString()}.jpg";
        }
    }
}
