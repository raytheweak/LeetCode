using System;
using System.Diagnostics;

namespace LeetCode
{
    public class MedianofTwoSortedArraysSolution
    {
        //i and j are two indexes pointing to the first element on the right side of the "split line".
        //Every element on the left should be smaller than those on the right.
        //for example:
        //1 | 2 5
        //3 | 7
        //
        //1 2 | 5
        //    | 3 7
        //step 1: i points to 2, j points to 7
        //step 2: i points to 5, j points to 3
        //My solution below is very verbose, I know.
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int m = nums1.Length, n = nums2.Length;
            if (m == 0 && n == 0)
            {
                throw new ArgumentException();
            }
            if (m < n)
            {
                return FindMedianSortedArrays(nums2, nums1);
            }
            if (n == 0) return (m & 1) == 1 ? nums1[m / 2] : ((double)nums1[m / 2] + nums1[m / 2 - 1]) / 2;

            int lo = 0, hi = m;
            while (lo <= hi)
            {
                int i = (hi + lo) / 2;
                int j = (m + n) / 2 - i;
                if (j < 0)
                {
                    hi = i;
                }
                else if (j > n)
                {
                    lo = i + 1;
                }
                else if (i != 0 && j != n && nums1[i - 1] > nums2[j])
                {
                    hi = i;
                }
                else if (j != 0 && i != m && nums2[j - 1] > nums1[i])
                {
                    lo = i + 1;
                }
                else
                {
                    int left;
                    int right;
                    if (i == 0)
                    {
                        left = nums2[j - 1];
                    }
                    else if (j == 0)
                    {
                        left = nums1[i - 1];
                    }
                    else
                    {
                        left = Math.Max(nums1[i - 1], nums2[j - 1]);
                    }

                    if (i == m)
                    {
                        right = nums2[j];
                    }
                    else if (j == n)
                    {
                        right = nums1[i];
                    }
                    else
                    {
                        right = Math.Min(nums1[i], nums2[j]);
                    }
                    if (i + j < m - i + n - j)
                    {
                        return right;
                    }
                    return ((double)left + right) / 2;
                }
            }
            throw new ArgumentException();
            return -1;
        }

        public static void Test()
        {
            var solution = new MedianofTwoSortedArraysSolution();
            int[] nums1;
            int[] nums2;

            nums1 = new int[] { 1, 2 };
            nums2 = new int[] { 3, 7 };
            double result = solution.FindMedianSortedArrays(nums1, nums2);
            Debug.Assert(result == 2.5d);

            nums1 = new int[] { 1, 2, 5 };
            nums2 = new int[] { 3, 7 };
            result = solution.FindMedianSortedArrays(nums1, nums2);
            Debug.Assert(result == 3.0d);

            nums1 = new int[] { 1, 2, 3 };
            nums2 = new int[] { 3, 4 };
            result = solution.FindMedianSortedArrays(nums1, nums2);
            Debug.Assert(result == 3.0d);

            nums1 = new int[] { 1, 2 };
            nums2 = new int[] { 3, 4 };
            result = solution.FindMedianSortedArrays(nums1, nums2);
            Debug.Assert(result == 2.5d);

            nums1 = new int[] { 1 };
            nums2 = new int[] { };
            result = solution.FindMedianSortedArrays(nums1, nums2);
            Debug.Assert(result == 1.0d);

            nums1 = new int[] { 1, 2, 3, 4 };
            nums2 = new int[] { };
            result = solution.FindMedianSortedArrays(nums1, nums2);
            Debug.Assert(result == 2.5d);

            nums1 = new int[] { };
            nums2 = new int[] { 1 };
            result = solution.FindMedianSortedArrays(nums1, nums2);
            Debug.Assert(result == 1.0d);

            nums1 = new int[] { 1 };
            nums2 = new int[] { 2, 3, 4 };
            result = solution.FindMedianSortedArrays(nums1, nums2);
            Debug.Assert(result == 2.5d);

            nums1 = new int[] { 1 };
            nums2 = new int[] { 2, 3, 4, 5 };
            result = solution.FindMedianSortedArrays(nums1, nums2);
            Debug.Assert(result == 3.0d);

            nums1 = new int[] { 4 };
            nums2 = new int[] { 1, 2, 3, 5, 6 };
            result = solution.FindMedianSortedArrays(nums1, nums2);
            Debug.Assert(result == 3.5d);

            nums1 = new int[] { 1 };
            nums2 = new int[] { 2, 3, 4, 5, 6, 7 };
            result = solution.FindMedianSortedArrays(nums1, nums2);
            Debug.Assert(result == 4.0d);
        }
    }
}
