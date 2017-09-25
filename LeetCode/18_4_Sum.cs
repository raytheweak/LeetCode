using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class FourSumSolution
    {
        //Similar to Problem 15 ThreeSum
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            var ret = new List<IList<int>>();
            if (nums == null || nums.Length < 4) return ret;
            Array.Sort(nums);
            for (int j = 0; j < nums.Length - 3; j++)
            {
                if (j != 0 && nums[j] == nums[j - 1]) continue;
                //find "3Sum" in nums[j+1,...,nums.Length -1], target is target-nums[j]
                for (int i = j + 1; i < nums.Length - 2; i++)
                {
                    //find "2Sum" in nums[i+1,...,nums.Length -1], target is target-nums[j]-nums[i]
                    if (i == j + 1 || nums[i] != nums[i - 1])
                    {
                        for (int lo = i + 1, hi = nums.Length - 1; lo != hi;)
                        {
                            if (lo == i + 1 || nums[lo] != nums[lo - 1])
                            {
                                if (target - nums[j] - nums[i] > nums[lo] + nums[hi]) lo++;
                                else if (target - nums[j] - nums[i] < nums[lo] + nums[hi]) hi--;
                                else ret.Add(new List<int>() { nums[j], nums[i], nums[lo++], nums[hi] });
                            }
                            else
                            {
                                lo++;
                            }
                        }
                    }
                }
            }
            return ret;
        }

        public static void Test()
        {
            var solution = new FourSumSolution();
            var result = solution.FourSum(new int[] { 1, 0, -1, 0, -2, 2 }, 0);
        }
    }
}
