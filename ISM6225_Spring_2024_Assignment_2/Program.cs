/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Security.Principal;
using System.Reflection.Metadata;
using System.Xml.Linq;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 1,1,2 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { 0,1,1};
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 0, 1, 1, 0, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101011;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 10};
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 1, 2, 1, 10 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("axxxxyyyyb", "xy");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            //This code efficiently identifies and counts unique elements in the input array nums, utilizing two lists to distinguish between unique elements and duplicates.
            //By combining the two lists into a single list, it effectively maintains the integrity of the unique elements while marking duplicates for reference.
            try
            {
                // Initialize a list to store the unique elements from the nums array
                List<int> output = new List<int>();

                // Initialize another list to mark the duplicates encountered
                List<string> output1 = new List<string>();

                // Add the first element of the nums array to the output list
                output.Add(nums[0]);

                // Iterate through the nums array starting from the second element
                for (int i = 1; i < nums.Length; i++)
                {
                    // If the output already contains the current element, mark it as a duplicate
                    if (output.Contains(nums[i]))
                    {
                        output1.Add("_");
                    }
                    else
                    {
                        // If the current element is unique, add it to the output list
                        output.Add(nums[i]);
                    }
                }

                // Combine the two lists (output and output1) into a single list
                var combinedList = output.Cast<object>().Concat(output1.Cast<object>()).ToList();

                // Return the count of unique elements (the count of elements in the output list)
                return output.Count;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            //This code efficiently separates zero elements from non-zero elements in the input array nums, preserving their relative order.
          //  By counting zero occurrences and appending them to the output list, it effectively maintains the integrity of the input array.
            try
            {
                // Check if the array contains only one element, if so, return the array itself
                if (nums.Length == 1)
                    return nums;
                // Initialize a variable to count the number of zeros encountered
                int zeroCount = 0;
                // Initialize a list to store the output
                List<int> output = new List<int>();
                // Iterate through the array
                for (int i = 0; i < nums.Length; i++)
                {
                    // If the current element is zero, increment the zero count
                    if (nums[i] == 0)
                    {
                        zeroCount++;
                    }
                    else
                    {
                        // If the current element is not zero, add it to the output list
                        output.Add(nums[i]);
                    }
                }
                // If there are zeros in the array, append them to the output list
                if (zeroCount > 0)
                {
                    for (int i = 0; i < zeroCount; i++)
                    {
                        output.Add(0);
                    }
                }
                // Return the modified output list
                return output;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {

            //  This code efficiently finds unique triplets that sum up to zero by utilizing sorting and the two-pointer technique, demonstrating an effective algorithmic approach.
           // By handling duplicates and skipping unnecessary iterations, the code optimizes its performance, showcasing attention to algorithmic efficiency
           try
            {
                Array.Sort(nums); // Sort the array

                IList<IList<int>> result = new List<IList<int>>(); // Initialize a list to store the triplets

                // Iterate through the sorted array
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    // Skip duplicates if the current element is not the first occurrence of the value
                    if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))
                    {
                        int left = i + 1; // Initialize the left pointer
                        int right = nums.Length - 1; // Initialize the right pointer
                        int target = -nums[i]; // Calculate the target sum

                        // Move the left and right pointers towards each other
                        while (left < right)
                        {
                            int sum = nums[left] + nums[right]; // Calculate the sum of elements at left and right pointers

                            // If the sum equals the target, a triplet is found
                            if (sum == target)
                            {
                                // Add the triplet to the result list
                                result.Add(new List<int> { nums[i], nums[left], nums[right] });

                                // Skip duplicates
                                while (left < right && nums[left] == nums[left + 1])
                                    left++;
                                while (left < right && nums[right] == nums[right - 1])
                                    right--;

                                left++; // Move the left pointer towards right
                                right--; // Move the right pointer towards left
                            }
                            else if (sum < target)
                            {
                                left++; // Move the left pointer towards right if sum is less than target
                            }
                            else
                            {
                                right--; // Move the right pointer towards left if sum is greater than target
                            }
                        }
                    }
                }

                // Return the list of triplets
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            // Self Reflection : This code efficiently counts the maximum consecutive sequence of ones in an input array nums.
           // It iterates through the array, resetting the count whenever it encounters a non-one element and updating the final count if a new maximum consecutive sequence is found.
            try
            {
                // Initialize variables to keep track of the current count and the final count
                int count = 0;
                int finalCount = 0;
                // Iterate through the array 'nums'
                for (int i = 0; i < nums.Length; i++)
                {
                    // Check if the final count is less than the current count
                    // If true, update the final count
                    if (finalCount < count)
                    {
                        finalCount = count;
                    }
                    // Check if the current element is 1
                    if (nums[i] == 1)
                    {
                        // Reset the count to 1 for consecutive 1s
                        count = 1;
                        // Iterate through subsequent elements to count consecutive 1s
                        for (int j = i + 1; j < nums.Length; j++)
                        {
                            if (nums[j] == 1)
                            {
                                // Increment count for each consecutive 1
                                count++;
                            }
                            else
                            {
                                // Break the loop if a non-1 element is encountered
                                break;
                            }
                        }
                    }
                }
                // Return the final count of consecutive 1s
                return finalCount;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            //Self Reflection : This code converts a binary integer into its decimal equivalent by iterating through its binary string representation.
            //It effectively handles each bit of the binary string, calculating the corresponding decimal value and accumulating it.
            // Convert the integer 'binary' to a binary string
            string binaryStr = binary.ToString();

            // Initialize variables to store the decimal equivalent and the length of the binary string
            int num = 0;
            int strLength = binaryStr.Length;

            // Initialize a variable to store the result of exponentiation
            int result = 1;

            try
            {
                // Iterate through each character of the binary string
                for (int i = 0; i < strLength; i++)
                {
                    // Reset the result for each iteration
                    result = 1;

                    // Check if the current character is '1'
                    if (binaryStr[i] == '1')
                    {
                        // Calculate the value of the current bit and add it to 'num'
                        // Using the position of the bit from right to left (starting from the least significant bit)
                        // If the bit is '1', add 2 raised to the power of its position to 'num'
                        for (int j = 1; j < strLength - i; j++)
                        {
                            result *= 2;
                        }

                        // Add the calculated value to 'num'
                        num += result;
                    }
                }

                // Return the decimal equivalent of the binary string
                return num;
            }
            catch (Exception)
            {
                throw; // Re-throw any exceptions that occur
            }
        }

        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.
 

        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            //Self Reflection : It efficiently calculates the maximum difference by iterating through the sorted array and updating the maximum difference if a larger difference is found.
            try
            {
                // Sort the array in non-decreasing order
                Array.Sort(nums);
                // Initialize a variable to count the number of elements in the array
                int count = 0;
                // If the array has less than 2 elements, it's not possible to calculate the maximum difference
                if (nums.Length < 2)
                {
                    // Return 0 as the maximum difference cannot be calculated with less than 2 elements
                    return 0;
                }
                // Initialize variables to keep track of the maximum difference and the current difference
                int maxDifference = 0;
                int difference = 0;
                // Iterate through the array to find the maximum difference between consecutive elements
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    // Calculate the difference between the current element and the next element
                    difference = nums[i + 1] - nums[i];
                    // If the current difference is greater than the maximum difference found so far,
                    // update the maximum difference
                    if (difference > maxDifference)
                    {
                        maxDifference = difference;
                    }
                }
                // Return the maximum difference found
                return maxDifference;


            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] nums)
        {
            //Self Reflection : The code efficiently handles edge cases by checking if the input array is null or has less than 3 elements and returning 0 accordingly.
            //It sorts the array to easily identify the longest sides for triangle formation and applies the triangle inequality theorem to determine if a valid triangle can be formed.
            try
            {
                if (nums == null || nums.Length < 3)
                {
                    // If the array is null or has less than 3 elements, it's not possible to form a triangle
                    // Return 0 as the perimeter of a triangle cannot be negative
                    return 0;
                }

                // Sort the array in non-decreasing order
                Array.Sort(nums);

                // Reverse the array to have the largest elements first
                Array.Reverse(nums);

                for (int i = 0; i < nums.Length - 2; i++)
                {
                    // Check if the current triplet satisfies the triangle inequality theorem
                    // According to the triangle inequality theorem, the sum of the lengths of any two sides of a triangle
                    // must be greater than the length of the remaining side
                    if (nums[i] < nums[i + 1] + nums[i + 2])
                    {
                        // If the current triplet satisfies the triangle inequality theorem,
                        // return the sum of the lengths of the sides as the perimeter of the triangle
                        return nums[i] + nums[i + 1] + nums[i + 2];
                    }
                }

                // If no valid triangle is found, return 0
                return 0;


            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.

 

        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string s, string part)
        {
            //Self Reflection : This code efficiently removes all occurrences of a given substring 'part' from the input string 's' using a while loop and string manipulation methods.
            //The use of exception handling with a catch block for all exceptions might be overly broad; specifying more targeted exceptions would be better for debugging.
            try
            {
                // Loop until all occurrences of 'part' are removed from the string 's'
                while (s.Contains(part))
                {
                    // Find the index of the first occurrence of 'part' in 's'
                    int index = s.IndexOf(part);

                    // Remove 'part' from 's' starting at the found index
                    // and continuing for the length of 'part'
                    s = s.Remove(index, part.Length);
                }

                // Return the modified string after removing all occurrences of 'part'
                return s;
            }
            catch (Exception)
            {
                // If any exception occurs during the process, re-throw it
                throw;
            }
        }


        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}
