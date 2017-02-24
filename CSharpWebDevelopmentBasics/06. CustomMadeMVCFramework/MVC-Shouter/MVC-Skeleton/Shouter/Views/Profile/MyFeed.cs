namespace Shouter.Views.Profile
{
    using System.Collections.Generic;
    using MVCFramework.MVC.Interfaces.Generic;
    using ViewModels;
    public class MyFeed : IRenderable<List<ShoutViewModel>>
     {
         public string Render()
         {
            //   < div class="thumbnail">
		    //	<h4><strong>MyUsername<strong>  <small>3 minutes ago</small></h4>
		    //	<p>Shout text goes here</p>
		    //	<input type = "button" class="btn btn-danger" value="Delete"/>
		    //</div>
             throw new System.NotImplementedException();
         }

         public List<ShoutViewModel> Model { get; set; }
     }
}
