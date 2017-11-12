using System;

namespace Numerical3DMatching
{
    class Program
    {
        static void Main(string[] args)
        {
			int checkSum = 0;
			int b = 10;
			int[] X = {3,4,4 };
			int[] Y = {1,4,6 };
			int[] Z = {1,2,5 };
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
			if (checkSum == X.Length * b)
			{
				Console.WriteLine("Check sum checks out.");
			}



			Console.WriteLine("Hello World!");
			Console.ReadKey(true);
        }
    }

}
