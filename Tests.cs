using System;
using System.Collections.Generic;

public static class Tests
{
    public static List<(bool, string)> RunAll(Func<int[], int, int[]> twoSumFunc)
    {
        var results = new List<(bool, string)>();

        void Test(int[] nums, int target, int[] expected, string description)
        {
            try
            {
                int[] result = twoSumFunc(nums, target);
                Array.Sort(result);
                Array.Sort(expected);
                bool equal = result.Length == expected.Length;
                for (int i = 0; i < result.Length && equal; i++)
                    if (result[i] != expected[i])
                        equal = false;

                results.Add((equal, description));
            }
            catch (Exception ex)
            {
                results.Add((false, $"{description} - Exception: {ex.Message}"));
            }
        }

        Test(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 }, "Simple pair");
        Test(new[] { 3, 2, 4 }, 6, new[] { 1, 2 }, "Middle pair");
        Test(new[] { 3, 3 }, 6, new[] { 0, 1 }, "Duplicate elements");
        Test(new[] { -1, -2, -3, -4, -5 }, -8, new[] { 2, 4 }, "Negative numbers");
        Test(new[] { 0, 4, 3, 0 }, 0, new[] { 0, 3 }, "Zeros");
        Test(new[] { 1, 2, 3 }, 7, new int[] { }, "No solution");
        Test(new[] { 1, 5, 1 }, 6, new[] { 0, 1 }, "Repeat with target match");
        Test(new[] { 5, 75, 25 }, 100, new[] { 1, 2 }, "Larger numbers");
        Test(new[] { 1, 3, 4, 2 }, 6, new[] { 2, 3 }, "Unsorted match");
        Test(new[] { 1, 2 }, 3, new[] { 0, 1 }, "Small array");

        return results;
    }
}
