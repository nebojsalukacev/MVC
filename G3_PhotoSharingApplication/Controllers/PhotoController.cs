using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using G3_PhotoSharingApplication.Models;

namespace G3_PhotoSharingApplication.Controllers
{
    //[Authorize] Moramo biti autorizovani. Ne mozemo da se ulogujemo na stranu.
    public class PhotoController : Controller
    {
        PhotoSharingContext context = new PhotoSharingContext();
        // GET: Photo
        public ActionResult Index()
        {
            // return View("Index", context.Photos.ToList());
            return View("Index");
        }

        public ActionResult Display(int id)
        {
            Photo photo = context.Photos.Find(id);
             if (photo == null)
            {
                return HttpNotFound();
            }
             else
            {
                return View("Display", photo);
            }
        }

      
        public ActionResult Create()
        {
            Photo newPhoto = new Photo();
            newPhoto.CreatedDate = DateTime.Today;
            return View("Create", newPhoto);
        }

        [HttpPost]
        public ActionResult Create(Photo photo, HttpPostedFileBase image)
        {
            photo.CreatedDate = DateTime.Today;
            if (!ModelState.IsValid)
            {
                return View("Create", photo);
            }
            else
            {
                if (image != null)
                {
                    photo.ImageMimeType = image.ContentType;
                    photo.PhotoFile = new byte[image.ContentLength];
                    image.InputStream.Read(photo.PhotoFile, 0, image.ContentLength);
                }
                context.Photos.Add(photo);

                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            Photo photo = context.Photos.Find(id);

            if (photo != null) return HttpNotFound();
            else return View("Delete", photo);
        }

        [HttpPost]
        [ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            Photo photo = context.Photos.Find(id);

            context.Photos.Remove(photo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public FileContentResult GetImage(int id)
        {
            Photo photo = context.Photos.Find(id);
            if (photo != null)
            {
                return File(photo.PhotoFile, photo.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        [ChildActionOnly]
        public ActionResult _PhotoGallery(int number = 0)
        {
            List<Photo> photos;
            if (number == 0)
            {
                photos = context.Photos.ToList();
            }
            else
            {
                photos =
                    (
                    from p in context.Photos
                    orderby p.CreatedDate descending
                    select p).Take(number).ToList();
            }
            return PartialView("_PhotoGallery", photos);
        }

        public ActionResult DisplayByTitle(string title)
        {
            Photo photo = (from p in context.Photos
                           where p.Title == title
                           select p).FirstOrDefault();
            if (photo == null) return HttpNotFound();
            else return View("Display", photo);
        }
    }
}