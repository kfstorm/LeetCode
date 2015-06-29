using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        Array.Sort(nums);
        var results = new Dictionary<string, IList<int>>();
        
        var cIndex = Array.BinarySearch(nums, 0);
        if (cIndex < 0) cIndex = ~cIndex;
        while (cIndex < nums.Length)
        {
            var c = nums[cIndex];
            var aIndex = 0;
            var bIndex = cIndex - 1;
            while (aIndex < bIndex)
            {
                //Console.WriteLine("{0} {1} {2}", aIndex, bIndex, cIndex);
                if (nums[aIndex] + nums[bIndex] + c < 0)
                {
                    var step = 1;
                    while (aIndex + step < bIndex && nums[aIndex + step] + nums[bIndex] + c < 0)
                    {
                        aIndex += step;
                        step *= 2;
                        //Console.WriteLine("{0} {1} {2}", aIndex, bIndex, cIndex);
                    }
                    step /= 2;
                    while (step > 0)
                    {
                        if (aIndex + step < bIndex && nums[aIndex + step] + nums[bIndex] + c < 0)
                        {
                            aIndex += step;
                        }
                        step /= 2;
                        //Console.WriteLine("{0} {1} {2}", aIndex, bIndex, cIndex);
                    }
                }
                
                if (nums[aIndex] + nums[bIndex] + c > 0)
                {
                    var step = 1;
                    while (aIndex < bIndex - step && nums[aIndex] + nums[bIndex - step] + c > 0)
                    {
                        bIndex -= step;
                        step *= 2;
                        //Console.WriteLine("{0} {1} {2}", aIndex, bIndex, cIndex);
                    }
                    step /= 2;
                    while (step > 0)
                    {
                        if (aIndex < bIndex - step && nums[aIndex] + nums[bIndex - step] + c > 0)
                        {
                            bIndex -= step;
                        }
                        step /= 2;
                        //Console.WriteLine("{0} {1} {2}", aIndex, bIndex, cIndex);
                    }
                }
                
                if (nums[aIndex] + nums[bIndex] + c == 0)
                {
                    var list = new List<int> { nums[aIndex], nums[bIndex], c };
                    var key = string.Join(",", list);
                    if (!results.ContainsKey(key))
                    {
                        results.Add(key, list);
                    }
                    ++aIndex;
                    --bIndex;
                    //Console.WriteLine("{0} {1} {2}", aIndex, bIndex, cIndex);
                }
                else if (nums[aIndex] + nums[bIndex] + c < 0)
                {
                    ++aIndex;
                }
                else
                {
                    --bIndex;
                }
            }
            ++cIndex;
        }
        
        return results.Values.ToList();
    }
}