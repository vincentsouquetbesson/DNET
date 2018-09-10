using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork
{
    public class MessageTO
    {
        public int Id { get; set; }
        public UserTO User { get; set; }
        public string Message { get; set; }
        public DateTime? Date { get; set; }
        public List<CommentTO> Commentlist{ get; set; }
        public List<MessageLikeTO> Likelist{ get; set; }
    }
}