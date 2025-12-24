using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        #region 6a1

        public static int SumBinaryTreeNodes(BinNode<int> binNode)
        {
            if (binNode == null)
                return 0;
            return binNode.GetValue() + SumBinaryTreeNodes(binNode.GetLeft()) + SumBinaryTreeNodes(binNode.GetRight());
        }

        public static int FindMaxInBinaryTree(BinNode<int> t)
        {
            if (t == null)
                return int.MinValue;
            return Math.Max(t.GetValue(), Math.Max(FindMaxInBinaryTree(t.GetLeft()), FindMaxInBinaryTree(t.GetRight())));
        }

        public static int CountSingleChildren(BinNode<int> t)
        {
            if (t == null)
                return 0;
            if (t.HasLeft() && !t.HasRight())
                return 1 + CountSingleChildren(t.GetLeft()) + CountSingleChildren(t.GetRight());
            if (t.HasRight() && !t.HasLeft())
                return 1 + CountSingleChildren(t.GetLeft()) + CountSingleChildren(t.GetRight());
            return CountSingleChildren(t.GetLeft()) + CountSingleChildren(t.GetRight());
        }

        public static int SumOfRightChildren(BinNode<int> tree)
        {
            if (tree == null)
                return 0;
            int sum = 0;
            if (tree.HasRight())
                sum += tree.GetRight().GetValue();
            return sum + SumOfRightChildren(tree.GetLeft()) + SumOfRightChildren(tree.GetRight());
        }

        public static int CountOccurrences(BinNode<int> t, int x)
        {
            if (t == null)
                return 0;
            if (t.GetValue() == x)
                return 1 + CountOccurrences(t.GetLeft(), x) + CountOccurrences(t.GetRight(), x);
            return CountOccurrences(t.GetLeft(), x) + CountOccurrences(t.GetRight(), x);
        }

        public static int CountLeaves(BinNode<int> t)
        {
            if (t == null)
                return 0;
            if (!t.HasRight() && !t.HasLeft())
                return 1 + CountLeaves(t.GetLeft()) + CountLeaves(t.GetRight());
            return CountLeaves(t.GetLeft()) + CountLeaves(t.GetRight());
        }

        public static int CountNodesSmallerThanChild(BinNode<int> t)
        {
            if (t == null)
                return 0;
            bool smallerThanLeft = false;
            bool smallerThanRight = false;
            if (t.HasLeft())
                smallerThanLeft = t.GetValue() < t.GetLeft().GetValue();
            if (t.HasRight())
                smallerThanRight = t.GetValue() < t.GetRight().GetValue();
            if (smallerThanLeft || smallerThanRight)
                return 1 + CountNodesSmallerThanChild(t.GetLeft()) + CountNodesSmallerThanChild(t.GetRight());
            return CountNodesSmallerThanChild(t.GetLeft()) + CountNodesSmallerThanChild(t.GetRight());
        }

        public static int CountNodesGreaterThanParent(BinNode<int> t)
        {
            if (t == null)
                return 0;
            int count = 0;
            bool smallerThanLeft = false;
            bool smallerThanRight = false;
            if (t.HasLeft())
                smallerThanLeft = t.GetValue() < t.GetLeft().GetValue();
            if (t.HasRight())
                smallerThanRight = t.GetValue() < t.GetRight().GetValue();
            if (smallerThanLeft)
                count++;
            if (smallerThanRight)
                count++;
            return count + CountNodesGreaterThanParent(t.GetLeft()) + CountNodesGreaterThanParent(t.GetRight());
        }

        public static int SumOddSingleNodes(BinNode<int> t, bool isSingle = false)
        {
            if (t == null)
                return 0;
            int sum = 0;
            if (isSingle && t.GetValue() % 2 != 0)
                sum += t.GetValue();
            bool leftIsSingle = t.HasLeft() && !t.HasRight();
            bool rightIsSingle = t.HasRight() && !t.HasLeft();
            return sum + SumOddSingleNodes(t.GetLeft(), leftIsSingle) + SumOddSingleNodes(t.GetRight(), rightIsSingle);
        }

        public static int CountGrandparents(BinNode<int> tree)
        {
            if (tree == null)
                return 0;
            int count = 0;
            bool isGrandparent = false;
            if (tree.HasLeft())
            {
                BinNode<int> left = tree.GetLeft();
                if (left.HasLeft() || left.HasRight())
                    isGrandparent = true;
            }
            if (tree.HasRight())
            {
                BinNode<int> right = tree.GetRight();
                if (right.HasLeft() || right.HasRight())
                    isGrandparent = true;
            }
            if (isGrandparent)
                count = 1;
            return count + CountGrandparents(tree.GetLeft()) + CountGrandparents(tree.GetRight());
        }

        public static bool AllValuesAreOdd(BinNode<int> t)
        {
            if (t == null)
                return true;
            return t.GetValue() % 2 != 0 && AllValuesAreOdd(t.GetLeft()) && AllValuesAreOdd(t.GetRight());
        }
        public static bool HasIdenticalSiblings(BinNode<int> t)
        {
            if (t == null)
                return false;
            if (t.HasLeft() && t.HasRight())
                if (t.GetLeft().GetValue() == t.GetRight().GetValue())
                    return true;
            return HasIdenticalSiblings(t.GetLeft()) || HasIdenticalSiblings(t.GetRight());
        }

        public static int CountEvenNodes(BinNode<int> tree) 
        {
            if (tree == null)
                return 0;
            int count = (tree.GetValue() % 2 == 0) ? 1 : 0;
            return count + CountEvenNodes(tree.GetLeft()) + CountEvenNodes(tree.GetRight());
        }

        public static int CountNodesWithTwoIdenticalChildren(BinNode<int> tree)
        {
            if (tree == null)
                return 0;
            int me = 0;
            if (tree.HasLeft() && tree.HasRight())
                if (tree.GetLeft().GetValue() == tree.GetRight().GetValue())
                    me = 1;
            return me + CountNodesWithTwoIdenticalChildren(tree.GetLeft()) + CountNodesWithTwoIdenticalChildren(tree.GetRight());
        }

        #endregion
    }
}
