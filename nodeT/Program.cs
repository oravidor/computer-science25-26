using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nodeT
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        #region node

        #region 3a1
        public static Node<int> Build1ToNListReverse(int n)
        {
            if (n <= 0) return null;
            Node<int> head = null;
            for (int i = 1; i <= n; i++)
            {
                head = new Node<int>(i, head);
            }
            return head;
        }
        public static Node<int> Build1ToNList(int n, int now = 1)
        {
            if (n < now)
                return null;
            Node<int> head = null;
            for (int i = n; i >= now; i--)
            {
                head = new Node<int>(i, head);
            }
            return head;
        }
        public static Node<int> BuildChainFromString(string numbersString)
        {
            if (string.IsNullOrWhiteSpace(numbersString))
                return null;

            Node<int> head = null;
            string[] stringParts = numbersString.Split(',');

            for (int i = stringParts.Length - 1; i >= 0; i--)
            {
                head = new Node<int>(int.Parse(stringParts[i]), head);
            }

            return head;
        }
        public static void PrintBiggerPrec(Node<int> head)
        {
            if (head == null)
                return;

            while (head != null)
            {
                if (head.GetNext() == null)
                    break;

                if (head.GetValue() > head.GetNext().GetValue())
                    Console.WriteLine(head.GetValue());

                head = head.GetNext();
            }
        }
        public static double ListAvg(Node<int> head)
        {
            if (head == null)
                return 0;

            double sum = 0;
            int count = 0;
            while (head != null)
            {
                sum += head.GetValue();
                count++;

                if (head.GetNext() == null)
                    break;

                head = head.GetNext();
            }
            return sum / count;
        }
        public static int MaxAndSecDistance(Node<int> head)
        {
            if (head == null || head.GetNext() == null)
                throw new NullReferenceException();

            int maxNum = head.GetValue();
            int secondNum = int.MinValue;
            Node<int> current = head;
            int distance = 0;

            while (current != null)
            {
                int value = current.GetValue();
                if (value > maxNum)
                {
                    secondNum = maxNum;
                    maxNum = value;
                }
                else if (value > secondNum && value < maxNum)
                {
                    secondNum = value;
                }
                current = current.GetNext();
            }

            current = head;
            bool isFound = false;
            while (current != null)
            {
                int num = current.GetValue();

                if ((num == secondNum || num == maxNum))
                {
                    if (!isFound)
                        isFound = true;
                    else
                        break;
                }

                if (isFound)
                    distance++;

                current = current.GetNext();
            }
            return distance;
        }

        #endregion

        #region 3a2
        public static Node<int> Build1toNListRec(int end, int now = 1)
        {
            Node<int> head = new Node<int>(now);
            if (now > end)
                return null;
            if (now == end)
                return head;
            head.SetNext(Build1toNListRec(end, now + 1));
            return head;
        }
        public static Node<int> RemoveNum(Node<int> head, int numToRemove)
        {
            if (head == null)
                return null;
            if (head.GetValue() == numToRemove)
                return head.GetNext();
            head.SetNext(RemoveNum(head.GetNext(), numToRemove));
            return head;
        }
        public static int MaxMemberRec(Node<int> head)
        {
            if (head == null)
                throw new NullReferenceException();
            if (!head.HasNext())
                return head.GetValue();
            int max = int.MinValue;
            while (head != null)
            {
                max = Math.Max(max, head.GetValue());
                head = head.GetNext();
            }
            return max;
        }
        public static Node<int> RemoveNegative(Node<int> head, Node<int> current = null)
        {
            if (head == null)
                return null;
            head.SetNext(RemoveNegative(head.GetNext()));
            if (head.GetValue() < 0)
                return head.GetNext();
            return head;
        }
        public static int SumLinkedListRecursive(Node<int> head)
        {
            if (head == null)
                return 0;
            return head.GetValue() + SumLinkedListRecursive(head.GetNext());
        }
        public static int CountEvenNodes(Node<int> head)
        {
            if (head == null)
                return 0;
            if (head.GetValue() % 2 == 0)
                return 1 + CountEvenNodes(head.GetNext());
            return CountEvenNodes(head.GetNext());
        }

        #endregion

        #region 3a3

        public static bool IsSubList(Node<int> list1, Node<int> list2)
        {
            if (list1 == null)
                return true;
            if (list2 == null)
                return false;

            if (StartsWith(list1, list2))
                return true;

            return IsSubList(list1, list2.GetNext());
        }
        public static bool StartsWith(Node<int> list1, Node<int> list2)
        {
            if (list1 == null)
                return true;
            if (list2 == null)
                return false;

            if (list1.GetValue() != list2.GetValue())
                return false;

            return StartsWith(list1.GetNext(), list2.GetNext());
        }

        public static void RemoveSequencesOfIdenticalNumbers(Node<int> head)
        {
            if (head == null || !head.HasNext())
                return;
            head.SetNext(RemoveNum_(head, head.GetValue()));
            RemoveSequencesOfIdenticalNumbers(head.GetNext());
        }
        public static Node<int> RemoveNum_(Node<int> head, int numToRemove, Node<int> current = null, Node<int> prev = null)
        {
            if (head == null)
                return null;
            head.SetNext(RemoveNum_(head.GetNext(), numToRemove));
            if (head.GetValue() == numToRemove)
                return head.GetNext();
            return head;
        }

        public static Node<T> NoDuply<T>(Node<T> head)
        {

        }

        public static Node<int> ListsUnion(Node<int> list1, Node<int> list2)
        {
            if (list1 == null)
                return list2;
            if (list2 == null)
                return list1;
            Node<int> tail = list1;
            while (tail.GetNext() != null)
                tail = tail.GetNext();
            tail.SetNext(list2);
            Node<int> current = list1;
            while (current != null)
            {
                RemoveNum_(current, current.GetValue());
                current = current.GetNext();
            }
            return list1;
        }

        public static Node<int> ListsIntersection(Node<int> list1, Node<int> list2)
        {
            if (list1 == null || list2 == null)
                return null;
            Node<int> result = null;
            Node<int> tail = null;
            Node<int> current1 = list1;
            while (current1 != null)
            {
                int val = current1.GetValue();
                if (ExistsIn(list2, val) && !ExistsIn(result, val))
                {
                    Node<int> newNode = new Node<int>(val);
                    if (result == null)
                    {
                        result = newNode;
                        tail = newNode;
                    }
                    else
                    {
                        tail.SetNext(newNode);
                        tail = newNode;
                    }
                }
                current1 = current1.GetNext();
            }
            return result;
        }

        private static bool ExistsIn(Node<int> head, int value)
        {
            Node<int> current = head;
            while (current != null)
            {
                if (current.GetValue() == value)
                    return true;
                current = current.GetNext();
            }
            return false;
        }

        public static int CountSequences(Node<int> head)
        {
            if (head == null)
                return 0;

            int count = 0;
            bool inSeq = false;
            int seqLength = 0;
            int direction = 0;

            Node<int> prev = null;
            Node<int> current = head;

            while (current != null)
            {
                int val = current.GetValue();
                if (val < 0)
                {
                    return 0;
                }

                if (val == 0)
                {
                    if (inSeq && seqLength >= 3)
                        count++;

                    inSeq = false;
                    seqLength = 0;
                    direction = 0;
                    prev = null;
                    current = current.GetNext();
                    continue;
                }

                if (prev == null)
                {
                    seqLength = 1;
                    inSeq = true;
                }
                else
                {
                    if (direction == 0)
                    {
                        if (val > prev.GetValue()) direction = 1;
                        else if (val < prev.GetValue()) direction = -1;
                    }
                    else
                    {
                        if (direction == 1 && val < prev.GetValue()) inSeq = false;
                        if (direction == -1 && val > prev.GetValue()) inSeq = false;
                    }

                    if (!inSeq)
                    {
                        if (seqLength >= 3)
                            count++;
                        seqLength = 1;
                        direction = 0;
                        inSeq = true;
                    }
                    else
                    {
                        seqLength++;
                    }
                }
                prev = current;
                current = current.GetNext();
            }
            if (inSeq && seqLength >= 3)
                count++;

            return count;
        }

        public static bool IsPalindrome(Node<int> head)
        {
            if (head == null)
                return true;
            if (!head.HasNext())
                return true;
            Node<int> revers = null;
            Node<int> temp = head;
            while (temp != null)
            {
                revers = new Node<int>(temp.GetValue(), revers);
                temp = temp.GetNext();
            }
            while (head.HasNext())
            {
                if (head.GetValue() != revers.GetValue())
                    return false;
                head = head.GetNext();
                revers = revers.GetNext();
            }
            return true;
        }

        public static void ParityPartition(Node<int> head)
        {
            if (head == null || head.GetNext() == null)
                return;
            bool evenStart = head.GetValue() % 2 == 0;
            Node<int> tail = head;
            int count = 1;
            while (tail.GetNext() != null)
            {
                tail = tail.GetNext();
                count++;
            }
            Node<int> end = tail;
            Node<int> prev = null;
            Node<int> curr = head;
            for (int i = 0; i < count; i++)
            {
                bool isEven = curr.GetValue() % 2 == 0;
                Node<int> next = curr.GetNext();
                if (isEven != evenStart)
                {
                    if (prev != null)
                        prev.SetNext(next);
                    else
                        head = next;
                    tail.SetNext(curr);
                    tail = curr;
                    tail.SetNext(null);
                }
                else
                    prev = curr;
                curr = next;
            }
        }




        #endregion

        #region 3a4

        public static Node<int> SortedUnionNew(Node<int> list1, Node<int> list2)
        {

        }

        #endregion

        #endregion

        #region stack

        #region 4a1

        public static bool StacksEqual(Stack<int> a, Stack<int> b)
        {
            bool isEqual = true;
            Stack<int> tempA = new Stack<int>();
            Stack<int> tempB = new Stack<int>();
            while (!a.IsEmpty() && !b.IsEmpty())
            {
                tempA.Push(a.Pop());
                tempB.Push(b.Pop());
                if (tempA.Top() != tempB.Top())
                    isEqual = false;
            }
            while (!tempA.IsEmpty() && !tempB.IsEmpty())
            {
                a.Push(tempA.Pop());
                b.Push(tempB.Pop());
            }
            return isEqual;
        }

        public static bool IsStackPalindrome(Stack<int> st)
        {
            if (st.IsEmpty()) return true;
            bool isPalindrome = true;
            Stack<int> temp = new Stack<int>();
            Stack<int> reversed = new Stack<int>();
            while (!st.IsEmpty())
            {
                int val = st.Pop();
                temp.Push(val);
            }
            while (!temp.IsEmpty())
            {
                int val = temp.Pop();
                st.Push(val);
                reversed.Push(val);
            }
            while (!st.IsEmpty())
            {
                int fromOriginal = st.Pop();
                temp.Push(fromOriginal);
            }
            while (!temp.IsEmpty())
            {
                int fromTemp = temp.Pop();
                int fromReversed = reversed.Pop();
                if (fromTemp != fromReversed)
                    isPalindrome = false;
                st.Push(fromTemp);
            }
            return isPalindrome;
        }

        public static Stack<int> CopyStack(Stack<int> originalStack)
        {
            Stack<int> temp = new Stack<int>();
            Stack<int> copy = new Stack<int>();
            while (!originalStack.IsEmpty())
                temp.Push(originalStack.Pop());
            while (!temp.IsEmpty())
            {
                int val = temp.Pop();
                originalStack.Push(val);
                copy.Push(val);
            }
            return copy;
        }

        public static int SumStackElements(Stack<int> stack)
        {
            int sum = 0;
            Stack<int> temp = new Stack<int>();
            while (!stack.IsEmpty())
            {
                sum += stack.Top();
                temp.Push(stack.Pop());
            }
            while (!temp.IsEmpty())
                stack.Push(temp.Pop());
            return sum;
        }

        public static int CountStackElements(Stack<int> stack)
        {
            int sum = 0;
            Stack<int> temp = new Stack<int>();
            while (!stack.IsEmpty())
            {
                sum += 1;
                temp.Push(stack.Pop());
            }
            while (!temp.IsEmpty())
                stack.Push(temp.Pop());
            return sum;
        }
        #endregion

        #endregion
    }
}
