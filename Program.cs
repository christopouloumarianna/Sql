using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Msql();
            db.M1sql();
            //var x1 = new SimpleText();
            //x1.LoadText("file.txt");
            Console.ReadLine();
        }
    }
}