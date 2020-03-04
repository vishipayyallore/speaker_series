using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace DownloadFiles.Controllers
{
    public class DownloadsController : ApiController
    {

        public IEnumerable<string> Get()
        {
            return new string[] { "Sample.txt", "Sample.xlsx" };
        }

        public HttpResponseMessage Get(string fileName)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);

            string filePath = HttpContext.Current.Server.MapPath("~/Downloads/") + fileName;

            if (!File.Exists(filePath))
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.ReasonPhrase = string.Format("File not found: {0} .", fileName);
                throw new HttpResponseException(response);
            }

            byte[] bytes = File.ReadAllBytes(filePath);
            response.Content = new ByteArrayContent(bytes);

            response.Content.Headers.ContentLength = bytes.LongLength;
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = fileName
            };

            response.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping(fileName));

            return response;
        }


    }
}
