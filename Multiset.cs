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
            Console.Write("\nTotal Score: {0}\n", this.totalScore);

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

		public static Multiset Randomize()
		{
            Multiset parent = new Multiset(Global.Xvalue(), Global.Yvalue(), Global.Zvalue());
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
            parent.totalScore = 0;
            for (int p = 0; p < parent.X.Length; p++)
            {
                parent.totalScore += Math.Abs(((parent.X[p] + parent.Y[p] + parent.Z[p]) - Global.b()));
            }
			//parent.print();
			//Console.Write("{0},{1},{2}, {3},{4},{5}, {6},{7},{8} Score: {9}\n", parent.X[0], parent.X[1], parent.X[2], parent.Y[0], parent.Y[1], parent.Y[2], parent.Z[0], parent.Z[1], parent.Z[2], parent.totalScore);

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
        public static Multiset CreateChild(Multiset parent1, Multiset parent2)
        {
            Multiset parent = Global.Initial();
            var xList = new List<int>(parent.X);
            var yList = new List<int>(parent.Y);
            var zList = new List<int>(parent.Z);
            int childSizeCounter = 0;
            List<Node> childNodeList = new List<Node>();
            List<Node> ParentToChild = new List<Node>();
            childNodeList = Node.MergeNodeLists(parent1.ToNodeList(), parent2.ToNodeList());

            foreach (Node nodes in childNodeList)
            {
                if (xList.Contains(nodes.X) && yList.Contains(nodes.Y) && zList.Contains(nodes.Z))
                {
                    //Node n is new and needs to be added to child
                    ParentToChild.Add(nodes);
                    xList.Remove(nodes.X);
                    yList.Remove(nodes.Y);
                    zList.Remove(nodes.Z);
                    childSizeCounter++;
                }
            }
            List<Node> child = new List<Node>();
            if (childSizeCounter < parent.X.Length)
            {
                List<Node> roulette = new List<Node>();
                xList.OrderByDescending(i => i); ;
                yList.OrderByDescending(i => i);
                zList.OrderByDescending(i => i);
                for (int i = 0; i < xList.Count(); i++)
                {
                    roulette.Add(new Node(xList[i], 0, 0));
                }
                roulette.Sort((x, y) => x.score.CompareTo(y.score));
                for (int i = 0; i < yList.Count(); i++)
                {
                    roulette[i].UpdateY(yList[i]);
                }
                roulette.Sort((x, y) => x.score.CompareTo(y.score));
                for (int i = 0; i < zList.Count(); i++)
                {
                    roulette[i].UpdateZ(zList[i]);
                }
                child = Node.MergeNodeLists(ParentToChild, roulette);
            }
            else
            {
                child = ParentToChild;
            }
            Multiset final = Node.ToMultiset(child);
            return final;
        }
	}
}
