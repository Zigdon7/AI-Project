﻿using System;
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
			int[] X = { 3, 4, 4 };
			int[] Y = { 1, 4, 6 };
			int[] Z = { 1, 2, 5 };

			Multiset initialSet = new Multiset(X, Y, Z);
            Boolean isSolveable = initialSet.CheckSolvability(b);
            List<Node> n = initialSet.ToNodeList();
            List<Node> m = Node.MergeNodeLists(n, n);
            //check if stored correctly
            //Console.Write("{0},{1},{2}, {3},{4},{5}, {6},{7},{8} Score: {9}\n", initialSet.X[0], initialSet.X[1], initialSet.X[2], initialSet.Y[0], initialSet.Y[1],initialSet.Y[2], initialSet.Z[0],initialSet.Z[1],initialSet.Z[2],initialSet.score);

            if (isSolveable)
            {
			
			//Randomly create populationMultiplier*k parents
			List<Multiset> parentList = new List<Multiset>();
			for (int i = 0; i < initialSet.X.Length * populationMultiplier; i++)
			{
				Multiset newParent = initialSet;
				parentList.Add(initialSet.Randomize(newParent));
			}
			parentList[0].print();
			//Create Children
			//if child needs to be mutated, call Mutate Function



                //Mutator Function


                //end
                Console.WriteLine("Hello World!");
                Console.ReadKey(true);
            }
        }



    }

}
