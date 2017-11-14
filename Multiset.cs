using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Numerical3DMatching
{

	public class Multiset
	{
		public int[] X, Y, Z;
		public int totalScore;
        public Multiset(int[] X = null , int[] Y = null, int[] Z = null)
		{
			this.X = X;
			this.Y = Y;
			this.Z = Z;
            this.totalScore = 0;
            for (int i = 0; i < X.Length; i++)
            {
                this.totalScore += Math.Abs(X[i] + Y[i] + Z[i] - Global.b());
            }
            CheckScore(this);

		}

        private static void CheckScore(Multiset ms){
            if(ms.totalScore == 0){
                Console.WriteLine("Perfect Solution Found: ");
                Node.print(ms.ToNodeList());
                Console.ReadKey(true);
            }
        }

        public static int[] Shuffle(int[] array)
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
            CheckScore(mutatedChild);
			return mutatedChild;
		}

        public void print()
        {
            Console.Write("{");
            for (int i = 0; i < this.X.Length; i++)
            {
                if(i != 0){
                    Console.Write(", ");
                }
                Console.Write("{0}", this.X[i]);
            }
            Console.Write("},{");
            for (int i = 0; i < this.Y.Length; i++)
            {
                if (i != 0)
                {
                    Console.Write(", ");
                }
                Console.Write("{0}", this.Y[i]);
            }
            Console.Write("},{");
            for (int i = 0; i < this.Z.Length; i++)
            {
                if (i != 0)
                {
                    Console.Write(", ");
                }
                Console.Write("{0}", this.Z[i]);
            }
            Console.Write("}} Total Score: {0}\n", this.totalScore);

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
                int checkSum = 0;

                foreach (int x in this.X)
                {
                    checkSum = checkSum + x;
                }
                foreach (int y in this.Y)
                {
                    checkSum = checkSum + y;
                }
                foreach (int z in this.Z)
                {
                    checkSum = checkSum + z;
                }
                //check if valid
                if (checkSum == b * this.X.Length)
                {
                    Console.WriteLine("Check sum checks out. This will now try to be solved. \n");
                } else{
                    Console.WriteLine("Check sum does not check out. This will not try to be solved. Try b= {0}\n", checkSum/this.X.Length );
                    isSolveable = false;
                }


            }

            return isSolveable;
        }

		public static Multiset Randomize()
		{
            Multiset parent = new Multiset(Global.Xvalue(), Global.Yvalue(), Global.Zvalue());
			Random rand = new Random();
			var xList = new List<int>(parent.X);
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
            parent.totalScore = 0;
            for (int p = 0; p < parent.X.Length; p++)
            {
                parent.totalScore += Math.Abs(((parent.X[p] + parent.Y[p] + parent.Z[p]) - Global.b()));
            }

			return parent;
		}
		
        public List<Node> ToNodeList()
        {
            List<Node> n = new List<Node>();

            for (int i = 0; i < this.X.Length; i++){
                n.Add(new Node(this.X[i], this.Y[i], this.Z[i]));
            }

            n.Sort((x, y) => x.score.CompareTo(y.score));
            return n;
        }

        public static Multiset CreateChild(Multiset parent1, Multiset parent2 )
        {
            List<Node> childNodeList = new List<Node>();
            childNodeList = Node.MergeNodeLists(parent1.ToNodeList(), parent2.ToNodeList());
            Multiset final = Node.FindBest(childNodeList);
            return final;
        }
	}
}
