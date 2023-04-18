// CAB301 - assignment 2
// An implementation of MovieCollection ADT
// 2023


using System;

//A class that models a node of a binary search tree
//An instance of this class is a node in the binary search tree 
public class BTreeNode
{
	private IMovie movie; // movie
	private BTreeNode? lchild; // reference to its left child 
	private BTreeNode? rchild; // reference to its right child

	public BTreeNode(IMovie movie)
	{
		this.movie = movie;
		lchild = null;
		rchild = null;
	}

	public IMovie Movie
	{
		get { return movie; }
		set { movie = value; }
	}

	public BTreeNode? LChild
	{
		get { return lchild; }
		set { lchild = value; }
	}

	public BTreeNode? RChild
	{
		get { return rchild; }
		set { rchild = value; }
	}
}

// invariant: no duplicate movie in this movie collection
public class MovieCollection : IMovieCollection
{
	private BTreeNode? root; // the root of the binary search tree in which movies are stored 
	private int count; // the number of movies currently stored in this movie collection 



	public int Number { get { return count; } }

	// constructor - create an empty movie collection
	public MovieCollection()
	{
		root = null;
		count = 0;	
	}

	public bool IsEmpty()
	{

		return false;

	}


	public bool Insert(IMovie movie)
	{
		BTreeNode newNode = new BTreeNode(movie);
		if (root == null)
        {
			root = newNode;
			Console.WriteLine("Empty");
			count++;
        }
        else
        {
			Console.WriteLine(root.Movie.Title);
        }
		return false;
    }




	public bool Delete(IMovie movie)
	{
		return false;

	}



	public IMovie? Search(string movietitle)
	{
		return new Movie("");

	}



    public int NoDVDs()
	{
		return 0;
    }

   
    public IMovie[] ToArray()
	{

		return new IMovie[1];

    }


	public void Clear()
	{

        //To be completed by students

    }
}





