using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity; //dodali

namespace G3_PhotoSharingApplication.Models
{
    public class PhotoSharingContext:DbContext
    {
        public PhotoSharingContext() : base("G3_PhotoSharingDB")
        {
         
        }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}