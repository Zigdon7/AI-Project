using System;
using System.Collections.Generic;
using System.Text;

namespace Numerical3DMatching
{

	class Multiset
	{
		public int[] X, Y, Z;
		public int score;
		public Multiset(int[] X, int[] Y, int[] Z, int b = 0)
		{
			this.X = X;
			this.Y = Y;
			this.Z = Z;
            this.score = 0;
            for (int i = 0; i < X.Length; i++)
            {
                this.score += Math.Abs(X[i] + Y[i] + Z[i] - Global.b());
            }
		}

        private static int[] Shuffle(int[] array)
        {
            int[] newArray = array;
            for (int i = 1; i < newArray.Length; i++)
            {
                Random rnd = new Random();
                int number = rnd.Next(0, 2); // creates a number between 0 and 1
                if (number == 1)
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
            int number = rnd.Next(0, 3); // creates a number between 0 and 2
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

        public void print()
        {
            //Console.Write("{0},{1},{2}, {3},{4},{5}, {6},{7},{8} Score: {9}/n", initialSet.X[0], initialSet.X[1], initialSet.X[2], initialSet.Y[0], initialSet.Y[1], initialSet.Y[2], initialSet.Z[0], initialSet.Z[1], initialSet.Z[2], initialSet.score);
            Console.Write("X: ");
            for (int i = 0; i < this.X.Length; i++)
            {
                if(i != 0){
                    Console.Write(", ");
                }
                Console.Write("{0}", this.X[i]);
            }
            Console.Write("\nY: ");
            for (int i = 0; i < this.Y.Length; i++)
            {
                if (i != 0)
                {
                    Console.Write(", ");
                }
                Console.Write("{0}", this.Y[i]);
            }
            Console.Write("\nZ: ");
            for (int i = 0; i < this.Z.Length; i++)
            {
                if (i != 0)
                {
                    Console.Write(", ");
                }
                Console.Write("{0}", this.Z[i]);
            }
            Console.Write("\nScore: {0}\n", this.score);

        }

        public Boolean CheckSolvability(int b)
        {
            Boolean isSolveable = true;
            if (this.X.Length != this.Y.Length || this.Y.Length != this.Z.Length || this.X.Length != this.Z.Length)
            {
                isSolveable = false;
                Console.Write("Some sets are not the same length \n This will not try to be solved. \n");
            }
            else
            {
                Console.Write("All sets are the same length \n");
                int checkSum = b * this.X.Length;

                foreach (int x in this.X)
                {
                    checkSum = checkSum - x;
                }
                foreach (int y in this.Y)
                {
                    checkSum = checkSum - y;
                }
                foreach (int z in this.Z)
                {
                    checkSum = checkSum - z;
                }
                //check if valid
                if (checkSum == 0)
                {
                    Console.WriteLine("Check sum checks out. This will now try to be solved. \n");
                } else{
                    Console.WriteLine("Check sum does not check out. This will not try to be solved. \n");
                    isSolveable = false;
                }


            }

            return isSolveable;
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
			//parent.print();
			//Console.Write("{0},{1},{2}, {3},{4},{5}, {6},{7},{8} Score: {9}\n", parent.X[0], parent.X[1], parent.X[2], parent.Y[0], parent.Y[1], parent.Y[2], parent.Z[0], parent.Z[1], parent.Z[2], parent.score);

			return parent;
		}
	}
}
