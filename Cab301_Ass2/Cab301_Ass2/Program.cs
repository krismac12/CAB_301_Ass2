using System;

namespace Cab301_Ass2
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieClassification movieClassification = MovieClassification.PG;
            MovieGenre genre = MovieGenre.Action;
            Movie movie1 = new Movie("ZZZ", genre, movieClassification, 120,200);
            Movie movie2 = new Movie("AAAA");
            Movie movie3 = new Movie("AAA");

            MovieCollection movieCollection = new MovieCollection();
            movieCollection.Insert(movie2);
            movieCollection.Insert(movie3);
            movieCollection.Insert(movie1);


            Console.WriteLine(movieCollection.Search("ZZZ")?.ToString());

        }
    }
}
