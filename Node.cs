using System;
using System.Collections.Generic;


namespace Numerical3DMatching
{
    public class Node
    {
        public int X, Y, Z;
        public int score;
        public Node(int X, int Y, int Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
            this.score = Math.Abs(X + Y + Z - Global.b());
        }

        public void UpdateX(int X)
        {
            this.X = X;
            this.UpdateScore();
        }

        public void UpdateY(int Y)
        {
            this.Y = Y;
            this.UpdateScore();
        }

        public void UpdateZ(int Z)
        {
            this.Z = Z;
            this.UpdateScore();
        }

        private void UpdateScore()
        {
            this.score = Math.Abs(this.X + this.Y + this.Z - Global.b());

        }

        public static List<Node> MergeNodeLists(List<Node> first, List<Node> second)
        {
            List<Node> final = new List<Node>();
            final.AddRange(first);
            final.AddRange(second);
            final.Sort((x, y) => x.score.CompareTo(y.score));
            return final;
        }

        public static Multiset ToMultiset(List<Node> n, Multiset initial)
        {
            int[] XList = initial.X, YList = initial.Y , ZList = initial.Z;
            for (int i = 0; i < n.Count; i++)
            {
                XList[i] = n[i].X;
                YList[i] = n[i].Y;  
                ZList[i] = n[i].Z;  

            }
            Multiset final = new Multiset(XList, YList, ZList);
            return final;
        }
    }


}
