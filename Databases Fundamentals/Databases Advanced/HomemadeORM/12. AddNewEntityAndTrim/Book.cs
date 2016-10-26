namespace _12.AddNewEntityAndTrim
{
    using System;
    using System.Data;
    using HomemadeORM.Attributes;

    [Entity("Books")]
    public class Book
    {
        [Id]
        private int id;

        [Column("Title")]
        private string title;

        [Column("Author")]
        private string author;

        [Column("PublishedOn")]
        private DateTime publishedOn;

        [Column("Language")]
        private string language;

        [Column("IsHardCovered")]
        private bool isHardCovered;

        [Column("Rating")]
        private int rating;

        public Book(string title, string author, DateTime publishedOn, string language, bool isHardCovered, int rating)
        {
            this.Title = title;
            this.Author = author;
            this.PublishedOn = publishedOn;
            this.Language = language;
            this.IsHardCovered = isHardCovered;
            this.Rating = rating;
        }

        public int Id
        {
            get
            {
                return id;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Author
        {
            get
            {
                return author;
            }

            set
            {
                author = value;
            }
        }

        public DateTime PublishedOn
        {
            get
            {
                return publishedOn;
            }

            set
            {
                publishedOn = value;
            }
        }

        public string Language
        {
            get
            {
                return language;
            }

            set
            {
                language = value;
            }
        }

        public bool IsHardCovered
        {
            get
            {
                return isHardCovered;
            }

            set
            {
                isHardCovered = value;
            }
        }

        public int Rating
        {
            get
            {
                return this.rating;
            }

            set
            {
                if (value < 0 || value > 10)
                {
                    this.rating = 0;
                }
                else
                {
                    this.rating = value;
                }
            }
        }

        public override string ToString()
        {
            return this.Title;
        }
    }
}
