using bagruts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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

            #region test 2025

            #region Q10

            //Tester();

            #endregion

            #region Q11

            //test();

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

        #region 3

        //ב
        static bool IsLeftK(BinNode<int> root, int k, int left = 0)
        {
            if (root == null)
                return true;
            if (left > k)
                return false;
            return IsLeftK(root.GetLeft(), k, left + 1) && IsLeftK(root.GetRight(), k, left);
        }

        #endregion

        #region 10

        public class Animal
        {
            private string color;
            private int weight;

            public Animal(string color, int weight)
            {
                this.color = color;
                this.weight = weight;
            }

            public string GetColor()
            {
                return this.color;
            }

            public void SetColor(string color)
            {
                this.color = color;
            }

            public int GetWeight()
            {
                return this.weight;
            }

            public void SetWeight(int weight)
            {
                this.weight = weight;
            }

            public override string ToString()
            {
                return "My color is " + this.color + "! And I weigh " + this.weight + " kilos!";
            }
        }

        public class Bird : Animal
        {
            private bool isFlying;

            public Bird(string color, int weight, bool isFlying)
                : base(color, weight)
            {
                this.isFlying = isFlying;
            }

            public bool GetIsFlying()
            {
                return this.isFlying;
            }

            public void SetIsFlying(bool isFlying)
            {
                this.isFlying = isFlying;
            }

            public void Zoo()
            {
                Console.WriteLine("Hello");
            }

            public override string ToString()
            {
                return $"I'm a bird! My color is {base.GetColor()}! And I weigh {base.GetWeight()} kilos!";
            }
        }

        public class Parrot : Bird
        {
            private bool isTalking;

            public Parrot(string color, int weight, bool isFlying, bool isTalking)
                : base(color, weight, isFlying)
            {
                this.isTalking = isTalking;
            }

            public bool GetIsTalking()
            {
                return this.isTalking;
            }

            public void SetIsTalking(bool isTalking)
            {
                this.isTalking = isTalking;
            }

            public override string ToString()
            {
                return $"I'm a parrot! My color is {base.GetColor()}!";
            }
        }

        public class Fish : Animal
        {
            private string waterType;

            public Fish(string color, int weight, string waterType)
                : base(color, weight)
            {
                this.waterType = waterType;
            }

            public string GetWaterType()
            {
                return this.waterType;
            }

            public void SetWaterType(string waterType)
            {
                this.waterType = waterType;
            }

            public override string ToString()
            {
                return $"My color is {base.GetColor()}! And I weigh {base.GetWeight()} kilos!";
            }
        }

        public class Snake : Animal
        {
            private int length;
            private bool isVenomous;

            public Snake(string color, int weight, int length, bool isVenomous)
                : base(color, weight)
            {
                this.length = length;
                this.isVenomous = isVenomous;
            }

            public int GetLength()
            {
                return this.length;
            }

            public void SetLength(int length)
            {
                this.length = length;
            }

            public bool GetIsVenomous()
            {
                return this.isVenomous;
            }

            public void SetIsVenomous(bool isVenomous)
            {
                this.isVenomous = isVenomous;
            }

            public override string ToString()
            {
                string line = "I'm a snake! ";
                if (this.isVenomous)
                    line += "I'm venomous, be careful!";
                else
                    line += "I'm not venomous!";
                line += $"My color is {base.GetColor()}! And I weigh {base.GetWeight()} kilos!";
                return line;
            }
        }

        static void Tester()
        {
            //ב
            Animal[] animals = new Animal[5];
            animals[0] = new Bird("white", 4, false);
            animals[1] = new Fish("blue", 3, "sweet water");
            animals[2] = new Parrot("brown", 12, true, true);
            animals[3] = new Snake("gray", 2, 6, true);
            animals[4] = new Snake("black", 3, 4, false);

            //ג1
            for(int i = 0; i < animals.Length; i++)
                Console.WriteLine(animals[i]);

            //ג2
            for (int i = 0; i < animals.Length; i++)
                if (animals[i] is Bird)
                    ((Bird)animals[i]).Zoo();
        }

        #endregion

        #region 11

        public class One
        {
            public static int count = 0;
            private int number;

            public One()
            {
                count++;
                number = count;
            }

            public One(int num)
            {
                number = num;
            }

            public override string ToString()
            {
                return count + ", " + number;
            }
        }

        public class Two : One
        {
            private string strTwo;

            public Two()
            {
                strTwo = "Fast";
            }

            public Two(string s) : base(15)
            {
                strTwo = s;
            }

            public override string ToString()
            {
                return base.ToString() + " " + strTwo;
            }
        }

        public class Three : Two
        {
            private string strThree;

            public Three(string s)
            {
                strThree = s;
            }

            public override string ToString()
            {
                return base.ToString() + " " + strThree;
            }
        }

        static void test()
        {
            One[] arr = new One[6];
            arr[0] = new Two();
            arr[1] = new Three("car");
            arr[2] = new Three("Horse");
            arr[3] = new Two("Small");
            arr[4] = new Two("Tall");
            arr[5] = new One();

            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine(arr[i]);
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

        #region 2023

        #region Q5

        internal class MyTime
        {
            private int myMinute; // 0-59
            private int myHour;   // 7-23

            // Constructor
            public MyTime(int myHour, int myMinute)
            {
                SetMyHour(myHour);
                SetMyMinute(myMinute);
            }

            // Getters
            public int GetMyHour()
            {
                return myHour;
            }

            public int GetMyMinute()
            {
                return myMinute;
            }

            // Setters עם בדיקת תקינות
            public void SetMyHour(int myHour)
            {
                if (myHour >= 7 && myHour <= 23)
                    this.myHour = myHour;
            }

            public void SetMyMinute(int myMinute)
            {
                if (myMinute >= 0 && myMinute <= 59)
                    this.myMinute = myMinute;
            }

            // מחזירה true אם הזמן הנוכחי מוקדם מ-other
            public bool Before(MyTime other)
            {
                if (this.myHour < other.myHour)
                    return true;

                if (this.myHour == other.myHour &&
                    this.myMinute < other.myMinute)
                    return true;

                return false;
            }

            // מחזירה הפרש בדקות בערך מוחלט
            public int Diff(MyTime other)
            {
                int thisTotalMinutes = this.myHour * 60 + this.myMinute;
                int otherTotalMinutes = other.myHour * 60 + other.myMinute;

                return Math.Abs(thisTotalMinutes - otherTotalMinutes);
            }
        }
        public class Parking
        {
            private string id;     // מספר רכב
            private MyTime In;     // זמן כניסה
            private MyTime Out;    // זמן יציאה

            // Constructor
            public Parking(string id, MyTime In, MyTime Out)
            {
                this.id = id;
                this.In = In;
                this.Out = Out;
            }

            // Getters
            public string GetId()
            {
                return id;
            }

            public MyTime GetIn()
            {
                return In;
            }

            public MyTime GetOut()
            {
                return Out;
            }

            // Setters
            public void SetId(string id)
            {
                this.id = id;
            }

            public void SetIn(MyTime In)
            {
                this.In = In;
            }

            public void SetOut(MyTime Out)
            {
                this.Out = Out;
            }

            //1ב
            public int Total()
            {
                return In.Diff(Out);
            }
        }

        // א
        static void First(Parking[] cars)
        {
            Parking firstCar = cars[0];
            for (int i = 1; i < cars.Length; i++)
                if (cars[i].GetIn().Before(firstCar.GetIn()))
                    firstCar = cars[i];
            Console.WriteLine(firstCar.GetId());
        }

        //ב2
        static int SumMoney(Parking[] cars)
        {
            int sumMoney = 0;
            int time;
            foreach (Parking car in cars)
            {
                time = car.Total();
                if (time > 120)
                    sumMoney += time - 120;
            }
            return sumMoney;
        }

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
