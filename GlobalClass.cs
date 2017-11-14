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
            int[] X = { 43, 26, 30, 1, 23, 9, 46, 12, 25, 26, 40, 33, 31, 7, 20, 30, 16, 27, 25, 46, 27, 24, 13, 23, 3 };
            return X;
        }
        public static int[] Yvalue()
        {
            int[] Y = { 32, 4, 14, 2, 19, 6, 35, 5, 14, 1, 16, 25, 14, 27, 9, 9, 27, 13, 23, 2, 20, 9, 7, 1, 32 };
            return Y;
        }
        public static int[] Zvalue()
        {
            int[] Z = { 3, 17, 10, 14, 8, 2, 5, 6, 11, 23, 13, 14, 5, 8, 10, 11, 16, 16, 2, 2, 7, 17, 7, 46, 5 };
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
