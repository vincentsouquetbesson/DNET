namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MessageLike")]
    public partial class MessageLike
    {
        public int Id { get; set; }

        public int MessageId { get; set; }

        public int UserId { get; set; }

        public virtual Message Message { get; set; }

        public virtual User User { get; set; }
    }
}
