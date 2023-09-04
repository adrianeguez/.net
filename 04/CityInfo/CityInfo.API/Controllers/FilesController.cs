using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;
        public FilesController(
            FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider;
        }
        [HttpGet("fileId")]
        public ActionResult GetFile(string  fileId)
        {
            Console.WriteLine(fileId);
            var pathToFile = "sample.pdf";
            if(!System.IO.File.Exists(pathToFile))
            {
                return NotFound(new JsonResult(new { message = "File not found" }));
            }
            if(!_fileExtensionContentTypeProvider.TryGetContentType(pathToFile, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            var bytes = System.IO.File.ReadAllBytes(pathToFile);
            return File(bytes, contentType, DateTime.Now + "_" + Path.GetFileName(pathToFile));
        }
    }
}
