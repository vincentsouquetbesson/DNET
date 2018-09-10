using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork
{
    public class CommentTO
    {
        public int Id { get; set; }
        public UserTO User { get; set; }
        public string Comment { get; set; }
        public DateTime? Date { get; set; }
        public List<LikeCommentTO> Likelist { get; set; }
    }
}