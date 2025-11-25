using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    }
}
