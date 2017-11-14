using System;
namespace Numerical3DMatching
{
    public static class Global
    {
        public static int b()
        {
<<<<<<< HEAD
            return 13;
=======
            return 100;
>>>>>>> 67cbe583a375cd186952af7532d610d649b54652
        }
        public static int populationMultiplier()
        {
            return 100;
        }
        public static int[] Xvalue(){
<<<<<<< HEAD
            int[] X = { 3, 4, 4 , 5 , 1 ,7 , 8 , 3};
=======
            int[] X = { 36, 69, 14, 23, 33, 99 };
>>>>>>> 67cbe583a375cd186952af7532d610d649b54652
            return X;
        }
        public static int[] Yvalue()
        {
<<<<<<< HEAD
            int[] Y = { 1, 4, 6 , 5, 2 , 5 , 6 , 5};
=======
            int[] Y = { 17, 30, 23, 35, 33, 0};
>>>>>>> 67cbe583a375cd186952af7532d610d649b54652
            return Y;
        }
        public static int[] Zvalue()
        {
<<<<<<< HEAD
            int[] Z = { 1, 2, 5 , 4, 2 , 6 , 7 , 8};
=======
            int[] Z = { 57, 1, 54, 34, 51, 1 };
>>>>>>> 67cbe583a375cd186952af7532d610d649b54652
            return Z;
        }
        public static Multiset Initial(){
            Multiset initial = new Multiset(Xvalue(), Yvalue(), Zvalue());
            return initial;
        }
    }
}
