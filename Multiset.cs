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
	}
}
