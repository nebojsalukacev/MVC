using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace G3_PhotoSharingApplication.Models
{
    public class Photo
    {
        public int PhotoID { get; set; }

        [Required(ErrorMessage = "Naziv slike je obavezan")]
        [DisplayName("Naziv slike")]
        public string Title { get; set; }

        [DisplayName("Slika")]
        public byte[] PhotoFile { get; set; }

        [DisplayName("Tip slike")]
        public string ImageMimeType { get; set; }



        [DisplayName("Opis slike")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName("Datum kreiranja")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yy}")]
        public DateTime CreatedDate { get; set; }

        [DisplayName("Fotograf")]
        public string UserName { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
            
    }
}