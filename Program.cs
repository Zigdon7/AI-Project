using System;
using System.Collections.Generic;
using System.Linq;

namespace Numerical3DMatching
{
    class Program
    {

		static void Main(string[] args)
		{
			//init
            int populationMultiplier = Global.populationMultiplier();
			int b = Global.b();
			int[] X = Global.Xvalue();
            int[] Y = Global.Yvalue();
            int[] Z = Global.Zvalue();

            Multiset initialSet = Global.Initial();
            Boolean isSolveable = initialSet.CheckSolvability(b);
            //check if stored correctly
            //Console.Write("{0},{1},{2}, {3},{4},{5}, {6},{7},{8} Score: {9}\n", initialSet.X[0], initialSet.X[1], initialSet.X[2], initialSet.Y[0], initialSet.Y[1],initialSet.Y[2], initialSet.Z[0],initialSet.Z[1],initialSet.Z[2],initialSet.score);

            if (isSolveable)
            {
			
    			//Randomly create populationMultiplier*k parents
    			List<Multiset> parentList = new List<Multiset>();
                Multiset newParent = initialSet;
    			for (int i = 0; i < initialSet.X.Length * populationMultiplier; i++)
    			{
                    Multiset holder = new Multiset(Global.Xvalue(), Global.Yvalue(), Global.Zvalue());
                    holder = Multiset.Randomize();
                    parentList.Add(holder);
                    //holder.print();
    			}
    			//parentList[0].print();
                //Create Children
                //if child needs to be mutated, call Mutate Function
                List<Multiset> NextGen = new List<Multiset>();
                for (int k = 0; k < parentList.Count; k += 2)
                {
                    Multiset holder = new Multiset(X, Y, Z);
                    holder = Multiset.CreateChild(parentList[k], parentList[k + 1]);
                    NextGen.Add(holder);
                    //parentList[k].print();
                    //parentList[k+1].print();
                    Console.Write("{0} : \n", k);
                    holder.print();
				}

				//List<Node> childNodeList = new List<Node>();
				//childNodeList.MergeNodeLists(parent1.ToNodeList(), parent2.ToNodeList());

				//Mutator Function


				//end
				Console.WriteLine("Hello World!");
                Console.ReadKey(true);
            }
        }



    }

}
