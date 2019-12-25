using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiddingWebAPI.Helpers
{
    public interface IUploadImageHelper
    {
        string SaveImage(string base64Image, string folderName);
    }
}
