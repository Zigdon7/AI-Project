using System;
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
    }
}
