using System;
using System.Collections.Generic;
using System.Linq;

namespace Numerical3DMatching
{
    public static class Global
    {
        public static int b()
        {
            return 1000;
        }
        public static int population()
        {
            return 1000;
        }
        public static int[] Xvalue(){
            int[] X = { 645, 239, 120, 142, 494, 765, 42, 233, 358, 823, 272, 785, 645, 792, 594, 308, 206, 323, 167, 415, 805, 123, 699, 700, 374, 815, 573, 595, 140, 367, 837, 403, 358, 533, 277, 867, 181, 637, 948, 588, 641, 784, 802, 528, 633, 222, 243, 286, 452, 61, 177, 49, 541, 992, 730, 626, 160, 889, 964, 413, 389, 380, 464, 863, 300, 414, 74, 16, 775, 464, 157, 440, 250, 800, 132, 75, 215, 393, 663, 371, 801, 934, 804, 815, 759, 743, 89, 52, 873, 813, 294, 454, 855, 209, 413, 519, 424, 162, 360, 523 };
            return X;
        }
        public static int[] Yvalue()
        {
            int[] Y = { 328, 113, 731, 502, 172, 344, 217, 610, 641, 78, 708, 29, 62, 78, 6, 310, 484, 84, 211, 103, 142, 139, 175, 469, 374, 139, 32, 364, 322, 17, 457, 34, 411, 291, 132, 589, 296, 314, 13, 27, 32, 194, 70, 193, 55, 636, 536, 37, 42, 425, 714, 643, 306, 2, 422, 156, 332, 112, 11, 86, 76, 18, 123, 22, 419, 80, 746, 875, 121, 541, 511, 555, 248, 261, 102, 145, 326, 561, 442, 89, 739, 80, 686, 16, 138, 37, 190, 65, 91, 81, 248, 245, 123, 83, 54, 84, 366, 627, 572, 440 };
            return Y;
        }
        public static int[] Zvalue()
        {
            int[] Z = { 27, 30, 122, 356, 708, 162, 550, 32, 250, 87, 377, 99, 153, 349, 382, 130, 593, 374, 730, 310, 53, 408, 161, 252, 126, 153, 288, 269, 449, 83, 140, 146, 53, 689, 1, 176, 523, 184, 39, 49, 289, 385, 312, 4, 279, 121, 242, 902, 506, 180, 289, 114, 153, 6, 418, 42, 237, 424, 25, 25, 535, 602, 203, 57, 464, 281, 75, 109, 415, 180, 595, 19, 524, 195, 98, 129, 780, 11, 46, 187, 110, 116, 29, 169, 225, 67, 103, 857, 80, 104, 458, 301, 354, 46, 707, 115, 533, 211, 200, 4 };
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
