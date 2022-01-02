using System;

namespace First_Missing_Positive
{
  class Program
  {
    static void Main(string[] args)
    {
      Program p = new Program();
      int[] nums = new int[] { 0, 3, 1, 5, 2 }; // 1, 2, 0 // 3, 4, -1, 1 // 7, 8, 9, 11, 12 // 1, 2, 3, 4 , 5
      Console.WriteLine(p.FirstMissingPositive(nums));
    }

    public int FirstMissingPositive(int[] nums)
    {
      bool containsOne = false;
      int length = nums.Length;
      // Step 1 -
      // loop entire array and mark the cells as 1 wherever cell value is <= 0 or value > N, also check input contains 1 as cell value or not.
      // if 1 value is not present in the given input, blindly we can return 1 as an output.
      for (int i = 0; i < length; i++)
      {
        if(nums[i] == 1)
        {
          containsOne = true;
        }
        if (nums[i] <= 0 || nums[i] > length)
        {
          nums[i] = 1;
        }
      }

      // if 1 is not present in input array.
      if (!containsOne)
      {
        return 1;
      }

      // Step 2 -
      // loop entire array and for each cell value -1 position, update to negetive to mark that value is present in range of 1-N
      for (int i = 0; i < length; i++)
      {
        int val = Math.Abs(nums[i]);
        if(nums[val - 1] > 0)
          nums[val - 1] *= -1;
      }

      // Step 3 -
      // loop entire array, any value as positive , that position + 1 is the missing element, if not found then N+1 is the missing element(eg- (1,2,3,4,5)=>O/p-6)
      for (int i = 0; i < length; i++)
      {
        if (nums[i] > 0) return i + 1;
      }
      return length + 1;
    }
  }
}
