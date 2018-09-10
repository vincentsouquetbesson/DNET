namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CommentLike")]
    public partial class CommentLike
    {
        public int Id { get; set; }

        public int CommentId { get; set; }

        public int UserId { get; set; }

        public virtual MessageComment MessageComment { get; set; }

        public virtual User User { get; set; }
    }
}
