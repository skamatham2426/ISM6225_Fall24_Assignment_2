using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // Edge Case 1: If the array is null or empty, return an empty list
                if (nums == null || nums.Length == 0)
                {
                    return new List<int>();
                }

                // Traverse the array and mark indices based on values
                for (int i = 0; i < nums.Length; i++)
                {
                    // Use absolute value to handle cases where value has already been marked (i.e., made negative)
                    int index = Math.Abs(nums[i]) - 1;

                    // Edge Case 2: Prevent double-negation issues — only negate if positive
                    if (nums[index] > 0)
                    {
                        nums[index] = -nums[index]; // Mark this index to indicate the number (index + 1) is present
                    }
                }

                List<int> result = new List<int>();

                // Now, any index with a positive value indicates the number (index + 1) was never marked, i.e., missing
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] > 0)
                    {
                        result.Add(i + 1); // (index + 1) is missing
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // Edge Case 1: If the array is null or empty, return an empty array
                if (nums == null || nums.Length == 0)
                {
                    return new int[0];
                }
                // Edge Case 2: If the array has only one element, return it as is
                if (nums.Length == 1)
                {
                    return nums;
                }
                // Create a new array to hold the sorted values
                int[] sortedArray = new int[nums.Length];
                int evenIndex = 0;
                int oddIndex = nums.Length - 1;
                // Traverse the array and place even numbers at the beginning and odd numbers at the end
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] % 2 == 0)
                    {
                        sortedArray[evenIndex] = nums[i];
                        evenIndex++;
                    }
                    else
                    {
                        sortedArray[oddIndex] = nums[i];
                        oddIndex--;
                    }
                }
                // Fill in the remaining even numbers
                for (int i = evenIndex; i < nums.Length; i++)
                {
                    sortedArray[i] = nums[i];
                }
                // Fill in the remaining odd numbers
                for (int i = oddIndex; i >= 0; i--)
                {
                    sortedArray[i] = nums[i];
                }
                // Return the sorted array
                return sortedArray;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Edge Case 1: If the array is null or empty, return an empty array
                if (nums == null || nums.Length == 0)
                {
                    return new int[0];
                }
                // Edge Case 2: If the array has only one element, return an empty array
                if (nums.Length == 1)
                {
                    return new int[0];
                }
                // Create a dictionary to store the indices of the numbers
                Dictionary<int, int> numIndices = new Dictionary<int, int>();
                // Traverse the array and check for the complement
                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i];
                    // If the complement exists in the dictionary, return the indices
                    if (numIndices.ContainsKey(complement))
                    {
                        return new int[] { numIndices[complement], i };
                    }
                    // Otherwise, add the current number and its index to the dictionary
                    if (!numIndices.ContainsKey(nums[i]))
                    {
                        numIndices[nums[i]] = i;
                    }
                }
                return new int[0]; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {


                // Edge Case 1: If the array is null or empty, return 0
                if (nums == null || nums.Length == 0)
                {
                    return 0;
                }
                // Edge Case 2: If the array has less than three elements, return 0
                if (nums.Length < 3)
                {
                    return 0;
                }
                // Sort the array in descending order
                Array.Sort(nums);
                Array.Reverse(nums);
                // Calculate the maximum product of the three largest numbers
                int maxProduct = nums[0] * nums[1] * nums[2];
                // Calculate the maximum product of the two smallest and the largest number
                int maxProductWithNegatives = nums[0] * nums[nums.Length - 1] * nums[nums.Length - 2];
                // Return the maximum of the two products
                return Math.Max(maxProduct, maxProductWithNegatives);
               } 
                catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {

                // Edge Case 1: If the number is negative, return an empty string
                if (decimalNumber < 0)
                {
                    return string.Empty;
                }
                // Edge Case 2: If the number is zero, return "0"
                if (decimalNumber == 0)
                {
                    return "0";
                }
                // Convert the decimal number to binary
                string binary = string.Empty;
                while (decimalNumber > 0)
                {
                    binary = (decimalNumber % 2) + binary;
                    decimalNumber /= 2;
                }
                return binary;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {

                // Edge Case 1: If the array is null or empty, return 0
                if (nums == null || nums.Length == 0)
                {
                    return 0;
                }
                // Edge Case 2: If the array has only one element, return that element
                if (nums.Length == 1)
                {
                    return nums[0];
                }
                // Initialize the left and right pointers
                int left = 0;
                int right = nums.Length - 1;
                // Perform binary search to find the minimum element
                while (left < right)
                {
                    int mid = left + (right - left) / 2;
                    // Check if the middle element is greater than the rightmost element
                    if (nums[mid] > nums[right])
                    {
                        left = mid + 1; // The minimum is in the right half
                    }
                    else
                    {
                        right = mid; // The minimum is in the left half or at mid
                    }
                }
                return nums[left]; // The minimum element
                // is at the left pointer
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {

                // Edge Case 1: If the number is negative, it cannot be a palindrome
                if (x < 0)
                {
                    return false;
                }
                // Edge Case 2: If the number is zero, it is a palindrome
                if (x == 0)
                {
                    return true;
                }
                // Convert the number to a string and check if it is a palindrome
                string str = x.ToString();
                int left = 0;
                int right = str.Length - 1;
                while (left < right)
                {
                    if (str[left] != str[right])
                    {
                        return false; // Not a palindrome
                    }
                    left++;
                    right--;
                }
                return true; // Is a palindrome            
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Edge Case 1: If the number is negative, return 0
                if (n < 0)
                {
                    return 0;
                }
                // Edge Case 2: If the number is zero, return 0
                if (n == 0)
                {
                    return 0;
                }
                // Edge Case 3: If the number is one, return 1
                if (n == 1)
                {
                    return 1;
                }
                // Calculate the Fibonacci number using recursion
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
