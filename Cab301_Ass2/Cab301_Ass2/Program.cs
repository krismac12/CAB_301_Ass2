using System;

namespace Cab301_Ass2
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieClassification movieClassification = MovieClassification.PG;
            MovieGenre genre = MovieGenre.Action;
            Movie movie1 = new Movie("A Movie",MovieGenre.Action,MovieClassification.G,120,10);
            Movie movie2 = new Movie("B Movie", MovieGenre.Action, MovieClassification.G, 120, 20);
            Movie movie3 = new Movie("C Movie", MovieGenre.Action, MovieClassification.G, 120, 0);
            Movie movie4 = new Movie("D Movie", MovieGenre.Action, MovieClassification.G, 120, 10);



            MovieCollection movieCollection = new MovieCollection();
            movieCollection.Insert(movie2);
            movieCollection.Insert(movie1);
            movieCollection.Insert(movie3);
            movieCollection.Insert(movie4);




            Console.WriteLine(movieCollection.NoDVDs());



        }
    }
}
