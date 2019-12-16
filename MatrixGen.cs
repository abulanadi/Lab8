using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
	// This class encompasses my matrix generation methods
	class MatrixGen
	{
		Random random = new Random();

		public int[,] RandomCost(int vertices, int maxCost)
		{
			int[,] adjMatrix = new int[vertices, vertices];
			
			for(int i = 0; i < vertices; i++)
			{
				for(int j = 0; j < i; j++)
				{
					int weight = random.Next(0, maxCost);
					adjMatrix[i, j] = weight;
					adjMatrix[j, i] = weight;
				}
			}

			return adjMatrix;
		}

        
    }
}
