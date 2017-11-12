﻿using System;
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

    }
}