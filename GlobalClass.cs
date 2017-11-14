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
            int[] X = { 36, 69, 14, 23, 33, 99 };
            return X;
        }
        public static int[] Yvalue()
        {
            int[] Y = { 17, 30, 23, 35, 33, 0};
            return Y;
        }
        public static int[] Zvalue()
        {
            int[] Z = { 57, 1, 54, 34, 51, 1 };
            return Z;
        }
        public static Multiset Initial(){
            Multiset initial = new Multiset(Xvalue(), Yvalue(), Zvalue());
            return initial;
        }
    }
}
