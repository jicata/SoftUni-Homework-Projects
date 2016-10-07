using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLDispenser
{
    class hurrdurr
    {
        static void Main(string[] args)
        {
            //elemBuilder class test zone 
            ElementBuilder hehe = new ElementBuilder("div");
            hehe.AddAttribute("id", "page");
            hehe.AddAttribute("class", "cenzura");
            hehe.AddContent("gaaasimu");
            //overloaded * operator
            Console.WriteLine(hehe * 2);

            //static classes
            Console.WriteLine(HTMLDispatcher.CreateImage("dir.bg", "404", "EmptyPillow"));
            Console.WriteLine(HTMLDispatcher.CreateURL("kaldata.bg", "shano site","KALDATA.BG"));
            Console.WriteLine(HTMLDispatcher.CreateInput("text","FirstName","Gosho ot P."));
        }
    }
}
