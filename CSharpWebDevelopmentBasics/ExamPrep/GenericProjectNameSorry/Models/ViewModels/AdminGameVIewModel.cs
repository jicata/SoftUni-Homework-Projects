namespace SoftUniStore.Models.ViewModels
{
    public class AdminGameViewModel
    {
        public string Title { get; set; }

        public string Size { get; set; }

        public string Price { get; set; }

        public string Id { get; set; }


        public override string ToString()
        {
            string template = $@"<tr>
                        <td>{this.Title}</td>
                        <td>{this.Size} GB</td>
                        <td>{this.Price} &euro;</td>
                        <td>
                            <a href=""/games/edit?id={this.Id}"" class=""btn btn-warning btn-sm"">Edit</a>
                            <a href=""/games/delete?id={this.Id}"" class=""btn btn-danger btn-sm"">Delete</a>
                        </td>
                    </tr>";
            return template;
        }
    }
}
