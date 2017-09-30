using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoMVC.Models
{
    public class Photo
    {
        [Required]
        public int PhotoID { get; set; }
        [Range(0,10)]
        public string Title { get; set; }
        public byte[] PhotoFile { get; set; }
        public string Description { get; set; }

        [DisplayName("Fecha de creacion")]
        public DateTime CreateDate { get; set; }

        public DateTime FutureDate
        {
            get { return CreateDate.AddDays(2); }
        }

        public string UserName { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }

    public class Comment
    {
        public int CommentID { get; set; }
        public int PhotoID { get; set; }
        public string UserName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public virtual Photo Photo { get; set; }
    }
}