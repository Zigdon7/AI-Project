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
			int totalCount = 0; //keeps track of the amount of children in the NextGen List.
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
                //Creates (parentList.Count/2) Children
                List<Multiset> NextGen = new List<Multiset>();
                for (int k = 0; k < parentList.Count; k += 2)
                {
                    Multiset holder = new Multiset(X, Y, Z);
                    holder = Multiset.CreateChild(parentList[k], parentList[k + 1]);
                    NextGen.Add(holder);
					totalCount++;
                    //parentList[k].print();
                    //parentList[k+1].print();
                    //Console.Write("{0} : \n", k);
                    //holder.print();
				}

				//Sort parentList by ascending totalScore, then add the top 10% to NextGen.
				parentList.Sort((x,y) => x.totalScore.CompareTo(y.totalScore));
				
				//foreach (Multiset item in parentList)
				//{
				//item.print();
				//}
				//Console.WriteLine("\n\n\n\nEND PARENT SORT\n\n\n\n\n");

				//Add the top 10% of parents into the NextGen population
				for (int r = 0; r < parentList.Count / 10; r++)
				{
					//Console.WriteLine("One of top 10% parents: ");
					//parentList[r].print();
					NextGen.Add(parentList[r]);
					totalCount++;
				}


				//Console.WriteLine("Total Number of children in NextGen should be 150 + 30: {0}", NextGen.Count);
				//foreach(Multiset item in NextGen)
				//{
				//	Console.WriteLine("NextGen Child: ");
				//	item.print();
				//}



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
