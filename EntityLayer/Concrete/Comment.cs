using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }

        public string CommentAuthor { get; set; }

        public string CommentValue { get; set; }

        public DateTime CommentDate { get; set; }

        public bool CommentStat { get; set; }

        //Relations

        public int DestinationID { get; set; }
        public Destination Destination { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
