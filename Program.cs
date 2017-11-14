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

            if (isSolveable)
            {
			
    			//Randomly create populationMultiplier*k parents
    			List<Multiset> parentList = new List<Multiset>();
    			for (int i = 0; i < initialSet.X.Length * populationMultiplier; i++)
    			{
                    Multiset holder = new Multiset(Global.Xvalue(), Global.Yvalue(), Global.Zvalue());
                    holder = Multiset.Randomize();
                    parentList.Add(holder);
  			    }
                //Creates (parentList.Count/2) Children
                List<Multiset> NextGen = new List<Multiset>();
                for (int k = 0; k < parentList.Count; k += 2)
                {
                    Multiset holder = new Multiset(X, Y, Z);
                    holder = Multiset.CreateChild(parentList[k], parentList[k + 1]);
                    NextGen.Add(holder);
					totalCount++;
				}

				//Sort parentList by ascending totalScore, then add the top 10% to NextGen.
				parentList.Sort((x,y) => x.totalScore.CompareTo(y.totalScore));
				

				//Add the top 10% of parents into the NextGen population
				for (int r = 0; r < parentList.Count / 10; r++)
				{
					//Console.WriteLine("One of top 10% parents: ");
					parentList[r].print();
					NextGen.Add(parentList[r]);
					totalCount++;
				}

				//Creates the last 40% of the NextGen children by crossover of the top 80% parents
				//Check top 80% parent size. -> Console.WriteLine("Top 80% parents size should be 240= {0}",parentList.Count*(.8));
				for (int s = 0; s < parentList.Count*(0.8); s += 2)
				{
					Multiset holder = new Multiset(X, Y, Z);
					holder = Multiset.CreateChild(parentList[s], parentList[s + 1]);
					NextGen.Add(holder);
					totalCount++;
                    //holder.print();
					
				}

				//Mutator Function


				//WoAC function

				//end
				Console.WriteLine("Hello World!");
                Console.ReadKey(true);
            }
        }



    }

}
