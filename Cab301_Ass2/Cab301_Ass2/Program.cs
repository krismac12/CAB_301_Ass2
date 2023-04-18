using System;

namespace Cab301_Ass2
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieClassification movieClassification = MovieClassification.PG;
            MovieGenre genre = MovieGenre.Action;
            Movie movie1 = new Movie("They\'re Title", genre, movieClassification, 120,200);
            Movie movie2 = new Movie("Jurassic Park III");


            Console.WriteLine(movie1.ToString());

        }
    }
}
