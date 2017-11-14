using System;
using System.Collections.Generic;
using System.Linq;

namespace Numerical3DMatching
{
    public static class Global
    {
        public static int b()
        {
            return 50;
        }
        public static int populationMultiplier()
        {
            return 100;
        }
        public static int[] Xvalue(){
            int[] X = { 47, 36, 14, 14, 40, 27, 13, 36, 24, 35, 11, 31, 22, 24, 8, 29, 44, 23, 4, 8, 47, 30, 40, 3, 40, 8, 33, 28, 37, 10 };
            return X;
        }
        public static int[] Yvalue()
        {
            int[] Y = { 1, 2, 8, 20, 9, 10, 36, 6, 9, 3, 23, 8, 13, 3, 10, 3, 4, 1, 22, 20, 34, 14, 19, 7, 8, 25, 5, 28, 8, 13 };
            return Y;
        }
        public static int[] Zvalue()
        {
            int[] Z = { 2, 12, 27, 16, 2, 14, 1, 4, 9, 18, 16, 23, 16, 11, 15, 38, 3, 7, 24, 8, 2, 1, 3, 2, 17, 33, 17, 12, 4, 5 };
            return Z;
        }
        public static Multiset Initial(){
            Multiset initial = new Multiset(Xvalue(), Yvalue(), Zvalue());
            return initial;
        }
        public static int Generations()
        {
            return 100;
        }
        public static Multiset GenerateRandom(int count){
            List<int> X = new List<int>();
            List<int> Y = new List<int>();
            List<int> Z = new List<int>();
            Random rand = new Random();

            for (int i = 0; i < count; i++){
                X.Add(rand.Next(1,Global.b()));
                Y.Add(rand.Next(1, Global.b() - X[i]));
                Z.Add(Global.b() - X[i] - Y[i]);
            }
            int[] Xa = Multiset.Shuffle(X.ToArray());
            int[] Ya = Multiset.Shuffle(Y.ToArray());
            int[] Za = Multiset.Shuffle(Z.ToArray());
            Multiset final = new Multiset(Xa, Ya, Za);
            return final;
        }
    }
}
