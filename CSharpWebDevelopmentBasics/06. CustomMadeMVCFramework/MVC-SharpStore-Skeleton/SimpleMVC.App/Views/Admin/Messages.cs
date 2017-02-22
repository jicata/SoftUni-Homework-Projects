    namespace SharpStore.Views.Admin
    {
        using System.Collections.Generic;
        using System.IO;
        using System.Text;
        using MVCFramework.MVC.Interfaces.Generic;
        using ViewModels;
        public class Messages:IRenderable<List<MessageViewModel>>
        {
            public string Render()
            {
                string messagesTop = File.ReadAllText(@"../../content/products-top-dark.html");
                StringBuilder pageBuilder = new StringBuilder();
                pageBuilder.Append(messagesTop);
                pageBuilder.Append(" <div class=\"row\" <div class=\"container\" style=\"padding-top:30px\"> ");

                foreach (var messageViewModel in Model)
                {
                    pageBuilder.Append($@"<div class=""col-sm-6"">
                <div id=""tb-testimonial"" class=""testimonial testimonial-primary-filled"">
                    <div class=""testimonial-section"">
                      {messageViewModel.Content}
            	    </div>
                    <div class=""testimonial-desc"">
                        <img src=""https://placeholdit.imgix.net/~text?txtsize=9&txt=100%C3%97100&w=100&h=100"" alt="""" />
                        <div class=""testimonial-writer"">
                    	    <div class=""testimonial-writer-name"">{messageViewModel.Subject}</div>
                    	    <div class=""testimonial-writer-designation"">{messageViewModel.Sender}</div>
                        </div>
                    </div>
                    <form method=""GET"" action=""/admin/reply"" >
                            <input type=""submit"" class=""btn btn-success"" value=""Reply"" style=""margin-top:1px"">
                            <input type=""hidden"" name=""content"" value=""{messageViewModel.Content}"">
                    </form>
                </div>   
		    </div>");
                }

                pageBuilder.Append("</div>");
                pageBuilder.Append("</div>");
                string pageBottom = File.ReadAllText(@"../../content/products-bottom.html");
                pageBuilder.Append(pageBottom);
                return pageBuilder.ToString();
            }

            public List<MessageViewModel> Model { get; set; }
        }
    }
