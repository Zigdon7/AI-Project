using System;
using System.Collections.Generic;
using System.Text;

namespace Numerical3DMatching
{
	class Multiset
	{
		public int[] X, Y, Z;
		public int score;
		public Multiset(int[] X, int[] Y, int[] Z, int score = 0)
		{
			this.X = X;
			this.Y = Y;
			this.Z = Z;
			this.score = score;
		}
		public Multiset MutateChild(Multiset child)
		{
			Multiset mutatedChild = child;

			//mutate the child's values here

			return mutatedChild;
		}

		public Multiset Randomize(Multiset init)
		{
			Multiset parent = init;
			Random rand = new Random();
			var xList = new List<int>(parent.X);
			//Console.Write("xList size should be 3: {0}", xList.Capacity);
			var yList = new List<int>(parent.Y);
			var zList = new List<int>(parent.Z);
			for (int i = 0; i < parent.X.Length; i++)
			{
				int randomNum = rand.Next(0,xList.Count);
				parent.X[i] = xList[randomNum];
				xList.RemoveAt(randomNum);
			}
			for (int j = 0; j < parent.Y.Length; j++)
			{
				int randomNum = rand.Next(0, yList.Count);
				parent.Y[j] = yList[randomNum];
				yList.RemoveAt(randomNum);
			}
			for (int k = 0; k < parent.Z.Length; k++)
			{
				int randomNum = rand.Next(0, zList.Count);
				parent.Z[k] = zList[randomNum];
				zList.RemoveAt(randomNum);
			}

			//Console.Write("{0},{1},{2}, {3},{4},{5}, {6},{7},{8} Score: {9}\n", parent.X[0], parent.X[1], parent.X[2], parent.Y[0], parent.Y[1], parent.Y[2], parent.Z[0], parent.Z[1], parent.Z[2], parent.score);

			return parent;
		}
	}
}
