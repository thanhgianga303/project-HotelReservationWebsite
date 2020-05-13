using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
namespace HotelReservationWebsite.Controllers
{
    public class ImgController : Controller
    {
        public readonly IWebHostEnvironment _webHost;
        public ImgController(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }
        [HttpPost]
        public async Task<IActionResult> UploadImg(IFormFile imgFile)
        {
            var saveImg = Path.Combine(_webHost.WebRootPath, "Images", imgFile.FileName);
            string imgExt = Path.GetExtension(imgFile.FileName);
            if (imgExt == ".jpg" || imgExt == ".png")
            {
                using (var upLoading = new FileStream(saveImg, FileMode.Create))
                {
                    await imgFile.CopyToAsync(upLoading);
                    ViewData["Message"] = "The Selected File" + imgFile.FileName + "Is Save Successfully";
                }
            }
            else
            {
                ViewData["Message"] = "Only The Image File Types .jpg & .png are allowed";
            }
            return View();
        }
    }
}