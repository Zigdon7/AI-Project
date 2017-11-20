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
        public static int population()
        {
            return 1000;
        }
        public static int[] Xvalue(){
            int[] X = { 32, 24, 5, 33, 5, 18, 46, 38, 30, 37, 23, 33, 46, 8, 27, 22, 38, 25, 37, 4, 29, 13, 47, 1, 42, 21, 38, 1, 32, 40, 8, 6, 49, 38, 18, 37, 33, 1, 32, 11 };
            return X;
        }
        public static int[] Yvalue()
        {
            int[] Y = { 12, 16, 2, 5, 2, 24, 12, 4, 14, 7, 15, 21, 2, 16, 38, 21, 24, 1, 2, 9, 10, 8, 33, 15, 24, 6, 10, 28, 9, 5, 7, 11, 8, 1, 1, 21, 7, 12, 8, 6 };
            return Y;
        }
        public static int[] Zvalue()
        {
            int[] Z = { 6, 29, 12, 24, 33, 2, 8, 6, 6, 8, 6, 2, 2, 4, 1, 7, 7, 3, 2, 13, 11, 11, 25, 3, 2, 1, 2, 29, 40, 39, 2, 1, 35, 0, 48, 6, 11, 5, 12, 31 };
            return Z;
        }
        public static Multiset Initial(){
            Multiset initial = new Multiset(Xvalue(), Yvalue(), Zvalue());
            return initial;
        }
        public static int Generations()
        {
            return 3000;
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
