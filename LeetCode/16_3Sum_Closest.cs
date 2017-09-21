using System;

namespace LeetCode
{
    //Similar to Problem 15 ThreeSum
    public class ThreeSumClosestSolution
    {
        public int ThreeSumClosest(int[] nums, int target)
        {
            if (nums == null || nums.Length < 3) return 0;
            Array.Sort(nums);
            int difference = int.MaxValue;
            int closest = 0;
            for (int i = 0; i < nums.Length - 2; i++)
            {
                //find "2Sum" in nums[i+1,...,nums.Length -1], target is target-nums[i]
                if (i == 0 || nums[i] != nums[i - 1])
                {
                    int target2Sum = target - nums[i];
                    for (int lo = i + 1, hi = nums.Length - 1; lo != hi;)
                    {
                        if (lo == i + 1 || nums[lo] != nums[lo - 1])
                        {
                            int current2Sum = nums[lo] + nums[hi];

                            if (target2Sum > current2Sum) lo++;
                            else if (target2Sum < current2Sum) hi--;
                            else return target;

                            int current3Sum = current2Sum + nums[i];
                            int currentDifference = Math.Abs(current3Sum - target);
                            if (currentDifference < difference)
                            {
                                closest = current3Sum;
                                difference = currentDifference;
                            }
                        }
                        else
                        {
                            lo++;
                        }
                    }
                }
            }
            return closest;
        }

        public static void Test()
        {
            var solution = new ThreeSumClosestSolution();
            var result = solution.ThreeSumClosest(new int[] { -1, 2, 1, -4 }, 1);
        }
    }
}
