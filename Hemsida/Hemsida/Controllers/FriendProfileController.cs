using Hemsida.Data.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hemsida.Controllers
{
    public class FriendProfileController : Controller
    {
        HemsidaEntities db = new HemsidaEntities();
        public ActionResult OtherUserProfile(Guid id)
        {
            var profile = new UserInfo(id);
            ViewBag.Profile = profile;
            ViewBag.id = id;
            return View(profile);
        }
        public FileContentResult OtherProfilePhoto(Guid id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id == null)
                {
                    string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");
                    byte[] imageData = null;
                    FileInfo fileInfo = new FileInfo(fileName);
                    long imageFileLength = fileInfo.Length;
                    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    imageData = br.ReadBytes((int)imageFileLength);
                    return File(imageData, "image/png");
                }
                
                // to get the user details to load user Image
                var getUserinfo = db.UserInfo.Where(u => u.id == id).FirstOrDefault();
                if(getUserinfo.Img != null)
                {
                return new FileContentResult(getUserinfo.Img, "image/jpeg");
                }
                else
                {
                    string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");
                    byte[] imageData = null;
                    FileInfo fileInfo = new FileInfo(fileName);
                    long imageFileLength = fileInfo.Length;
                    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    imageData = br.ReadBytes((int)imageFileLength);
                    return File(imageData, "image/png");
                }

            }
            else
            {
                string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");

                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(fileName);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);
                return File(imageData, "image/png");
            }
        }
    }
}