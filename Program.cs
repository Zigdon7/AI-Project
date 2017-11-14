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
            // Set in Global

			int[] X = Global.Xvalue();
            int[] Y = Global.Yvalue();
            int[] Z = Global.Zvalue();
            Multiset initialSet = Global.Initial();

            //Random
             Multiset possibleRandom = Global.GenerateRandom(30);
             possibleRandom.print();
             Console.Write("\n Here is a possible random solution that is solveable");

            Console.Write("Initial Set: \n");
            initialSet.print();


            Boolean isSolveable = initialSet.CheckSolvability(b);

            if (isSolveable)
            {
			
    			//Randomly create populationMultiplier*k parents
    			List<Multiset> parentList = new List<Multiset>();
    			for (int i = 0; i < initialSet.X.Length * populationMultiplier; i++)
    			{
                    Multiset holder = new Multiset(Global.Xvalue() , Global.Yvalue(), Global.Zvalue());
                    holder = Multiset.Randomize();
                    parentList.Add(holder);
  			    }
                List<Multiset> NextGen = parentList;

                for (int i = 0; i < Global.Generations(); i++)
                {
                    Console.Write("Finding Generation {0}\n", i);
                    NextGen = FindNextGen(NextGen);
                    Console.Write("Generation {0}'s best score is {1}\n", i, NextGen[0].totalScore);
                    Console.Write("Gen {0}'s Solution: ", i);
                    NextGen[0].print();
                    Console.Write("\n");

                }  

				Console.WriteLine("Hello World!");
                Console.ReadKey(true);
            }
        }
        public static List<Multiset> FindNextGen( List<Multiset> parentList){
            //Creates (parentList.Count/2) Children
            int totalCount = 0; //keeps track of the amount of children in the NextGen List.
            List<Multiset> NextGen = new List<Multiset>();
            for (int k = 0; k < parentList.Count; k += 2)
            {
                Multiset holder = new Multiset(Global.Xvalue(), Global.Yvalue(), Global.Zvalue());
                holder = Multiset.CreateChild(parentList[k], parentList[k + 1]);
                NextGen.Add(holder);
                totalCount++;
            }

            //Sort parentList by ascending totalScore, then add the top 10% to NextGen.
            parentList.Sort((x, y) => x.totalScore.CompareTo(y.totalScore));


            //Add the top 10% of parents into the NextGen population
            for (int r = 0; r < parentList.Count / 10; r++)
            {
                //parentList[r].print();
                NextGen.Add(parentList[r]);
                totalCount++;
            }

            //Creates the last 40% of the NextGen children by crossover of the top 80% parents
            //Check top 80% parent size. -> Console.WriteLine("Top 80% parents size should be 240= {0}",parentList.Count*(.8));
            for (int s = 0; s < parentList.Count * (0.8); s += 2)
            {
                Multiset holder = new Multiset(Global.Xvalue(), Global.Yvalue(), Global.Zvalue());
                holder = Multiset.CreateChild(parentList[s+1], parentList[s]);
                NextGen.Add(holder);
                totalCount++;

            }

            //Mutator Function
            Random randMutate = new Random();
            NextGen.Sort((x, y) => x.totalScore.CompareTo(y.totalScore));
            int startPercentage = 1;
            //int increment = 1;
			//int counter = 0;
            for(int v = 0; v < NextGen.Count; v++)
            {
				if (v > ((NextGen.Count/10) * startPercentage))
				{
					startPercentage += 2;
				}
                int r = randMutate.Next(startPercentage, 101);
                if (r == startPercentage)
                {
					//Mutate child
					NextGen[v] = NextGen[v].MutateChild();
                }
                //increment++;
            }

            //WoAC function
            return NextGen;
            //end
        }



    }

}
