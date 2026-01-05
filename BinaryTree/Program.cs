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

        public static int CountEvenNodes(BinNode<int> tree)
        {
            if (tree == null)
                return 0;
            if (tree.GetValue() % 2 == 0)
                return 1 + CountEvenNodes(tree.GetLeft()) + CountEvenNodes(tree.GetRight());
            return CountEvenNodes(tree.GetLeft()) + CountEvenNodes(tree.GetRight());
        }

        public static int CountNodesWithTwoIdenticalChildren(BinNode<int> tree)
        {
            if (tree == null)
                return 0;
            if (tree.HasLeft() && tree.HasRight())
                if (tree.GetLeft().GetValue() == tree.GetRight().GetValue())
                    return 1 + CountNodesWithTwoIdenticalChildren(tree.GetLeft()) + CountNodesWithTwoIdenticalChildren(tree.GetRight());
            return CountNodesWithTwoIdenticalChildren(tree.GetLeft()) + CountNodesWithTwoIdenticalChildren(tree.GetRight());
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

        #endregion

        #region 6a2

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

        public static bool AreLeavesEqualToParent(BinNode<int> t, int parentValue = -1)
        {
            if (t == null)
                return true;
            bool hasLeft = t.HasLeft();
            bool hasRight = t.HasRight();
            if (!hasLeft && !hasRight)
            {
                if (parentValue == -1)
                    return true;
                return t.GetValue() == parentValue;
            }
            int currentValue = t.GetValue();
            bool leftOk = true;
            bool rightOk = true;
            if (hasLeft)
                leftOk = AreLeavesEqualToParent(t.GetLeft(), currentValue);
            if (hasRight)
                rightOk = AreLeavesEqualToParent(t.GetRight(), currentValue);
            return leftOk && rightOk;
        }

        public static bool IsYoniTree(BinNode<int> t)
        {
            if (t == null)
                return true;
            bool hasLeft = t.HasLeft();
            bool hasRight = t.HasRight();
            if (!hasLeft && !hasRight)
                return true;
            if (hasLeft && hasRight)
                return IsYoniTree(t.GetLeft()) && IsYoniTree(t.GetRight());
            return false;
        }

        public static bool HasDifferentChildren(BinNode<int> t)
        {
            if (t == null)
                return false;
            if (t.HasLeft() && t.HasRight())
                if (t.GetLeft().GetValue() != t.GetRight().GetValue())
                    return true;
            return HasDifferentChildren(t.GetLeft()) || HasDifferentChildren(t.GetRight());
        }


        public static bool HasNoDifferentChildren(BinNode<int> t)
        {
            if (t == null)
                return true;
            if (t.HasLeft() && t.HasRight())
                if (t.GetLeft().GetValue() != t.GetRight().GetValue())
                    return false;
            return HasNoDifferentChildren(t.GetLeft()) && HasNoDifferentChildren(t.GetRight());
        }

        public static bool IsYechielTree(BinNode<int> t)
        {
            if (t == null)
                return true;
            bool hasLeft = t.HasLeft();
            bool hasRight = t.HasRight();
            if (!hasLeft && !hasRight)
                return true;
            int value = t.GetValue();
            if (hasLeft && hasRight)
            {
                int leftVal = t.GetLeft().GetValue();
                int rightVal = t.GetRight().GetValue();
                if (value != leftVal + rightVal)
                    return false;
                return IsYechielTree(t.GetLeft()) && IsYechielTree(t.GetRight());
            }
            if (hasLeft)
            {
                int leftVal = t.GetLeft().GetValue();
                if (value != leftVal)
                    return false;
                return IsYechielTree(t.GetLeft());
            }
            int rightValue = t.GetRight().GetValue();
            if (value != rightValue)
                return false;
            return IsYechielTree(t.GetRight());
        }

        public static bool IsSachiTree(BinNode<int> t, int target = -1)
        {
            if (t == null)
                return false;
            if (target == -1)
                target = t.GetValue();
            if (t.GetValue() != target)
                return false;
            bool hasLeft = t.HasLeft();
            bool hasRight = t.HasRight();
            if (!hasLeft && !hasRight)
                return true;
            return IsSachiTree(t.GetLeft(), target) || IsSachiTree(t.GetRight(), target);
        }

        public static bool CheckSpecialBinaryTree(BinNode<int> t)
        {
            if (t == null)
                return true;
            if (t.HasLeft())
                if (!(t.GetLeft().GetValue() > t.GetValue()))
                    return false;
            if (t.HasRight())
                if (!(t.GetRight().GetValue() < t.GetValue()))
                    return false;
            return CheckSpecialBinaryTree(t.GetLeft()) && CheckSpecialBinaryTree(t.GetRight());
        }

        public static bool IsLiaTree(BinNode<int> t)
        {
            if (t == null)
                return true;
            bool hasGrandchild = false;
            if (t.HasLeft())
            {
                var left = t.GetLeft();
                if (left.HasLeft() || left.HasRight())
                    hasGrandchild = true;
            }
            if (t.HasRight())
            {
                var right = t.GetRight();
                if (right.HasLeft() || right.HasRight())
                    hasGrandchild = true;
            }
            if (hasGrandchild)
            {
                bool hasLeft = t.HasLeft();
                bool hasRight = t.HasRight();
                if (hasLeft == hasRight)
                    return false;
            }
            return IsLiaTree(t.GetLeft()) && IsLiaTree(t.GetRight());
        }
        #endregion

        #region 6a3

        public static int CalculateTreeHeight(BinNode<int> t)
        {
            if (t == null)
                return -1;
            int leftHeight = CalculateTreeHeight(t.GetLeft());
            int rightHeight = CalculateTreeHeight(t.GetRight());
            return 1 + Math.Max(leftHeight, rightHeight);
        }

        public static void PrintPostOrder(BinNode<int> t)
        {
            if (t == null)
                return;
            PrintPostOrder(t.GetLeft());
            PrintPostOrder(t.GetRight());
            Console.WriteLine(t.GetValue());
        }

        public static void PrintRightChildren(BinNode<int> t)
        {
            if (t == null)
                return;
            if (t.HasRight())
                Console.WriteLine(t.GetRight().GetValue());
            PrintRightChildren(t.GetLeft());
            PrintRightChildren(t.GetRight());
        }

        public static void PrintLeavesLeftToRight(BinNode<int> t)
        {
            if (t == null)
                return;
            if (!t.HasLeft() && !t.HasRight())
            {
                Console.Write(t.GetValue() + " ");
                return;
            }
            PrintLeavesLeftToRight(t.GetLeft());
            PrintLeavesLeftToRight(t.GetRight());
        }

        public static void PrintNodesSmallerThanParent(BinNode<int> t, int parentValue = -1)
        {
            if (t == null)
                return;
            int value = t.GetValue();
            if (value < parentValue)
                Console.WriteLine(value);
            if (t.HasLeft())
                PrintNodesSmallerThanParent(t.GetLeft(), value);
            if (t.HasRight())
                PrintNodesSmallerThanParent(t.GetRight(), value);
        }

        public static void PrintNodesWithTwoChildrenAndGreaterValue(BinNode<int> t)
        {
            if (t == null)
                return;
            if (t.HasLeft() && t.HasRight())
                if (t.GetValue() > t.GetLeft().GetValue() || t.GetValue() > t.GetRight().GetValue())
                    Console.WriteLine(t.GetValue());
            PrintNodesWithTwoChildrenAndGreaterValue(t.GetLeft());
            PrintNodesWithTwoChildrenAndGreaterValue(t.GetRight());
        }

        #endregion

        #region 6a4

        public static bool AreTreesIdentical(BinNode<int> t1, BinNode<int> t2)
        {
            if (t1 == null && t2 == null)
                return true;
            if ((t1 == null && t2 != null) || (t1 != null && t2 == null))
                return false && AreTreesIdentical(t1.GetLeft(), t2.GetLeft()) && AreTreesIdentical(t1.GetRight(), t2.GetRight());
            if (t1.GetValue() == t2.GetValue())
                return true && AreTreesIdentical(t1.GetLeft(), t2.GetLeft()) && AreTreesIdentical(t1.GetRight(), t2.GetRight());
            return false && AreTreesIdentical(t1.GetLeft(), t2.GetLeft()) && AreTreesIdentical(t1.GetRight(), t2.GetRight());
        }

        public static bool AreMirror(BinNode<int> t1, BinNode<int> t2)
        {
            if (t1 == null && t2 == null)
                return true;
            if (t1 == null || t2 == null)
                return false;
            if (t1.GetValue() != t2.GetValue())
                return false;
            return AreMirror(t1.GetLeft(), t2.GetRight()) && AreMirror(t1.GetRight(), t2.GetLeft());
        }

        public static void UpdateLeavesWithParentValue(BinNode<int> tree)
        {
            if (tree == null)
                return;
            if (tree.HasLeft())
            {
                BinNode<int> left = tree.GetLeft();
                if (!left.HasLeft() && !left.HasRight())
                    left.SetValue(tree.GetValue());
                UpdateLeavesWithParentValue(left);
                if (tree.HasRight())
                {
                    BinNode<int> right = tree.GetRight();
                    if (!right.HasLeft() && !right.HasRight())
                        right.SetValue(tree.GetValue());
                    UpdateLeavesWithParentValue(right);
                }
            }
        }

        public static BinNode<int> DeleteSingleChildNodes(BinNode<int> root)
        {
            if (root == null)
                return null;
            root.SetLeft(DeleteSingleChildNodes(root.GetLeft()));
            root.SetRight(DeleteSingleChildNodes(root.GetRight()));
            bool hasLeft = root.GetLeft() != null;
            bool hasRight = root.GetRight() != null;
            if (hasLeft && !hasRight || !hasLeft && hasRight)
                return hasLeft ? root.GetLeft() : root.GetRight();
            return root;
        }

        public static void AddLeftChildToLeaves(BinNode<int> tree)
        {
            if (tree == null)
                return;
            if (tree.GetLeft() == null && tree.GetRight() == null)
            {
                tree.SetLeft(new BinNode<int>(tree.GetValue()));
                return;
            }
            AddLeftChildToLeaves(tree.GetLeft());
            AddLeftChildToLeaves(tree.GetRight());
        }

        public static void AddSiblingToSingleChild(BinNode<int> tree)
        {
            if (tree == null)
                return;
            bool hasLeft = tree.GetLeft() != null;
            bool hasRight = tree.GetRight() != null;
            if (hasLeft && !hasRight)
                tree.SetRight(new BinNode<int>(tree.GetLeft().GetValue() - 1));
            else if (!hasLeft && hasRight)
                tree.SetLeft(new BinNode<int>(tree.GetRight().GetValue() - 1));
            if (hasLeft)
                AddSiblingToSingleChild(tree.GetLeft());
            if (hasRight)
                AddSiblingToSingleChild(tree.GetRight());
        }

        public static int CountNodesAtLevel(BinNode<int> tree, int level)
        {
            if (tree == null || level < 0)
                return 0;
            if (level == 0)
                return 1;
            int leftCount = CountNodesAtLevel(tree.GetLeft(), level - 1);
            int rightCount = CountNodesAtLevel(tree.GetRight(), level - 1);
            return leftCount + rightCount;
        }

        public static Node<char> GetTreeFence(BinNode<char> root)
        {
            if (root == null)
                return null;
            Node<char> head = null;
            Node<char> tail = null;
            void Append(Node<char> node)
            {
                if (head == null)
                {
                    head = node;
                    tail = node;
                }
                else
                {
                    tail.SetNext(node);
                    tail = node;
                }
            }
            if (root.GetLeft() == null && root.GetRight() == null)
            {
                Append(new Node<char>(root.GetValue()));
                return head;
            }
            Stack<BinNode<char>> stack = new Stack<BinNode<char>>();
            BinNode<char> current = root;
            while (current != null)
            {
                if (current.GetRight() != null)
                {
                    stack.Push(current.GetRight());
                    current = current.GetRight();
                }
                else if (current.GetLeft() != null)
                    current = current.GetLeft();
                else
                    break;
            }
            while (!stack.IsEmpty())
            {
                BinNode<char> node = stack.Pop();
                Append(new Node<char>(node.GetValue()));
            }
            Append(new Node<char>(root.GetValue()));
            current = root;
            while (current != null)
            {
                if (current.GetLeft() != null)
                {
                    Append(new Node<char>(current.GetLeft().GetValue()));
                    current = current.GetLeft();
                }
                else if (current.GetRight() != null)
                    current = current.GetRight();
                else
                    break;
            }
            return head;
        }


        public static bool HasAscendingPath(BinNode<int> tree, int prev = int.MinValue)
        {
            if (tree == null) return false;
            if (tree.GetValue() < prev) return false;
            if (tree.GetLeft() == null && tree.GetRight() == null) return true;
            return HasAscendingPath(tree.GetLeft(), tree.GetValue()) || HasAscendingPath(tree.GetRight(), tree.GetValue());
        }

        public static int FindMaxPathSum(BinNode<int> tree)
        {
            if (tree == null) return int.MinValue;
            int leftSum = FindMaxPathSum(tree.GetLeft());
            int rightSum = FindMaxPathSum(tree.GetRight());
            if (tree.GetLeft() == null && tree.GetRight() == null)
                return tree.GetValue();
            if (tree.GetLeft() == null) return tree.GetValue() + rightSum;
            if (tree.GetRight() == null) return tree.GetValue() + leftSum;
            return tree.GetValue() + Math.Max(leftSum, rightSum);
        }

        #endregion

    }
}
