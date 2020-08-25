using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using WebGrease.Extensions;

namespace Vidly2
{
    public class RawQueries
    {
        public static void Main(String[] args)
        {

            MyDBContext db = new MyDBContext();

            //Ex for reading data 
           IEnumerable<Movie> movies =  db.Movies.SqlQuery("Select from Movies where id=1");

            //And then we display it
            foreach(Movie m in movies)
            {
                Console.WriteLine("{0}", m.Name);
            }
        }
    }
}