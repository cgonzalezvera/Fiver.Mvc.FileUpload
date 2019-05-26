using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiver.Mvc.FileUpload.Controllers
{
    [Route("api/file")]
    public class FileController : Controller
    {
        
        [Route("test/{value}")]
        public int Index(int value)
        {
            return value * 3;
        }
        
        // IMPORTANT: 'key' must match 'parameter name' in controller action

        /*
            Postman:
                Url: <host>/api/values/uploadfile
                Verb: POST
                Body: form-data
                        key (file): file
                        value: selected file
                Headers: 'multipart/form-data' is set implicitly, no need to add manually
        */
        [HttpPost("UploadFile")]
        public IActionResult UploadFile(IFormFile file)
            => Ok(file.Length);

        /*
           Postman:
               Url: <host>/api/values/uploadfiles
               Verb: POST
               Body: form-data
                       key (file): files
                       value: selected files
               Headers: 'multipart/form-data' is set implicitly, no need to add manually
       */
        [HttpPost("UploadFiles")]
        public IActionResult UploadFiles(List<IFormFile> files) // or IFormFileCollection
            => Ok(files.Sum(file => file.Length));
    }
}