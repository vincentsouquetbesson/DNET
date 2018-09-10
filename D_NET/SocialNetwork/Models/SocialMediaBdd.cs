namespace SocialNetwork.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SocialMediaBdd : DbContext
    {
        public SocialMediaBdd()
            : base("name=SocialMediaBdd")
        {
        }

        public virtual DbSet<CommentLike> CommentLike { get; set; }
        public virtual DbSet<Friend> Friend { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<MessageComment> MessageComment { get; set; }
        public virtual DbSet<MessageLike> MessageLike { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .Property(e => e.Message1)
                .IsUnicode(false);

            modelBuilder.Entity<Message>()
                .HasMany(e => e.MessageComment)
                .WithRequired(e => e.Message)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .HasMany(e => e.MessageLike)
                .WithRequired(e => e.Message)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MessageComment>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<MessageComment>()
                .HasMany(e => e.CommentLike)
                .WithRequired(e => e.MessageComment)
                .HasForeignKey(e => e.CommentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Mail)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.CommentLike)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Friend)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Friend1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.FriendId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Message)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.MessageComment)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.MessageLike)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
