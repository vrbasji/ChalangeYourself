using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;

namespace ChalangeYourself.Services
{
    public class ImageService
    {
        private const string defaultImage = "Content/Photos/Users/default_image.png";
        public async Task<string> SaveImage(HttpPostedFileBase postedFile)
        {
            if (postedFile != null && postedFile.ContentLength > 0)
            {
                using (var reader = new BinaryReader(postedFile.InputStream))
                {
                    var content = reader.ReadBytes(postedFile.ContentLength);
                    return SaveFile(content);
                }

            }
            return defaultImage;
        }

        private string SaveFile(byte[] content)
        {
            var serverPath = HostingEnvironment.ApplicationPhysicalPath;
            var photoId = Guid.NewGuid().ToString();
            var path = serverPath+$"Content/Photos/Users/{photoId}.jpg";

            File.WriteAllBytes(path, content);

            return path;
        }
        
    }
}
