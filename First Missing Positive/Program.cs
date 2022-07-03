using System;

namespace First_Missing_Positive
{
  class Program
  {
    static void Main(string[] args)
    {
      int[] nums = new int[] { 0, 3, 1, 5, 2 }; // 1, 2, 0 // 3, 4, -1, 1 // 7, 8, 9, 11, 12 // 1, 2, 3, 4 , 5
      Solution s = new Solution();
      Console.WriteLine(s.FirstMissingPositive(nums));
    }

    public class Solution
    {
      public int FirstMissingPositive(int[] nums)
      {
        int length = nums.Length;
        // Step 1 -
        // loop entire array and mark the cells as 0 wherever cell value is < 0, negetive
        // coz the smallest positive int value is 1 and negetive values are havong no meaning here
        for (int i = 0; i < length; i++)
        {
          if (nums[i] < 0)
          {
            nums[i] = 0;
          }
        }

        // Step 2 -
        // loop entire array and for each abs value of cell mark it as present 
        // how ? absVal - 1 would be the array index where we set the current cell value to * -1
        // or if the cell value is 0 which is possible due to the negetive value we made it to negetive from step 1
        // will set it with -1 * length + 1
        for (int i = 0; i < length; i++)
        {
          // take the abs value, as there can be a value still negetive as we are modifying the input array cell to negetive to mark a value exist
          int absVal = Math.Abs(nums[i]);
          if (absVal >= 1 && absVal <= length)
          {
            int index = absVal - 1;
            if (nums[index] > 0)
              nums[index] *= -1;
            else if (nums[index] == 0)
              nums[index] = -1 * (length + 1);
          }
        }
        // Step 3 -
        for (int i = 1; i <= length; i++)
        {
          int index = i - 1;
          // in step 3 if we find any positive value in cell which tell that the missing value is found
          if (nums[index] >= 0)
          {
            return i;
          }
        }
        return length + 1;
      }
    }
  }
}
