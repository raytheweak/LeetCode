namespace LeetCode
{
    public class ContainerWithMostWater
    {
        //The lesson is that through some technique, many possibilities can be excluded 
        //from all the possibilities of the brute force approach.
        public int MaxArea(int[] height)
        {
            int lo = 0, hi = height.Length - 1;
            int maxArea = 0;
            while (lo < hi)
            {
                if (height[lo] < height[hi])
                {
                    int currentArea = height[lo] * (hi - lo);
                    if (maxArea < currentArea)
                    {
                        maxArea = currentArea;
                    }
                    lo++;
                }
                else
                {
                    int currentArea = height[hi] * (hi - lo);
                    if (maxArea < currentArea)
                    {
                        maxArea = currentArea;
                    }
                    hi--;
                }
            }
            return maxArea;
        }
    }
}
