using bagruts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

            #region tests 2021 381

            #region Q1

            bool b2021Q1 = IsDouble("a@a@");

            #endregion

            #region Q5

            Node<int> Q5381 = new Node<int>(5, new Node<int>(1, new Node<int>(2, new Node<int>(8, new Node<int>(4)))));
            Q5381 = Move(Q5381, 2);

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
                if (i == num)
                    count++;
            int[] newArr = new int[arr.Length - count];
            for (int i = 0, j = 0; i < arr.Length; i++)
                if (arr[i] != num)
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
                foreach (Subject sub in subArray)
                    sum += sub.GetGrade();
                return sum;
            }
            public bool IsExcellent()
            {
                if (Average() < 85)
                    return false;
                bool isOver100 = false;
                foreach (Subject sub in subArray)
                {
                    int g = sub.GetGrade();
                    if (g < 54)
                        return false;
                    if (g == 100)
                        isOver100 = true;
                }
                return isOver100;
            }
        }

        static void PrintExcellent(ReportCard[] reportCards)
        {
            foreach (ReportCard reportCard in reportCards)
                if (reportCard.IsExcellent())
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

        public class Store
        {
            public Node<Game> lst;
            // סעיף א
            public int Remove(int n, int pr)
            {
                int removed = 0;
                while (lst != null && removed < n && lst.GetValue().GetPrice() == pr)
                {
                    lst = lst.GetNext();
                    removed++;
                }
                Node<Game> current = lst;
                while (current != null && removed < n)
                {
                    Node<Game> nextNode = current.GetNext();
                    while (nextNode != null && removed < n && nextNode.GetValue().GetPrice() == pr)
                    {
                        nextNode = nextNode.GetNext();
                        removed++;
                        current.SetNext(nextNode);
                    }
                    current = current.GetNext();
                }
                return removed;
            }

            // סעיף ב
            public int RemoveCheap(int num)
            {
                if (lst == null) return 0;
                int minPrice = lst.GetValue().GetPrice();
                Node<Game> current = lst.GetNext();
                while (current != null)
                {
                    int price = current.GetValue().GetPrice();
                    if (price < minPrice)
                        minPrice = price;
                    current = current.GetNext();
                }
                int totalRemoved = 0;
                int remainingToRemove = num;
                while (remainingToRemove > 0)
                {
                    int removedThisRound = Remove(remainingToRemove, minPrice);
                    totalRemoved += removedThisRound * minPrice;
                    remainingToRemove -= removedThisRound;
                    if (remainingToRemove > 0)
                    {
                        minPrice = int.MaxValue;
                        current = lst;
                        while (current != null)
                        {
                            int price = current.GetValue().GetPrice();
                            if (price < minPrice)
                                minPrice = price;
                            current = current.GetNext();
                        }
                    }
                }

                return totalRemoved;
            }
        }




        #endregion

        #region 12

        //ב1
        /* a: int i = 1
         * b: int i = 3
         * c: int i = 4
         * d: int i = 9
         * bd: int i = 11
         * ac: int i = 6
         */

        //ב2
        /* 1: Foo3, T
         * 2: Foo1, F
         * 3: Foo1, F
         * 4: Foo4, Foo2, T
         * 5: Foo1, F
         */
        #endregion

        #endregion

        #region 2023 381

        #region 5

        internal class NumCount
        {
            private int num;
            private int count;

            public NumCount(int num, int count)
            {
                this.num = num;
                this.count = count;
            }

            public void SetNum(int Num)
            {
                num = Num;
            }
            public int GetNum()
            {
                return num;
            }
            public int GetCount()
            {
                return count;
            }
            public void SetCount(int Count)
            {
                count = Count;
            }
        }

        internal class OrderedList
        {
            private Node<NumCount> lst;

            public OrderedList(Node<NumCount> lst)
            {
                this.lst = lst;
            }

            //א1
            public void InsertNum(int x)
            {
                Node<NumCount> temp = lst;
                while (temp != null)
                {
                    if (temp.GetValue().GetNum() == x)
                    {
                        temp.GetValue().SetCount(temp.GetValue().GetCount() + 1);
                        return;
                    }
                    temp = temp.GetNext();
                }
                temp = lst;
                bool isAdded = false;
                NumCount add = new NumCount(x, 1);
                Node<NumCount> addlst = new Node<NumCount>(add);
                if (temp.GetValue().GetNum() > x)
                {
                    addlst.SetNext(temp);
                    temp.SetNext(addlst);
                    isAdded = true;
                }
                while (!isAdded)
                {
                    if (temp.GetNext().GetValue().GetNum() > x)
                    {
                        addlst.SetNext(temp.GetNext());
                        temp.SetNext(addlst);
                        isAdded = true;
                    }
                    else if (temp.GetNext() == null)
                    {
                        temp.SetNext(addlst);
                        isAdded = true;
                    }
                    temp = temp.GetNext();
                }
            }
            #region פתרונות טובים יותר

            public void InsertNumRecursive(int x)
            {
                lst = InsertRec(lst, x);
            }

            private Node<NumCount> InsertRec(Node<NumCount> node, int x)
            {
                // רשימה ריקה או מקום נכון להוספה
                if (node == null || node.GetValue().GetNum() > x)
                {
                    return new Node<NumCount>(new NumCount(x, 1), node);
                }

                // המספר כבר קיים
                if (node.GetValue().GetNum() == x)
                {
                    node.GetValue().SetCount(node.GetValue().GetCount() + 1);
                    return node;
                }

                // ממשיכים רקורסיה
                node.SetNext(InsertRec(node.GetNext(), x));
                return node;
            }



            public void InsertNumEfficient(int x)
            {
                // רשימה ריקה
                if (lst == null)
                {
                    lst = new Node<NumCount>(new NumCount(x, 1));
                    return;
                }

                // הוספה לראש
                if (lst.GetValue().GetNum() > x)
                {
                    lst = new Node<NumCount>(new NumCount(x, 1), lst);
                    return;
                }

                Node<NumCount> curr = lst;

                while (curr != null)
                {
                    // המספר כבר קיים
                    if (curr.GetValue().GetNum() == x)
                    {
                        curr.GetValue().SetCount(curr.GetValue().GetCount() + 1);
                        return;
                    }

                    // מקום נכון להוספה באמצע
                    if (curr.GetNext() == null || curr.GetNext().GetValue().GetNum() > x)
                    {
                        curr.SetNext(new Node<NumCount>(new NumCount(x, 1), curr.GetNext()));
                        return;
                    }

                    curr = curr.GetNext();
                }
            }

            #endregion


            //א2
            //O(n) - בגלל שעוברים על השרשרת פעם אחת כל פעם

            //ב
            public int ValueN(int n)
            {
                Node<NumCount> temp = lst;
                int num = 0;
                while (temp != null)
                {
                    num += temp.GetValue().GetCount();
                    if (num >= n)
                        return temp.GetValue().GetNum();
                    temp = temp.GetNext();
                }
                return -1;
            }
        }

        #endregion

        #region 6

        public static bool IsPrime(int n)
        {
            if (n <= 1)
                return false;
            for (int i = 2; i * i <= n; i++)
                if (n % i == 0)
                    return false;
            return true;
        }

        //א
        public static bool AddNodes(BinNode<int> tr)
        {
            int val = tr.GetValue();
            if (IsPrime(val))
                return false;
            for (int R = 2; R < val; R++)
                for (int L = 2; L < val; L++)
                    if (L * R == val)
                    {
                        BinNode<int> addL = new BinNode<int>(L);
                        BinNode<int> addR = new BinNode<int>(R);
                        tr.SetLeft(addL);
                        tr.SetRight(addR);
                    }
            return true;
        }


        public static void What(BinNode<int> tr)
        {
            if (AddNodes(tr))
            {
                What(tr.GetLeft());
                What(tr.GetRight());
            }
        }
        //ב2
        //הפעולה מחלקת את הצמתים על שהערכים האחרונים של העץ הם מספרים ראשונים


        #endregion

        #endregion

        #region 2021 381

        #region 1

        public static bool IsDouble(string str)
        {
            if (str.Length % 2 != 0)
                return false;
            string part1 = str.Substring(0, str.Length / 2);
            string part2 = str.Substring(str.Length / 2);
            return part1.Equals(part2);
        }

        #endregion

        #region 2

        internal class PairOfNums
        {
            private int num1;
            private int num2;

            public PairOfNums(int num1, int num2)
            {
                this.num1 = num1;
                this.num2 = num2;
            }

            public void SetNum1(int num) { num1 = num; }
            public int GetNum1() { return num1; }
            public int GetNum2() { return num2; }
            public void SetNum2(int num) { num2 = num; }

            public bool EndStart()
            {
                int Num1 = num1;
                while (Num1 >= 10)
                    Num1 = Num1 / 10;
                int Num2 = num2 % 10;
                return Num1 == Num2;
            }

        }

        public static PairOfNums[] Generate(int n)
        {
            PairOfNums[] pairOfNums = new PairOfNums[n];
            Random random = new Random();
            int index = 0;
            do
            {
                int num1 = random.Next(0, 1000);
                int num2 = random.Next(0, 1000);
                PairOfNums pair = new PairOfNums(num1, num2);
                if (pair.EndStart())
                {
                    pairOfNums[index] = pair;
                    index++;
                }
            } while (index < n);
            return pairOfNums;
        }

        #endregion

        #region 5

        public static Node<int> Move(Node<int> lst, int n)
        {
            if (n == 0)
                return lst;
            int length = 1;
            Node<int> temp = lst;
            while (temp.GetNext() != null)
            {
                length++;
                temp = temp.GetNext();
            }
            int index = length - n;
            Node<int> prev = lst;
            for (int i = 1; i < index; i++)
                prev = prev.GetNext();
            Node<int> newHead = prev.GetNext();
            prev.SetNext(null);
            temp.SetNext(lst);
            return newHead;
        }


        #endregion

        #endregion

    }
}
