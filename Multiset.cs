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

        public static int[] Shuffle(int[] array)
        {
            int[] newArray = array;
            for (int i = 1; i < newArray.Length; i++)
            {
                Random rnd = new Random();
                int number = rnd.Next(0, 1); // creates a number between 0 and 1
                if (true)
                {
                    int holder = newArray[i];
                    newArray[i] = newArray[i - 1];
                    newArray[i - 1] = holder;
                }

            }
            return newArray;
        }

		public Multiset MutateChild()
        {
			Multiset mutatedChild = this;

            Random rnd = new Random();
            int number = rnd.Next(0, 2); // creates a number between 0 and 2
            if(number == 0)
            {
                mutatedChild.X = Shuffle(mutatedChild.X);  
            } else if(number== 1) 
            {
                mutatedChild.Y = Shuffle(mutatedChild.Y);  
            }else if (number == 2)
            {
                mutatedChild.Z = Shuffle(mutatedChild.Z);  

            }

			return mutatedChild;
		}

    }
}
