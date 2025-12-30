using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = CalcCheckDigit(869419);

            Queue<int> q = new Queue<int>();
            q.Insert(1);
            q.Insert(2);
            q.Insert(3);
            sum = SumQueue(q);
        }

        #region 24.11.25

        public static bool Repeats(Node<char> lst)
        {
            if (lst == null)
                return false;
            if (IsMoreThan3(lst.GetNext(), lst.GetValue()))
                return true;
            return Repeats(lst.GetNext());
        }
        public static bool IsMoreThan3(Node<char> lst, char ch, int count = 0)
        {
            if (lst == null)
                return false;
            if (lst.GetValue() == ch)
                count++;
            if (count > 3)
                return true;
            return IsMoreThan3(lst.GetNext(), ch, count);
        }

        public static int CalcCheckDigit(int number)
        {
            if (number < 10)
                return number;
            return CalcCheckDigit(findnumber(number));
        }
        public static int findnumber(int number)
        {
            if (number <= 0)
                return number;
            return number % 10 + findnumber(number / 10);
        }

        public static int MaxAdjacentDifference(Node<int> head)
        {
            if (head == null || !head.HasNext())
                return int.MinValue;
            int maxDiff = int.MinValue;
            while (head.HasNext())
            {
                maxDiff = Math.Max(maxDiff, head.GetValue() - head.GetNext().GetValue());
                head = head.GetNext();
            }
            return maxDiff;
        }



        #endregion

        #region queue 19.12.25

        #region Q1
        //א
        static int SumQueue(Queue<int> queue)
        {
            if (queue.IsEmpty())
                return 0;
            int count = 0;
            int num = 0;
            Queue<int> temp = new Queue<int>();
            while (!temp.IsEmpty())
            {
                num = queue.Head();
                temp.Insert(queue.Remove());
                count++;
            }
            while (!temp.IsEmpty())
                queue.Insert(temp.Remove());
            if (count == 1)
                return 2 * queue.Head();
            return queue.Head() + num;
        }

        #endregion

        #endregion
    }
}
