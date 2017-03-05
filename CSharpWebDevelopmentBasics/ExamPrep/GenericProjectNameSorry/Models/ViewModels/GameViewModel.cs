namespace SoftUniStore.Models.ViewModels
{
    using System.Linq;

    public class GameViewModel
    { 
        public string Title { get; set; }

        public string Price { get; set; }

        public string Size { get; set; }

        public string Description { get; set; }

        public string Id { get; set; }

        public string ImageUrl { get; set; }

        public override string ToString()
        {
            string template =
                $@"  <div class=""card col-4 thumbnail"">
                      <img class=""card-image-top img-fluid img-thumbnail"" src=""{this.ImageUrl}"">

                        <div class=""card-block"">
                            <h4 class=""card-title"">{this.Title}</h4>
                            <p class=""card-text""><strong>Price</strong> - {this.Price}&euro;</p>
                            <p class=""card-text""><strong>Size</strong> - {this.Size} GB</p>
                            <p class=""card-text"">{this.Description.Substring(0,300).Trim()}...</p>
                        </div>

                        <div class=""card-footer"">
                            <a class=""card-button btn btn-outline-primary"" name=""info"" href=""/home/details?id={this.Id}"">Info</a>
                        </div>
                      </div>";
            return template;
        }
    }
}
