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
        Test(new[] { 1, 2, 3, 4, 4 }, 8, new[] { 3, 4 }, "Duplicate valid values");
        Test(new[] { 0, 1, 2, 3, 4, 5 }, 0, new int[] { }, "Target zero with no zero");
        Test(new[] { 0, 0, 1 }, 0, new[] { 0, 1 }, "Two zeros sum to zero");
        Test(new[] { int.MaxValue, int.MinValue, -1, 1 }, 0, new[] { 2, 3 }, "Overflow-safe sum to 0");
        Test(new[] { 1, 3, 5, 7 }, 12, new[] { 2, 3 }, "Last two elements");
        Test(new[] { 8, 2, 9, 0, 1 }, 10, new[] { 0, 1 }, "First two elements");
        Test(new[] { 1, 5, 3, 5 }, 10, new[] { 1, 3 }, "Same value, different positions");
        Test(new[] { 100, 200, 300, 400, 500 }, 900, new[] { 3, 4 }, "Large numbers");
        Test(new[] { 4, 4 }, 8, new[] { 0, 1 }, "Exactly two of the same");
        Test(new int[1000], 1, new int[] { }, "Large array of zeroes, no match");

        return results;
    }
}
