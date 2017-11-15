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
            return 10000;
        }
        public static int[] Xvalue(){
            int[] X = { 22, 46, 20, 33, 21, 39, 20, 18, 3, 21, 1, 41, 28, 3, 33, 10, 15, 18, 43, 3, 20, 18, 30, 28, 42, 44, 11, 21, 7, 34, 3, 38, 5, 13, 5, 24, 9, 22, 19, 33, 11, 30, 4, 48, 24, 18, 1, 36, 25, 29 };
            return X;
        }
        public static int[] Yvalue()
        {
            int[] Y = { 28, 7, 13, 1, 27, 5, 14, 1, 2, 23, 1, 22, 8, 8, 36, 14, 1, 28, 1, 27, 18, 16, 2, 25, 14, 34, 19, 3, 6, 29, 3, 14, 2, 15, 22, 40, 9, 3, 30, 36, 1, 12, 1, 11, 1, 11, 30, 5, 2, 21 };
            return Y;
        }
        public static int[] Zvalue()
        {
            int[] Z = { 1, 21, 17, 3, 12, 10, 16, 22, 30, 7, 21, 24, 1, 9, 12, 11, 19, 5, 6, 31, 12, 21, 7, 8, 3, 6, 10, 5, 41, 10, 18, 9, 31, 22, 17, 23, 25, 1, 16, 10, 38, 8, 15, 1, 1, 3, 2, 28, 23, 16 };
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
