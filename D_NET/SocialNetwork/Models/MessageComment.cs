namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MessageComment")]
    public partial class MessageComment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MessageComment()
        {
            CommentLike = new HashSet<CommentLike>();
        }

        public int Id { get; set; }

        public int MessageId { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Comment { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommentLike> CommentLike { get; set; }

        public virtual Message Message { get; set; }

        public virtual User User { get; set; }
    }
}
