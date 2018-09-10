using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork
{
    public class LikeCommentTO
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }
    }
}