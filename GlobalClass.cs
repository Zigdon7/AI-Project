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
            return 500;
        }
        public static int[] Xvalue(){
            int[] X = { 19, 48, 11, 35, 30, 22, 27, 14, 30, 25, 6, 26, 49, 7, 49, 47, 31, 29, 4, 38, 48, 30, 17, 20, 23 };
            return X;
        }
        public static int[] Yvalue()
        {
            int[] Y = { 4, 19, 10, 1, 3, 9, 13, 18, 17, 16, 17, 1, 6, 25, 8, 1, 1, 4, 1, 11, 17, 5, 1, 18, 13 };
            return Y;
        }
        public static int[] Zvalue()
        {
            int[] Z = { 27, 20, 1, 5, 7, 19, 17, 6, 18, 9, 27, 18, 18, 0, 0, 2, 17, 1, 45, 1, 11, 22, 3, 17, 15 };
            return Z;
        }
        public static Multiset Initial(){
            Multiset initial = new Multiset(Xvalue(), Yvalue(), Zvalue());
            return initial;
        }
        public static int Generations()
        {
            return 1000;
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
