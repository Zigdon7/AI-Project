using System;

namespace Numerical3DMatching
{
    class Program
    {
		static void Main(string[] args)
		{
			//init
			int checkSum = 0;
			int b = 10;
			int[] X = { 3, 4, 4 };
			int[] Y = { 1, 4, 6 };
			int[] Z = { 1, 2, 5 };
			foreach (int x in X)
			{
				checkSum = checkSum + x;
			}
			foreach (int y in Y)
			{
				checkSum = checkSum + y;
			}
			foreach (int z in Z)
			{
				checkSum = checkSum + z;
			}
			//check if valid
			if (checkSum == X.Length * b)
			{
				Console.WriteLine("Check sum checks out.");
			}
			//Randomly create 1000k parents
			Multiset initialSet = new Multiset(X, Y, Z);
			//Console.Write("{{0},{1},{2}}, {{3},{4},{5}}, {{6},{7},{8}} Score: {9}/n", initialSet.X[0], initialSet.X[1], initialSet.X[2], initialSet.Y[0], initialSet.Y[1],initialSet.Y[2], initialSet.Z[0],initialSet.Z[1],initialSet.Z[2],initialSet.score);


			//Create Children
				//if child needs to be mutated, call Mutate Function


			//Mutator Function


			//end
			Console.WriteLine("Hello World!");
			Console.ReadKey(true);
        }
    }

}
