using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;

namespace Numerical3DMatching
{
    class Program
    {

		static void Main(string[] args)
		{
			//init
            int population = Global.population();
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
			
    			//Randomly create population parents
    			List<Multiset> parentList = new List<Multiset>();
    			for (int i = 0; i < population; i++)
    			{
                    Multiset holder = new Multiset(Global.Xvalue() , Global.Yvalue(), Global.Zvalue());
                    holder = Multiset.Randomize();
                    parentList.Add(holder);
  			    }
                List<Multiset> NextGen = parentList;

                for (int i = 0; i < Global.Generations(); i++)
                {
                    Console.Write("Finding Generation {0}\n", i+1);
                    NextGen = FindNextGen(NextGen);
                    Console.Write("Generation {0}'s best score is {1}\n", i+1, NextGen[0].totalScore);
                    Console.Write("Gen {0}'s Solution: \n", i+1);
                    NextGen[0].print();
                    Console.Write("\n");

                }
                List<Node> guess = WoC(NextGen);
                Multiset finalguess = Node.FindBest(guess);
                Console.Write("Best guess's score is {0}\n", finalguess.totalScore);
                Console.Write("Final Guess Solution: \n");
                Node.print(finalguess.ToNodeList());
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
				if (v > ((NextGen.Count*(0.05)) * startPercentage))
				{
					startPercentage++;
				}
                int r = randMutate.Next(startPercentage, 101);
                if (r == startPercentage)
                {
					//Mutate child
					NextGen[v] = NextGen[v].MutateChild();
                }
                //increment++;
            }


            return NextGen;
            //end
        }

        public static List<Node >WoC(List<Multiset> start){
            List<Node> best = new List<Node>();
            foreach(Multiset item in start){
                best = Node.MergeNodeLists(best, item.ToNodeList());
            }
            best.GroupBy(o => new { o.X, o.Y, o.Z }).OrderByDescending(g => g.Count()).ToList();
            List<Node> final = best.DistinctBy(o => new { o.X, o.Y, o.Z }).ToList();;
            return final;
        }
    }

}
