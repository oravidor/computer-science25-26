using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QueueT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> a19 = new Queue<int>();
            a19.Insert(10);
            a19.Insert(2);
            CalculateDifferenceQueue(a19);

            Queue<int> a21 = new Queue<int>();
            a21.Insert(5);
            a21.Insert(-2);
            a21.Insert(8);
            a21.Insert(-1);
            a21.Insert(0);
            a21.Insert(3);
            RearrangeQueue(a21);

            Queue<int> a25 = new Queue<int>();
            a25.Insert(200);
            bool result = IsElementInQueueRec(a25, 100);
        }

        #region 5a1

        public static int CountQueueElements<T>(Queue<T> queue)
        {
            Queue<T> temp = new Queue<T>();
            int count = 0;
            while (!queue.IsEmpty())
            {
                count++;
                temp.Insert(queue.Remove());
            }
            while (!temp.IsEmpty())
                queue.Insert(temp.Remove());
            return count;
        }

        public static int SumQueue(Queue<int> queue)
        {
            Queue<int> temp = new Queue<int>();
            int sum = 0;
            while (!queue.IsEmpty())
            {
                sum += queue.Head();
                temp.Insert(queue.Remove());
            }
            while (!temp.IsEmpty())
                queue.Insert(temp.Remove());
            return sum;
        }

        public static bool IsElementInQueue(Queue<int> queue, int element)
        {
            Queue<int> temp = new Queue<int>();
            bool isInQueue = false;
            while (!queue.IsEmpty())
            {
                if (!isInQueue)
                    isInQueue = queue.Head() == element;
                temp.Insert(queue.Remove());
            }
            while (!temp.IsEmpty())
                queue.Insert(temp.Remove());
            return isInQueue;
        }

        public static int CountOccurrences<T>(Queue<T> queue, T item)
        {
            Queue<T> temp = new Queue<T>();
            int count = 0;
            while (!queue.IsEmpty())
            {
                if (item.Equals(queue.Head()))
                    count++;
                temp.Insert(queue.Remove());
            }
            while (!temp.IsEmpty())
                queue.Insert(temp.Remove());
            return count;
        }

        public static void ShiftQueueForward(Queue<int> queue)
        {
            queue.Insert(queue.Remove());
        }

        public static Queue<int> MultiplyQueueElements(Queue<int> originalQueue, int factor)
        {
            Queue<int> result = new Queue<int>();
            Queue<int> temp = new Queue<int>();
            while (!originalQueue.IsEmpty())
            {
                result.Insert(originalQueue.Head() * factor);
                temp.Insert(originalQueue.Remove());
            }
            while (!temp.IsEmpty())
                originalQueue.Insert(temp.Remove());
            return result;
        }

        public static Queue<int> CopyQueue(Queue<int> originalQueue)
        {
            Queue<int> result = new Queue<int>();
            Queue<int> temp = new Queue<int>();
            while (!originalQueue.IsEmpty())
            {
                result.Insert(originalQueue.Head());
                temp.Insert(originalQueue.Remove());
            }
            while (!temp.IsEmpty())
                originalQueue.Insert(temp.Remove());
            return result;
        }

        public static Queue<double> CopyKElementsFromQueue(Queue<double> originalQueue, int k)
        {
            Queue<double> result = new Queue<double>();
            Queue<double> temp = new Queue<double>();
            while (!originalQueue.IsEmpty())
            {
                if (k > 0)
                {
                    result.Insert(originalQueue.Head());
                    k--;
                }
                temp.Insert(originalQueue.Remove());
            }
            while (!temp.IsEmpty())
                originalQueue.Insert(temp.Remove());
            return result;
        }

        public static Queue<int> CalculateDifferenceQueue(Queue<int> q)
        {
            Queue<int> result = new Queue<int>();
            Queue<int> temp = new Queue<int>();
            while (!q.IsEmpty())
            {
                int n1 = q.Remove();
                int n2 = q.Remove();
                temp.Insert(n1);
                temp.Insert(n2);
                result.Insert(n2 - n1);
            }
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());
            return result;
        }

        public static Queue<int> RemoveDuplicatesFromQueue(Queue<int> originalQueue)
        {
            Queue<int> result = new Queue<int>();
            Queue<int> temp = new Queue<int>();
            int count = 0;
            while (!originalQueue.IsEmpty())
            {
                int val = originalQueue.Remove();
                temp.Insert(val);
                count++;
            }
            int[] uniques = new int[count];
            int uniqueCount = 0;
            while (!temp.IsEmpty())
            {
                int val = temp.Remove();
                originalQueue.Insert(val);
                bool found = false;
                for (int i = 0; i < uniqueCount; i++)
                    if (uniques[i] == val)
                    {
                        found = true;
                        break;
                    }
                if (!found)
                {
                    uniques[uniqueCount] = val;
                    uniqueCount++;
                    result.Insert(val);
                }
            }
            return result;
        }

        #endregion

        #region 5a2

        public static void RearrangeQueue(Queue<int> queue)
        {
            Queue<int> nagative = new Queue<int>();
            Queue<int> positive = new Queue<int>();
            while (!queue.IsEmpty())
            {
                int val = queue.Remove();
                if (val >= 0)
                    positive.Insert(val);
                else
                    nagative.Insert(val);
            }
            while (!nagative.IsEmpty())
                queue.Insert(nagative.Remove());
            while (!positive.IsEmpty())
                queue.Insert(positive.Remove());
        }

        public static void ReverseQueue(Queue<int> queue)
        {
            Stack<int> stack = new Stack<int>();
            while (!queue.IsEmpty())
                stack.Push(queue.Remove());
            while (!stack.IsEmpty())
                queue.Insert(stack.Pop());
        }

        public static bool IsPalindromeQueue<T>(Queue<T> q)
        {
            Stack<T> stack = new Stack<T>();
            Queue<T> temp = new Queue<T>();
            while (!q.IsEmpty())
            {
                var val = q.Remove();
                stack.Push(val);
                temp.Insert(val);
            }
            bool isPalindrome = true;
            while (!stack.IsEmpty())
            {
                var fromTemp = temp.Remove();
                var fromStack = stack.Pop();
                if (!fromTemp.Equals(fromStack))
                    isPalindrome = false;
                temp.Insert(fromTemp);
            }
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());
            return isPalindrome;
        }

        public static int CountQueueElementsRec(Queue<int> queue)
        {
            if (queue.IsEmpty())
                return 0;
            int val = queue.Remove();
            int count = 1 + CountQueueElementsRec(queue);
            queue.Insert(val);
            for (int i = 0; i < count - 1; i++)
                queue.Insert(queue.Remove());
            return count;
        }

        public static bool IsElementInQueueRec(Queue<int> q, int element)
        {
            if (q.IsEmpty())
                return false;
            int x = q.Remove();
            if (x == element)
            {
                Queue<int> temp1 = new Queue<int>();
                while (!q.IsEmpty())
                    temp1.Insert(q.Remove());
                q.Insert(x);
                while (!temp1.IsEmpty())
                    q.Insert(temp1.Remove());
                return true;
            }
            bool result = IsElementInQueueRec(q, element);
            Queue<int> temp = new Queue<int>();
            while (!q.IsEmpty())
                temp.Insert(q.Remove());
            q.Insert(x);
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());
            return result;
        }

        public static void MergeQueues(Queue<string> q1, Queue<string> q2)
        {
            Queue<string> temp = new Queue<string>();
            while (!q1.IsEmpty() && !q2.IsEmpty())
            {
                temp.Insert(q2.Remove());
                temp.Insert(q1.Remove());
            }
            while (!q1.IsEmpty())
                temp.Insert(q1.Remove());
            while (!q2.IsEmpty())
                temp.Insert(q2.Remove());
            while (!temp.IsEmpty())
                q2.Insert(temp.Remove());
        }

        public static void DecodeSecretMessage(Queue<char> lettersQueue, Queue<int> lengthsQueue)
        {
            Queue<char> lettersCopy = new Queue<char>();
            Queue<int> lengthsCopy = new Queue<int>();
            Queue<char> tempLetters = new Queue<char>();
            while (!lettersQueue.IsEmpty())
            {
                char c = lettersQueue.Remove();
                lettersCopy.Insert(c);
                tempLetters.Insert(c);
            }
            while (!tempLetters.IsEmpty())
                lettersQueue.Insert(tempLetters.Remove());
            Queue<int> tempLengths = new Queue<int>();
            while (!lengthsQueue.IsEmpty())
            {
                int len = lengthsQueue.Remove();
                lengthsCopy.Insert(len);
                tempLengths.Insert(len);
            }
            while (!tempLengths.IsEmpty())
                lengthsQueue.Insert(tempLengths.Remove());
            string message = "";
            while (!lengthsCopy.IsEmpty())
            {
                int wordLength = lengthsCopy.Remove();
                Queue<char> check = new Queue<char>();
                int available = 0;
                while (!lettersCopy.IsEmpty() && available < wordLength)
                {
                    check.Insert(lettersCopy.Remove());
                    available++;
                }
                if (available < wordLength)
                {
                    Console.WriteLine("ERROR");
                    return;
                }
                while (!check.IsEmpty())
                    message += check.Remove();
                if (!lengthsCopy.IsEmpty())
                    message += " ";
            }
            if (!lettersCopy.IsEmpty())
            {
                Console.WriteLine("ERROR");
                return;
            }
            Console.WriteLine(message);
        }

        #endregion
    }
}
