namespace FormationDotNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string title { get; set; }

        [Column(TypeName = "money")]
        public decimal price { get; set; }

        public int? nbPage { get; set; }

        public int publisher_id { get; set; }

        public int? author_id { get; set; }

        public virtual book_author book_author { get; set; }

        public virtual publisher publisher { get; set; }
    }
}
