using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recutsion
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        #region 1a1
        public static int Factorial(int n)
        {
            if (n == 0 || n == 1)
                return 1;
            return n * Factorial(n - 1);
        }
        public static int SumDigits(int num)
        {
            if (num < 10)
                return num;
            return num % 10 + SumDigits(num / 10);
        }
        public static bool IsEven(int n)
        {
            n = Math.Abs(n);
            if (n == 0)
                return true;
            if (n == 1)
                return false;
            return IsEven(n - 2);
        }
        public static int Power(int baseNum, int exp)
        {
            if (exp == 0)
                return 1;
            return baseNum * Power(baseNum, exp - 1);
        }
        public static bool IsAscending(int num)
        {
            num = Math.Abs(num);
            if (num < 10)
                return true;
            if (num % 10 <= (num / 10) % 10)
                return false;
            return IsAscending(num / 10);
        }
        public static bool IsPalindrome(int num)
        {
            num = Math.Abs(num);
            if (num < 10)
                return true;
            int reverse = Reverse(num, 0);
            return num == reverse;
        }

        static int Reverse(int num, int result)
        {
            if (num == 0)
                return result;
            return Reverse(num / 10, result * 10 + num % 10);
        }
        public static bool HasDigit(int num, int digit)
        {
            if (num < 10 && num != digit)
                return false;
            if (num % 10 == digit)
                return true;
            return HasDigit(num / 10, digit);
        }
        public static int GCD(int a, int b)
        {
            if (b == 0)
                return a;
            return GCD(b, a % b);
        }
        public static int Fibonacci(int n)
        {
            switch (n)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
            }
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
        public static bool IsPrime(int num, int divisor = 2)
        {
            if (num <= 1)
                return false;
            if (num == 2)
                return true;
            if (divisor * divisor > num)
                return true;
            if (num % divisor == 0)
                return false;
            return IsPrime(num, divisor + 1);
        }

        #endregion

        #region 1a2
        public static bool IsPalindromeString(string str)
        {
            if (str.Length == 1)
                return true;
            if (str.Equals(Reverse(str, "", 0)))
                return true;
            return false;
        }

        static string Reverse(string str, string result, int place)
        {
            if (place == str.Length)
                return result;
            return Reverse(str, str[place] + result, place + 1);
        }
        public static string RemoveChar(string str, char ch)
        {
            int indexCharToRemove = str.IndexOf(ch);
            if (indexCharToRemove == -1)
                return str;
            str = str.Remove(indexCharToRemove, 1);
            return RemoveChar(str, ch);
        }
        public static int CountOccurrences(string str, char ch)
        {
            if (str == "" || str == null)
                return 0;
            if (str[0] == ch)
            {
                str = str.Remove(0, 1);
                return 1 + CountOccurrences(str, ch);
            }
            str = str.Remove(0, 1);
            return CountOccurrences(str, ch);
        }
        public static string ReverseString(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            else
                return ReverseString(str.Substring(1, str.Length - 1)) + str[0];
        }
        public static int CountVowels(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;
            if (str[0] == 'a' || str[0] == 'e' || str[0] == 'i' || str[0] == 'o' || str[0] == 'u')
            {
                str = str.Remove(0, 1);
                return 1 + CountVowels(str);
            }
            str = str.Remove(0, 1);
            return CountVowels(str);
        }

        #endregion

        #region 1a3
        public static bool EvenExists(int[] arr, int i = 0)
        {
            if (i == arr.Length)
                return false;
            if (arr[i] % 2 == 0)
                return true;
            return EvenExists(arr, i + 1);
        }
        public static int FindFirstIndex(int[] arr, int target, int i = 0)
        {
            if (i == arr.Length)
                return -1;
            if (arr[i] == target)
                return i;
            return FindFirstIndex(arr, target, i + 1);
        }
        public static int SumArray(int[] arr, int i = 0)
        {
            if (i == arr.Length)
                return 0;
            return arr[i] + SumArray(arr, i + 1);
        }
        public static void PrintArrayReverse(int[] arr, int index = -2)
        {
            if (arr == null || arr.Length == 0)
                return;
            if (index < 0 && index != -2)
                return;
            if (index < 0)
                index = arr.Length - 1;
            Console.Write($"{arr[index]}  ");
            PrintArrayReverse(arr, index - 1);
        }
        public static void MergeSort(int[] arr)
        {
            if (arr == null || arr.Length <= 1)
                return;
            MergeSort(arr, 0, arr.Length - 1);
        }
        private static void MergeSort(int[] arr, int left, int right)
        {
            if (left >= right)
                return;
            int mid = (left + right) / 2;
            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }
        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int numItemsL = mid - left + 1;
            int numItemsR = right - mid;
            int[] leftArr = new int[numItemsL];
            int[] rightArr = new int[numItemsR];
            for (int i = 0; i < numItemsL; i++)
                leftArr[i] = arr[left + i];
            for (int j = 0; j < numItemsR; j++)
                rightArr[j] = arr[mid + 1 + j];
            int indexL = 0, indexR = 0;
            int indexO = left;
            while (indexL < numItemsL && indexR < numItemsR)
            {
                if (leftArr[indexL] <= rightArr[indexR])
                {
                    arr[indexO] = leftArr[indexL];
                    indexL++;
                }
                else
                {
                    arr[indexO] = rightArr[indexR];
                    indexR++;
                }
                indexO++;
            }
            while (indexL < numItemsL)
            {
                arr[indexO] = leftArr[indexL];
                indexL++;
                indexO++;
            }
            while (indexR < numItemsR)
            {
                arr[indexO] = rightArr[indexR];
                indexR++;
                indexO++;
            }
        }
        public static int CountEven(int[] arr, int index = 0)
        {
            if (arr == null || arr.Length == 0)
                return 0;
            if (index == arr.Length)
                return 0;
            if (arr[index] % 2 == 0)
                return 1 + CountEven(arr, index + 1);
            return CountEven(arr, index + 1);
        }
        public static int MaxArray(int[] arr, int index = 0, int maxNum = 0)
        {
            if (index == 0)
                maxNum = arr[0];
            if (index == arr.Length)
                return maxNum;
            if (arr[index] > maxNum)
                maxNum = arr[index];
            return MaxArray(arr, index + 1, maxNum);
        }
        public static bool IsSorted(int[] arr, int index = 0)
        {
            if (index >= arr.Length - 1)
                return true;
            if (arr[index] > arr[index + 1])
                return false;
            return IsSorted(arr, index + 1);
        }
        public static bool SearchArray(int[] arr, int target, int index = 0)
        {
            if (arr.Length == 0 || arr == null)
                return false;
            if (index == arr.Length)
                return false;
            if (arr[index] == target)
                return true;
            return SearchArray(arr, target, index + 1);
        }
        public static bool SearchArraySorted(int[] arr, int target, int index = 0)
        {
            if (arr.Length == 0 || arr == null)
                return false;
            if (index == arr.Length)
                return false;
            if (arr[index] == target)
                return true;
            return SearchArraySorted(arr, target, index + 1);
        }
        public static int[] ReverseArray(int[] arr, int index = 0)
        {
            if (arr.Length == 0 || arr.Length == 1)
                return arr;
            if (index == arr.Length - 1 || index == arr.Length / 2)
                return arr;
            int temp = arr[index];
            arr[index] = arr[arr.Length - index - 1];
            arr[arr.Length - index - 1] = temp;
            return ReverseArray(arr, index + 1);
        }

        #endregion

        #region 1a4
        public static void PrintReverse(int n, int index = 1)
        {
            if (n < index)
                return;
            Console.Write($"{index} ");
            PrintReverse(n, index + 1);
        }
        public static void PrintNumbers(int n)
        {
            if (n == 0)
                return;
            Console.Write($"{n} ");
            PrintNumbers(n - 1);
        }
        public static void DrawTriangle(int n, int num = 0, int index = 1)
        {
            if (index > n)
                return;
            if (num < index)
            {
                Console.Write('*');
                DrawTriangle(n, num + 1, index);
            }
            else
            {
                Console.WriteLine();
                DrawTriangle(n, 0, index + 1);
            }
        }
        public static void PrintStringChars(string str, int index = 0)
        {
            if (str.Length == index)
                return;
            Console.WriteLine(str[index]);
        }
        public static void PrintDigits(int num)
        {
            if (num < 10)
            {
                Console.WriteLine(num);
                return;
            }
            PrintDigits(num / 10);
            Console.WriteLine(num % 10);
        }

        #endregion

        #region 1a5
        public static int TowerOfHanoiSteps(int n, char from, char to, char aux)
        {
            if (n == 1)
            {
                Console.WriteLine($"Move disk 1 from {from} to {to}");
                return 1;
            }
            int steps1 = TowerOfHanoiSteps(n - 1, from, aux, to);
            Console.WriteLine($"Move disk {n} from {from} to {to}");
            int steps2 = 1;
            int steps3 = TowerOfHanoiSteps(n - 1, aux, to, from);
            return steps1 + steps2 + steps3;
        }
        public static int TowerOfHanoiRecursive(int n)
        {
            if (n == 1)
                return 1;
            return 2 * TowerOfHanoiRecursive(n - 1) + 1;
        }
        public static int TowersOfHanoiClosedForm(int n)
        {
            return (int)Math.Pow(2, n) - 1;
        }
        public static bool IsValidSudoku(int[,] board, int row, int col, int num)
        {
            if (board[row, col] != 0)
                return false;
            if (ExistsInRow(board, row, 0, num))
                return false;
            if (ExistsInCol(board, col, 0, num))
                return false;
            int startRow = (row / 3) * 3;
            int startCol = (col / 3) * 3;
            if (ExistsInBox(board, startRow, startCol, 0, num))
                return false;
            return true;
        }
        private static bool ExistsInRow(int[,] board, int row, int colIndex, int num)
        {
            if (colIndex >= 9)
                return false;
            if (board[row, colIndex] == num)
                return true;
            return ExistsInRow(board, row, colIndex + 1, num);
        }
        private static bool ExistsInCol(int[,] board, int col, int rowIndex, int num)
        {
            if (rowIndex >= 9)
                return false;
            if (board[rowIndex, col] == num)
                return true;
            return ExistsInCol(board, col, rowIndex + 1, num);
        }
        private static bool ExistsInBox(int[,] board, int startRow, int startCol, int index, int num)
        {
            if (index >= 9)
                return false;
            int r = startRow + index / 3;
            int c = startCol + index % 3;
            if (board[r, c] == num)
                return true;
            return ExistsInBox(board, startRow, startCol, index + 1, num);
        }
        public static int CountPaths(int[,] matrix, int row, int col)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (row < 0 || col < 0 || row >= rows || col >= cols)
                return 0;
            if (row == rows - 1 && col == cols - 1)
                return 1;
            int rightPaths = CountPaths(matrix, row, col + 1);
            int downPaths = CountPaths(matrix, row + 1, col);
            return rightPaths + downPaths;
        }
        public static bool SolveMaze(int[,] maze, int row, int col, int[,] solution)
        {
            int n = maze.GetLength(0);
            if (row < 0 || col < 0 || row >= n || col >= n)
                return false;
            if (maze[row, col] == 1 || solution[row, col] == 1)
                return false;
            if (row == n - 1 && col == n - 1)
            {
                solution[row, col] = 1;
                return true;
            }
            solution[row, col] = 1;
            if (SolveMaze(maze, row + 1, col, solution))
                return true;
            if (SolveMaze(maze, row, col + 1, solution))
                return true;
            if (SolveMaze(maze, row - 1, col, solution))
                return true;
            if (SolveMaze(maze, row, col - 1, solution))
                return true;
            solution[row, col] = 0;
            return false;
        }

        #endregion
    }
}
