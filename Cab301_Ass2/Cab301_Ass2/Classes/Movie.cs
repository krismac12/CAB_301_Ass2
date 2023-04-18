//CAB301 assessment 2 - 2023
//An implementation of Movie ADT




public class Movie : IMovie
{
    private string title;  // the titleof this movie
    private MovieGenre genre;  // the genre of this movie
    private MovieClassification classification; // the classification of this movie
    private int duration; // the duration of this movie in minutes
    private int availablecopies; // the number of DVDs (copies) of this movie that are currently available in the library
    private int totalcopies; // the total number of copies of this movie
 
  

    // a constructor 
    public Movie(string t, MovieGenre g, MovieClassification c, int d, int n)
    {
        title = t;
        genre = g;
        classification = c;
        duration = d;
        availablecopies = n;
        totalcopies = n;
    }

    // another constructor
    public Movie(string t)
    {
        title = t;
    }

    // get and set the tile of this movie
    public string Title { get { return title; } set { title = value; } }

    //get and set the genre of this movie
    public MovieGenre Genre { get { return genre; } set { genre = value; } }

    //get and set the classification of this movie
    public MovieClassification Classification { get { return classification; } set { classification = value; } }

    //get and set the duration of this movie
    public int Duration { get { return duration; } set { duration = value;  } }

    //get and set the number of DVDs of this movie currently available in the library
    public int AvailableCopies { get { return availablecopies; } set { availablecopies = value;  } }

    //get and set the total number of DVDs of this movie in the library
    public int TotalCopies { get { return totalcopies; } set { totalcopies = value;  } }





    public int CompareTo(IMovie another)
    {
        string title_A = Movie.ToLower(this.Title);
        string title_B = Movie.ToLower(another.Title);

        if (title_A == title_B)
        {
            return 0;
        }

        int shortest_length = 0;
        int comparator = 0;
        if (this.Title.Length < another.Title.Length)
        {
            shortest_length = this.Title.Length;
            comparator = -1;
        }
        else
        {
            shortest_length = another.Title.Length;
            comparator = 1;
        }


        for (int i = 0;i < shortest_length; i++)
        {
            if(title_A[i] > title_B[i])
            {
                return 1;
            }
            else if(title_A[i] < title_B[i])
            {
                return -1;
            }
        }

        return comparator;
    }
    public static string ToLower(string str)
    {
        char[] arr = str.ToCharArray();
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] >= 'A' && arr[i] <= 'Z')
            {
                arr[i] = (char)(arr[i] + 32);
            }
        }
        return new string(arr);
    }


    public string ToString()
    {
        string result = "Title: " + title + "\nGenre: ";
        if(genre != 0)
        {
            result += genre;
        }
        result += "\nClassification: ";

        if (classification != 0)
        {
            result += classification;
        }

        result += "\nDuration: ";

        if (duration != 0)
        {
            result += duration + " minutes";
        }

        result += "\nAvailable Copies: ";

        if (availablecopies != 0)
        {
            result += availablecopies;
        }

        return result;
    }
}

