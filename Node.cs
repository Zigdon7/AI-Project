using System;
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
    }
}
