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

	private int NumberOfChildren(BTreeNode node)
	{
		int children = 0;
		if (node.LChild != null)
		{
			children++;
		}
		if (node.RChild != null)
		{
			children++;
		}
		return children;
	}

	private BTreeNode minRChild()
    {
		BTreeNode current = root.RChild;
		while(current.LChild != null)
        {
			current = current.LChild;
        }
		return current;
    }
	public bool Delete(IMovie movie)
	{
		BTreeNode current = root;
		BTreeNode parent = null;

		while (current.Movie != movie)
		{
			parent = current;
			if (movie.CompareTo(current.Movie) < 0)
			{
				if (current.LChild == null)
				{
					return false;
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
					return false;
				}
				else
				{
					current = current.RChild;
				}
			}
		}

		int numChildren = NumberOfChildren(current);

		if (numChildren == 0)
        {
			if (current == root)
			{
				root = null;
				return true;
			}
			else if (parent.LChild == current)
			{
				parent.LChild = null;
				return true;
			}
			else
			{
				parent.RChild = null;
				return true;
			}
		}

		else if (numChildren == 1)
		{
			BTreeNode child = (current.LChild != null) ? current.LChild : current.RChild;
			if (current == root)
			{
				root = child;
				return true;
			}
			else if (parent.LChild == current)
			{
				parent.LChild = child;
				return true;
			}
			else
			{
				parent.RChild = child;
				return true;
			}
		}
        else
        {
			BTreeNode minR = minRChild();
			IMovie minRMovie = minR.Movie;
			Delete(minR.Movie);
			current.Movie = minRMovie;
			return true;
        }
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


	private int recursiveSearch(BTreeNode node)
    {
		if(node == null)
        {
			return 0;
        }
        else
        {
			int LeftSum = recursiveSearch(node.LChild);
			int RightSum = recursiveSearch(node.RChild);
			return node.Movie.TotalCopies + LeftSum + RightSum;
		}
    }
    public int NoDVDs()
	{
		return recursiveSearch(root);
    }

    public IMovie[] ToArray()
	{
		if (root == null)
		{
			return new IMovie[0];
		}
		else
		{
			IMovie[] result = new IMovie[this.count];
			int index = 0;
			fill_array_in_order(root, result, ref index);
			return result;
		}

	}

	private static void fill_array_in_order(BTreeNode node, IMovie[] result, ref int index)
	{
		if (node != null)
		{
			fill_array_in_order(node.LChild, result, ref index);
			result[index] = node.Movie;
			index++;
			fill_array_in_order(node.RChild, result, ref index);
		}
	}

	private void ClearRecursive(BTreeNode node)
	{
		if (node == null)
		{
			return;
		}

		ClearRecursive(node.LChild);
		ClearRecursive(node.RChild);

		node.LChild = null;
		node.RChild = null;

		count--;
	}
	public void Clear()
	{
		if (root == null)
		{
			return;
		}

		ClearRecursive(root.LChild);
		ClearRecursive(root.RChild);

		root.LChild = null;
		root.RChild = null;

		root = null;

		count--;

	}
}





