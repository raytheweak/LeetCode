using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class ThreeSumSolution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var ret = new List<IList<int>>();
            if (nums == null || nums.Length < 3) return ret;
            Array.Sort(nums);//If we don't sort it first, it will be hard to eliminate the duplicate triplets.
            for (int i = 0; i < nums.Length - 2; i++)
            {
                //find "2Sum" in nums[i+1,...,nums.Length -1], target is -nums[i]
                if (i == 0 || nums[i] != nums[i - 1])
                {
                    for (int lo = i + 1, hi = nums.Length - 1; lo != hi;)
                    {
                        if (lo == i + 1 || nums[lo] != nums[lo - 1])
                        {
                            if (-nums[i] > nums[lo] + nums[hi]) lo++;
                            else if (-nums[i] < nums[lo] + nums[hi]) hi--;
                            else ret.Add(new List<int>() { nums[i], nums[lo++], nums[hi] });
                        }
                        else
                        {
                            lo++;
                        }
                    }
                }
            }
            return ret;
        }

        public static void Test()
        {
            var solution = new ThreeSumSolution();
            var result = solution.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });

            result = solution.ThreeSum(new int[] { 0, 0, 0, 0 });
        }
    }
}
