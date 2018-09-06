namespace FormationDotNet.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MediaBdd : DbContext
    {
        public MediaBdd()
            : base("name=MediaBdd")
        {
        }

        public virtual DbSet<author> authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<book_author> book_author { get; set; }
        public virtual DbSet<publisher> publishers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<author>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<author>()
                .HasMany(e => e.book_author)
                .WithRequired(e => e.author)
                .HasForeignKey(e => e.id_author)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<book_author>()
                .HasMany(e => e.Books)
                .WithOptional(e => e.book_author)
                .HasForeignKey(e => e.author_id);

            modelBuilder.Entity<publisher>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<publisher>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.publisher)
                .HasForeignKey(e => e.publisher_id)
                .WillCascadeOnDelete(false);
        }
    }
}
