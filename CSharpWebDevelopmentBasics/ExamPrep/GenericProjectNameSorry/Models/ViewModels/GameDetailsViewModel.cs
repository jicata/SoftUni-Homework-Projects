namespace SoftUniStore.Models.ViewModels
{
    public class GameDetailsViewModel
    {
        public bool IsUserLogged { get; set; }

        public string Title { get; set; }

        public string Price { get; set; }

        public string Size { get; set; }

        public string Description { get; set; }

        public string Id { get; set; }

        public string TrailerUrl { get; set; }

        public string ReleaseDate { get; set; }

        public override string ToString()
        {
            string urlTemplate = "https://www.youtube.com/embed/" + $"{this.TrailerUrl}";
            string template = $@"  <h1 class=""display-3"">{this.Title}</h1>
                <br/>
                     <iframe width=""560"" height=""315"" src=""{urlTemplate}"" frameborder=""0"" allowfullscreen></iframe>
                  <br/>
                <br/>

                <p>{this.Description}</p>

                <p><strong>Price</strong> - {this.Price}&euro;</p>
                <p><strong>Size</strong> - {this.Size} GB</p>
                <p><strong>Release Date</strong> - {this.ReleaseDate}</p>

                <a class=""btn btn-outline-primary"" name=""back"" href=""/home/index"">Back</a>
                <form action=""/home/buy"" method=""post"">
                    <input type=""number"" value=""{this.Id}"" hidden=""hidden"" name=""id"" />
                    <br/>
                    <input type=""submit"" class=""btn btn-success"" value=""Buy"" />
                </form>
                <br/>
                <br/>";
            return template;
        }
    }
}
