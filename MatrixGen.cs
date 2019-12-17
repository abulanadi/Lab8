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

		public double[,] EuclideanCost(int vertices, int maxRange)
		{
			double[,] distanceMatrix = new double[vertices, vertices];

			for(int i = 0; i < vertices; i++)
			{
				for(int j = 0; j < i; j++)
				{
					double x1 = random.NextDouble() * maxRange;
					double y1 = random.NextDouble() * maxRange;
					double x2 = random.NextDouble() * maxRange;
					double y2 = random.NextDouble() * maxRange;

					var distanceValue = Math.Sqrt(((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)));

					distanceMatrix[i, j] = Math.Round(distanceValue, 2, MidpointRounding.AwayFromZero);
					distanceMatrix[j, i] = Math.Round(distanceValue, 2, MidpointRounding.AwayFromZero);
				}
			}
			return distanceMatrix;
		}

		public double[,] CircularCost(int vertices, int radius)
		{
			double[,] circleMatrix = new double[vertices, vertices];
			double[] x = new double[vertices];
			double[] y = new double[vertices];

			double stepAngle = (2 * Math.PI) / vertices;

			for(int i = 0; i < vertices; i++)
			{
				x[i] = radius * Math.Sin(i * stepAngle);
				y[i] = radius * Math.Cos(i * stepAngle);
			}
			for(int i = 0; i < vertices; i++)
			{
				for(int j = 0; j < i; j++)
				{
					var distanceValue = Math.Sqrt(((x[i] - x[j]) * (x[i] - x[j]) + (y[i] - y[j]) * (y[i] - y[j])));
					circleMatrix[i, j] = Math.Round(distanceValue, 2, MidpointRounding.AwayFromZero);
					circleMatrix[j, i] = Math.Round(distanceValue, 2, MidpointRounding.AwayFromZero);
				}
			}
			return circleMatrix;
		}

    }
}
