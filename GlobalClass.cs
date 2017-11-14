using System;
using System.Collections.Generic;
using System.Linq;

namespace Numerical3DMatching
{
    public static class Global
    {
        public static int b()
        {
            return 100;
        }
        public static int populationMultiplier()
        {
            return 100;
        }
        public static int[] Xvalue(){
            int[] X = { 99, 69, 24, 23, 33, 36 };
            return X;
        }
        public static int[] Yvalue()
        {
            int[] Y = { 0, 23, 30, 35, 16, 17};
            return Y;
        }
        public static int[] Zvalue()
        {
            int[] Z = { 47, 1, 53, 42, 51, 1 };
            return Z;
        }
        public static Multiset Initial(){
            Multiset initial = new Multiset(Xvalue(), Yvalue(), Zvalue());
            return initial;
        }
        public static int Generations()
        {
            return 20;
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
            X.Sort();
            Y.Sort();
            Z.Sort();
            Multiset final = new Multiset(X.ToArray(), Y.ToArray(), Z.ToArray());
            return final;
        }
    }
}
