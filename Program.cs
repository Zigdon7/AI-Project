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
            initialSet = initialSet.MutateChild();
            initialSet.print();

			//Create Children
				//if child needs to be mutated, call Mutate Function


			//Mutator Function


			//end
			Console.WriteLine("Hello World!");
			Console.ReadKey(true);
        }
    }

}
