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
		// create node of movie to insert
		BTreeNode newNode = new BTreeNode(movie);

		// make node root if there are no movies
		if (root == null)
        {
			root = newNode;
			count++;
        }
		BTreeNode current = root;

		// traverse the binary tree
		while(current != null)
        {
			if(movie.CompareTo(current.Movie) < 0)
            {
				// set left child of current as newNode
				if(current.LChild == null)
                {
					current.LChild = newNode;
					count++;
					return true;
                }
				// set current node as left child
                else
                {
					current = current.LChild;
                }
            }
			else if(movie.CompareTo(current.Movie) > 0)
            {
				// set right child of current as newNode
				if (current.RChild == null)
				{
					current.RChild = newNode;
					count++;
					return true;
				}
				// set current node as right child
				else
				{
					current = current.RChild;
				}
			}
			// If the new movie is equal to the current node's movie, return false (no duplicates allowed)
			else
			{
				return false;
            }
        }
		return false;
    }




	public bool Delete(IMovie movie)
	{
		return false;

	}



	public IMovie? Search(string movietitle)
	{

		Movie movie = new Movie(movietitle);
		if(root == null)
        {
			return null;
        }
		BTreeNode current = root;

		while(current.Movie.Title != movietitle)
        {
			if (movie.CompareTo(current.Movie) < 0)
			{
				if (current.LChild == null)
				{
					return null;
				}
				else
				{
					current = current.LChild;
				}
			}

			if (movie.CompareTo(current.Movie) > 0)
			{
				if (current.RChild == null)
				{
					return null;
				}
				else
				{
					current = current.RChild;
				}
			}
		}
		return current.Movie;
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





