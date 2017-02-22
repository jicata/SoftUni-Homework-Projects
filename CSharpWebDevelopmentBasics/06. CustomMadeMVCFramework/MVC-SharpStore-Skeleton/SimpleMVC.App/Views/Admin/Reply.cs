namespace SharpStore.Views.Admin
{
    using System.IO;
    using System.Text;
    using MVCFramework.MVC.Interfaces.Generic;
    using ViewModels;
    public class Reply: IRenderable<MessageViewModel>
    {
        public string Render()
        {

            string messagesTop = File.ReadAllText(@"../../content/products-top-dark.html");
            StringBuilder pageBuilder = new StringBuilder();
            pageBuilder.Append(messagesTop);
            pageBuilder.Append(" <div class=\"row\" <div class=\"container\" style=\"padding-top:30px\">");


            pageBuilder.Append($@"<div class=""col-sm-6"">
            <div id=""tb-testimonial"" class=""testimonial testimonial-primary-filled"">
                <div class=""testimonial-section"">
                  {this.Model.Content}
            	</div>
                <div class=""testimonial-desc"">
                    <img src=""https://placeholdit.imgix.net/~text?txtsize=9&txt=100%C3%97100&w=100&h=100"" alt="""" />
                    <div class=""testimonial-writer"">
                    	<div class=""testimonial-writer-name"">{this.Model.Subject}</div>
                    	<div class=""testimonial-writer-designation"">{this.Model.Sender}</div>
                    </div>
                </div>
            </div>   
		</div>");
            pageBuilder.Append("</div>");
            pageBuilder.Append(@"   <form action=""/admin/reply"" method=""POST"" role=""FORM"" class=""form-vertical"" >
<div class=""form-group"">
                    <label class=""control-label"">Subject</label>
                    <div class=""input-group input-group-lg"">
                        <input type=""text"" class=""form-control"" placeholder=""Subject"" name=""Subject"">
                       
                    </div>
                </div>
                <div class=""form-group"">
                    <label class=""control-label"">Your message</label>
                    <div class=""input-group input-group-lg"">
                        <textarea class=""form-control"" rows=""5"" placeholder=""Enter your text here""id=""comment"" name=""Content""></textarea>
                
                    </div>
                </div>
                <div class=""form-group text-right"">
                    <input type=""submit"" class=""btn btn-primary col-md-2"" value=""Reply"">
                </div>
</form>");

            pageBuilder.Append("</div>");
            pageBuilder.Append("</div>");
            string pageBottom = File.ReadAllText(@"../../content/products-bottom.html");
            pageBuilder.Append(pageBottom);
            return pageBuilder.ToString();
        }

        public MessageViewModel Model { get; set; }
    }
}
