namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Friend")]
    public partial class Friend
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int UserId { get; set; }

        public int FriendId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
