using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G3_PhotoSharingApplication.Models;

namespace G3_PhotoSharingApplication.Controllers
{
    public class CommentController : Controller
    {
        PhotoSharingContext context = new PhotoSharingContext();

        [ChildActionOnly]
        public PartialViewResult _CommentsForPhoto(int PhotoId)
        {
            var comments = from c in context.Comments
                           where c.PhotoID == PhotoId
                           select c;
            return PartialView("_CommentsForPhoto", comments.ToList());
        }

        // GET: Comment
       // public ActionResult Index()
        //{
          //  return View();
        //}
    }
}