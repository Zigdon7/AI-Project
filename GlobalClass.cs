using System;
namespace Numerical3DMatching
{
    public static class Global
    {
        public static int b()
        {
            return 10;
        }
        public static int populationMultiplier()
        {
            return 100;
        }
        public static int[] Xvalue(){
            int[] X = { 3, 4, 4 };
            return X;
        }
        public static int[] Yvalue()
        {
            int[] Y = { 1, 4, 6 };
            return Y;
        }
        public static int[] Zvalue()
        {
            int[] Z = { 1, 2, 5 };
            return Z;
        }
        public static Multiset Initial(){
            Multiset initial = new Multiset(Xvalue(), Yvalue(), Zvalue());
            return initial;
        }
    }
}
