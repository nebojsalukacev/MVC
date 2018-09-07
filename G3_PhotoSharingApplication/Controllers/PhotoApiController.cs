using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using G3_PhotoSharingApplication.Models;

namespace G3_PhotoSharingApplication.Controllers
{
    public class PhotoApiController : ApiController
    {
        PhotoSharingContext context = new PhotoSharingContext();

        public IEnumerable<Photo> GetAllPhotos()
        {
            return context.Photos.AsEnumerable();
        }

        public Photo GetPhotoId(int id)
        {
            Photo photo = context.Photos.Find(id);
            if (photo == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            else
                return photo;
        }

        public Photo GetPhotoByTitle(string title)
        {
            Photo photo = (from p in context.Photos
                           where p.Title == title
                           select p).FirstOrDefault();
            if (photo == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            else
                return photo;
        }
    }
}
