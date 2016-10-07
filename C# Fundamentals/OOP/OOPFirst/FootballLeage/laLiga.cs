using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeage
{
    public class laLiga
    {
        static void Main(string[] args)
        {
            string random = "AddPlayerToTeam Levski Pesho Peshev 1914.05.24 133.37";
        try 
	    {	        
		    LeagueManager.HandleInput(random);
            
	    }
	    catch (Exception e)
	    {
		
		    Console.WriteLine(e.Message);
	    }
            Team pesho = new Team("asd", "asd", DateTime.Parse("19.03.2014"));
            Player asd = new Player("asd", "kur", DateTime.Parse("19.03.2012"), 20M);
            
           
        }
    }
}
