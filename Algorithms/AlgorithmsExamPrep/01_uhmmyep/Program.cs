using System;

public class PartitionProblem
	{
	     public static void Main(string[] args)
	    {
	        PartitionProblem solution = new PartitionProblem();
	        
	        int[] set = { 15, 5, 15, 20, 45 };

	         Console.WriteLine(solution.partitionExists(set));
	         
	    }

	    private bool partitionPossible(int requiredSum, int currIndex, int[] set)
	    {
	         
	        if (requiredSum == 0)
	        {
	            return true;
	        }

	        if (currIndex == set.Length)
	        {
	            return false;
	        }
	        
	         
	        return ( 
	                 partitionPossible(requiredSum-set[currIndex], currIndex+1, set) || 
	                 partitionPossible(requiredSum, currIndex+1, set)
	               );
	    }
	    
	    public bool partitionExists(int[] set)
	    {
	        int sum = 0;
	        for (int i = 0; i<set.Length; i++)
	        {
	            sum += set[i];
	        }
	        
	         
	        if ((sum % 2) != 0)
	        {
	            return false;
	        }
	        
	         
	        return partitionPossible(sum/2, 0, set);
	    }
	    
	    
	}