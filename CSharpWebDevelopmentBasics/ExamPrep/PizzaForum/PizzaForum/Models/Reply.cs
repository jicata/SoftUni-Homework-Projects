namespace PizzaForum.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Reply
    {
        public int Id { get; set; }

        [ForeignKey("Topic")]
        public int TopicId { get; set; }

        public string Content { get; set; }

        public DateTime? PublishDate { get; set; }

        public string ImageUrl { get; set; }

        public virtual User Author { get; set; }

        public virtual Topic Topic { get; set; }
        

    }
}
