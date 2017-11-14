using System;
using System.Collections.Generic;
using System.Linq;

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

        public static Multiset ToMultiset(List<Node> n)
        {
            int[] XList = Global.Xvalue(), YList = Global.Yvalue() , ZList = Global.Zvalue();
            Shuffle(n);
            for (int i = 1; i < n.Count; i++)
            {
                XList[i-1] = n[i].X;
                YList[i-1] = n[i].Y;  
                ZList[i-1] = n[i].Z;  

            }
            XList[n.Count-1] = n[0].X;
            YList[n.Count-1] = n[0].Y;  
            ZList[n.Count-1] = n[0].Z; 
            Multiset final = new Multiset(XList, YList, ZList);
            return final;
        }
        public static void Shuffle(List<Node> n){
            Random rnd = new Random();
            n.OrderBy(item => rnd.Next());

        }
    }


}
