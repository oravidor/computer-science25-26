using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace complexity
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        #region 2a1

        public static bool FindEquilibriumIndex(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return false;

            int totalSum = 0;
            for (int i = 0; i < arr.Length; i++)
                totalSum += arr[i];

            int leftSum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int rightSum = totalSum - leftSum - arr[i];
                if (leftSum == rightSum)
                    return true;
                leftSum += arr[i];
            }
            return false;
        }

        public static bool HasPairWithSum(int[] arr, int target)
        {
            int left = 0;
            int right = arr.Length - 1;
            while (left < right)
            {
                int sum = arr[left] + arr[right];
                if (sum == target)
                    return true;
                else if (sum < target)
                    left++;
                else
                    right--;
            }
            return false;
        }
        public static int MaxDifference(int[] arr)
        {
            if (arr == null || arr.Length < 2)
                return 0;
            int minSoFar = arr[0];
            int maxDiff = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                int diff = arr[i] - minSoFar;
                if (diff > maxDiff)
                    maxDiff = diff;
                if (arr[i] < minSoFar)
                    minSoFar = arr[i];
            }
            return maxDiff;
        }
        public static bool BinarySearch(int[] arr, int target, int left = 0, int right = -2)
        {
            if (arr == null || arr.Length == 0)
                return false;
            if (right == -2)
                right = arr.Length - 1;
            if (left > right)
                return false;
            int mid = (left + right) / 2;
            if (arr[mid] == target)
                return true;
            if (arr[mid] > target)
                return BinarySearch(arr, target, left, mid - 1);
            else
                return BinarySearch(arr, target, mid + 1, right);
        }
        public static int FindLocalPeak(int[] arr)
        {
            if (arr == null || arr.Length < 2)
                throw new IndexOutOfRangeException("Array must contain at least two elements.");
            int n = arr.Length;
            int left = 0;
            int right = n - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                bool leftSmaller = (mid == 0) || (arr[mid] > arr[mid - 1]);
                bool rightSmaller = (mid == n - 1) || (arr[mid] > arr[mid + 1]);
                if (leftSmaller && rightSmaller)
                    return mid;
                if (mid > 0 && arr[mid - 1] > arr[mid])
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            return -1;
        }

        #endregion
    }
}
