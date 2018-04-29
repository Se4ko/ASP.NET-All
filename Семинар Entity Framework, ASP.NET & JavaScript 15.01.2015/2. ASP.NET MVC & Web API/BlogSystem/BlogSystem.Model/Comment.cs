namespace BlogSystem.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment : IEntity
    {
        public Comment()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public string Content { get; set; }

        public DateTime CommentedOn { get; set; }

        public bool IsPaid { get; set; }

        public string Title { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
