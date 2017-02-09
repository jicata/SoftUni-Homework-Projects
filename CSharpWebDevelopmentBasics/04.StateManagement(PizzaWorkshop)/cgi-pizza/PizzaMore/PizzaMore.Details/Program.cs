namespace PizzaMore.Details
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Models;
    using Utility;

    class Program
    {
        private static Session Session;
        static void Main(string[] args)
        {
            Header header = new Header();
            Console.WriteLine(header);
            var context = new PizzaMoreContext();
            var cookies = WebUtil.GetCookies();
            if (!cookies.ContainsKey("sid"))
            {
                WebUtil.PrintFileContent(@"D:\xampp\cgi-bin\cgi-pizza\PizzaMoreAssets\game\index.html");
            }
            else
            {
                int sid = int.Parse(cookies["sid"].Value.ToString());

                Session = context.Sessions.FirstOrDefault(s => s.Id == sid);


                if (Session == null)
                {
                    WebUtil.PrintFileContent(@"D:\xampp\cgi-bin\cgi-pizza\PizzaMoreAssets\game\index.html");
                }
            }


            if (WebUtil.IsGet())
            {


                IDictionary<string, string> parameters = WebUtil.RetrieveGetParameters();
                foreach (var parameter in parameters)
                {
                    Logger.Log($"param: {parameter.Key}={parameter.Value} \n");
                }
                int pizzaId = int.Parse(parameters["pizzaId"]);
                var pizza = context.Pizzas.FirstOrDefault(p => p.Id == pizzaId);
                string link =
                    @"http://localhost/cgi-bin/cgi-pizza/PizzaMore/PizzaMore.SignIn/bin/Debug/PizzaMore.Suggestions.exe";
                Console.WriteLine($@"
<!doctype html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"" />
    <title>PizzaMore - Details</title>
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"" />
	<link rel=""stylesheet"" href=""\bootstrap-3.3.7-dist\css\bootstrap.css"">
	<link rel=""stylesheet"" href=""/css/signin.css"">
</head>
</head>
<body>
	<div class=""container"">
		<div class=""jumbotron"">
			<a class=""btn btn-danger"" href=""{link}"">All Suggestions</a>
            <h3>{pizza.Name}</h3>
			<img src=""{pizza.ImageUrl}"" width=""300px""/>
			<p>{pizza.Recipe}</p>
			<p>Up: {pizza.Upvotes}</p>
			<p>Down: {pizza.Downvotes}</p>
		</div>
	</div>
	<script src=""\..\jquery\jquery-3.1.1.js""></script>
	<script src=""\..\bootstrap-3.3.7-dist\js\bootstrap.js""></script>
</body>
</html>");


            }
        }
    }
}
