using System;
using System.Collections.Generic;
using System.Text;

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
            score = Math.Abs(X + Y + Z - Global.b());
        }
        public static List<Node> MergeNodeLists(List<Node> first, List<Node> second)
        {
            List<Node> final = new List<Node>();
            final.AddRange(first);
            final.AddRange(second);
            final.Sort((x, y) => x.score.CompareTo(y.score));
            return final;
        }

    }


}
