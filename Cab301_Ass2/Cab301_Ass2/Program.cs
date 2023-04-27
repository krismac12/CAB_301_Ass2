using System;

namespace Cab301_Ass2
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieClassification movieClassification = MovieClassification.PG;
            MovieGenre genre = MovieGenre.Action;
            Movie movie1 = new Movie("A Movie");
            Movie movie2 = new Movie("B Movie");
            Movie movie3 = new Movie("C Movie");
            Movie movie4 = new Movie("D Movie");



            MovieCollection movieCollection = new MovieCollection();
            movieCollection.Insert(movie2);
            movieCollection.Insert(movie1);
            movieCollection.Insert(movie3);




            Console.WriteLine(movieCollection);
            movieCollection.Clear();
            Console.WriteLine(movieCollection);



        }
    }
}
