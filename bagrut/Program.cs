using bagruts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagruts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region tests 2024

            #region Q5

            Node<int> lst = new Node<int>(-3, new Node<int>(-5, new Node<int>(7, new Node<int>(5, new Node<int>(3, new Node<int>(7))))));
            int B2024Q5a = Width(7, lst);
            int B2024Q5b = Longest(lst);

            #endregion

            #endregion
        }

        #region 2024

        #region 5

        //א
        static int Width(int num, Node<int> lst)
        {
            Node<int> curr = lst;
            int length = 0;
            bool isFound = false;
            while (curr.HasNext())
            {
                if (Math.Abs(curr.GetValue()) == Math.Abs(num))
                {
                    if (isFound)
                        return length;
                    isFound = true;
                }
                if (isFound)
                    length++;
                curr = curr.GetNext();
            }
            return length;
        }

        //ב
        static int Longest(Node<int> lst)
        {
            int length = -1;
            while (lst.HasNext())
            {
                length = Math.Max(length, Width(lst.GetValue(), lst));
                lst = lst.GetNext();
            }
            return length;
        }

        #endregion

        #endregion

        #region 2021

        #region 1

        public static int[] Filter(int[] arr, int num)
        {
            int count = 0;
            foreach (int i in arr)
                if(i == num)
                    count++;
            int[] newArr = new int[arr.Length - count];
            for(int i = 0 , j = 0; i < arr.Length; i++)
                if(arr[i] != num)
                {
                    newArr[j] = arr[i];
                    j++;
                }
            return newArr;
        }

        #endregion

        #region 2

        internal class Subject
        {
            private string subName;
            private int grade;

            public Subject(string subName, int grade)
            {
                this.subName = subName;
                this.grade = grade;
            }

            public string GetSubName()
            {
                return subName;
            }
            public int GetGrade()
            {
                return grade;
            }
            public void SetSubName(string subName)
            {
                this.subName = subName;
            }
            public void SetGrade(int grade)
            {
                this.grade = grade;
            }
        }
        internal class ReportCard
        {
            private string stuName;
            private Subject[] subArray;
            public ReportCard(string stuName, int num)
            {
                this.stuName = stuName;
                this.subArray = new Subject[num];
            }
            public string GetStuName()
            {
                return stuName;
            }
            public Subject[] GetSubArray()
            {
                return subArray;
            }
            public void SetStuName(string stuName)
            {
                this.stuName = stuName;
            }
            public void SetSubArray(Subject[] subArray)
            {
                this.subArray = subArray;
            }

            public double Average()
            {
                int sum = 0;
                foreach(Subject sub in subArray)
                    sum += sub.GetGrade();
                return sum;
            }
            public bool IsExcellent()
            {
                if(Average() < 85)
                    return false;
                bool isOver100 = false;
                foreach(Subject sub in subArray)
                {
                    int g = sub.GetGrade();
                    if (g < 54)
                        return false;
                    if(g == 100)
                        isOver100 = true;
                }
                return isOver100;
            }
        }

        static void PrintExcellent(ReportCard[] reportCards)
        {
            foreach(ReportCard reportCard in reportCards)
                if(reportCard.IsExcellent())
                    Console.WriteLine(reportCard.GetStuName());
        }

        #endregion

        #region 3

        /*public static MyString Special(MyString ms)
         * {
         *      MyString lst = new MyString();
         *      while(!ms.IsEmpty())
         *      {
         *          cahr first = ms.FirstChar();
         *          int count = ms.CountChar(first);
         *          for(int i = 0; i < count; i++)
         *              lst.AppendChar(first);
         *           ms.RemoveChar(first);
         *      }
         *      return lst;
         * }
         */

        #endregion

        #endregion

        #region 2025

        #region 1
        internal class Game
        {
            private string Name;
            private int Price;
            public Game(string name, int price)
            {
                Name = name;
                Price = price;
            }
            public string GetName()
            {
                return Name;
            }
            public int GetPrice()
            {
                return Price;

            }
            public void SetName(string name)
            {
                Name = name;
            }
            public void SetPrice(int price)
            {
                Price = price;
            }
        }

        internal class Store
        {
            private Node<Game> lst;
            public Store(Node<Game> lst)
            {
                this.lst = lst;
            }

            //א
            public int Remove(int n, int pr)
            {
                Node<Game> prev = lst;
                Node<Game> current = lst;
                int count = 0;
                while (n > 0 && current != null)
                {
                    if(lst.GetValue().GetPrice() == pr)
                    {
                        n -= 1;
                        count++;
                        prev.SetNext(current.GetNext());
                    }
                    prev = current;
                    current = current.GetNext();
                }
                return count;
            }
        }

        #endregion

        #endregion

    }
}
