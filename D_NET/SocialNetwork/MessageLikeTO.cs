using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork
{
    public class MessageLikeTO
    {
        public int Id { get; set; }
        public int MessageId { get; set; }
        public int UserId { get; set; }
    }
}